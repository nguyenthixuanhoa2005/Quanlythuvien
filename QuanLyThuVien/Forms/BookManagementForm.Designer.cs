namespace QuanLyThuVien.Forms;

partial class BookManagementForm
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
        this.lblMaSach = new Label();
        this.txtMaSach = new TextBox();
        this.lblTenSach = new Label();
        this.txtTenSach = new TextBox();
        this.lblTacGia = new Label();
        this.txtTacGia = new TextBox();
        this.lblNhaXuatBan = new Label();
        this.txtNhaXuatBan = new TextBox();
        this.lblNamXuatBan = new Label();
        this.nudNamXuatBan = new NumericUpDown();
        this.lblTheLoai = new Label();
        this.txtTheLoai = new TextBox();
        this.lblSoLuong = new Label();
        this.nudSoLuong = new NumericUpDown();
        this.lblViTri = new Label();
        this.txtViTri = new TextBox();
        this.btnThem = new Button();
        this.btnSua = new Button();
        this.btnXoa = new Button();
        this.groupBoxTimKiem = new GroupBox();
        this.txtTimKiem = new TextBox();
        this.btnTimKiem = new Button();
        this.dgvBooks = new DataGridView();
        
        this.groupBoxThongTin.SuspendLayout();
        this.groupBoxTimKiem.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.nudNamXuatBan)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
        this.SuspendLayout();

        // lblTitle
        this.lblTitle.AutoSize = false;
        this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        this.lblTitle.Location = new Point(300, 10);
        this.lblTitle.Size = new Size(400, 40);
        this.lblTitle.Text = "QUẢN LÝ SÁCH";
        this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        this.lblTitle.ForeColor = Color.DarkBlue;

        // groupBoxThongTin
        this.groupBoxThongTin.Text = "Thông tin sách";
        this.groupBoxThongTin.Location = new Point(20, 60);
        this.groupBoxThongTin.Size = new Size(450, 500);
        this.groupBoxThongTin.Font = new Font("Segoe UI", 10F);

        // lblMaSach
        this.lblMaSach.Location = new Point(20, 30);
        this.lblMaSach.Size = new Size(120, 25);
        this.lblMaSach.Text = "Mã sách:";

        // txtMaSach
        this.txtMaSach.Location = new Point(150, 30);
        this.txtMaSach.Size = new Size(280, 25);

        // lblTenSach
        this.lblTenSach.Location = new Point(20, 70);
        this.lblTenSach.Size = new Size(120, 25);
        this.lblTenSach.Text = "Tên sách:";

        // txtTenSach
        this.txtTenSach.Location = new Point(150, 70);
        this.txtTenSach.Size = new Size(280, 25);

        // lblTacGia
        this.lblTacGia.Location = new Point(20, 110);
        this.lblTacGia.Size = new Size(120, 25);
        this.lblTacGia.Text = "Tác giả:";

        // txtTacGia
        this.txtTacGia.Location = new Point(150, 110);
        this.txtTacGia.Size = new Size(280, 25);

        // lblNhaXuatBan
        this.lblNhaXuatBan.Location = new Point(20, 150);
        this.lblNhaXuatBan.Size = new Size(120, 25);
        this.lblNhaXuatBan.Text = "Nhà xuất bản:";

        // txtNhaXuatBan
        this.txtNhaXuatBan.Location = new Point(150, 150);
        this.txtNhaXuatBan.Size = new Size(280, 25);

        // lblNamXuatBan
        this.lblNamXuatBan.Location = new Point(20, 190);
        this.lblNamXuatBan.Size = new Size(120, 25);
        this.lblNamXuatBan.Text = "Năm xuất bản:";

        // nudNamXuatBan
        this.nudNamXuatBan.Location = new Point(150, 190);
        this.nudNamXuatBan.Size = new Size(280, 25);
        this.nudNamXuatBan.Minimum = 1900;
        this.nudNamXuatBan.Maximum = DateTime.Now.Year + 10;
        this.nudNamXuatBan.Value = DateTime.Now.Year;

        // lblTheLoai
        this.lblTheLoai.Location = new Point(20, 230);
        this.lblTheLoai.Size = new Size(120, 25);
        this.lblTheLoai.Text = "Thể loại:";

        // txtTheLoai
        this.txtTheLoai.Location = new Point(150, 230);
        this.txtTheLoai.Size = new Size(280, 25);

        // lblSoLuong
        this.lblSoLuong.Location = new Point(20, 270);
        this.lblSoLuong.Size = new Size(120, 25);
        this.lblSoLuong.Text = "Số lượng:";

        // nudSoLuong
        this.nudSoLuong.Location = new Point(150, 270);
        this.nudSoLuong.Size = new Size(280, 25);
        this.nudSoLuong.Minimum = 1;
        this.nudSoLuong.Maximum = 10000;
        this.nudSoLuong.Value = 1;

        // lblViTri
        this.lblViTri.Location = new Point(20, 310);
        this.lblViTri.Size = new Size(120, 25);
        this.lblViTri.Text = "Vị trí:";

        // txtViTri
        this.txtViTri.Location = new Point(150, 310);
        this.txtViTri.Size = new Size(280, 25);

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
        this.groupBoxThongTin.Controls.Add(this.lblMaSach);
        this.groupBoxThongTin.Controls.Add(this.txtMaSach);
        this.groupBoxThongTin.Controls.Add(this.lblTenSach);
        this.groupBoxThongTin.Controls.Add(this.txtTenSach);
        this.groupBoxThongTin.Controls.Add(this.lblTacGia);
        this.groupBoxThongTin.Controls.Add(this.txtTacGia);
        this.groupBoxThongTin.Controls.Add(this.lblNhaXuatBan);
        this.groupBoxThongTin.Controls.Add(this.txtNhaXuatBan);
        this.groupBoxThongTin.Controls.Add(this.lblNamXuatBan);
        this.groupBoxThongTin.Controls.Add(this.nudNamXuatBan);
        this.groupBoxThongTin.Controls.Add(this.lblTheLoai);
        this.groupBoxThongTin.Controls.Add(this.txtTheLoai);
        this.groupBoxThongTin.Controls.Add(this.lblSoLuong);
        this.groupBoxThongTin.Controls.Add(this.nudSoLuong);
        this.groupBoxThongTin.Controls.Add(this.lblViTri);
        this.groupBoxThongTin.Controls.Add(this.txtViTri);
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

        // dgvBooks
        this.dgvBooks.Location = new Point(490, 150);
        this.dgvBooks.Size = new Size(480, 410);
        this.dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvBooks.MultiSelect = false;
        this.dgvBooks.ReadOnly = true;
        this.dgvBooks.AllowUserToAddRows = false;
        this.dgvBooks.AllowUserToDeleteRows = false;
        this.dgvBooks.CellClick += dgvBooks_CellClick;

        // BookManagementForm
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1000, 600);
        this.Controls.Add(this.lblTitle);
        this.Controls.Add(this.groupBoxThongTin);
        this.Controls.Add(this.groupBoxTimKiem);
        this.Controls.Add(this.dgvBooks);
        this.Name = "BookManagementForm";
        this.Text = "Quản Lý Sách";
        this.StartPosition = FormStartPosition.CenterScreen;

        this.groupBoxThongTin.ResumeLayout(false);
        this.groupBoxTimKiem.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.nudNamXuatBan)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
        this.ResumeLayout(false);
    }

    private Label lblTitle;
    private GroupBox groupBoxThongTin;
    private Label lblMaSach;
    private TextBox txtMaSach;
    private Label lblTenSach;
    private TextBox txtTenSach;
    private Label lblTacGia;
    private TextBox txtTacGia;
    private Label lblNhaXuatBan;
    private TextBox txtNhaXuatBan;
    private Label lblNamXuatBan;
    private NumericUpDown nudNamXuatBan;
    private Label lblTheLoai;
    private TextBox txtTheLoai;
    private Label lblSoLuong;
    private NumericUpDown nudSoLuong;
    private Label lblViTri;
    private TextBox txtViTri;
    private Button btnThem;
    private Button btnSua;
    private Button btnXoa;
    private GroupBox groupBoxTimKiem;
    private TextBox txtTimKiem;
    private Button btnTimKiem;
    private DataGridView dgvBooks;
}
