using System;
using System.Windows.Forms;

namespace st.ind2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TabControl tabControlMain;
        private TabPage tabPageProduse, tabPageCategorii, tabPageFurnizori, tabPageStocuri, tabPageReduceri, tabPageRapoarte;
        private Button btnLogout;
        private PictureBox pictureBoxLogo;

        // --- Products ---
        private Label lblTitleProduse, lblIdProdus, lblNumeProdus, lblPret, lblCategorie, lblFurnizor, lblFabricatie, lblExpirare;
        private DataGridView dataGridViewProduse;
        private TextBox txtIdProdus, txtNumeProdus, txtPret;
        private ComboBox cmbCategorie, cmbFurnizor;
        private DateTimePicker dtpFabricatie, dtpExpirare;
        private Button btnAddProdus, btnEditProdus, btnDeleteProdus, btnRefreshProdus;

        // --- Categories ---
        private Label lblTitleCategorii, lblIdCategorie, lblNumeCategorie;
        private DataGridView dataGridViewCategorii;
        private TextBox txtIdCategorie, txtNumeCategorie;
        private Button btnAddCategorie, btnEditCategorie, btnDeleteCategorie, btnRefreshCategorie;

        // --- Suppliers ---
        private Label lblTitleFurnizori, lblIdFurnizor, lblNumeFurnizor, lblAdresaFurnizor, lblTelefonFurnizor, lblEmailFurnizor;
        private DataGridView dataGridViewFurnizori;
        private TextBox txtIdFurnizor, txtNumeFurnizor, txtAdresaFurnizor, txtTelefonFurnizor, txtEmailFurnizor;
        private Button btnAddFurnizor, btnEditFurnizor, btnDeleteFurnizor, btnRefreshFurnizor;

        // --- Inventory ---
        private Label lblTitleStocuri, lblIdStoc, lblProdusStoc, lblCantitateStoc, lblUnitateStoc;
        private DataGridView dataGridViewStocuri;
        private TextBox txtIdStoc, txtCantitateStoc;
        private ComboBox cmbProdusStoc, cmbUnitateStoc;
        private Button btnAddStoc, btnEditStoc, btnDeleteStoc, btnRefreshStoc;

        // --- Discounts ---
        private Label lblTitleReduceri, lblIdReducere, lblProdusReducere, lblDescriereReducere, lblProcentReducere, lblConditieReducere, lblDataInceputReducere, lblDataSfarsitReducere;
        private DataGridView dataGridViewReduceri;
        private TextBox txtIdReducere, txtDescriereReducere, txtProcentReducere, txtConditieReducere;
        private ComboBox cmbProdusReducere;
        private DateTimePicker dtpDataInceputReducere, dtpDataSfarsitReducere;
        private Button btnAddReducere, btnEditReducere, btnDeleteReducere, btnRefreshReducere;

        // --- Reports ---

        private Label lblTitleRapoarte;
        private Button btnExpiredProducts, btnDiscount50, btnDiscount20, btnAtLeast1Year, btnMax1Month, btnExportExpired, btnMax5Days, btnByCategory;
        private Button btnExpiredProductsToExcel, btnDiscount50ToExcel, btnDiscount20ToExcel, btnAtLeast1YearToExcel, btnMax1MonthToExcel, btnMax5DaysToExcel, btnByCategoryToExcel;
        private ComboBox cmbCategorieRaport;
        private DataGridView dataGridViewRaport;





        // Add Dispose override to use the components field
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // --- TabControl ---
            this.tabControlMain = new TabControl();
            this.tabPageProduse = new TabPage("Products");
            this.tabPageCategorii = new TabPage("Categories");
            this.tabPageFurnizori = new TabPage("Suppliers");
            this.tabPageStocuri = new TabPage("Inventory");
            this.tabPageReduceri = new TabPage("Discounts");
            this.tabPageRapoarte = new TabPage("Reports");
            this.tabControlMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlMain.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControlMain_DrawItem);
            this.tabControlMain.ItemSize = new System.Drawing.Size(180, 60);
            this.tabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;

            // --- Products ---
            this.lblTitleProduse = new Label { Text = "Product Management", Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.White, BackColor = System.Drawing.Color.Orange, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, Dock = DockStyle.Top, Height = 40 };
            this.dataGridViewProduse = new DataGridView { Location = new System.Drawing.Point(350, 50), Size = new System.Drawing.Size(700, 400), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, BackgroundColor = System.Drawing.Color.White };
            this.dataGridViewProduse.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Orange;
            this.dataGridViewProduse.EnableHeadersVisualStyles = false;
            int y = 60, dy = 35;
            this.lblIdProdus = new Label { Text = "ID:", Location = new System.Drawing.Point(30, y) };
            this.txtIdProdus = new TextBox { Location = new System.Drawing.Point(150, y), Width = 150, ReadOnly = true };
            y += dy;
            this.lblNumeProdus = new Label { Text = "Name:", Location = new System.Drawing.Point(30, y) };
            this.txtNumeProdus = new TextBox { Location = new System.Drawing.Point(150, y), Width = 150 };
            y += dy;
            this.lblPret = new Label { Text = "Price:", Location = new System.Drawing.Point(30, y) };
            this.txtPret = new TextBox { Location = new System.Drawing.Point(150, y), Width = 150 };
            y += dy;
            this.lblCategorie = new Label { Text = "Category:", Location = new System.Drawing.Point(30, y) };
            this.cmbCategorie = new ComboBox { Location = new System.Drawing.Point(150, y), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
            y += dy;
            this.lblFurnizor = new Label { Text = "Supplier:", Location = new System.Drawing.Point(30, y) };
            this.cmbFurnizor = new ComboBox { Location = new System.Drawing.Point(150, y), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
            y += dy;
            this.lblFabricatie = new Label { Text = "Manufacturing Date:", Location = new System.Drawing.Point(30, y) };
            this.dtpFabricatie = new DateTimePicker { Location = new System.Drawing.Point(150, y), Width = 150 };
            y += dy;
            this.lblExpirare = new Label { Text = "Expiration Date:", Location = new System.Drawing.Point(30, y) };
            this.dtpExpirare = new DateTimePicker { Location = new System.Drawing.Point(150, y), Width = 150 };
            y += dy;
            this.btnAddProdus = new Button { Text = "Add", BackColor = System.Drawing.Color.Orange, ForeColor = System.Drawing.Color.White, Location = new System.Drawing.Point(30, y), Width = 100 };
            this.btnEditProdus = new Button { Text = "Edit", BackColor = System.Drawing.Color.Orange, ForeColor = System.Drawing.Color.White, Location = new System.Drawing.Point(140, y), Width = 100 };
            this.btnDeleteProdus = new Button { Text = "Delete", BackColor = System.Drawing.Color.Orange, ForeColor = System.Drawing.Color.White, Location = new System.Drawing.Point(250, y), Width = 100 };
            this.btnRefreshProdus = new Button { Text = "Refresh", BackColor = System.Drawing.Color.Orange, ForeColor = System.Drawing.Color.White, Location = new System.Drawing.Point(360, y), Width = 100 };

            this.tabPageProduse.Controls.AddRange(new Control[] {
                lblTitleProduse, dataGridViewProduse, lblIdProdus, txtIdProdus, lblNumeProdus, txtNumeProdus, lblPret, txtPret,
                lblCategorie, cmbCategorie, lblFurnizor, cmbFurnizor, lblFabricatie, dtpFabricatie, lblExpirare, dtpExpirare,
                btnAddProdus, btnEditProdus, btnDeleteProdus, btnRefreshProdus
            });

            // --- Categories ---
            this.lblTitleCategorii = new Label { Text = "Category Management", Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.White, BackColor = System.Drawing.Color.Orange, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, Dock = DockStyle.Top, Height = 40 };
            this.dataGridViewCategorii = new DataGridView { Location = new System.Drawing.Point(350, 50), Size = new System.Drawing.Size(400, 300), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, BackgroundColor = System.Drawing.Color.White };
            this.dataGridViewCategorii.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Orange;
            this.dataGridViewCategorii.EnableHeadersVisualStyles = false;
            y = 60;
            this.lblIdCategorie = new Label { Text = "ID:", Location = new System.Drawing.Point(30, y) };
            this.txtIdCategorie = new TextBox { Location = new System.Drawing.Point(150, y), Width = 150, ReadOnly = true };
            y += dy;
            this.lblNumeCategorie = new Label { Text = "Name:", Location = new System.Drawing.Point(30, y) };
            this.txtNumeCategorie = new TextBox { Location = new System.Drawing.Point(150, y), Width = 150 };
            y += dy;
            this.btnAddCategorie = new Button { Text = "Add", BackColor = System.Drawing.Color.Orange, ForeColor = System.Drawing.Color.White, Location = new System.Drawing.Point(30, y), Width = 100 };
            this.btnEditCategorie = new Button { Text = "Edit", BackColor = System.Drawing.Color.Orange, ForeColor = System.Drawing.Color.White, Location = new System.Drawing.Point(140, y), Width = 100 };
            this.btnDeleteCategorie = new Button { Text = "Delete", BackColor = System.Drawing.Color.Orange, ForeColor = System.Drawing.Color.White, Location = new System.Drawing.Point(250, y), Width = 100 };
            this.btnRefreshCategorie = new Button { Text = "Refresh", BackColor = System.Drawing.Color.Orange, ForeColor = System.Drawing.Color.White, Location = new System.Drawing.Point(360, y), Width = 100 };

            this.tabPageCategorii.Controls.AddRange(new Control[] {
                lblTitleCategorii, dataGridViewCategorii, lblIdCategorie, txtIdCategorie, lblNumeCategorie, txtNumeCategorie,
                btnAddCategorie, btnEditCategorie, btnDeleteCategorie, btnRefreshCategorie
            });

            // --- Suppliers ---
            this.lblTitleFurnizori = new Label { Text = "Supplier Management", Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.White, BackColor = System.Drawing.Color.Orange, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, Dock = DockStyle.Top, Height = 40 };
            this.dataGridViewFurnizori = new DataGridView { Location = new System.Drawing.Point(350, 50), Size = new System.Drawing.Size(500, 300), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, BackgroundColor = System.Drawing.Color.White };
            this.dataGridViewFurnizori.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Orange;
            this.dataGridViewFurnizori.EnableHeadersVisualStyles = false;
            y = 60;
            this.lblIdFurnizor = new Label { Text = "ID:", Location = new System.Drawing.Point(30, y) };
            this.txtIdFurnizor = new TextBox { Location = new System.Drawing.Point(150, y), Width = 150, ReadOnly = true };
            y += dy;
            this.lblNumeFurnizor = new Label { Text = "Name:", Location = new System.Drawing.Point(30, y) };
            this.txtNumeFurnizor = new TextBox { Location = new System.Drawing.Point(150, y), Width = 150 };
            y += dy;
            this.lblAdresaFurnizor = new Label { Text = "Address:", Location = new System.Drawing.Point(30, y) };
            this.txtAdresaFurnizor = new TextBox { Location = new System.Drawing.Point(150, y), Width = 150 };
            y += dy;
            this.lblTelefonFurnizor = new Label { Text = "Phone:", Location = new System.Drawing.Point(30, y) };
            this.txtTelefonFurnizor = new TextBox { Location = new System.Drawing.Point(150, y), Width = 150 };
            y += dy;
            this.lblEmailFurnizor = new Label { Text = "Email:", Location = new System.Drawing.Point(30, y) };
            this.txtEmailFurnizor = new TextBox { Location = new System.Drawing.Point(150, y), Width = 150 };
            y += dy;
            this.btnAddFurnizor = new Button { Text = "Add", BackColor = System.Drawing.Color.Orange, ForeColor = System.Drawing.Color.White, Location = new System.Drawing.Point(30, y), Width = 100 };
            this.btnEditFurnizor = new Button { Text = "Edit", BackColor = System.Drawing.Color.Orange, ForeColor = System.Drawing.Color.White, Location = new System.Drawing.Point(140, y), Width = 100 };
            this.btnDeleteFurnizor = new Button { Text = "Delete", BackColor = System.Drawing.Color.Orange, ForeColor = System.Drawing.Color.White, Location = new System.Drawing.Point(250, y), Width = 100 };
            this.btnRefreshFurnizor = new Button { Text = "Refresh", BackColor = System.Drawing.Color.Orange, ForeColor = System.Drawing.Color.White, Location = new System.Drawing.Point(360, y), Width = 100 };

            this.tabPageFurnizori.Controls.AddRange(new Control[] {
                lblTitleFurnizori, dataGridViewFurnizori, lblIdFurnizor, txtIdFurnizor, lblNumeFurnizor, txtNumeFurnizor,
                lblAdresaFurnizor, txtAdresaFurnizor, lblTelefonFurnizor, txtTelefonFurnizor, lblEmailFurnizor, txtEmailFurnizor,
                btnAddFurnizor, btnEditFurnizor, btnDeleteFurnizor, btnRefreshFurnizor
            });

            // --- Inventory ---
            this.lblTitleStocuri = new Label { Text = "Inventory Management", Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.White, BackColor = System.Drawing.Color.Orange, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, Dock = DockStyle.Top, Height = 40 };
            this.dataGridViewStocuri = new DataGridView { Location = new System.Drawing.Point(350, 50), Size = new System.Drawing.Size(400, 300), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, BackgroundColor = System.Drawing.Color.White };
            this.dataGridViewStocuri.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Orange;
            this.dataGridViewStocuri.EnableHeadersVisualStyles = false;
            y = 60;
            this.lblIdStoc = new Label { Text = "ID:", Location = new System.Drawing.Point(30, y) };
            this.txtIdStoc = new TextBox { Location = new System.Drawing.Point(150, y), Width = 150, ReadOnly = true };
            y += dy;
            this.lblProdusStoc = new Label { Text = "Product:", Location = new System.Drawing.Point(30, y) };
            this.cmbProdusStoc = new ComboBox { Location = new System.Drawing.Point(150, y), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
            y += dy;
            this.lblCantitateStoc = new Label { Text = "Quantity:", Location = new System.Drawing.Point(30, y) };
            this.txtCantitateStoc = new TextBox { Location = new System.Drawing.Point(150, y), Width = 150 };
            y += dy;
            this.lblUnitateStoc = new Label { Text = "Unit:", Location = new System.Drawing.Point(30, y) };
            this.cmbUnitateStoc = new ComboBox { Location = new System.Drawing.Point(150, y), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
            y += dy;
            this.btnAddStoc = new Button { Text = "Add", BackColor = System.Drawing.Color.Orange, ForeColor = System.Drawing.Color.White, Location = new System.Drawing.Point(30, y), Width = 100 };
            this.btnEditStoc = new Button { Text = "Edit", BackColor = System.Drawing.Color.Orange, ForeColor = System.Drawing.Color.White, Location = new System.Drawing.Point(140, y), Width = 100 };
            this.btnDeleteStoc = new Button { Text = "Delete", BackColor = System.Drawing.Color.Orange, ForeColor = System.Drawing.Color.White, Location = new System.Drawing.Point(250, y), Width = 100 };
            this.btnRefreshStoc = new Button { Text = "Refresh", BackColor = System.Drawing.Color.Orange, ForeColor = System.Drawing.Color.White, Location = new System.Drawing.Point(360, y), Width = 100 };

            this.tabPageStocuri.Controls.AddRange(new Control[] {
                lblTitleStocuri, dataGridViewStocuri, lblIdStoc, txtIdStoc, lblProdusStoc, cmbProdusStoc, lblCantitateStoc, txtCantitateStoc,
                lblUnitateStoc, cmbUnitateStoc, btnAddStoc, btnEditStoc, btnDeleteStoc, btnRefreshStoc
            });

            // --- Discounts ---
            this.lblTitleReduceri = new Label { Text = "Discount Management", Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.White, BackColor = System.Drawing.Color.Orange, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, Dock = DockStyle.Top, Height = 40 };
            this.dataGridViewReduceri = new DataGridView { Location = new System.Drawing.Point(350, 50), Size = new System.Drawing.Size(600, 300), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, BackgroundColor = System.Drawing.Color.White };
            this.dataGridViewReduceri.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Orange;
            this.dataGridViewReduceri.EnableHeadersVisualStyles = false;
            y = 60;
            this.lblIdReducere = new Label { Text = "ID:", Location = new System.Drawing.Point(30, y) };
            this.txtIdReducere = new TextBox { Location = new System.Drawing.Point(150, y), Width = 150, ReadOnly = true };
            y += dy;
            this.lblProdusReducere = new Label { Text = "Product:", Location = new System.Drawing.Point(30, y) };
            this.cmbProdusReducere = new ComboBox { Location = new System.Drawing.Point(150, y), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
            y += dy;
            this.lblDescriereReducere = new Label { Text = "Description:", Location = new System.Drawing.Point(30, y) };
            this.txtDescriereReducere = new TextBox { Location = new System.Drawing.Point(150, y), Width = 150 };
            y += dy;
            this.lblProcentReducere = new Label { Text = "Percentage:", Location = new System.Drawing.Point(30, y) };
            this.txtProcentReducere = new TextBox { Location = new System.Drawing.Point(150, y), Width = 150 };
            y += dy;
            this.lblConditieReducere = new Label { Text = "Condition:", Location = new System.Drawing.Point(30, y) };
            this.txtConditieReducere = new TextBox { Location = new System.Drawing.Point(150, y), Width = 150 };
            y += dy;
            this.lblDataInceputReducere = new Label { Text = "Start Date:", Location = new System.Drawing.Point(30, y) };
            this.dtpDataInceputReducere = new DateTimePicker { Location = new System.Drawing.Point(150, y), Width = 150 };
            y += dy;
            this.lblDataSfarsitReducere = new Label { Text = "End Date:", Location = new System.Drawing.Point(30, y) };
            this.dtpDataSfarsitReducere = new DateTimePicker { Location = new System.Drawing.Point(150, y), Width = 150 };
            y += dy;
            this.btnAddReducere = new Button { Text = "Add", BackColor = System.Drawing.Color.Orange, ForeColor = System.Drawing.Color.White, Location = new System.Drawing.Point(30, y), Width = 100 };
            this.btnEditReducere = new Button { Text = "Edit", BackColor = System.Drawing.Color.Orange, ForeColor = System.Drawing.Color.White, Location = new System.Drawing.Point(140, y), Width = 100 };
            this.btnDeleteReducere = new Button { Text = "Delete", BackColor = System.Drawing.Color.Orange, ForeColor = System.Drawing.Color.White, Location = new System.Drawing.Point(250, y), Width = 100 };
            this.btnRefreshReducere = new Button { Text = "Refresh", BackColor = System.Drawing.Color.Orange, ForeColor = System.Drawing.Color.White, Location = new System.Drawing.Point(360, y), Width = 100 };

            this.tabPageReduceri.Controls.AddRange(new Control[] {
                lblTitleReduceri, dataGridViewReduceri, lblIdReducere, txtIdReducere, lblProdusReducere, cmbProdusReducere,
                lblDescriereReducere, txtDescriereReducere, lblProcentReducere, txtProcentReducere, lblConditieReducere, txtConditieReducere,
                lblDataInceputReducere, dtpDataInceputReducere, lblDataSfarsitReducere, dtpDataSfarsitReducere,
                btnAddReducere, btnEditReducere, btnDeleteReducere, btnRefreshReducere
            });

            // --- Reports ---
            this.lblTitleRapoarte = new Label { Text = "Reports", Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.White, BackColor = System.Drawing.Color.Orange, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, Dock = DockStyle.Top, Height = 40 };

            this.btnExpiredProducts = new Button { Text = "Expired Products", Location = new System.Drawing.Point(10, 10), Size = new System.Drawing.Size(220, 30) };
            this.btnDiscount50 = new Button { Text = "50% Discount (from original price)", Location = new System.Drawing.Point(10, 50), Size = new System.Drawing.Size(220, 30) };
            this.btnDiscount20 = new Button { Text = "20% Discount (from current price)", Location = new System.Drawing.Point(10, 90), Size = new System.Drawing.Size(220, 30) };
            this.btnAtLeast1Year = new Button { Text = "Shelf life ≥ 1 year", Location = new System.Drawing.Point(10, 130), Size = new System.Drawing.Size(220, 30) };
            this.btnMax1Month = new Button { Text = "Shelf life ≤ 1 month", Location = new System.Drawing.Point(10, 170), Size = new System.Drawing.Size(220, 30) };
            this.btnExportExpired = new Button { Text = "Export expired (Excel)", Location = new System.Drawing.Point(10, 210), Size = new System.Drawing.Size(220, 30) };
            this.btnMax5Days = new Button { Text = "Shelf life ≤ 5 days", Location = new System.Drawing.Point(10, 250), Size = new System.Drawing.Size(220, 30) };
            this.cmbCategorieRaport = new ComboBox { Location = new System.Drawing.Point(10, 290), Size = new System.Drawing.Size(150, 30), DropDownStyle = ComboBoxStyle.DropDownList };
            this.btnByCategory = new Button { Text = "By Category", Location = new System.Drawing.Point(10, 330), Size = new System.Drawing.Size(220, 30) };

            this.btnExpiredProductsToExcel = new Button { Text = "To Excel", Location = new System.Drawing.Point(240, 10), Size = new System.Drawing.Size(80, 30) };
            this.btnDiscount50ToExcel = new Button { Text = "To Excel", Location = new System.Drawing.Point(240, 50), Size = new System.Drawing.Size(80, 30) };
            this.btnDiscount20ToExcel = new Button { Text = "To Excel", Location = new System.Drawing.Point(240, 90), Size = new System.Drawing.Size(80, 30) };
            this.btnAtLeast1YearToExcel = new Button { Text = "To Excel", Location = new System.Drawing.Point(240, 130), Size = new System.Drawing.Size(80, 30) };
            this.btnMax1MonthToExcel = new Button { Text = "To Excel", Location = new System.Drawing.Point(240, 170), Size = new System.Drawing.Size(80, 30) };
            this.btnMax5DaysToExcel = new Button { Text = "To Excel", Location = new System.Drawing.Point(240, 250), Size = new System.Drawing.Size(80, 30) };
            this.btnByCategoryToExcel = new Button { Text = "To Excel", Location = new System.Drawing.Point(240, 330), Size = new System.Drawing.Size(80, 30) };

            this.dataGridViewRaport = new DataGridView { Location = new System.Drawing.Point(350, 60), Size = new System.Drawing.Size(900, 450), ReadOnly = true, AllowUserToAddRows = false, AllowUserToDeleteRows = false, BackgroundColor = System.Drawing.Color.White };

            this.tabPageRapoarte.Controls.AddRange(new Control[] {
                lblTitleRapoarte,
                btnExpiredProducts, btnExpiredProductsToExcel,
                btnDiscount50, btnDiscount50ToExcel,
                btnDiscount20, btnDiscount20ToExcel,
                btnAtLeast1Year, btnAtLeast1YearToExcel,
                btnMax1Month, btnMax1MonthToExcel,
                btnExportExpired,
                btnMax5Days, btnMax5DaysToExcel,
                cmbCategorieRaport, btnByCategory, btnByCategoryToExcel,
                dataGridViewRaport
            });



            // --- TabControl ---
            this.tabControlMain.Controls.AddRange(new TabPage[] {
                tabPageProduse, tabPageCategorii, tabPageFurnizori, tabPageStocuri, tabPageReduceri, tabPageRapoarte
            });
            this.tabControlMain.Dock = DockStyle.Fill;

           
            // --- Logout Button ---
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnLogout.Text = "Logout";
            this.btnLogout.BackColor = System.Drawing.Color.Orange;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Size = new System.Drawing.Size(100, 35);
            this.btnLogout.Location = new System.Drawing.Point(10, this.ClientSize.Height - 55);
            this.btnLogout.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // --- Add controls to form ---
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.btnLogout);
            this.btnLogout.BringToFront();

            this.Text = "SuperMarket Management System";
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 600);


            this.tabControlMain.Dock = DockStyle.Fill;







        }
    }
}