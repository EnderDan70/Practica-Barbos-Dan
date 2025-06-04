using System;
using System.Data;
using System.Windows.Forms;

namespace SpitalApp
{
    public partial class MainForm : Form
    {
        private DataTable dataTable;

        public MainForm()
        {
            InitializeComponent();
            InitializeDataTable();
        }

        private void InitializeDataTable()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("Pacient");
            dataTable.Columns.Add("Boala");
            dataTable.Columns.Add("Tratament");
            dataTable.Columns.Add("Personal");
            dataTable.Columns.Add("Nume");
            dataTable.Columns.Add("Prenume");
            dataTable.Columns.Add("Adresa");

            dataGridView1.DataSource = dataTable;
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            DataRow row = dataTable.NewRow();
            row["Pacient"] = cmbPacienti.Text;
            row["Boala"] = cmbBoli.Text;
            row["Tratament"] = cmbTratament.Text;
            row["Personal"] = cmbPersonal.Text;
            row["Nume"] = txtNume.Text;
            row["Prenume"] = txtPrenume.Text;
            row["Adresa"] = txtAdresa.Text;
            dataTable.Rows.Add(row);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                row.Cells["Pacient"].Value = cmbPacienti.Text;
                row.Cells["Boala"].Value = cmbBoli.Text;
                row.Cells["Tratament"].Value = cmbTratament.Text;
                row.Cells["Personal"].Value = cmbPersonal.Text;
                row.Cells["Nume"].Value = txtNume.Text;
                row.Cells["Prenume"].Value = txtPrenume.Text;
                row.Cells["Adresa"].Value = txtAdresa.Text;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
        }
    }
}
