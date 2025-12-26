namespace QuanLyThuVien.Forms;

partial class StatisticsForm
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
        this.panelStats = new Panel();
        this.lblTongSach = new Label();
        this.lblTongBanSao = new Label();
        this.lblSachConLai = new Label();
        this.lblTongDocGia = new Label();
        this.lblDangMuon = new Label();
        this.lblQuaHan = new Label();
        this.lblDaTra = new Label();
        this.btnLamMoi = new Button();
        
        this.panelStats.SuspendLayout();
        this.SuspendLayout();

        // lblTitle
        this.lblTitle.AutoSize = false;
        this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        this.lblTitle.Location = new Point(200, 10);
        this.lblTitle.Size = new Size(400, 40);
        this.lblTitle.Text = "THỐNG KÊ THƯ VIỆN";
        this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        this.lblTitle.ForeColor = Color.DarkBlue;

        // panelStats
        this.panelStats.Location = new Point(100, 70);
        this.panelStats.Size = new Size(600, 450);
        this.panelStats.BorderStyle = BorderStyle.FixedSingle;

        // lblTongSach
        this.lblTongSach.Location = new Point(50, 30);
        this.lblTongSach.Size = new Size(500, 50);
        this.lblTongSach.Text = "Tổng số sách: 0";
        this.lblTongSach.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        this.lblTongSach.ForeColor = Color.DarkBlue;
        this.lblTongSach.BackColor = Color.LightBlue;
        this.lblTongSach.TextAlign = ContentAlignment.MiddleLeft;
        this.lblTongSach.Padding = new Padding(20, 0, 0, 0);

        // lblTongBanSao
        this.lblTongBanSao.Location = new Point(50, 90);
        this.lblTongBanSao.Size = new Size(500, 50);
        this.lblTongBanSao.Text = "Tổng bản sao: 0";
        this.lblTongBanSao.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        this.lblTongBanSao.ForeColor = Color.DarkGreen;
        this.lblTongBanSao.BackColor = Color.LightGreen;
        this.lblTongBanSao.TextAlign = ContentAlignment.MiddleLeft;
        this.lblTongBanSao.Padding = new Padding(20, 0, 0, 0);

        // lblSachConLai
        this.lblSachConLai.Location = new Point(50, 150);
        this.lblSachConLai.Size = new Size(500, 50);
        this.lblSachConLai.Text = "Sách còn lại: 0";
        this.lblSachConLai.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        this.lblSachConLai.ForeColor = Color.DarkCyan;
        this.lblSachConLai.BackColor = Color.LightCyan;
        this.lblSachConLai.TextAlign = ContentAlignment.MiddleLeft;
        this.lblSachConLai.Padding = new Padding(20, 0, 0, 0);

        // lblTongDocGia
        this.lblTongDocGia.Location = new Point(50, 210);
        this.lblTongDocGia.Size = new Size(500, 50);
        this.lblTongDocGia.Text = "Tổng độc giả: 0";
        this.lblTongDocGia.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        this.lblTongDocGia.ForeColor = Color.DarkOrange;
        this.lblTongDocGia.BackColor = Color.LightYellow;
        this.lblTongDocGia.TextAlign = ContentAlignment.MiddleLeft;
        this.lblTongDocGia.Padding = new Padding(20, 0, 0, 0);

        // lblDangMuon
        this.lblDangMuon.Location = new Point(50, 270);
        this.lblDangMuon.Size = new Size(500, 40);
        this.lblDangMuon.Text = "Đang mượn: 0";
        this.lblDangMuon.Font = new Font("Segoe UI", 12F);
        this.lblDangMuon.ForeColor = Color.Blue;
        this.lblDangMuon.TextAlign = ContentAlignment.MiddleLeft;
        this.lblDangMuon.Padding = new Padding(20, 0, 0, 0);

        // lblQuaHan
        this.lblQuaHan.Location = new Point(50, 320);
        this.lblQuaHan.Size = new Size(500, 40);
        this.lblQuaHan.Text = "Quá hạn: 0";
        this.lblQuaHan.Font = new Font("Segoe UI", 12F);
        this.lblQuaHan.ForeColor = Color.Red;
        this.lblQuaHan.TextAlign = ContentAlignment.MiddleLeft;
        this.lblQuaHan.Padding = new Padding(20, 0, 0, 0);

        // lblDaTra
        this.lblDaTra.Location = new Point(50, 370);
        this.lblDaTra.Size = new Size(500, 40);
        this.lblDaTra.Text = "Đã trả: 0";
        this.lblDaTra.Font = new Font("Segoe UI", 12F);
        this.lblDaTra.ForeColor = Color.Green;
        this.lblDaTra.TextAlign = ContentAlignment.MiddleLeft;
        this.lblDaTra.Padding = new Padding(20, 0, 0, 0);

        // btnLamMoi
        this.btnLamMoi.Location = new Point(300, 540);
        this.btnLamMoi.Size = new Size(200, 50);
        this.btnLamMoi.Text = "Làm Mới";
        this.btnLamMoi.BackColor = Color.LightGray;
        this.btnLamMoi.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        this.btnLamMoi.Cursor = Cursors.Hand;
        this.btnLamMoi.Click += btnLamMoi_Click;

        // Add controls to panelStats
        this.panelStats.Controls.Add(this.lblTongSach);
        this.panelStats.Controls.Add(this.lblTongBanSao);
        this.panelStats.Controls.Add(this.lblSachConLai);
        this.panelStats.Controls.Add(this.lblTongDocGia);
        this.panelStats.Controls.Add(this.lblDangMuon);
        this.panelStats.Controls.Add(this.lblQuaHan);
        this.panelStats.Controls.Add(this.lblDaTra);

        // StatisticsForm
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(800, 620);
        this.Controls.Add(this.lblTitle);
        this.Controls.Add(this.panelStats);
        this.Controls.Add(this.btnLamMoi);
        this.Name = "StatisticsForm";
        this.Text = "Thống Kê";
        this.StartPosition = FormStartPosition.CenterScreen;

        this.panelStats.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    private Label lblTitle;
    private Panel panelStats;
    private Label lblTongSach;
    private Label lblTongBanSao;
    private Label lblSachConLai;
    private Label lblTongDocGia;
    private Label lblDangMuon;
    private Label lblQuaHan;
    private Label lblDaTra;
    private Button btnLamMoi;
}
