namespace Quanlisachcoban
{
    partial class TaiKhoanUserControl
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
            this.panelThongTinTaiKhoan = new System.Windows.Forms.Panel();
            this.panelThongTinTK = new System.Windows.Forms.Panel();
            this.buttonXoaTaiKhoan = new System.Windows.Forms.Button();
            this.buttonLuuThongTin = new System.Windows.Forms.Button();
            this.buttonSuaThongTin = new System.Windows.Forms.Button();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxMatKhau = new System.Windows.Forms.TextBox();
            this.labelMatKhau = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTenNguoiDung = new System.Windows.Forms.TextBox();
            this.labelTenNguoiDung = new System.Windows.Forms.Label();
            this.textBoxMaTaiKhoan = new System.Windows.Forms.TextBox();
            this.labelMaTaiKhoan = new System.Windows.Forms.Label();
            this.labelTaiKhoan = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTenDangNhap = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSoDienThoai = new System.Windows.Forms.TextBox();
            this.panelThongTinTaiKhoan.SuspendLayout();
            this.panelThongTinTK.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelThongTinTaiKhoan
            // 
            this.panelThongTinTaiKhoan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelThongTinTaiKhoan.BackColor = System.Drawing.SystemColors.Control;
            this.panelThongTinTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelThongTinTaiKhoan.Controls.Add(this.panelThongTinTK);
            this.panelThongTinTaiKhoan.Controls.Add(this.labelTaiKhoan);
            this.panelThongTinTaiKhoan.Location = new System.Drawing.Point(79, 69);
            this.panelThongTinTaiKhoan.Name = "panelThongTinTaiKhoan";
            this.panelThongTinTaiKhoan.Size = new System.Drawing.Size(1078, 518);
            this.panelThongTinTaiKhoan.TabIndex = 100;
            // 
            // panelThongTinTK
            // 
            this.panelThongTinTK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelThongTinTK.Controls.Add(this.textBoxSoDienThoai);
            this.panelThongTinTK.Controls.Add(this.label3);
            this.panelThongTinTK.Controls.Add(this.textBoxTenDangNhap);
            this.panelThongTinTK.Controls.Add(this.label2);
            this.panelThongTinTK.Controls.Add(this.buttonXoaTaiKhoan);
            this.panelThongTinTK.Controls.Add(this.buttonLuuThongTin);
            this.panelThongTinTK.Controls.Add(this.buttonSuaThongTin);
            this.panelThongTinTK.Controls.Add(this.textBoxEmail);
            this.panelThongTinTK.Controls.Add(this.labelEmail);
            this.panelThongTinTK.Controls.Add(this.textBoxMatKhau);
            this.panelThongTinTK.Controls.Add(this.labelMatKhau);
            this.panelThongTinTK.Controls.Add(this.label1);
            this.panelThongTinTK.Controls.Add(this.textBoxTenNguoiDung);
            this.panelThongTinTK.Controls.Add(this.labelTenNguoiDung);
            this.panelThongTinTK.Controls.Add(this.textBoxMaTaiKhoan);
            this.panelThongTinTK.Controls.Add(this.labelMaTaiKhoan);
            this.panelThongTinTK.Location = new System.Drawing.Point(58, 74);
            this.panelThongTinTK.Name = "panelThongTinTK";
            this.panelThongTinTK.Size = new System.Drawing.Size(964, 390);
            this.panelThongTinTK.TabIndex = 99;
            // 
            // buttonXoaTaiKhoan
            // 
            this.buttonXoaTaiKhoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonXoaTaiKhoan.BackColor = System.Drawing.Color.Tomato;
            this.buttonXoaTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonXoaTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.buttonXoaTaiKhoan.Location = new System.Drawing.Point(39, 303);
            this.buttonXoaTaiKhoan.Name = "buttonXoaTaiKhoan";
            this.buttonXoaTaiKhoan.Size = new System.Drawing.Size(157, 58);
            this.buttonXoaTaiKhoan.TabIndex = 56;
            this.buttonXoaTaiKhoan.Text = "Khóa tài khoản";
            this.buttonXoaTaiKhoan.UseVisualStyleBackColor = false;
            this.buttonXoaTaiKhoan.Click += new System.EventHandler(this.buttonXoaTaiKhoan_Click);
            // 
            // buttonLuuThongTin
            // 
            this.buttonLuuThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLuuThongTin.BackColor = System.Drawing.Color.White;
            this.buttonLuuThongTin.Enabled = false;
            this.buttonLuuThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLuuThongTin.ForeColor = System.Drawing.Color.Black;
            this.buttonLuuThongTin.Location = new System.Drawing.Point(833, 303);
            this.buttonLuuThongTin.Name = "buttonLuuThongTin";
            this.buttonLuuThongTin.Size = new System.Drawing.Size(97, 58);
            this.buttonLuuThongTin.TabIndex = 55;
            this.buttonLuuThongTin.Text = "Lưu";
            this.buttonLuuThongTin.UseVisualStyleBackColor = false;
            this.buttonLuuThongTin.Click += new System.EventHandler(this.buttonLuuThongTin_Click);
            // 
            // buttonSuaThongTin
            // 
            this.buttonSuaThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSuaThongTin.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonSuaThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSuaThongTin.ForeColor = System.Drawing.Color.White;
            this.buttonSuaThongTin.Location = new System.Drawing.Point(648, 303);
            this.buttonSuaThongTin.Name = "buttonSuaThongTin";
            this.buttonSuaThongTin.Size = new System.Drawing.Size(157, 58);
            this.buttonSuaThongTin.TabIndex = 54;
            this.buttonSuaThongTin.Text = "Sửa thông tin";
            this.buttonSuaThongTin.UseVisualStyleBackColor = false;
            this.buttonSuaThongTin.Click += new System.EventHandler(this.buttonSuaThongTin_Click);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxEmail.Location = new System.Drawing.Point(171, 209);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.ReadOnly = true;
            this.textBoxEmail.Size = new System.Drawing.Size(305, 26);
            this.textBoxEmail.TabIndex = 49;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelEmail.Location = new System.Drawing.Point(42, 215);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(52, 20);
            this.labelEmail.TabIndex = 48;
            this.labelEmail.Text = "Email:";
            // 
            // textBoxMatKhau
            // 
            this.textBoxMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxMatKhau.Location = new System.Drawing.Point(689, 135);
            this.textBoxMatKhau.Name = "textBoxMatKhau";
            this.textBoxMatKhau.ReadOnly = true;
            this.textBoxMatKhau.Size = new System.Drawing.Size(190, 26);
            this.textBoxMatKhau.TabIndex = 43;
            // 
            // labelMatKhau
            // 
            this.labelMatKhau.AutoSize = true;
            this.labelMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelMatKhau.Location = new System.Drawing.Point(556, 135);
            this.labelMatKhau.Name = "labelMatKhau";
            this.labelMatKhau.Size = new System.Drawing.Size(79, 20);
            this.labelMatKhau.TabIndex = 42;
            this.labelMatKhau.Text = "Mật khẩu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(227, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 36;
            // 
            // textBoxTenNguoiDung
            // 
            this.textBoxTenNguoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxTenNguoiDung.Location = new System.Drawing.Point(689, 50);
            this.textBoxTenNguoiDung.Name = "textBoxTenNguoiDung";
            this.textBoxTenNguoiDung.ReadOnly = true;
            this.textBoxTenNguoiDung.Size = new System.Drawing.Size(190, 26);
            this.textBoxTenNguoiDung.TabIndex = 3;
            // 
            // labelTenNguoiDung
            // 
            this.labelTenNguoiDung.AutoSize = true;
            this.labelTenNguoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelTenNguoiDung.Location = new System.Drawing.Point(556, 53);
            this.labelTenNguoiDung.Name = "labelTenNguoiDung";
            this.labelTenNguoiDung.Size = new System.Drawing.Size(127, 20);
            this.labelTenNguoiDung.TabIndex = 2;
            this.labelTenNguoiDung.Text = "Tên người dùng: ";
            // 
            // textBoxMaTaiKhoan
            // 
            this.textBoxMaTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxMaTaiKhoan.Location = new System.Drawing.Point(171, 50);
            this.textBoxMaTaiKhoan.Name = "textBoxMaTaiKhoan";
            this.textBoxMaTaiKhoan.ReadOnly = true;
            this.textBoxMaTaiKhoan.Size = new System.Drawing.Size(311, 26);
            this.textBoxMaTaiKhoan.TabIndex = 1;
            // 
            // labelMaTaiKhoan
            // 
            this.labelMaTaiKhoan.AutoSize = true;
            this.labelMaTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaTaiKhoan.Location = new System.Drawing.Point(42, 53);
            this.labelMaTaiKhoan.Name = "labelMaTaiKhoan";
            this.labelMaTaiKhoan.Size = new System.Drawing.Size(108, 20);
            this.labelMaTaiKhoan.TabIndex = 0;
            this.labelMaTaiKhoan.Text = "Mã tài khoản: ";
            // 
            // labelTaiKhoan
            // 
            this.labelTaiKhoan.BackColor = System.Drawing.SystemColors.Control;
            this.labelTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.labelTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTaiKhoan.ForeColor = System.Drawing.Color.DarkRed;
            this.labelTaiKhoan.Location = new System.Drawing.Point(52, 21);
            this.labelTaiKhoan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTaiKhoan.Name = "labelTaiKhoan";
            this.labelTaiKhoan.Size = new System.Drawing.Size(314, 42);
            this.labelTaiKhoan.TabIndex = 98;
            this.labelTaiKhoan.Text = "Thông tin tài khoản";
            this.labelTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(42, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 57;
            this.label2.Text = "Tên đăng nhập:";
            // 
            // textBoxTenDangNhap
            // 
            this.textBoxTenDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxTenDangNhap.Location = new System.Drawing.Point(171, 135);
            this.textBoxTenDangNhap.Name = "textBoxTenDangNhap";
            this.textBoxTenDangNhap.ReadOnly = true;
            this.textBoxTenDangNhap.Size = new System.Drawing.Size(305, 26);
            this.textBoxTenDangNhap.TabIndex = 58;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(556, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 59;
            this.label3.Text = "Số điện thoại:";
            // 
            // textBoxSoDienThoai
            // 
            this.textBoxSoDienThoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxSoDienThoai.Location = new System.Drawing.Point(689, 206);
            this.textBoxSoDienThoai.Name = "textBoxSoDienThoai";
            this.textBoxSoDienThoai.ReadOnly = true;
            this.textBoxSoDienThoai.Size = new System.Drawing.Size(190, 26);
            this.textBoxSoDienThoai.TabIndex = 60;
            // 
            // TaiKhoanUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelThongTinTaiKhoan);
            this.Name = "TaiKhoanUserControl";
            this.Size = new System.Drawing.Size(1227, 657);
            this.panelThongTinTaiKhoan.ResumeLayout(false);
            this.panelThongTinTK.ResumeLayout(false);
            this.panelThongTinTK.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelThongTinTaiKhoan;
        private System.Windows.Forms.Panel panelThongTinTK;
        private System.Windows.Forms.Button buttonXoaTaiKhoan;
        private System.Windows.Forms.Button buttonLuuThongTin;
        private System.Windows.Forms.Button buttonSuaThongTin;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxMatKhau;
        private System.Windows.Forms.Label labelMatKhau;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMaTaiKhoan;
        private System.Windows.Forms.Label labelMaTaiKhoan;
        private System.Windows.Forms.Label labelTaiKhoan;
        private System.Windows.Forms.TextBox textBoxTenNguoiDung;
        private System.Windows.Forms.Label labelTenNguoiDung;
        private System.Windows.Forms.TextBox textBoxSoDienThoai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTenDangNhap;
        private System.Windows.Forms.Label label2;
    }
}
