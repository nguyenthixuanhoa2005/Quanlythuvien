namespace Quanlisachcoban
{
    partial class FormXemChiTietPhieu
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
            this.dataGridViewDanhSach = new System.Windows.Forms.DataGridView();
            this.labelDanhSachDaMuon = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDanhSach
            // 
            this.dataGridViewDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDanhSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDanhSach.Location = new System.Drawing.Point(12, 78);
            this.dataGridViewDanhSach.Name = "dataGridViewDanhSach";
            this.dataGridViewDanhSach.ReadOnly = true;
            this.dataGridViewDanhSach.Size = new System.Drawing.Size(764, 341);
            this.dataGridViewDanhSach.TabIndex = 107;
            // 
            // labelDanhSachDaMuon
            // 
            this.labelDanhSachDaMuon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelDanhSachDaMuon.AutoSize = true;
            this.labelDanhSachDaMuon.BackColor = System.Drawing.Color.Teal;
            this.labelDanhSachDaMuon.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDanhSachDaMuon.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelDanhSachDaMuon.Location = new System.Drawing.Point(171, 21);
            this.labelDanhSachDaMuon.Name = "labelDanhSachDaMuon";
            this.labelDanhSachDaMuon.Size = new System.Drawing.Size(468, 45);
            this.labelDanhSachDaMuon.TabIndex = 136;
            this.labelDanhSachDaMuon.Text = "Danh sách chi tiết phiếu mượn";
            // 
            // FormXemChiTietPhieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 431);
            this.Controls.Add(this.labelDanhSachDaMuon);
            this.Controls.Add(this.dataGridViewDanhSach);
            this.Name = "FormXemChiTietPhieu";
            this.Text = "FormXemChiTietPhieu";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDanhSach;
        private System.Windows.Forms.Label labelDanhSachDaMuon;
    }
}