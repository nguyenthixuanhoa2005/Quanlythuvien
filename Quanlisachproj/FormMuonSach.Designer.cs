namespace Quanlisachcoban
{
    partial class FormMuonSach
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewPhieuMuon = new System.Windows.Forms.DataGridView();
            this.textBoxMaDocGia = new System.Windows.Forms.TextBox();
            this.labelMaDocGia = new System.Windows.Forms.Label();
            this.labelMaPhieuMuon = new System.Windows.Forms.Label();
            this.textBoxTenSach = new System.Windows.Forms.TextBox();
            this.buttonMuon = new System.Windows.Forms.Button();
            this.buttonThem = new System.Windows.Forms.Button();
            this.labelDanhSachDaMuon = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSoLuongMuon = new System.Windows.Forms.TextBox();
            this.textBoxMaSach = new System.Windows.Forms.TextBox();
            this.labelSoLuongMuon = new System.Windows.Forms.Label();
            this.groupBoxThongTinMuonSach = new System.Windows.Forms.GroupBox();
            this.textBoxMaPhieuMuon = new System.Windows.Forms.TextBox();
            this.labelTenSach = new System.Windows.Forms.Label();
            this.labelMaSach = new System.Windows.Forms.Label();
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.labelDanhSachSach = new System.Windows.Forms.Label();
            this.panelThongTinMuonSach = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.textBoxTimKiem = new System.Windows.Forms.TextBox();
            this.comboBoxTimKiem = new System.Windows.Forms.ComboBox();
            this.buttonXem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhieuMuon)).BeginInit();
            this.groupBoxThongTinMuonSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            this.panelThongTinMuonSach.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewPhieuMuon
            // 
            this.dataGridViewPhieuMuon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPhieuMuon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPhieuMuon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewPhieuMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPhieuMuon.Location = new System.Drawing.Point(519, 478);
            this.dataGridViewPhieuMuon.Name = "dataGridViewPhieuMuon";
            this.dataGridViewPhieuMuon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPhieuMuon.Size = new System.Drawing.Size(559, 279);
            this.dataGridViewPhieuMuon.TabIndex = 137;
            this.dataGridViewPhieuMuon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPhieuMuon_CellClick);
            // 
            // textBoxMaDocGia
            // 
            this.textBoxMaDocGia.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMaDocGia.Location = new System.Drawing.Point(165, 148);
            this.textBoxMaDocGia.Name = "textBoxMaDocGia";
            this.textBoxMaDocGia.Size = new System.Drawing.Size(283, 27);
            this.textBoxMaDocGia.TabIndex = 112;
            // 
            // labelMaDocGia
            // 
            this.labelMaDocGia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMaDocGia.AutoSize = true;
            this.labelMaDocGia.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaDocGia.ForeColor = System.Drawing.Color.Black;
            this.labelMaDocGia.Location = new System.Drawing.Point(20, 150);
            this.labelMaDocGia.Name = "labelMaDocGia";
            this.labelMaDocGia.Size = new System.Drawing.Size(110, 25);
            this.labelMaDocGia.TabIndex = 111;
            this.labelMaDocGia.Text = "Mã độc giả:";
            // 
            // labelMaPhieuMuon
            // 
            this.labelMaPhieuMuon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMaPhieuMuon.AutoSize = true;
            this.labelMaPhieuMuon.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaPhieuMuon.ForeColor = System.Drawing.Color.Black;
            this.labelMaPhieuMuon.Location = new System.Drawing.Point(20, 70);
            this.labelMaPhieuMuon.Name = "labelMaPhieuMuon";
            this.labelMaPhieuMuon.Size = new System.Drawing.Size(150, 25);
            this.labelMaPhieuMuon.TabIndex = 107;
            this.labelMaPhieuMuon.Text = "Mã phiếu mượn:";
            // 
            // textBoxTenSach
            // 
            this.textBoxTenSach.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTenSach.Location = new System.Drawing.Point(133, 307);
            this.textBoxTenSach.Name = "textBoxTenSach";
            this.textBoxTenSach.Size = new System.Drawing.Size(315, 27);
            this.textBoxTenSach.TabIndex = 106;
            // 
            // buttonMuon
            // 
            this.buttonMuon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMuon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(177)))), ((int)(((byte)(219)))));
            this.buttonMuon.FlatAppearance.BorderSize = 0;
            this.buttonMuon.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMuon.ForeColor = System.Drawing.Color.Transparent;
            this.buttonMuon.Location = new System.Drawing.Point(147, 480);
            this.buttonMuon.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMuon.Name = "buttonMuon";
            this.buttonMuon.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonMuon.Size = new System.Drawing.Size(217, 79);
            this.buttonMuon.TabIndex = 104;
            this.buttonMuon.Text = "Thêm thông tin phiếu mượn";
            this.buttonMuon.UseVisualStyleBackColor = false;
            this.buttonMuon.Click += new System.EventHandler(this.buttonMuon_Click);
            // 
            // buttonThem
            // 
            this.buttonThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(177)))), ((int)(((byte)(219)))));
            this.buttonThem.FlatAppearance.BorderSize = 0;
            this.buttonThem.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThem.ForeColor = System.Drawing.Color.Transparent;
            this.buttonThem.Location = new System.Drawing.Point(8, 101);
            this.buttonThem.Margin = new System.Windows.Forms.Padding(2);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonThem.Size = new System.Drawing.Size(188, 48);
            this.buttonThem.TabIndex = 136;
            this.buttonThem.Text = "Thêm";
            this.buttonThem.UseVisualStyleBackColor = false;
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
            // 
            // labelDanhSachDaMuon
            // 
            this.labelDanhSachDaMuon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelDanhSachDaMuon.AutoSize = true;
            this.labelDanhSachDaMuon.BackColor = System.Drawing.SystemColors.Control;
            this.labelDanhSachDaMuon.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDanhSachDaMuon.ForeColor = System.Drawing.Color.Firebrick;
            this.labelDanhSachDaMuon.Location = new System.Drawing.Point(642, 420);
            this.labelDanhSachDaMuon.Name = "labelDanhSachDaMuon";
            this.labelDanhSachDaMuon.Size = new System.Drawing.Size(364, 45);
            this.labelDanhSachDaMuon.TabIndex = 135;
            this.labelDanhSachDaMuon.Text = "Danh Sách Phiếu Mượn";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Firebrick;
            this.label4.Location = new System.Drawing.Point(521, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(261, 45);
            this.label4.TabIndex = 134;
            this.label4.Text = "Danh Sách Sách ";
            // 
            // textBoxSoLuongMuon
            // 
            this.textBoxSoLuongMuon.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSoLuongMuon.Location = new System.Drawing.Point(220, 394);
            this.textBoxSoLuongMuon.Name = "textBoxSoLuongMuon";
            this.textBoxSoLuongMuon.Size = new System.Drawing.Size(228, 27);
            this.textBoxSoLuongMuon.TabIndex = 10;
            // 
            // textBoxMaSach
            // 
            this.textBoxMaSach.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMaSach.Location = new System.Drawing.Point(133, 230);
            this.textBoxMaSach.Name = "textBoxMaSach";
            this.textBoxMaSach.Size = new System.Drawing.Size(315, 27);
            this.textBoxMaSach.TabIndex = 9;
            // 
            // labelSoLuongMuon
            // 
            this.labelSoLuongMuon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSoLuongMuon.AutoSize = true;
            this.labelSoLuongMuon.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSoLuongMuon.ForeColor = System.Drawing.Color.Black;
            this.labelSoLuongMuon.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelSoLuongMuon.Location = new System.Drawing.Point(20, 396);
            this.labelSoLuongMuon.Name = "labelSoLuongMuon";
            this.labelSoLuongMuon.Size = new System.Drawing.Size(194, 25);
            this.labelSoLuongMuon.TabIndex = 4;
            this.labelSoLuongMuon.Text = "Nhập số lượng mượn:";
            // 
            // groupBoxThongTinMuonSach
            // 
            this.groupBoxThongTinMuonSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxThongTinMuonSach.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBoxThongTinMuonSach.Controls.Add(this.textBoxMaDocGia);
            this.groupBoxThongTinMuonSach.Controls.Add(this.labelMaDocGia);
            this.groupBoxThongTinMuonSach.Controls.Add(this.textBoxMaPhieuMuon);
            this.groupBoxThongTinMuonSach.Controls.Add(this.labelMaPhieuMuon);
            this.groupBoxThongTinMuonSach.Controls.Add(this.textBoxTenSach);
            this.groupBoxThongTinMuonSach.Controls.Add(this.labelTenSach);
            this.groupBoxThongTinMuonSach.Controls.Add(this.buttonMuon);
            this.groupBoxThongTinMuonSach.Controls.Add(this.textBoxSoLuongMuon);
            this.groupBoxThongTinMuonSach.Controls.Add(this.textBoxMaSach);
            this.groupBoxThongTinMuonSach.Controls.Add(this.labelSoLuongMuon);
            this.groupBoxThongTinMuonSach.Controls.Add(this.labelMaSach);
            this.groupBoxThongTinMuonSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxThongTinMuonSach.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBoxThongTinMuonSach.Location = new System.Drawing.Point(3, 3);
            this.groupBoxThongTinMuonSach.Name = "groupBoxThongTinMuonSach";
            this.groupBoxThongTinMuonSach.Size = new System.Drawing.Size(496, 584);
            this.groupBoxThongTinMuonSach.TabIndex = 6;
            this.groupBoxThongTinMuonSach.TabStop = false;
            this.groupBoxThongTinMuonSach.Text = "Thông tin Mượn sách";
            // 
            // textBoxMaPhieuMuon
            // 
            this.textBoxMaPhieuMuon.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMaPhieuMuon.Location = new System.Drawing.Point(187, 68);
            this.textBoxMaPhieuMuon.Name = "textBoxMaPhieuMuon";
            this.textBoxMaPhieuMuon.Size = new System.Drawing.Size(261, 27);
            this.textBoxMaPhieuMuon.TabIndex = 108;
            this.textBoxMaPhieuMuon.Text = "`";
            // 
            // labelTenSach
            // 
            this.labelTenSach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTenSach.AutoSize = true;
            this.labelTenSach.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenSach.ForeColor = System.Drawing.Color.Black;
            this.labelTenSach.Location = new System.Drawing.Point(20, 309);
            this.labelTenSach.Name = "labelTenSach";
            this.labelTenSach.Size = new System.Drawing.Size(88, 25);
            this.labelTenSach.TabIndex = 105;
            this.labelTenSach.Text = "Tên sách:";
            // 
            // labelMaSach
            // 
            this.labelMaSach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMaSach.AutoSize = true;
            this.labelMaSach.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaSach.ForeColor = System.Drawing.Color.Black;
            this.labelMaSach.Location = new System.Drawing.Point(20, 232);
            this.labelMaSach.Name = "labelMaSach";
            this.labelMaSach.Size = new System.Drawing.Size(86, 25);
            this.labelMaSach.TabIndex = 0;
            this.labelMaSach.Text = "Mã sách:";
            // 
            // dataGridViewBooks
            // 
            this.dataGridViewBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBooks.Location = new System.Drawing.Point(520, 55);
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBooks.Size = new System.Drawing.Size(775, 343);
            this.dataGridViewBooks.TabIndex = 132;
            this.dataGridViewBooks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBooks_CellClick);
            // 
            // labelDanhSachSach
            // 
            this.labelDanhSachSach.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelDanhSachSach.AutoSize = true;
            this.labelDanhSachSach.BackColor = System.Drawing.SystemColors.Control;
            this.labelDanhSachSach.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDanhSachSach.ForeColor = System.Drawing.Color.Firebrick;
            this.labelDanhSachSach.Location = new System.Drawing.Point(782, -314);
            this.labelDanhSachSach.Name = "labelDanhSachSach";
            this.labelDanhSachSach.Size = new System.Drawing.Size(261, 45);
            this.labelDanhSachSach.TabIndex = 131;
            this.labelDanhSachSach.Text = "Danh Sách Sách ";
            // 
            // panelThongTinMuonSach
            // 
            this.panelThongTinMuonSach.BackColor = System.Drawing.Color.White;
            this.panelThongTinMuonSach.Controls.Add(this.groupBoxThongTinMuonSach);
            this.panelThongTinMuonSach.Location = new System.Drawing.Point(2, 12);
            this.panelThongTinMuonSach.Name = "panelThongTinMuonSach";
            this.panelThongTinMuonSach.Size = new System.Drawing.Size(502, 615);
            this.panelThongTinMuonSach.TabIndex = 133;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 25);
            this.label1.TabIndex = 113;
            this.label1.Text = "Chọn mã độc giả:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.comboBoxUser);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonThem);
            this.panel1.Location = new System.Drawing.Point(1095, 495);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 190);
            this.panel1.TabIndex = 142;
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxUser.FormattingEnabled = true;
            this.comboBoxUser.Location = new System.Drawing.Point(8, 51);
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.Size = new System.Drawing.Size(121, 24);
            this.comboBoxUser.TabIndex = 143;
            this.comboBoxUser.SelectedIndexChanged += new System.EventHandler(this.comboBoxUsers_SelectedIndexChanged);
            // 
            // textBoxTimKiem
            // 
            this.textBoxTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTimKiem.Location = new System.Drawing.Point(970, 16);
            this.textBoxTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTimKiem.Name = "textBoxTimKiem";
            this.textBoxTimKiem.Size = new System.Drawing.Size(160, 27);
            this.textBoxTimKiem.TabIndex = 143;
            this.textBoxTimKiem.Text = "Thanh tìm kiếm";
            this.textBoxTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTimKiem_KeyDown);
            // 
            // comboBoxTimKiem
            // 
            this.comboBoxTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTimKiem.FormattingEnabled = true;
            this.comboBoxTimKiem.Items.AddRange(new object[] {
            "Mã sách",
            "Tên sách"});
            this.comboBoxTimKiem.Location = new System.Drawing.Point(1144, 15);
            this.comboBoxTimKiem.Name = "comboBoxTimKiem";
            this.comboBoxTimKiem.Size = new System.Drawing.Size(151, 28);
            this.comboBoxTimKiem.TabIndex = 144;
            this.comboBoxTimKiem.Text = "Tìm kiếm theo";
            // 
            // buttonXem
            // 
            this.buttonXem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonXem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(177)))), ((int)(((byte)(219)))));
            this.buttonXem.FlatAppearance.BorderSize = 0;
            this.buttonXem.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonXem.ForeColor = System.Drawing.Color.Transparent;
            this.buttonXem.Location = new System.Drawing.Point(1095, 709);
            this.buttonXem.Margin = new System.Windows.Forms.Padding(2);
            this.buttonXem.Name = "buttonXem";
            this.buttonXem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonXem.Size = new System.Drawing.Size(200, 48);
            this.buttonXem.TabIndex = 144;
            this.buttonXem.Text = "Xem chi tiết phiếu";
            this.buttonXem.UseVisualStyleBackColor = false;
            this.buttonXem.Click += new System.EventHandler(this.buttonXem_Click);
            // 
            // FormMuonSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 788);
            this.Controls.Add(this.buttonXem);
            this.Controls.Add(this.comboBoxTimKiem);
            this.Controls.Add(this.textBoxTimKiem);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewPhieuMuon);
            this.Controls.Add(this.labelDanhSachDaMuon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridViewBooks);
            this.Controls.Add(this.labelDanhSachSach);
            this.Controls.Add(this.panelThongTinMuonSach);
            this.Name = "FormMuonSach";
            this.Text = "FormMuonSach";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhieuMuon)).EndInit();
            this.groupBoxThongTinMuonSach.ResumeLayout(false);
            this.groupBoxThongTinMuonSach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            this.panelThongTinMuonSach.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewPhieuMuon;
        private System.Windows.Forms.TextBox textBoxMaDocGia;
        private System.Windows.Forms.Label labelMaDocGia;
        private System.Windows.Forms.Label labelMaPhieuMuon;
        private System.Windows.Forms.TextBox textBoxTenSach;
        private System.Windows.Forms.Button buttonMuon;
        private System.Windows.Forms.Button buttonThem;
        private System.Windows.Forms.Label labelDanhSachDaMuon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSoLuongMuon;
        private System.Windows.Forms.TextBox textBoxMaSach;
        private System.Windows.Forms.Label labelSoLuongMuon;
        private System.Windows.Forms.GroupBox groupBoxThongTinMuonSach;
        private System.Windows.Forms.Label labelMaSach;
        private System.Windows.Forms.DataGridView dataGridViewBooks;
        private System.Windows.Forms.Label labelDanhSachSach;
        private System.Windows.Forms.Panel panelThongTinMuonSach;
        private System.Windows.Forms.Label labelTenSach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxUser;
        private System.Windows.Forms.TextBox textBoxMaPhieuMuon;
        private System.Windows.Forms.TextBox textBoxTimKiem;
        private System.Windows.Forms.ComboBox comboBoxTimKiem;
        private System.Windows.Forms.Button buttonXem;
    }
}