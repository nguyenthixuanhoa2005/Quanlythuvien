namespace QuanLyThuVien;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.lblTitle = new Label();
        this.btnQuanLySach = new Button();
        this.btnQuanLyDocGia = new Button();
        this.btnMuonSach = new Button();
        this.btnTraSach = new Button();
        this.btnThongKe = new Button();
        this.panelMenu = new Panel();
        
        this.SuspendLayout();
        
        // lblTitle
        this.lblTitle.AutoSize = false;
        this.lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
        this.lblTitle.Location = new Point(300, 30);
        this.lblTitle.Size = new Size(600, 60);
        this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ THƯ VIỆN";
        this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        this.lblTitle.ForeColor = Color.DarkBlue;
        
        // panelMenu
        this.panelMenu.Location = new Point(300, 120);
        this.panelMenu.Size = new Size(600, 500);
        this.panelMenu.BorderStyle = BorderStyle.FixedSingle;
        
        // btnQuanLySach
        this.btnQuanLySach.Location = new Point(150, 50);
        this.btnQuanLySach.Size = new Size(300, 60);
        this.btnQuanLySach.Text = "📚 Quản Lý Sách";
        this.btnQuanLySach.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        this.btnQuanLySach.BackColor = Color.LightBlue;
        this.btnQuanLySach.FlatStyle = FlatStyle.Flat;
        this.btnQuanLySach.Cursor = Cursors.Hand;
        this.btnQuanLySach.Click += btnQuanLySach_Click;
        
        // btnQuanLyDocGia
        this.btnQuanLyDocGia.Location = new Point(150, 130);
        this.btnQuanLyDocGia.Size = new Size(300, 60);
        this.btnQuanLyDocGia.Text = "👥 Quản Lý Độc Giả";
        this.btnQuanLyDocGia.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        this.btnQuanLyDocGia.BackColor = Color.LightGreen;
        this.btnQuanLyDocGia.FlatStyle = FlatStyle.Flat;
        this.btnQuanLyDocGia.Cursor = Cursors.Hand;
        this.btnQuanLyDocGia.Click += btnQuanLyDocGia_Click;
        
        // btnMuonSach
        this.btnMuonSach.Location = new Point(150, 210);
        this.btnMuonSach.Size = new Size(300, 60);
        this.btnMuonSach.Text = "📖 Mượn Sách";
        this.btnMuonSach.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        this.btnMuonSach.BackColor = Color.LightYellow;
        this.btnMuonSach.FlatStyle = FlatStyle.Flat;
        this.btnMuonSach.Cursor = Cursors.Hand;
        this.btnMuonSach.Click += btnMuonSach_Click;
        
        // btnTraSach
        this.btnTraSach.Location = new Point(150, 290);
        this.btnTraSach.Size = new Size(300, 60);
        this.btnTraSach.Text = "✅ Trả Sách";
        this.btnTraSach.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        this.btnTraSach.BackColor = Color.LightCoral;
        this.btnTraSach.FlatStyle = FlatStyle.Flat;
        this.btnTraSach.Cursor = Cursors.Hand;
        this.btnTraSach.Click += btnTraSach_Click;
        
        // btnThongKe
        this.btnThongKe.Location = new Point(150, 370);
        this.btnThongKe.Size = new Size(300, 60);
        this.btnThongKe.Text = "📊 Thống Kê";
        this.btnThongKe.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        this.btnThongKe.BackColor = Color.LightGray;
        this.btnThongKe.FlatStyle = FlatStyle.Flat;
        this.btnThongKe.Cursor = Cursors.Hand;
        this.btnThongKe.Click += btnThongKe_Click;
        
        // Add controls to panel
        this.panelMenu.Controls.Add(this.btnQuanLySach);
        this.panelMenu.Controls.Add(this.btnQuanLyDocGia);
        this.panelMenu.Controls.Add(this.btnMuonSach);
        this.panelMenu.Controls.Add(this.btnTraSach);
        this.panelMenu.Controls.Add(this.btnThongKe);
        
        // Form1
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1200, 700);
        this.Controls.Add(this.lblTitle);
        this.Controls.Add(this.panelMenu);
        this.Name = "Form1";
        this.Text = "Quản Lý Thư Viện";
        this.StartPosition = FormStartPosition.CenterScreen;
        
        this.ResumeLayout(false);
    }

    private Label lblTitle;
    private Button btnQuanLySach;
    private Button btnQuanLyDocGia;
    private Button btnMuonSach;
    private Button btnTraSach;
    private Button btnThongKe;
    private Panel panelMenu;

    #endregion
}
