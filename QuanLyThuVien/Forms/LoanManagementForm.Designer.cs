namespace QuanLyThuVien.Forms;

partial class LoanManagementForm
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
        this.groupBoxMuonSach = new GroupBox();
        this.lblSach = new Label();
        this.cboBooks = new ComboBox();
        this.lblSoLuongConLai = new Label();
        this.lblDocGia = new Label();
        this.cboMembers = new ComboBox();
        this.lblNgayMuon = new Label();
        this.dtpNgayMuon = new DateTimePicker();
        this.lblNgayHenTra = new Label();
        this.dtpNgayHenTra = new DateTimePicker();
        this.btnMuon = new Button();
        this.groupBoxDanhSach = new GroupBox();
        this.dgvLoans = new DataGridView();
        
        this.groupBoxMuonSach.SuspendLayout();
        this.groupBoxDanhSach.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).BeginInit();
        this.SuspendLayout();

        // lblTitle
        this.lblTitle.AutoSize = false;
        this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        this.lblTitle.Location = new Point(350, 10);
        this.lblTitle.Size = new Size(400, 40);
        this.lblTitle.Text = "MƯỢN SÁCH";
        this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        this.lblTitle.ForeColor = Color.DarkOrange;

        // groupBoxMuonSach
        this.groupBoxMuonSach.Text = "Thông tin mượn sách";
        this.groupBoxMuonSach.Location = new Point(20, 60);
        this.groupBoxMuonSach.Size = new Size(500, 300);
        this.groupBoxMuonSach.Font = new Font("Segoe UI", 10F);

        // lblSach
        this.lblSach.Location = new Point(20, 30);
        this.lblSach.Size = new Size(120, 25);
        this.lblSach.Text = "Chọn sách:";

        // cboBooks
        this.cboBooks.Location = new Point(150, 30);
        this.cboBooks.Size = new Size(330, 25);
        this.cboBooks.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cboBooks.SelectedIndexChanged += cboBooks_SelectedIndexChanged;

        // lblSoLuongConLai
        this.lblSoLuongConLai.Location = new Point(150, 60);
        this.lblSoLuongConLai.Size = new Size(330, 25);
        this.lblSoLuongConLai.Text = "Số lượng còn lại: 0";
        this.lblSoLuongConLai.ForeColor = Color.Blue;

        // lblDocGia
        this.lblDocGia.Location = new Point(20, 90);
        this.lblDocGia.Size = new Size(120, 25);
        this.lblDocGia.Text = "Chọn độc giả:";

        // cboMembers
        this.cboMembers.Location = new Point(150, 90);
        this.cboMembers.Size = new Size(330, 25);
        this.cboMembers.DropDownStyle = ComboBoxStyle.DropDownList;

        // lblNgayMuon
        this.lblNgayMuon.Location = new Point(20, 130);
        this.lblNgayMuon.Size = new Size(120, 25);
        this.lblNgayMuon.Text = "Ngày mượn:";

        // dtpNgayMuon
        this.dtpNgayMuon.Location = new Point(150, 130);
        this.dtpNgayMuon.Size = new Size(330, 25);
        this.dtpNgayMuon.Format = DateTimePickerFormat.Short;

        // lblNgayHenTra
        this.lblNgayHenTra.Location = new Point(20, 170);
        this.lblNgayHenTra.Size = new Size(120, 25);
        this.lblNgayHenTra.Text = "Ngày hẹn trả:";

        // dtpNgayHenTra
        this.dtpNgayHenTra.Location = new Point(150, 170);
        this.dtpNgayHenTra.Size = new Size(330, 25);
        this.dtpNgayHenTra.Format = DateTimePickerFormat.Short;
        this.dtpNgayHenTra.Value = DateTime.Now.AddDays(14);

        // btnMuon
        this.btnMuon.Location = new Point(180, 220);
        this.btnMuon.Size = new Size(150, 50);
        this.btnMuon.Text = "Xác Nhận Mượn";
        this.btnMuon.BackColor = Color.LightGreen;
        this.btnMuon.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        this.btnMuon.Cursor = Cursors.Hand;
        this.btnMuon.Click += btnMuon_Click;

        // Add controls to groupBoxMuonSach
        this.groupBoxMuonSach.Controls.Add(this.lblSach);
        this.groupBoxMuonSach.Controls.Add(this.cboBooks);
        this.groupBoxMuonSach.Controls.Add(this.lblSoLuongConLai);
        this.groupBoxMuonSach.Controls.Add(this.lblDocGia);
        this.groupBoxMuonSach.Controls.Add(this.cboMembers);
        this.groupBoxMuonSach.Controls.Add(this.lblNgayMuon);
        this.groupBoxMuonSach.Controls.Add(this.dtpNgayMuon);
        this.groupBoxMuonSach.Controls.Add(this.lblNgayHenTra);
        this.groupBoxMuonSach.Controls.Add(this.dtpNgayHenTra);
        this.groupBoxMuonSach.Controls.Add(this.btnMuon);

        // groupBoxDanhSach
        this.groupBoxDanhSach.Text = "Danh sách sách đang mượn";
        this.groupBoxDanhSach.Location = new Point(20, 380);
        this.groupBoxDanhSach.Size = new Size(1050, 240);
        this.groupBoxDanhSach.Font = new Font("Segoe UI", 10F);

        // dgvLoans
        this.dgvLoans.Location = new Point(20, 30);
        this.dgvLoans.Size = new Size(1010, 190);
        this.dgvLoans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvLoans.MultiSelect = false;
        this.dgvLoans.ReadOnly = true;
        this.dgvLoans.AllowUserToAddRows = false;
        this.dgvLoans.AllowUserToDeleteRows = false;

        // Add controls to groupBoxDanhSach
        this.groupBoxDanhSach.Controls.Add(this.dgvLoans);

        // LoanManagementForm
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1100, 650);
        this.Controls.Add(this.lblTitle);
        this.Controls.Add(this.groupBoxMuonSach);
        this.Controls.Add(this.groupBoxDanhSach);
        this.Name = "LoanManagementForm";
        this.Text = "Mượn Sách";
        this.StartPosition = FormStartPosition.CenterScreen;

        this.groupBoxMuonSach.ResumeLayout(false);
        this.groupBoxDanhSach.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).EndInit();
        this.ResumeLayout(false);
    }

    private Label lblTitle;
    private GroupBox groupBoxMuonSach;
    private Label lblSach;
    private ComboBox cboBooks;
    private Label lblSoLuongConLai;
    private Label lblDocGia;
    private ComboBox cboMembers;
    private Label lblNgayMuon;
    private DateTimePicker dtpNgayMuon;
    private Label lblNgayHenTra;
    private DateTimePicker dtpNgayHenTra;
    private Button btnMuon;
    private GroupBox groupBoxDanhSach;
    private DataGridView dgvLoans;
}
