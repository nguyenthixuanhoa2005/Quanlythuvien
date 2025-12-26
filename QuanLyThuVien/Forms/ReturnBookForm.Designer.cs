namespace QuanLyThuVien.Forms;

partial class ReturnBookForm
{
    private System.ComponentModel.IContainer components = null;

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
        this.lblTitle = new Label();
        this.groupBoxDangMuon = new GroupBox();
        this.dgvActiveLoans = new DataGridView();
        this.btnTraSach = new Button();
        this.groupBoxQuaHan = new GroupBox();
        this.dgvOverdueLoans = new DataGridView();
        this.btnXemQuaHan = new Button();
        
        this.groupBoxDangMuon.SuspendLayout();
        this.groupBoxQuaHan.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvActiveLoans)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvOverdueLoans)).BeginInit();
        this.SuspendLayout();

        // lblTitle
        this.lblTitle.AutoSize = false;
        this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        this.lblTitle.Location = new Point(350, 10);
        this.lblTitle.Size = new Size(400, 40);
        this.lblTitle.Text = "TRẢ SÁCH";
        this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        this.lblTitle.ForeColor = Color.DarkRed;

        // groupBoxDangMuon
        this.groupBoxDangMuon.Text = "Sách đang mượn";
        this.groupBoxDangMuon.Location = new Point(20, 60);
        this.groupBoxDangMuon.Size = new Size(1050, 280);
        this.groupBoxDangMuon.Font = new Font("Segoe UI", 10F);

        // dgvActiveLoans
        this.dgvActiveLoans.Location = new Point(20, 30);
        this.dgvActiveLoans.Size = new Size(1010, 190);
        this.dgvActiveLoans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvActiveLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvActiveLoans.MultiSelect = false;
        this.dgvActiveLoans.ReadOnly = true;
        this.dgvActiveLoans.AllowUserToAddRows = false;
        this.dgvActiveLoans.AllowUserToDeleteRows = false;
        this.dgvActiveLoans.CellClick += dgvActiveLoans_CellClick;

        // btnTraSach
        this.btnTraSach.Location = new Point(450, 230);
        this.btnTraSach.Size = new Size(150, 40);
        this.btnTraSach.Text = "Trả Sách";
        this.btnTraSach.BackColor = Color.LightGreen;
        this.btnTraSach.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        this.btnTraSach.Cursor = Cursors.Hand;
        this.btnTraSach.Click += btnTraSach_Click;

        // Add controls to groupBoxDangMuon
        this.groupBoxDangMuon.Controls.Add(this.dgvActiveLoans);
        this.groupBoxDangMuon.Controls.Add(this.btnTraSach);

        // groupBoxQuaHan
        this.groupBoxQuaHan.Text = "Sách quá hạn";
        this.groupBoxQuaHan.Location = new Point(20, 360);
        this.groupBoxQuaHan.Size = new Size(1050, 260);
        this.groupBoxQuaHan.Font = new Font("Segoe UI", 10F);

        // dgvOverdueLoans
        this.dgvOverdueLoans.Location = new Point(20, 30);
        this.dgvOverdueLoans.Size = new Size(1010, 170);
        this.dgvOverdueLoans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvOverdueLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvOverdueLoans.MultiSelect = false;
        this.dgvOverdueLoans.ReadOnly = true;
        this.dgvOverdueLoans.AllowUserToAddRows = false;
        this.dgvOverdueLoans.AllowUserToDeleteRows = false;

        // btnXemQuaHan
        this.btnXemQuaHan.Location = new Point(450, 210);
        this.btnXemQuaHan.Size = new Size(150, 40);
        this.btnXemQuaHan.Text = "Xem Quá Hạn";
        this.btnXemQuaHan.BackColor = Color.LightYellow;
        this.btnXemQuaHan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnXemQuaHan.Cursor = Cursors.Hand;
        this.btnXemQuaHan.Click += btnXemQuaHan_Click;

        // Add controls to groupBoxQuaHan
        this.groupBoxQuaHan.Controls.Add(this.dgvOverdueLoans);
        this.groupBoxQuaHan.Controls.Add(this.btnXemQuaHan);

        // ReturnBookForm
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1100, 650);
        this.Controls.Add(this.lblTitle);
        this.Controls.Add(this.groupBoxDangMuon);
        this.Controls.Add(this.groupBoxQuaHan);
        this.Name = "ReturnBookForm";
        this.Text = "Trả Sách";
        this.StartPosition = FormStartPosition.CenterScreen;

        this.groupBoxDangMuon.ResumeLayout(false);
        this.groupBoxQuaHan.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvActiveLoans)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvOverdueLoans)).EndInit();
        this.ResumeLayout(false);
    }

    private Label lblTitle;
    private GroupBox groupBoxDangMuon;
    private DataGridView dgvActiveLoans;
    private Button btnTraSach;
    private GroupBox groupBoxQuaHan;
    private DataGridView dgvOverdueLoans;
    private Button btnXemQuaHan;
}
