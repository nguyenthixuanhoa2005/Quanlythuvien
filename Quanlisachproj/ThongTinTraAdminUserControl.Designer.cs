namespace Quanlisachcoban
{
    partial class ThongTinTraAdminUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioOverdue = new System.Windows.Forms.RadioButton();
            this.radioReturned = new System.Windows.Forms.RadioButton();
            this.radioBorrowing = new System.Windows.Forms.RadioButton();
            this.textBoxSoLuongMuon = new System.Windows.Forms.TextBox();
            this.textBoxMaSach = new System.Windows.Forms.TextBox();
            this.textBoxMaPhieuMuon = new System.Windows.Forms.TextBox();
            this.labelTrangThai = new System.Windows.Forms.Label();
            this.labelSoLuong = new System.Windows.Forms.Label();
            this.labelMaSach = new System.Windows.Forms.Label();
            this.labelMaPhieuMuon = new System.Windows.Forms.Label();
            this.labelTenSach = new System.Windows.Forms.Label();
            this.textBoxTenSach = new System.Windows.Forms.TextBox();
            this.labelNgayMuon = new System.Windows.Forms.Label();
            this.dateTimePickerNgayMuon = new System.Windows.Forms.DateTimePicker();
            this.labelHanTra = new System.Windows.Forms.Label();
            this.dateTimePickerHanTra = new System.Windows.Forms.DateTimePicker();
            this.btnTraSach = new System.Windows.Forms.Button();
            this.panelThongTin = new System.Windows.Forms.Panel();
            this.groupBoxThongTin = new System.Windows.Forms.GroupBox();
            this.dataGridViewTraSach = new System.Windows.Forms.DataGridView();
            this.panelThongTin.SuspendLayout();
            this.groupBoxThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTraSach)).BeginInit();
            this.SuspendLayout();
            // 
            // radioOverdue
            // 
            this.radioOverdue.AutoSize = true;
            this.radioOverdue.Location = new System.Drawing.Point(868, 199);
            this.radioOverdue.Name = "radioOverdue";
            this.radioOverdue.Size = new System.Drawing.Size(117, 34);
            this.radioOverdue.TabIndex = 0;
            this.radioOverdue.Text = "Quá hạn";
            // 
            // radioReturned
            // 
            this.radioReturned.AutoSize = true;
            this.radioReturned.Location = new System.Drawing.Point(1023, 199);
            this.radioReturned.Name = "radioReturned";
            this.radioReturned.Size = new System.Drawing.Size(95, 34);
            this.radioReturned.TabIndex = 1;
            this.radioReturned.Text = "Đã trả";
            // 
            // radioBorrowing
            // 
            this.radioBorrowing.AutoSize = true;
            this.radioBorrowing.Location = new System.Drawing.Point(699, 199);
            this.radioBorrowing.Name = "radioBorrowing";
            this.radioBorrowing.Size = new System.Drawing.Size(154, 34);
            this.radioBorrowing.TabIndex = 2;
            this.radioBorrowing.Text = "Đang mượn";
            // 
            // textBoxSoLuongMuon
            // 
            this.textBoxSoLuongMuon.Location = new System.Drawing.Point(710, 51);
            this.textBoxSoLuongMuon.Name = "textBoxSoLuongMuon";
            this.textBoxSoLuongMuon.Size = new System.Drawing.Size(250, 36);
            this.textBoxSoLuongMuon.TabIndex = 3;
            // 
            // textBoxMaSach
            // 
            this.textBoxMaSach.Location = new System.Drawing.Point(177, 135);
            this.textBoxMaSach.Name = "textBoxMaSach";
            this.textBoxMaSach.Size = new System.Drawing.Size(285, 36);
            this.textBoxMaSach.TabIndex = 4;
            // 
            // textBoxMaPhieuMuon
            // 
            this.textBoxMaPhieuMuon.Location = new System.Drawing.Point(212, 57);
            this.textBoxMaPhieuMuon.Name = "textBoxMaPhieuMuon";
            this.textBoxMaPhieuMuon.Size = new System.Drawing.Size(250, 36);
            this.textBoxMaPhieuMuon.TabIndex = 5;
            // 
            // labelTrangThai
            // 
            this.labelTrangThai.Location = new System.Drawing.Point(508, 201);
            this.labelTrangThai.Name = "labelTrangThai";
            this.labelTrangThai.Size = new System.Drawing.Size(149, 41);
            this.labelTrangThai.TabIndex = 6;
            this.labelTrangThai.Text = "Trạng Thái:";
            // 
            // labelSoLuong
            // 
            this.labelSoLuong.Location = new System.Drawing.Point(508, 54);
            this.labelSoLuong.Name = "labelSoLuong";
            this.labelSoLuong.Size = new System.Drawing.Size(200, 43);
            this.labelSoLuong.TabIndex = 7;
            this.labelSoLuong.Text = "Số Lượng Mượn:";
            // 
            // labelMaSach
            // 
            this.labelMaSach.Location = new System.Drawing.Point(6, 135);
            this.labelMaSach.Name = "labelMaSach";
            this.labelMaSach.Size = new System.Drawing.Size(182, 43);
            this.labelMaSach.TabIndex = 8;
            this.labelMaSach.Text = "Mã Sách:";
            // 
            // labelMaPhieuMuon
            // 
            this.labelMaPhieuMuon.Location = new System.Drawing.Point(6, 60);
            this.labelMaPhieuMuon.Name = "labelMaPhieuMuon";
            this.labelMaPhieuMuon.Size = new System.Drawing.Size(238, 43);
            this.labelMaPhieuMuon.TabIndex = 9;
            this.labelMaPhieuMuon.Text = "Mã Phiếu Mượn:";
            // 
            // labelTenSach
            // 
            this.labelTenSach.Location = new System.Drawing.Point(6, 201);
            this.labelTenSach.Name = "labelTenSach";
            this.labelTenSach.Size = new System.Drawing.Size(119, 36);
            this.labelTenSach.TabIndex = 10;
            this.labelTenSach.Text = "Tên Sách:";
            // 
            // textBoxTenSach
            // 
            this.textBoxTenSach.Location = new System.Drawing.Point(131, 197);
            this.textBoxTenSach.Name = "textBoxTenSach";
            this.textBoxTenSach.Size = new System.Drawing.Size(331, 36);
            this.textBoxTenSach.TabIndex = 11;
            // 
            // labelNgayMuon
            // 
            this.labelNgayMuon.Location = new System.Drawing.Point(508, 138);
            this.labelNgayMuon.Name = "labelNgayMuon";
            this.labelNgayMuon.Size = new System.Drawing.Size(149, 36);
            this.labelNgayMuon.TabIndex = 12;
            this.labelNgayMuon.Text = "Ngày Mượn:";
            // 
            // dateTimePickerNgayMuon
            // 
            this.dateTimePickerNgayMuon.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNgayMuon.Location = new System.Drawing.Point(663, 135);
            this.dateTimePickerNgayMuon.Name = "dateTimePickerNgayMuon";
            this.dateTimePickerNgayMuon.Size = new System.Drawing.Size(160, 36);
            this.dateTimePickerNgayMuon.TabIndex = 13;
            // 
            // labelHanTra
            // 
            this.labelHanTra.Location = new System.Drawing.Point(845, 135);
            this.labelHanTra.Name = "labelHanTra";
            this.labelHanTra.Size = new System.Drawing.Size(115, 34);
            this.labelHanTra.TabIndex = 14;
            this.labelHanTra.Text = "Hạn Trả:";
            // 
            // dateTimePickerHanTra
            // 
            this.dateTimePickerHanTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerHanTra.Location = new System.Drawing.Point(966, 135);
            this.dateTimePickerHanTra.Name = "dateTimePickerHanTra";
            this.dateTimePickerHanTra.Size = new System.Drawing.Size(152, 36);
            this.dateTimePickerHanTra.TabIndex = 15;
            // 
            // btnTraSach
            // 
            this.btnTraSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.btnTraSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTraSach.FlatAppearance.BorderSize = 0;
            this.btnTraSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraSach.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnTraSach.ForeColor = System.Drawing.Color.White;
            this.btnTraSach.Location = new System.Drawing.Point(490, 316);
            this.btnTraSach.Name = "btnTraSach";
            this.btnTraSach.Size = new System.Drawing.Size(195, 43);
            this.btnTraSach.TabIndex = 0;
            this.btnTraSach.Text = " TRẢ SÁCH";
            this.btnTraSach.UseVisualStyleBackColor = false;
            this.btnTraSach.Click += new System.EventHandler(this.btnTraSach_Click);
            // 
            // panelThongTin
            // 
            this.panelThongTin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelThongTin.Controls.Add(this.btnTraSach);
            this.panelThongTin.Controls.Add(this.groupBoxThongTin);
            this.panelThongTin.Location = new System.Drawing.Point(23, 27);
            this.panelThongTin.Name = "panelThongTin";
            this.panelThongTin.Size = new System.Drawing.Size(1180, 374);
            this.panelThongTin.TabIndex = 2;
            // 
            // groupBoxThongTin
            // 
            this.groupBoxThongTin.BackColor = System.Drawing.Color.LightBlue;
            this.groupBoxThongTin.Controls.Add(this.radioOverdue);
            this.groupBoxThongTin.Controls.Add(this.radioReturned);
            this.groupBoxThongTin.Controls.Add(this.radioBorrowing);
            this.groupBoxThongTin.Controls.Add(this.textBoxSoLuongMuon);
            this.groupBoxThongTin.Controls.Add(this.textBoxMaSach);
            this.groupBoxThongTin.Controls.Add(this.textBoxMaPhieuMuon);
            this.groupBoxThongTin.Controls.Add(this.labelTrangThai);
            this.groupBoxThongTin.Controls.Add(this.labelSoLuong);
            this.groupBoxThongTin.Controls.Add(this.labelMaSach);
            this.groupBoxThongTin.Controls.Add(this.labelMaPhieuMuon);
            this.groupBoxThongTin.Controls.Add(this.labelTenSach);
            this.groupBoxThongTin.Controls.Add(this.textBoxTenSach);
            this.groupBoxThongTin.Controls.Add(this.labelNgayMuon);
            this.groupBoxThongTin.Controls.Add(this.dateTimePickerNgayMuon);
            this.groupBoxThongTin.Controls.Add(this.labelHanTra);
            this.groupBoxThongTin.Controls.Add(this.dateTimePickerHanTra);
            this.groupBoxThongTin.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.groupBoxThongTin.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBoxThongTin.Location = new System.Drawing.Point(20, 10);
            this.groupBoxThongTin.Name = "groupBoxThongTin";
            this.groupBoxThongTin.Size = new System.Drawing.Size(1140, 287);
            this.groupBoxThongTin.TabIndex = 1;
            this.groupBoxThongTin.TabStop = false;
            this.groupBoxThongTin.Text = "Thông tin Trả sách";
            // 
            // dataGridViewTraSach
            // 
            this.dataGridViewTraSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTraSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTraSach.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewTraSach.ColumnHeadersHeight = 29;
            this.dataGridViewTraSach.Location = new System.Drawing.Point(23, 407);
            this.dataGridViewTraSach.Name = "dataGridViewTraSach";
            this.dataGridViewTraSach.RowHeadersWidth = 51;
            this.dataGridViewTraSach.Size = new System.Drawing.Size(1180, 209);
            this.dataGridViewTraSach.TabIndex = 3;
            this.dataGridViewTraSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTraSach_CellClick);
            // 
            // ThongTinTraAdminUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelThongTin);
            this.Controls.Add(this.dataGridViewTraSach);
            this.Name = "ThongTinTraAdminUserControl";
            this.Size = new System.Drawing.Size(1227, 657);
            this.panelThongTin.ResumeLayout(false);
            this.groupBoxThongTin.ResumeLayout(false);
            this.groupBoxThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTraSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioOverdue;
        private System.Windows.Forms.RadioButton radioReturned;
        private System.Windows.Forms.RadioButton radioBorrowing;
        private System.Windows.Forms.TextBox textBoxSoLuongMuon;
        private System.Windows.Forms.TextBox textBoxMaSach;
        private System.Windows.Forms.TextBox textBoxMaPhieuMuon;
        private System.Windows.Forms.Label labelTrangThai;
        private System.Windows.Forms.Label labelSoLuong;
        private System.Windows.Forms.Label labelMaSach;
        private System.Windows.Forms.Label labelMaPhieuMuon;
        private System.Windows.Forms.Label labelTenSach;
        private System.Windows.Forms.TextBox textBoxTenSach;
        private System.Windows.Forms.Label labelNgayMuon;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayMuon;
        private System.Windows.Forms.Label labelHanTra;
        private System.Windows.Forms.DateTimePicker dateTimePickerHanTra;
        private System.Windows.Forms.Button btnTraSach;
        private System.Windows.Forms.Panel panelThongTin;
        private System.Windows.Forms.GroupBox groupBoxThongTin;
        private System.Windows.Forms.DataGridView dataGridViewTraSach;
    }
}
