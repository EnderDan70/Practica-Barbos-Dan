using System;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Windows.Forms;

namespace st.ind2
{
    public partial class LoginForm : Form
    {
        public UserRole SelectedRole { get; private set; }
        public string Username { get; private set; }

        private int failedAttempts = 0;
        private string last2FACode = null;
        private DateTime last2FASent;
        private bool isPermanentlyLocked = false;
        private DateTime? lockoutEndTime = null;
        private Timer lockoutTimer;

        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=MagazinAlimentar;Integrated Security=True";

        public LoginForm()
        {
            InitializeComponent();
            comboRole.Items.Clear();
            comboRole.Items.Add("Seller");
            comboRole.Items.Add("Administrator");

            lockoutTimer = new Timer();
            lockoutTimer.Interval = 1000; // 1 second
            lockoutTimer.Tick += LockoutTimer_Tick;

            // добавить пользователя (удалить после первого запуска)
            //AddUser("admin12", "123", "andrei.a7854@mail.ru", "Administrator");
        }

        private void LockoutTimer_Tick(object sender, EventArgs e)
        {
            if (lockoutEndTime.HasValue && DateTime.Now >= lockoutEndTime.Value)
            {
                lockoutTimer.Stop();
                lockoutEndTime = null;
                buttonLogin.Enabled = true;
                this.Text = "Login";
            }
            else if (lockoutEndTime.HasValue)
            {
                var secondsLeft = (int)(lockoutEndTime.Value - DateTime.Now).TotalSeconds;
                this.Text = $"Locked for {secondsLeft} sec";
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (isPermanentlyLocked)
            {
                MessageBox.Show("Application is permanently locked. Please restart to try again.", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (lockoutEndTime.HasValue && DateTime.Now < lockoutEndTime.Value)
            {
                MessageBox.Show($"Too many failed attempts. Please wait {(int)(lockoutEndTime.Value - DateTime.Now).TotalSeconds} seconds.", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboRole.SelectedIndex < 0)
            {
                MessageBox.Show("Choose a role.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textUsername.Text))
            {
                MessageBox.Show("Enter the user's name.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textPassword.Text))
            {
                MessageBox.Show("Write a password.");
                return;
            }

            // Get user from database
            string username = textUsername.Text.Trim();
            string role = comboRole.SelectedItem.ToString();
            string hashFromDb = null, saltFromDb = null, emailFromDb = null, roleFromDb = null;

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT PasswordHash, Salt, Email, Role FROM Users WHERE Username=@u", conn);
                cmd.Parameters.AddWithValue("@u", username);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        hashFromDb = reader.GetString(0);
                        saltFromDb = reader.GetString(1);
                        emailFromDb = reader.GetString(2);
                        roleFromDb = reader.GetString(3);
                    }
                }
            }

            if (hashFromDb == null)
            {
                MessageBox.Show("User not found.");
                return;
            }

            // Check role
            if (!string.Equals(roleFromDb, role, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Role does not match this user.");
                return;
            }

            // Check password
            string enteredPassword = textPassword.Text;
            string hash = PasswordHelper.HashPassword(enteredPassword, saltFromDb);

            if (hash == hashFromDb)
            {
                failedAttempts = 0;
                lockoutEndTime = null;
                isPermanentlyLocked = false;
                buttonLogin.Enabled = true;
                this.Text = "Login";

                // Successful password, send 2FA code
                last2FACode = GenerateCode();
                last2FASent = DateTime.Now;
                try
                {
                    SendEmail(emailFromDb, "Login confirmation code", $"Your code: {last2FACode}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending the code to the mail: " + ex.Message);
                    return;
                }

                string inputCode = Prompt.ShowDialog("Enter the code from the email:", "Double authentication");
                if (inputCode == last2FACode)
                {
                    // Access granted
                    SelectedRole = (UserRole)Enum.Parse(typeof(UserRole), roleFromDb);
                    Username = username;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid code.");
                }
            }
            else
            {
                failedAttempts++;
                if (failedAttempts == 3)
                {
                    lockoutEndTime = DateTime.Now.AddMinutes(1);
                    buttonLogin.Enabled = false;
                    lockoutTimer.Start();
                    try
                    {
                        SendEmail(emailFromDb, "Suspicious login attempt",
                            "There were 3 failed login attempts to your account. If this was not you, please change your password immediately.");
                    }
                    catch { /* ignore email errors here */ }
                    MessageBox.Show("Too many failed attempts. Application is locked for 1 minute.", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (failedAttempts >= 6)
                {
                    isPermanentlyLocked = true;
                    buttonLogin.Enabled = false;
                    try
                    {
                        SendEmail(emailFromDb, "Account frozen due to suspicious activity",
                            "Your account has been frozen due to multiple suspicious login attempts. Please contact support to restore access.");
                    }
                    catch { /* ignore email errors here */ }
                    MessageBox.Show("Application is permanently locked. Please restart to try again.", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
        }

        // Метод для автоматического добавления пользователя в базу
        private void AddUser(string username, string password, string email, string role)
        {
            string salt = PasswordHelper.GenerateSalt();
            string hash = PasswordHelper.HashPassword(password, salt);

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "INSERT INTO Users (Username, PasswordHash, Salt, Email, Role) VALUES (@u, @h, @s, @e, @r)", conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@h", hash);
                cmd.Parameters.AddWithValue("@s", salt);
                cmd.Parameters.AddWithValue("@e", email);
                cmd.Parameters.AddWithValue("@r", role);
                cmd.ExecuteNonQuery();
            }
        }

        private void linkClear_Click(object sender, EventArgs e)
        {
            comboRole.SelectedIndex = -1;
            textUsername.Clear();
            textPassword.Clear();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            comboRole.SelectedIndex = -1;
        }

        // Генерация 2FA-кода
        private string GenerateCode()
        {
            var rnd = new Random();
            return rnd.Next(100000, 999999).ToString();
        }

        // Отправка email 
        private void SendEmail(string to, string subject, string body)
        {
            var smtp = new SmtpClient("smtp.mail.ru")
            {
                Port = 587,
                Credentials = new System.Net.NetworkCredential("andrei.a7854@mail.ru", "hKMYjzMjp2beuzenWeQ8"),
                EnableSsl = true,
            };
            var mail = new MailMessage("andrei.a7854@mail.ru", to, subject, body);
            smtp.Send(mail);
        }

        private void f_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

    // Вспомогательная форма для ввода кода
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                Text = caption
            };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = text, Width = 240 };
            TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 240 };
            Button confirmation = new Button() { Text = "OK", Left = 180, Width = 80, Top = 80, DialogResult = DialogResult.OK };
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : "";
        }
    }
}