namespace Quanlisachcoban
{
    partial class ThongTinMuonUserControl
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
            this.dataGridViewSachDaMuon = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewSachDaTra = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSachDaMuon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSachDaTra)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSachDaMuon
            // 
            this.dataGridViewSachDaMuon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSachDaMuon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSachDaMuon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewSachDaMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSachDaMuon.Location = new System.Drawing.Point(34, 82);
            this.dataGridViewSachDaMuon.Name = "dataGridViewSachDaMuon";
            this.dataGridViewSachDaMuon.Size = new System.Drawing.Size(1249, 321);
            this.dataGridViewSachDaMuon.TabIndex = 119;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Firebrick;
            this.label4.Location = new System.Drawing.Point(464, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(437, 45);
            this.label4.TabIndex = 118;
            this.label4.Text = "Danh Sách Sách Đang Mượn";
            // 
            // dataGridViewSachDaTra
            // 
            this.dataGridViewSachDaTra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSachDaTra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSachDaTra.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewSachDaTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSachDaTra.Location = new System.Drawing.Point(34, 477);
            this.dataGridViewSachDaTra.Name = "dataGridViewSachDaTra";
            this.dataGridViewSachDaTra.Size = new System.Drawing.Size(1249, 326);
            this.dataGridViewSachDaTra.TabIndex = 121;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(505, 417);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 45);
            this.label1.TabIndex = 120;
            this.label1.Text = "Danh Sách Sách Đã Trả";
            // 
            // ThongTinMuonUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.dataGridViewSachDaTra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewSachDaMuon);
            this.Controls.Add(this.label4);
            this.Name = "ThongTinMuonUserControl";
            this.Size = new System.Drawing.Size(1311, 825);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSachDaMuon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSachDaTra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewSachDaMuon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewSachDaTra;
        private System.Windows.Forms.Label label1;
    }
}
