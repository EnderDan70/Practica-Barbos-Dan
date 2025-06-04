using System;
using System.Windows.Forms;

namespace st.ind2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Показываем LoadingForm только один раз
            using (var loading = new LoadingForm())
            {
                loading.ShowDialog();
            }

            // 2. Основной цикл: LoginForm → Form1 → (Logout) → LoginForm → ...
            while (true)
            {
                using (var login = new LoginForm())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                        break; // Если закрыли LoginForm — выходим из приложения

                    // Передаём роль пользователя в Form1
                    using (var main = new Form1(login.SelectedRole))
                    {
                        main.ShowDialog(); // После закрытия Form1 (Logout) — снова LoginForm
                    }
                }
            }
        }
    }
}
