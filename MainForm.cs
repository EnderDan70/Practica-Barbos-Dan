namespace SpitalApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbPacienti;
        private System.Windows.Forms.ComboBox cmbBoli;
        private System.Windows.Forms.ComboBox cmbTratament;
        private System.Windows.Forms.ComboBox cmbPersonal;
        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.TextBox txtPrenume;
        private System.Windows.Forms.TextBox txtAdresa;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddDispecerat;
        private System.Windows.Forms.Label lblPacienti;
        private System.Windows.Forms.Label lblBoli;
        private System.Windows.Forms.Label lblTratament;
        private System.Windows.Forms.Label lblPersonal;
        private System.Windows.Forms.Label lblNume;
        private System.Windows.Forms.Label lblPrenume;
        private System.Windows.Forms.Label lblAdresa;
        private System.Windows.Forms.GroupBox groupBoxInputs;

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbPacienti = new System.Windows.Forms.ComboBox();
            this.cmbBoli = new System.Windows.Forms.ComboBox();
            this.cmbTratament = new System.Windows.Forms.ComboBox();
            this.cmbPersonal = new System.Windows.Forms.ComboBox();
            this.txtNume = new System.Windows.Forms.TextBox();
            this.txtPrenume = new System.Windows.Forms.TextBox();
            this.txtAdresa = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddDispecerat = new System.Windows.Forms.Button();
            this.lblPacienti = new System.Windows.Forms.Label();
            this.lblBoli = new System.Windows.Forms.Label();
            this.lblTratament = new System.Windows.Forms.Label();
            this.lblPersonal = new System.Windows.Forms.Label();
            this.lblNume = new System.Windows.Forms.Label();
            this.lblPrenume = new System.Windows.Forms.Label();
            this.lblAdresa = new System.Windows.Forms.Label();
            this.groupBoxInputs = new System.Windows.Forms.GroupBox();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxInputs.SuspendLayout();
            this.SuspendLayout();

            // dataGridView1
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Size = new System.Drawing.Size(760, 200);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            // groupBoxInputs
            this.groupBoxInputs.Controls.Add(this.lblPacienti);
            this.groupBoxInputs.Controls.Add(this.cmbPacienti);
            this.groupBoxInputs.Controls.Add(this.lblBoli);
            this.groupBoxInputs.Controls.Add(this.cmbBoli);
            this.groupBoxInputs.Controls.Add(this.lblTratament);
            this.groupBoxInputs.Controls.Add(this.cmbTratament);
            this.groupBoxInputs.Controls.Add(this.lblPersonal);
            this.groupBoxInputs.Controls.Add(this.cmbPersonal);
            this.groupBoxInputs.Controls.Add(this.lblNume);
            this.groupBoxInputs.Controls.Add(this.txtNume);
            this.groupBoxInputs.Controls.Add(this.lblPrenume);
            this.groupBoxInputs.Controls.Add(this.txtPrenume);
            this.groupBoxInputs.Controls.Add(this.lblAdresa);
            this.groupBoxInputs.Controls.Add(this.txtAdresa);
            this.groupBoxInputs.Location = new System.Drawing.Point(12, 230);
            this.groupBoxInputs.Size = new System.Drawing.Size(400, 200);
            this.groupBoxInputs.TabIndex = 12;
            this.groupBoxInputs.Text = "Patient Details";

            // Labels and ComboBoxes/TextBoxes
            this.lblPacienti.Text = "Pacienti:";
            this.lblPacienti.Location = new System.Drawing.Point(10, 20);
            this.cmbPacienti.Location = new System.Drawing.Point(100, 20);

            this.lblBoli.Text = "Boli:";
            this.lblBoli.Location = new System.Drawing.Point(10, 50);
            this.cmbBoli.Location = new System.Drawing.Point(100, 50);

            this.lblTratament.Text = "Tratament:";
            this.lblTratament.Location = new System.Drawing.Point(10, 80);
            this.cmbTratament.Location = new System.Drawing.Point(100, 80);

            this.lblPersonal.Text = "Personal:";
            this.lblPersonal.Location = new System.Drawing.Point(10, 110);
            this.cmbPersonal.Location = new System.Drawing.Point(100, 110);

            this.lblNume.Text = "Nume:";
            this.lblNume.Location = new System.Drawing.Point(10, 140);
            this.txtNume.Location = new System.Drawing.Point(100, 140);

            this.lblPrenume.Text = "Prenume:";
            this.lblPrenume.Location = new System.Drawing.Point(10, 170);
            this.txtPrenume.Location = new System.Drawing.Point(100, 170);

            this.lblAdresa.Text = "Adresa:";
            this.lblAdresa.Location = new System.Drawing.Point(10, 200);
            this.txtAdresa.Location = new System.Drawing.Point(100, 200);

            // Buttons
            this.btnInsert.Location = new System.Drawing.Point(450, 230);
            this.btnInsert.Size = new System.Drawing.Size(100, 30);
            this.btnInsert.Text = "Insert";
            this.btnInsert.Click += new System.EventHandler(this.BtnInsert_Click);

            this.btnUpdate.Location = new System.Drawing.Point(450, 270);
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);

            this.btnDelete.Location = new System.Drawing.Point(450, 310);
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            this.btnAddDispecerat.Location = new System.Drawing.Point(450, 350);
            this.btnAddDispecerat.Size = new System.Drawing.Size(150, 30);
            this.btnAddDispecerat.Text = "Add to Dispecerat";

            // MainForm
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBoxInputs);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddDispecerat);
            this.Text = "Spital Management";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxInputs.ResumeLayout(false);
            this.groupBoxInputs.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
