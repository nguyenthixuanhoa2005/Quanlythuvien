namespace Quanlisachcoban
{
    partial class QuenMatKhau
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
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.buttonLayMK = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonReload = new System.Windows.Forms.Button();
            this.textBoxMaCaptcha = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelQuenMK = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.Location = new System.Drawing.Point(170, 156);
            this.textBoxEmail.MinimumSize = new System.Drawing.Size(4, 40);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(486, 32);
            this.textBoxEmail.TabIndex = 20;
            // 
            // buttonLayMK
            // 
            this.buttonLayMK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(213)))), ((int)(((byte)(245)))));
            this.buttonLayMK.FlatAppearance.BorderSize = 0;
            this.buttonLayMK.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLayMK.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonLayMK.Location = new System.Drawing.Point(285, 318);
            this.buttonLayMK.Name = "buttonLayMK";
            this.buttonLayMK.Size = new System.Drawing.Size(229, 42);
            this.buttonLayMK.TabIndex = 18;
            this.buttonLayMK.Text = "Lấy lại mật khẩu";
            this.buttonLayMK.UseVisualStyleBackColor = false;
            this.buttonLayMK.Click += new System.EventHandler(this.buttonLayMK_Click);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(429, 231);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(66, 19);
            this.textBox2.TabIndex = 17;
            this.textBox2.Text = "CAPTCHA";
            // 
            // buttonReload
            // 
            this.buttonReload.FlatAppearance.BorderSize = 0;
            this.buttonReload.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.buttonReload.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.buttonReload.Location = new System.Drawing.Point(532, 218);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(57, 42);
            this.buttonReload.TabIndex = 16;
            this.buttonReload.Text = "Reload";
            this.buttonReload.UseVisualStyleBackColor = true;
            // 
            // textBoxMaCaptcha
            // 
            this.textBoxMaCaptcha.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMaCaptcha.Location = new System.Drawing.Point(170, 218);
            this.textBoxMaCaptcha.MinimumSize = new System.Drawing.Size(4, 40);
            this.textBoxMaCaptcha.Name = "textBoxMaCaptcha";
            this.textBoxMaCaptcha.Size = new System.Drawing.Size(175, 32);
            this.textBoxMaCaptcha.TabIndex = 14;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(165, 101);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(513, 25);
            this.labelEmail.TabIndex = 13;
            this.labelEmail.Text = "Nhập Email của bạn để nhận mã xác nhận lấy lại mật khẩu. ";
            // 
            // labelQuenMK
            // 
            this.labelQuenMK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelQuenMK.AutoSize = true;
            this.labelQuenMK.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuenMK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.labelQuenMK.Location = new System.Drawing.Point(277, 26);
            this.labelQuenMK.Name = "labelQuenMK";
            this.labelQuenMK.Size = new System.Drawing.Size(248, 45);
            this.labelQuenMK.TabIndex = 12;
            this.labelQuenMK.Text = "Quên mật khẩu";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.Location = new System.Drawing.Point(417, 218);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 42);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // QuenMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 392);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.buttonLayMK);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonReload);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxMaCaptcha);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelQuenMK);
            this.Name = "QuenMatKhau";
            this.Text = "Quên Mật Khẩu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Button buttonLayMK;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonReload;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxMaCaptcha;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelQuenMK;
    }
}