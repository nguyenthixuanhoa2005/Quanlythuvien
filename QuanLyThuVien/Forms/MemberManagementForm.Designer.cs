namespace QuanLyThuVien.Forms;

partial class MemberManagementForm
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
        this.groupBoxThongTin = new GroupBox();
        this.lblMaDocGia = new Label();
        this.txtMaDocGia = new TextBox();
        this.lblHoTen = new Label();
        this.txtHoTen = new TextBox();
        this.lblNgaySinh = new Label();
        this.dtpNgaySinh = new DateTimePicker();
        this.lblGioiTinh = new Label();
        this.cboGioiTinh = new ComboBox();
        this.lblDiaChi = new Label();
        this.txtDiaChi = new TextBox();
        this.lblSoDienThoai = new Label();
        this.txtSoDienThoai = new TextBox();
        this.lblEmail = new Label();
        this.txtEmail = new TextBox();
        this.btnThem = new Button();
        this.btnSua = new Button();
        this.btnXoa = new Button();
        this.groupBoxTimKiem = new GroupBox();
        this.txtTimKiem = new TextBox();
        this.btnTimKiem = new Button();
        this.dgvMembers = new DataGridView();
        
        this.groupBoxThongTin.SuspendLayout();
        this.groupBoxTimKiem.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
        this.SuspendLayout();

        // lblTitle
        this.lblTitle.AutoSize = false;
        this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        this.lblTitle.Location = new Point(300, 10);
        this.lblTitle.Size = new Size(400, 40);
        this.lblTitle.Text = "QUẢN LÝ ĐỘC GIẢ";
        this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        this.lblTitle.ForeColor = Color.DarkGreen;

        // groupBoxThongTin
        this.groupBoxThongTin.Text = "Thông tin độc giả";
        this.groupBoxThongTin.Location = new Point(20, 60);
        this.groupBoxThongTin.Size = new Size(450, 500);
        this.groupBoxThongTin.Font = new Font("Segoe UI", 10F);

        // lblMaDocGia
        this.lblMaDocGia.Location = new Point(20, 30);
        this.lblMaDocGia.Size = new Size(120, 25);
        this.lblMaDocGia.Text = "Mã độc giả:";

        // txtMaDocGia
        this.txtMaDocGia.Location = new Point(150, 30);
        this.txtMaDocGia.Size = new Size(280, 25);

        // lblHoTen
        this.lblHoTen.Location = new Point(20, 70);
        this.lblHoTen.Size = new Size(120, 25);
        this.lblHoTen.Text = "Họ tên:";

        // txtHoTen
        this.txtHoTen.Location = new Point(150, 70);
        this.txtHoTen.Size = new Size(280, 25);

        // lblNgaySinh
        this.lblNgaySinh.Location = new Point(20, 110);
        this.lblNgaySinh.Size = new Size(120, 25);
        this.lblNgaySinh.Text = "Ngày sinh:";

        // dtpNgaySinh
        this.dtpNgaySinh.Location = new Point(150, 110);
        this.dtpNgaySinh.Size = new Size(280, 25);
        this.dtpNgaySinh.Format = DateTimePickerFormat.Short;
        this.dtpNgaySinh.Value = DateTime.Now.AddYears(-18);

        // lblGioiTinh
        this.lblGioiTinh.Location = new Point(20, 150);
        this.lblGioiTinh.Size = new Size(120, 25);
        this.lblGioiTinh.Text = "Giới tính:";

        // cboGioiTinh
        this.cboGioiTinh.Location = new Point(150, 150);
        this.cboGioiTinh.Size = new Size(280, 25);
        this.cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
        this.cboGioiTinh.SelectedIndex = 0;

        // lblDiaChi
        this.lblDiaChi.Location = new Point(20, 190);
        this.lblDiaChi.Size = new Size(120, 25);
        this.lblDiaChi.Text = "Địa chỉ:";

        // txtDiaChi
        this.txtDiaChi.Location = new Point(150, 190);
        this.txtDiaChi.Size = new Size(280, 25);

        // lblSoDienThoai
        this.lblSoDienThoai.Location = new Point(20, 230);
        this.lblSoDienThoai.Size = new Size(120, 25);
        this.lblSoDienThoai.Text = "Số điện thoại:";

        // txtSoDienThoai
        this.txtSoDienThoai.Location = new Point(150, 230);
        this.txtSoDienThoai.Size = new Size(280, 25);

        // lblEmail
        this.lblEmail.Location = new Point(20, 270);
        this.lblEmail.Size = new Size(120, 25);
        this.lblEmail.Text = "Email:";

        // txtEmail
        this.txtEmail.Location = new Point(150, 270);
        this.txtEmail.Size = new Size(280, 25);

        // btnThem
        this.btnThem.Location = new Point(30, 380);
        this.btnThem.Size = new Size(120, 40);
        this.btnThem.Text = "Thêm";
        this.btnThem.BackColor = Color.LightGreen;
        this.btnThem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnThem.Cursor = Cursors.Hand;
        this.btnThem.Click += btnThem_Click;

        // btnSua
        this.btnSua.Location = new Point(170, 380);
        this.btnSua.Size = new Size(120, 40);
        this.btnSua.Text = "Sửa";
        this.btnSua.BackColor = Color.LightBlue;
        this.btnSua.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnSua.Cursor = Cursors.Hand;
        this.btnSua.Click += btnSua_Click;

        // btnXoa
        this.btnXoa.Location = new Point(310, 380);
        this.btnXoa.Size = new Size(120, 40);
        this.btnXoa.Text = "Xóa";
        this.btnXoa.BackColor = Color.LightCoral;
        this.btnXoa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnXoa.Cursor = Cursors.Hand;
        this.btnXoa.Click += btnXoa_Click;

        // Add controls to groupBoxThongTin
        this.groupBoxThongTin.Controls.Add(this.lblMaDocGia);
        this.groupBoxThongTin.Controls.Add(this.txtMaDocGia);
        this.groupBoxThongTin.Controls.Add(this.lblHoTen);
        this.groupBoxThongTin.Controls.Add(this.txtHoTen);
        this.groupBoxThongTin.Controls.Add(this.lblNgaySinh);
        this.groupBoxThongTin.Controls.Add(this.dtpNgaySinh);
        this.groupBoxThongTin.Controls.Add(this.lblGioiTinh);
        this.groupBoxThongTin.Controls.Add(this.cboGioiTinh);
        this.groupBoxThongTin.Controls.Add(this.lblDiaChi);
        this.groupBoxThongTin.Controls.Add(this.txtDiaChi);
        this.groupBoxThongTin.Controls.Add(this.lblSoDienThoai);
        this.groupBoxThongTin.Controls.Add(this.txtSoDienThoai);
        this.groupBoxThongTin.Controls.Add(this.lblEmail);
        this.groupBoxThongTin.Controls.Add(this.txtEmail);
        this.groupBoxThongTin.Controls.Add(this.btnThem);
        this.groupBoxThongTin.Controls.Add(this.btnSua);
        this.groupBoxThongTin.Controls.Add(this.btnXoa);

        // groupBoxTimKiem
        this.groupBoxTimKiem.Text = "Tìm kiếm";
        this.groupBoxTimKiem.Location = new Point(490, 60);
        this.groupBoxTimKiem.Size = new Size(480, 80);
        this.groupBoxTimKiem.Font = new Font("Segoe UI", 10F);

        // txtTimKiem
        this.txtTimKiem.Location = new Point(20, 30);
        this.txtTimKiem.Size = new Size(320, 25);

        // btnTimKiem
        this.btnTimKiem.Location = new Point(350, 25);
        this.btnTimKiem.Size = new Size(110, 35);
        this.btnTimKiem.Text = "Tìm kiếm";
        this.btnTimKiem.BackColor = Color.LightYellow;
        this.btnTimKiem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnTimKiem.Cursor = Cursors.Hand;
        this.btnTimKiem.Click += btnTimKiem_Click;

        // Add controls to groupBoxTimKiem
        this.groupBoxTimKiem.Controls.Add(this.txtTimKiem);
        this.groupBoxTimKiem.Controls.Add(this.btnTimKiem);

        // dgvMembers
        this.dgvMembers.Location = new Point(490, 150);
        this.dgvMembers.Size = new Size(480, 410);
        this.dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvMembers.MultiSelect = false;
        this.dgvMembers.ReadOnly = true;
        this.dgvMembers.AllowUserToAddRows = false;
        this.dgvMembers.AllowUserToDeleteRows = false;
        this.dgvMembers.CellClick += dgvMembers_CellClick;

        // MemberManagementForm
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1000, 600);
        this.Controls.Add(this.lblTitle);
        this.Controls.Add(this.groupBoxThongTin);
        this.Controls.Add(this.groupBoxTimKiem);
        this.Controls.Add(this.dgvMembers);
        this.Name = "MemberManagementForm";
        this.Text = "Quản Lý Độc Giả";
        this.StartPosition = FormStartPosition.CenterScreen;

        this.groupBoxThongTin.ResumeLayout(false);
        this.groupBoxTimKiem.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
        this.ResumeLayout(false);
    }

    private Label lblTitle;
    private GroupBox groupBoxThongTin;
    private Label lblMaDocGia;
    private TextBox txtMaDocGia;
    private Label lblHoTen;
    private TextBox txtHoTen;
    private Label lblNgaySinh;
    private DateTimePicker dtpNgaySinh;
    private Label lblGioiTinh;
    private ComboBox cboGioiTinh;
    private Label lblDiaChi;
    private TextBox txtDiaChi;
    private Label lblSoDienThoai;
    private TextBox txtSoDienThoai;
    private Label lblEmail;
    private TextBox txtEmail;
    private Button btnThem;
    private Button btnSua;
    private Button btnXoa;
    private GroupBox groupBoxTimKiem;
    private TextBox txtTimKiem;
    private Button btnTimKiem;
    private DataGridView dgvMembers;
}
