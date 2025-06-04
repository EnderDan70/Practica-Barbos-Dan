using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using ClosedXML.Excel;

namespace st.ind2
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<int, Image> tabImages = new Dictionary<int, Image>();
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=MagazinAlimentar;Integrated Security=True";
        private UserRole currentUserRole; // Оставить только это объявление!

        public Form1(UserRole userRole) // Исправлено: UserRole
        {
            InitializeComponent();
            currentUserRole = userRole;
            ApplyRolePermissions();
           

            tabControlMain.BackColor = SystemColors.Control;
            foreach (TabPage page in tabControlMain.TabPages)
                page.BackColor = SystemColors.Control;

            // Event bindings for tabs
            this.Load += Form1_Load;
            // Products
            btnAddProdus.Click += BtnAddProdus_Click;
            btnEditProdus.Click += BtnEditProdus_Click;
            btnDeleteProdus.Click += BtnDeleteProdus_Click;
            btnRefreshProdus.Click += (s, e) => LoadProduse();
            dataGridViewProduse.CellClick += DataGridViewProduse_CellClick;

            // Categories
            btnAddCategorie.Click += BtnAddCategorie_Click;
            btnEditCategorie.Click += BtnEditCategorie_Click;
            btnDeleteCategorie.Click += BtnDeleteCategorie_Click;
            btnRefreshCategorie.Click += (s, e) => LoadCategorii();
            dataGridViewCategorii.CellClick += DataGridViewCategorii_CellClick;

            // Suppliers
            btnAddFurnizor.Click += BtnAddFurnizor_Click;
            btnEditFurnizor.Click += BtnEditFurnizor_Click;
            btnDeleteFurnizor.Click += BtnDeleteFurnizor_Click;
            btnRefreshFurnizor.Click += (s, e) => LoadFurnizori();
            dataGridViewFurnizori.CellClick += DataGridViewFurnizori_CellClick;

            // Stock
            btnAddStoc.Click += BtnAddStoc_Click;
            btnEditStoc.Click += BtnEditStoc_Click;
            btnDeleteStoc.Click += BtnDeleteStoc_Click;
            btnRefreshStoc.Click += (s, e) => LoadStocuri();
            dataGridViewStocuri.CellClick += DataGridViewStocuri_CellClick;

            // Discounts
            btnAddReducere.Click += BtnAddReducere_Click;
            btnEditReducere.Click += BtnEditReducere_Click;
            btnDeleteReducere.Click += BtnDeleteReducere_Click;
            btnRefreshReducere.Click += (s, e) => LoadReduceri();
            dataGridViewReduceri.CellClick += DataGridViewReduceri_CellClick;

            // Reports
            btnExpiredProducts.Click += btnExpiredProducts_Click;
            btnDiscount50.Click += btnDiscount50_Click;
            btnDiscount20.Click += btnDiscount20_Click;
            btnAtLeast1Year.Click += btnAtLeast1Year_Click;
            btnMax1Month.Click += btnMax1Month_Click;
            btnExportExpired.Click += btnExportExpired_Click;
            btnMax5Days.Click += btnMax5Days_Click;
            btnByCategory.Click += btnByCategory_Click;

            // Excel export buttons for each report
            btnExpiredProductsToExcel.Click += btnExpiredProductsToExcel_Click;
            btnDiscount50ToExcel.Click += btnDiscount50ToExcel_Click;
            btnDiscount20ToExcel.Click += btnDiscount20ToExcel_Click;
            btnAtLeast1YearToExcel.Click += btnAtLeast1YearToExcel_Click;
            btnMax1MonthToExcel.Click += btnMax1MonthToExcel_Click;
            btnMax5DaysToExcel.Click += btnMax5DaysToExcel_Click;
            btnByCategoryToExcel.Click += btnByCategoryToExcel_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ApplyExpirationDiscounts();
            LoadProduse();
            LoadCategorii();
            LoadFurnizori();
            LoadStocuri();
            LoadReduceri();

            LoadCategorieCombo();
            LoadFurnizorCombo();
            LoadProdusCombo();
            LoadProdusReducereCombo();
            LoadUnitateStocCombo();
            LoadCategorieRaportCombo();
        }

        private void ApplyRolePermissions()
        {
            if (currentUserRole == UserRole.Seller)
            {
                // Все вкладки доступны для просмотра
                tabPageProduse.Enabled = true;
                tabPageCategorii.Enabled = true;
                tabPageFurnizori.Enabled = true;
                tabPageStocuri.Enabled = true;
                tabPageReduceri.Enabled = true;
                tabPageRapoarte.Enabled = true;

                // Только продукты можно менять
                btnAddProdus.Enabled = btnEditProdus.Enabled = btnDeleteProdus.Enabled = true;

                // Остальные кнопки изменения — только просмотр
                btnAddCategorie.Enabled = btnEditCategorie.Enabled = btnDeleteCategorie.Enabled = false;
                btnAddFurnizor.Enabled = btnEditFurnizor.Enabled = btnDeleteFurnizor.Enabled = false;
                btnAddStoc.Enabled = btnEditStoc.Enabled = btnDeleteStoc.Enabled = false;
                btnAddReducere.Enabled = btnEditReducere.Enabled = btnDeleteReducere.Enabled = false;
            }
            else if (currentUserRole == UserRole.Administrator)
            {
                // Администратор видит и меняет всё
                tabPageProduse.Enabled = true;
                tabPageCategorii.Enabled = true;
                tabPageFurnizori.Enabled = true;
                tabPageStocuri.Enabled = true;
                tabPageReduceri.Enabled = true;
                tabPageRapoarte.Enabled = true;

                btnAddProdus.Enabled = btnEditProdus.Enabled = btnDeleteProdus.Enabled = true;
                btnAddCategorie.Enabled = btnEditCategorie.Enabled = btnDeleteCategorie.Enabled = true;
                btnAddFurnizor.Enabled = btnEditFurnizor.Enabled = btnDeleteFurnizor.Enabled = true;
                btnAddStoc.Enabled = btnEditStoc.Enabled = btnDeleteStoc.Enabled = true;
                btnAddReducere.Enabled = btnEditReducere.Enabled = btnDeleteReducere.Enabled = true;
            }
        }



        // --- Excel Export Handlers for Each Report ---
        private void btnExpiredProductsToExcel_Click(object sender, EventArgs e)
        {
            ExportDataGridViewToExcel(dataGridViewRaport, "ExpiredProducts.xlsx", "Expired Products");
        }
        private void btnDiscount50ToExcel_Click(object sender, EventArgs e)
        {
            ExportDataGridViewToExcel(dataGridViewRaport, "Discount50.xlsx", "50% Discount");
        }
        private void btnDiscount20ToExcel_Click(object sender, EventArgs e)
        {
            ExportDataGridViewToExcel(dataGridViewRaport, "Discount20.xlsx", "20% Discount");
        }
        private void btnAtLeast1YearToExcel_Click(object sender, EventArgs e)
        {
            ExportDataGridViewToExcel(dataGridViewRaport, "AtLeast1Year.xlsx", "Shelf life ≥ 1 year");
        }
        private void btnMax1MonthToExcel_Click(object sender, EventArgs e)
        {
            ExportDataGridViewToExcel(dataGridViewRaport, "Max1Month.xlsx", "Shelf life ≤ 1 month");
        }
        private void btnMax5DaysToExcel_Click(object sender, EventArgs e)
        {
            ExportDataGridViewToExcel(dataGridViewRaport, "Max5Days.xlsx", "Shelf life ≤ 5 days");
        }
        private void btnByCategoryToExcel_Click(object sender, EventArgs e)
        {
            ExportDataGridViewToExcel(dataGridViewRaport, "ByCategory.xlsx", "By Category");
        }

        // --- Universal Export Method ---
        private void ExportDataGridViewToExcel(DataGridView dgv, string fileName, string sheetName)
        {
            if (dgv.Rows.Count == 0 || dgv.Columns.Count == 0)
            {
                MessageBox.Show("The DataGridView is empty. Please ensure it contains data before exporting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var workbook = new XLWorkbook())
            {
                var ws = workbook.Worksheets.Add(sheetName);

                // Заголовки
                for (int col = 0; col < dgv.Columns.Count; col++)
                {
                    ws.Cell(1, col + 1).Value = dgv.Columns[col].HeaderText;
                    ws.Cell(1, col + 1).Style.Font.Bold = true;
                    ws.Cell(1, col + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                    ws.Cell(1, col + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Column(col + 1).AdjustToContents();
                }

                // Данные
                for (int row = 0; row < dgv.Rows.Count; row++)
                {
                    for (int col = 0; col < dgv.Columns.Count; col++)
                    {
                        var cellValue = dgv.Rows[row].Cells[col].Value;
                        ws.Cell(row + 2, col + 1).Value = cellValue == null ? "" : cellValue.ToString();
                    }
                }

                // Границы
                var rng = ws.Range(1, 1, dgv.Rows.Count + 1, dgv.Columns.Count);
                rng.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                rng.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                // Сохраняем
                var saveDlg = new SaveFileDialog { Filter = "Excel files|*.xlsx", FileName = fileName };
                if (saveDlg.ShowDialog() == DialogResult.OK)
                    workbook.SaveAs(saveDlg.FileName);
            }
        }

        /// <summary>
        /// Calculates the current price of a product depending on the date.
        /// </summary>
        public decimal GetCurrentPrice(decimal initialPrice, DateTime startDate, DateTime expirationDate, DateTime currentDate)
        {
            if (currentDate > expirationDate)
                return 0m;

            TimeSpan totalPeriod = expirationDate - startDate;
            TimeSpan elapsed = currentDate - startDate;

            // If the current date is the middle of the shelf life
            if (Math.Abs(elapsed.TotalDays - totalPeriod.TotalDays / 2) < 0.01)
                return initialPrice * 0.8m;

            // If less than or equal to 25% of shelf life remains
            double fractionLeft = (expirationDate - currentDate).TotalDays / totalPeriod.TotalDays;
            if (fractionLeft <= 0.25)
                return initialPrice * 0.5m;

            // Otherwise, return the initial price
            return initialPrice;
        }

        /// <summary>
        /// Checks products for expiration and applies a discount if needed.
        /// </summary>
        private void ApplyExpirationDiscounts()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Get all products
                string selectQuery = @"SELECT ID_Produs, NumeProdus, DataFabricatiei, DataExpirarii, PretInitial, PretActual 
                               FROM Produse";
                var selectCmd = new SqlCommand(selectQuery, conn);
                var reader = selectCmd.ExecuteReader();
                var expiredProducts = new List<(int id, string name, DateTime fabricatie, DateTime expirare, decimal pretInitial, decimal pretActual, decimal newPrice)>();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    DateTime fabricatie = reader.GetDateTime(2);
                    DateTime expirare = reader.GetDateTime(3);
                    decimal pretInitial = reader.GetDecimal(4);
                    decimal pretActual = reader.GetDecimal(5);

                    decimal newPrice = GetCurrentPrice(pretInitial, fabricatie, expirare, DateTime.Now);

                    if (newPrice != pretActual)
                    {
                        expiredProducts.Add((id, name, fabricatie, expirare, pretInitial, pretActual, newPrice));
                    }
                }
                reader.Close();

                // Update price and add discount for each product if needed
                foreach (var prod in expiredProducts)
                {
                    // Update price in Produse table
                    string updateQuery = "UPDATE Produse SET PretActual=@pret WHERE ID_Produs=@id";
                    var updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@pret", prod.newPrice);
                    updateCmd.Parameters.AddWithValue("@id", prod.id);
                    updateCmd.ExecuteNonQuery();

                    // Check if such a discount already exists
                    string checkDiscountQuery = @"SELECT COUNT(*) FROM Reduceri 
                                          WHERE ID_Produs=@id AND Descriere='Expiration date discount'";
                    var checkCmd = new SqlCommand(checkDiscountQuery, conn);
                    checkCmd.Parameters.AddWithValue("@id", prod.id);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        // Add discount to Reduceri table
                        string insertDiscountQuery = @"INSERT INTO Reduceri 
                    (ID_Produs, Descriere, ProcentReducere, ConditieAplicare, DataInceput, DataSfarsit)
                    VALUES (@id, @desc, @proc, @cond, @start, @end)";
                        var insertCmd = new SqlCommand(insertDiscountQuery, conn);
                        insertCmd.Parameters.AddWithValue("@id", prod.id);
                        insertCmd.Parameters.AddWithValue("@desc", "Expiration date discount");
                        // Calculate discount percent
                        decimal percent = prod.pretInitial == 0 ? 0 : (1 - prod.newPrice / prod.pretInitial) * 100;
                        insertCmd.Parameters.AddWithValue("@proc", percent);
                        insertCmd.Parameters.AddWithValue("@cond", "Expiration date");
                        insertCmd.Parameters.AddWithValue("@start", DateTime.Now.Date);
                        insertCmd.Parameters.AddWithValue("@end", prod.expirare);
                        insertCmd.ExecuteNonQuery();
                    }
                }
            }
        }
        // ------------------- REPORTS -------------------
        private void LoadCategorieRaportCombo()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var dt = new DataTable();
                new SqlDataAdapter("SELECT ID_Categorie, NumeCategorie FROM Categorii", conn).Fill(dt);
                cmbCategorieRaport.DataSource = dt;
                cmbCategorieRaport.DisplayMember = "NumeCategorie";
                cmbCategorieRaport.ValueMember = "ID_Categorie";
            }
        }

        private void btnExpiredProducts_Click(object sender, EventArgs e) => ShowExpiredProductsReport();
        private void btnDiscount50_Click(object sender, EventArgs e) => ShowProductsWith50PercentDiscount();
        private void btnDiscount20_Click(object sender, EventArgs e) => ShowProductsWith20PercentDiscount();
        private void btnAtLeast1Year_Click(object sender, EventArgs e) => ShowProductsWithAtLeastOneYearValidity();
        private void btnMax1Month_Click(object sender, EventArgs e) => ShowProductsWithMaxOneMonthValidity();
        private void btnExportExpired_Click(object sender, EventArgs e)
        {
            ExportDataGridViewToExcel(dataGridViewRaport, "ExpiredProducts.xlsx", "Expired Products");
        }
        private void btnMax5Days_Click(object sender, EventArgs e) => ShowProductsWithMaxFiveDaysValidity();
        private void btnByCategory_Click(object sender, EventArgs e)
        {
            if (cmbCategorieRaport.SelectedValue != null)
                ShowProductsByCategory(Convert.ToInt32(cmbCategorieRaport.SelectedValue));
        }

        private void ShowExpiredProductsReport()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT ID_Produs, NumeProdus, DataExpirarii, PretInitial, PretActual
                                 FROM Produse
                                 WHERE DataExpirarii < GETDATE()";
                var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewRaport.DataSource = dt;
            }
        }

        private void ShowProductsWith50PercentDiscount()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT p.ID_Produs, p.NumeProdus, p.PretInitial, p.PretActual, r.ProcentReducere
                                 FROM Produse p
                                 INNER JOIN Reduceri r ON p.ID_Produs = r.ID_Produs
                                 WHERE r.ProcentReducere = 50
                                 ORDER BY p.PretInitial ASC";
                var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewRaport.DataSource = dt;
            }
        }

        private void ShowProductsWith20PercentDiscount()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT p.ID_Produs, p.NumeProdus, p.PretInitial, p.PretActual, r.ProcentReducere
                                 FROM Produse p
                                 INNER JOIN Reduceri r ON p.ID_Produs = r.ID_Produs
                                 WHERE r.ProcentReducere = 20
                                 ORDER BY p.PretActual ASC";
                var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewRaport.DataSource = dt;
            }
        }

        private void ShowProductsWithAtLeastOneYearValidity()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT ID_Produs, NumeProdus, DataFabricatiei, DataExpirarii
                         FROM Produse
                         WHERE DATEDIFF(day, DataFabricatiei, DataExpirarii) >= 365";
                var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewRaport.DataSource = dt;
            }
        }

        private void ShowProductsWithMaxOneMonthValidity()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT ID_Produs, NumeProdus, DataFabricatiei, DataExpirarii
                                 FROM Produse
                                 WHERE DATEDIFF(day, GETDATE(), DataExpirarii) <= 31 AND DATEDIFF(day, GETDATE(), DataExpirarii) >= 0";
                var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewRaport.DataSource = dt;
            }
        }

        private void ExportExpiredProductsToExcel()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT ID_Produs, NumeProdus, DataExpirarii, PretInitial, PretActual
                                 FROM Produse
                                 WHERE DataExpirarii < GETDATE()";
                var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);

                string filePath = @"C:\Users\user\Desktop\produse_expirate.csv";
                using (var sw = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                        sw.Write((i > 0 ? "," : "") + dt.Columns[i].ColumnName);
                    sw.WriteLine();
                    foreach (DataRow row in dt.Rows)
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                            sw.Write((i > 0 ? "," : "") + row[i].ToString());
                        sw.WriteLine();
                    }
                }
                MessageBox.Show("Export completed: " + filePath);
            }
        }

        private void ShowProductsWithMaxFiveDaysValidity()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT ID_Produs, NumeProdus, DataFabricatiei, DataExpirarii
                                 FROM Produse
                                 WHERE DATEDIFF(day, GETDATE(), DataExpirarii) <= 5 AND DATEDIFF(day, GETDATE(), DataExpirarii) >= 0";
                var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewRaport.DataSource = dt;
            }
        }

        private void ShowProductsByCategory(int idCategorie)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT p.ID_Produs, p.NumeProdus, p.DataExpirarii, p.PretInitial, p.PretActual, c.NumeCategorie
                                 FROM Produse p
                                 INNER JOIN Categorii c ON p.ID_Categorie = c.ID_Categorie
                                 WHERE p.ID_Categorie = @idCategorie";
                var adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@idCategorie", idCategorie);
                var dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewRaport.DataSource = dt;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes Form1, return to LoginForm will happen automatically in Program.cs
        }

        // ------------------- PRODUCTS -------------------
        private void LoadProduse()
        {
            ApplyExpirationDiscounts();
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT p.ID_Produs, p.NumeProdus, p.DataFabricatiei, p.DataExpirarii, p.PretInitial, 
                                        c.NumeCategorie, f.NumeFurnizor
                                 FROM Produse p
                                 LEFT JOIN Categorii c ON p.ID_Categorie = c.ID_Categorie
                                 LEFT JOIN Furnizori f ON p.ID_Furnizor = f.ID_Furnizor";
                var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewProduse.DataSource = dt;
            }
        }
        private void BtnAddProdus_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Produse 
                        (NumeProdus, DataFabricatiei, DataExpirarii, PretInitial, PretActual, ID_Categorie, ID_Furnizor)
                        VALUES (@nume, @fabricatie, @expirare, @pret, @pret, @cat, @furn)";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nume", txtNumeProdus.Text.Trim());
                    cmd.Parameters.AddWithValue("@fabricatie", dtpFabricatie.Value.Date);
                    cmd.Parameters.AddWithValue("@expirare", dtpExpirare.Value.Date);
                    cmd.Parameters.AddWithValue("@pret", decimal.Parse(txtPret.Text));
                    cmd.Parameters.AddWithValue("@cat", cmbCategorie.SelectedValue);
                    cmd.Parameters.AddWithValue("@furn", cmbFurnizor.SelectedValue);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadProduse();
                MessageBox.Show("Product added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding: " + ex.Message);
            }
        }
        private void BtnEditProdus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdProdus.Text)) { MessageBox.Show("Please select a product."); return; }
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = @"UPDATE Produse SET 
                        NumeProdus=@nume, DataFabricatiei=@fabricatie, DataExpirarii=@expirare, 
                        PretInitial=@pret, PretActual=@pret, ID_Categorie=@cat, ID_Furnizor=@furn
                        WHERE ID_Produs=@id";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nume", txtNumeProdus.Text.Trim());
                    cmd.Parameters.AddWithValue("@fabricatie", dtpFabricatie.Value.Date);
                    cmd.Parameters.AddWithValue("@expirare", dtpExpirare.Value.Date);
                    cmd.Parameters.AddWithValue("@pret", decimal.Parse(txtPret.Text));
                    cmd.Parameters.AddWithValue("@cat", cmbCategorie.SelectedValue);
                    cmd.Parameters.AddWithValue("@furn", cmbFurnizor.SelectedValue);
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtIdProdus.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadProduse();
                MessageBox.Show("Product updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating: " + ex.Message);
            }
        }
        private void BtnDeleteProdus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdProdus.Text)) { MessageBox.Show("Please select a product."); return; }
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Produse WHERE ID_Produs=@id";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtIdProdus.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadProduse();
                MessageBox.Show("Product deleted!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting: " + ex.Message);
            }
        }
        private void DataGridViewProduse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewProduse.Rows[e.RowIndex];
                txtIdProdus.Text = row.Cells["ID_Produs"].Value.ToString();
                txtNumeProdus.Text = row.Cells["NumeProdus"].Value.ToString();

                // Check for DBNull for dates
                var fabricatie = row.Cells["DataFabricatiei"].Value;
                dtpFabricatie.Value = fabricatie == DBNull.Value ? DateTime.Now : Convert.ToDateTime(fabricatie);

                var expirare = row.Cells["DataExpirarii"].Value;
                dtpExpirare.Value = expirare == DBNull.Value ? DateTime.Now : Convert.ToDateTime(expirare);

                txtPret.Text = row.Cells["PretInitial"].Value.ToString();
                cmbCategorie.Text = row.Cells["NumeCategorie"].Value.ToString();
                cmbFurnizor.Text = row.Cells["NumeFurnizor"].Value.ToString();
            }
        }

        // ------------------- CATEGORIES -------------------



        private void tabControlMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            LoadTabImages(); // Ensure images are loaded

            TabControl tabControl = sender as TabControl;
            TabPage page = tabControl.TabPages[e.Index];
            Graphics g = e.Graphics;
            Rectangle tabRect = tabControl.GetTabRect(e.Index);

            // Colors
            Color activeColor = Color.Orange;
            Color inactiveColor = Color.FromArgb(255, 241, 148);
            Color textColor = Color.White;

            // Tab background
            using (SolidBrush backBrush = new SolidBrush(e.Index == tabControl.SelectedIndex ? activeColor : inactiveColor))
                g.FillRectangle(backBrush, tabRect);

            // Draw image
            int imgSize = 28; // Adjust as needed
            int imgMargin = 8;
            int textMargin = 6;
            int imgY = tabRect.Y + (tabRect.Height - imgSize) / 2;
            int imgX = tabRect.X + imgMargin;

            if (tabImages.ContainsKey(e.Index) && tabImages[e.Index] != null)
            {
                g.DrawImage(tabImages[e.Index], new Rectangle(imgX, imgY, imgSize, imgSize));
            }

            // Draw text
            using (Font font = new Font("Segoe UI", 20, e.Index == tabControl.SelectedIndex ? FontStyle.Bold : FontStyle.Regular))
            using (SolidBrush textBrush = new SolidBrush(textColor))
            {
                StringFormat sf = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };
                int textX = imgX + imgSize + textMargin;
                Rectangle textRect = new Rectangle(textX, tabRect.Y, tabRect.Width - (textX - tabRect.X), tabRect.Height);
                g.DrawString(page.Text, font, textBrush, textRect, sf);
            }

            // Underline active tab (if needed)
            if (e.Index == tabControl.SelectedIndex)
            {
                int underlineHeight = 5;
                Rectangle underlineRect = new Rectangle(tabRect.X, tabRect.Bottom - underlineHeight, tabRect.Width, underlineHeight);
                using (SolidBrush underlineBrush = new SolidBrush(Color.Orange))
                    g.FillRectangle(underlineBrush, underlineRect);
            }

            // Border around tab
            using (Pen borderPen = new Pen(Color.Gray))
                g.DrawRectangle(borderPen, tabRect);
        }

        private void LoadCategorii()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Categorii";
                var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewCategorii.DataSource = dt;
            }
        }

        private void BtnAddCategorie_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Categorii (NumeCategorie) VALUES (@nume)";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nume", txtNumeCategorie.Text.Trim());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadCategorii();
                MessageBox.Show("Category added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding: " + ex.Message);
            }
        }

        private void BtnEditCategorie_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdCategorie.Text)) { MessageBox.Show("Select a category."); return; }
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Categorii SET NumeCategorie=@nume WHERE ID_Categorie=@id";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nume", txtNumeCategorie.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtIdCategorie.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadCategorii();
                MessageBox.Show("Category updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating: " + ex.Message);
            }
        }

        private void BtnDeleteCategorie_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdCategorie.Text)) { MessageBox.Show("Select a category."); return; }
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Categorii WHERE ID_Categorie=@id";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtIdCategorie.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadCategorii();
                MessageBox.Show("Category deleted!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting: " + ex.Message);
            }
        }

        private void DataGridViewCategorii_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewCategorii.Rows[e.RowIndex];
                txtIdCategorie.Text = row.Cells["ID_Categorie"].Value.ToString();
                txtNumeCategorie.Text = row.Cells["NumeCategorie"].Value.ToString();
            }
        }

        // ------------------- SUPPLIERS -------------------
        private void LoadFurnizori()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Furnizori";
                var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewFurnizori.DataSource = dt;
            }
        }

        private void BtnAddFurnizor_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Furnizori (NumeFurnizor, Adresa, Telefon, Email) VALUES (@nume, @adresa, @telefon, @email)";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nume", txtNumeFurnizor.Text.Trim());
                    cmd.Parameters.AddWithValue("@adresa", txtAdresaFurnizor.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefon", txtTelefonFurnizor.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmailFurnizor.Text.Trim());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadFurnizori();
                MessageBox.Show("Supplier added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding: " + ex.Message);
            }
        }

        private void BtnEditFurnizor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdFurnizor.Text)) { MessageBox.Show("Select a supplier."); return; }
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Furnizori SET NumeFurnizor=@nume, Adresa=@adresa, Telefon=@telefon, Email=@email WHERE ID_Furnizor=@id";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nume", txtNumeFurnizor.Text.Trim());
                    cmd.Parameters.AddWithValue("@adresa", txtAdresaFurnizor.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefon", txtTelefonFurnizor.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmailFurnizor.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtIdFurnizor.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadFurnizori();
                MessageBox.Show("Supplier updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating: " + ex.Message);
            }
        }

        private void BtnDeleteFurnizor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdFurnizor.Text)) { MessageBox.Show("Select a supplier."); return; }
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Furnizori WHERE ID_Furnizor=@id";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtIdFurnizor.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadFurnizori();
                MessageBox.Show("Supplier deleted!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting: " + ex.Message);
            }
        }

        private void DataGridViewFurnizori_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewFurnizori.Rows[e.RowIndex];
                txtIdFurnizor.Text = row.Cells["ID_Furnizor"].Value.ToString();
                txtNumeFurnizor.Text = row.Cells["NumeFurnizor"].Value.ToString();
                txtAdresaFurnizor.Text = row.Cells["Adresa"].Value.ToString();
                txtTelefonFurnizor.Text = row.Cells["Telefon"].Value.ToString();
                txtEmailFurnizor.Text = row.Cells["Email"].Value.ToString();
            }
        }

        // ------------------- INVENTORY -------------------
        private void LoadStocuri()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT s.ID_Stoc, p.NumeProdus, s.Cantitate, s.UnitateMasura
                         FROM Stocuri s
                         LEFT JOIN Produse p ON s.ID_Produs = p.ID_Produs";
                var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewStocuri.DataSource = dt;
            }
        }

        private void BtnAddStoc_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Stocuri (ID_Produs, Cantitate, UnitateMasura) VALUES (@produs, @cant, @um)";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@produs", cmbProdusStoc.SelectedValue);
                    cmd.Parameters.AddWithValue("@cant", int.Parse(txtCantitateStoc.Text));
                    cmd.Parameters.AddWithValue("@um", cmbUnitateStoc.SelectedItem.ToString());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadStocuri();
                MessageBox.Show("Inventory record added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding: " + ex.Message);
            }
        }

        private void BtnEditStoc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdStoc.Text)) { MessageBox.Show("Select a record."); return; }
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Stocuri SET ID_Produs=@produs, Cantitate=@cant, UnitateMasura=@um WHERE ID_Stoc=@id";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@produs", cmbProdusStoc.SelectedValue);
                    cmd.Parameters.AddWithValue("@cant", int.Parse(txtCantitateStoc.Text));
                    cmd.Parameters.AddWithValue("@um", cmbUnitateStoc.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtIdStoc.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadStocuri();
                MessageBox.Show("Inventory record updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating: " + ex.Message);
            }
        }

        private void BtnDeleteStoc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdStoc.Text)) { MessageBox.Show("Select a record."); return; }
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Stocuri WHERE ID_Stoc=@id";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtIdStoc.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadStocuri();
                MessageBox.Show("Inventory record deleted!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting: " + ex.Message);
            }
        }

        private void DataGridViewStocuri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewStocuri.Rows[e.RowIndex];
                txtIdStoc.Text = row.Cells["ID_Stoc"].Value.ToString();
                cmbProdusStoc.Text = row.Cells["NumeProdus"].Value.ToString();
                txtCantitateStoc.Text = row.Cells["Cantitate"].Value.ToString();
                cmbUnitateStoc.Text = row.Cells["UnitateMasura"].Value.ToString();
            }
        }

        // ------------------- DISCOUNTS -------------------
        private void LoadReduceri()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT r.ID_Reducere, p.NumeProdus, r.Descriere, r.ProcentReducere, r.ConditieAplicare, r.DataInceput, r.DataSfarsit
                         FROM Reduceri r
                         LEFT JOIN Produse p ON r.ID_Produs = p.ID_Produs";
                var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewReduceri.DataSource = dt;
            }
        }

        private void BtnAddReducere_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Reduceri (ID_Produs, Descriere, ProcentReducere, ConditieAplicare, DataInceput, DataSfarsit)
                             VALUES (@produs, @desc, @proc, @cond, @start, @end)";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@produs", cmbProdusReducere.SelectedValue);
                    cmd.Parameters.AddWithValue("@desc", txtDescriereReducere.Text.Trim());
                    cmd.Parameters.AddWithValue("@proc", float.Parse(txtProcentReducere.Text));
                    cmd.Parameters.AddWithValue("@cond", txtConditieReducere.Text.Trim());
                    cmd.Parameters.AddWithValue("@start", dtpDataInceputReducere.Value.Date);
                    cmd.Parameters.AddWithValue("@end", dtpDataSfarsitReducere.Value.Date);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadReduceri();
                MessageBox.Show("Discount added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding: " + ex.Message);
            }
        }

        private void BtnEditReducere_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdReducere.Text)) { MessageBox.Show("Select a discount."); return; }
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = @"UPDATE Reduceri SET ID_Produs=@produs, Descriere=@desc, ProcentReducere=@proc, ConditieAplicare=@cond, DataInceput=@start, DataSfarsit=@end
                             WHERE ID_Reducere=@id";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@produs", cmbProdusReducere.SelectedValue);
                    cmd.Parameters.AddWithValue("@desc", txtDescriereReducere.Text.Trim());
                    cmd.Parameters.AddWithValue("@proc", float.Parse(txtProcentReducere.Text));
                    cmd.Parameters.AddWithValue("@cond", txtConditieReducere.Text.Trim());
                    cmd.Parameters.AddWithValue("@start", dtpDataInceputReducere.Value.Date);
                    cmd.Parameters.AddWithValue("@end", dtpDataSfarsitReducere.Value.Date);
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtIdReducere.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadReduceri();
                MessageBox.Show("Discount updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating: " + ex.Message);
            }
        }

        private void BtnDeleteReducere_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdReducere.Text)) { MessageBox.Show("Select a discount."); return; }
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Reduceri WHERE ID_Reducere=@id";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtIdReducere.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadReduceri();
                MessageBox.Show("Discount deleted!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting: " + ex.Message);
            }
        }

        private void DataGridViewReduceri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewReduceri.Rows[e.RowIndex];
                txtIdReducere.Text = row.Cells["ID_Reducere"].Value.ToString();
                cmbProdusReducere.Text = row.Cells["NumeProdus"].Value.ToString();
                txtDescriereReducere.Text = row.Cells["Descriere"].Value.ToString();
                txtProcentReducere.Text = row.Cells["ProcentReducere"].Value.ToString();
                txtConditieReducere.Text = row.Cells["ConditieAplicare"].Value.ToString();
                dtpDataInceputReducere.Value = Convert.ToDateTime(row.Cells["DataInceput"].Value);
                dtpDataSfarsitReducere.Value = Convert.ToDateTime(row.Cells["DataSfarsit"].Value);
            }
        }

        // ------------------- HELPER METHODS FOR ComboBox -------------------
        private void LoadCategorieCombo()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var dt = new DataTable();
                new SqlDataAdapter("SELECT ID_Categorie, NumeCategorie FROM Categorii", conn).Fill(dt);
                cmbCategorie.DataSource = dt.Copy();
                cmbCategorie.DisplayMember = "NumeCategorie";
                cmbCategorie.ValueMember = "ID_Categorie";
            }
        }

        private void LoadFurnizorCombo()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var dt = new DataTable();
                new SqlDataAdapter("SELECT ID_Furnizor, NumeFurnizor FROM Furnizori", conn).Fill(dt);
                cmbFurnizor.DataSource = dt.Copy();
                cmbFurnizor.DisplayMember = "NumeFurnizor";
                cmbFurnizor.ValueMember = "ID_Furnizor";
            }
        }

        private void LoadProdusCombo()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var dt = new DataTable();
                new SqlDataAdapter("SELECT ID_Produs, NumeProdus FROM Produse", conn).Fill(dt);
                cmbProdusStoc.DataSource = dt.Copy();
                cmbProdusStoc.DisplayMember = "NumeProdus";
                cmbProdusStoc.ValueMember = "ID_Produs";
            }
        }



        private void LoadProdusReducereCombo()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var dt = new DataTable();
                new SqlDataAdapter("SELECT ID_Produs, NumeProdus FROM Produse", conn).Fill(dt);
                cmbProdusReducere.DataSource = dt.Copy();
                cmbProdusReducere.DisplayMember = "NumeProdus";
                cmbProdusReducere.ValueMember = "ID_Produs";
            }
        }

        private void LoadTabImages()
        {
            if (tabImages.Count > 0) return;

            try
            {
                tabImages[0] = Properties.Resources.prod;   // Products
                tabImages[1] = Properties.Resources.kat;    // Categories
                tabImages[2] = Properties.Resources.pos;    // Suppliers
                tabImages[3] = Properties.Resources.scl;    // Stock
                tabImages[4] = Properties.Resources.skid;   // Discounts
                tabImages[5] = Properties.Resources.rap;    // Reports
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading icons: " + ex.Message);
            }
        }


        private void LoadUnitateStocCombo()
        {
            cmbUnitateStoc.Items.Clear();
            cmbUnitateStoc.Items.AddRange(new object[] { "kg", "l", "pcs" });
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            // Empty method
        }

        private void Form1_Load_2(object sender, EventArgs e)
        {
            // Empty method
        }
    }
}