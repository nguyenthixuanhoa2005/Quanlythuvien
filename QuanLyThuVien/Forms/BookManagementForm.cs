using QuanLyThuVien.Data;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Forms;

public partial class BookManagementForm : Form
{
    private DataManager _dataManager;
    private Book? _selectedBook;

    public BookManagementForm()
    {
        InitializeComponent();
        _dataManager = DataManager.Instance;
        LoadBooks();
    }

    private void LoadBooks()
    {
        dgvBooks.DataSource = null;
        dgvBooks.DataSource = _dataManager.GetAllBooks();
        dgvBooks.AutoResizeColumns();
    }

    private void btnThem_Click(object sender, EventArgs e)
    {
        if (ValidateInput())
        {
            var book = new Book
            {
                MaSach = txtMaSach.Text.Trim(),
                TenSach = txtTenSach.Text.Trim(),
                TacGia = txtTacGia.Text.Trim(),
                NhaXuatBan = txtNhaXuatBan.Text.Trim(),
                NamXuatBan = (int)nudNamXuatBan.Value,
                TheLoai = txtTheLoai.Text.Trim(),
                SoLuong = (int)nudSoLuong.Value,
                SoLuongConLai = (int)nudSoLuong.Value,
                ViTri = txtViTri.Text.Trim()
            };

            _dataManager.AddBook(book);
            MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearInputs();
            LoadBooks();
        }
    }

    private void btnSua_Click(object sender, EventArgs e)
    {
        if (_selectedBook == null)
        {
            MessageBox.Show("Vui lòng chọn sách cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (ValidateInput())
        {
            _selectedBook.MaSach = txtMaSach.Text.Trim();
            _selectedBook.TenSach = txtTenSach.Text.Trim();
            _selectedBook.TacGia = txtTacGia.Text.Trim();
            _selectedBook.NhaXuatBan = txtNhaXuatBan.Text.Trim();
            _selectedBook.NamXuatBan = (int)nudNamXuatBan.Value;
            _selectedBook.TheLoai = txtTheLoai.Text.Trim();
            
            int oldQuantity = _selectedBook.SoLuong;
            int newQuantity = (int)nudSoLuong.Value;
            int difference = newQuantity - oldQuantity;
            
            _selectedBook.SoLuong = newQuantity;
            _selectedBook.SoLuongConLai += difference;
            _selectedBook.ViTri = txtViTri.Text.Trim();

            _dataManager.UpdateBook(_selectedBook);
            MessageBox.Show("Cập nhật sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearInputs();
            LoadBooks();
        }
    }

    private void btnXoa_Click(object sender, EventArgs e)
    {
        if (_selectedBook == null)
        {
            MessageBox.Show("Vui lòng chọn sách cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sách '{_selectedBook.TenSach}'?", 
            "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            _dataManager.DeleteBook(_selectedBook.Id);
            MessageBox.Show("Xóa sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearInputs();
            LoadBooks();
        }
    }

    private void btnTimKiem_Click(object sender, EventArgs e)
    {
        string keyword = txtTimKiem.Text.Trim();
        if (string.IsNullOrEmpty(keyword))
        {
            LoadBooks();
        }
        else
        {
            dgvBooks.DataSource = null;
            dgvBooks.DataSource = _dataManager.SearchBooks(keyword);
            dgvBooks.AutoResizeColumns();
        }
    }

    private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            DataGridViewRow row = dgvBooks.Rows[e.RowIndex];
            _selectedBook = row.DataBoundItem as Book;

            if (_selectedBook != null)
            {
                txtMaSach.Text = _selectedBook.MaSach;
                txtTenSach.Text = _selectedBook.TenSach;
                txtTacGia.Text = _selectedBook.TacGia;
                txtNhaXuatBan.Text = _selectedBook.NhaXuatBan;
                nudNamXuatBan.Value = _selectedBook.NamXuatBan;
                txtTheLoai.Text = _selectedBook.TheLoai;
                nudSoLuong.Value = _selectedBook.SoLuong;
                txtViTri.Text = _selectedBook.ViTri;
            }
        }
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtMaSach.Text))
        {
            MessageBox.Show("Vui lòng nhập mã sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtMaSach.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtTenSach.Text))
        {
            MessageBox.Show("Vui lòng nhập tên sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenSach.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtTacGia.Text))
        {
            MessageBox.Show("Vui lòng nhập tác giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTacGia.Focus();
            return false;
        }

        return true;
    }

    private void ClearInputs()
    {
        txtMaSach.Clear();
        txtTenSach.Clear();
        txtTacGia.Clear();
        txtNhaXuatBan.Clear();
        nudNamXuatBan.Value = DateTime.Now.Year;
        txtTheLoai.Clear();
        nudSoLuong.Value = 1;
        txtViTri.Clear();
        _selectedBook = null;
    }
}
