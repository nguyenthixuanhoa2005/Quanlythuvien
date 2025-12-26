using QuanLyThuVien.Data;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Forms;

public partial class MemberManagementForm : Form
{
    private DataManager _dataManager;
    private Member? _selectedMember;

    public MemberManagementForm()
    {
        InitializeComponent();
        _dataManager = DataManager.Instance;
        LoadMembers();
    }

    private void LoadMembers()
    {
        dgvMembers.DataSource = null;
        dgvMembers.DataSource = _dataManager.GetAllMembers();
        dgvMembers.AutoResizeColumns();
    }

    private void btnThem_Click(object sender, EventArgs e)
    {
        if (ValidateInput())
        {
            var member = new Member
            {
                MaDocGia = txtMaDocGia.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value,
                GioiTinh = cboGioiTinh.SelectedItem?.ToString() ?? "Khác",
                DiaChi = txtDiaChi.Text.Trim(),
                SoDienThoai = txtSoDienThoai.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };

            _dataManager.AddMember(member);
            MessageBox.Show("Thêm độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearInputs();
            LoadMembers();
        }
    }

    private void btnSua_Click(object sender, EventArgs e)
    {
        if (_selectedMember == null)
        {
            MessageBox.Show("Vui lòng chọn độc giả cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (ValidateInput())
        {
            _selectedMember.MaDocGia = txtMaDocGia.Text.Trim();
            _selectedMember.HoTen = txtHoTen.Text.Trim();
            _selectedMember.NgaySinh = dtpNgaySinh.Value;
            _selectedMember.GioiTinh = cboGioiTinh.SelectedItem?.ToString() ?? "Khác";
            _selectedMember.DiaChi = txtDiaChi.Text.Trim();
            _selectedMember.SoDienThoai = txtSoDienThoai.Text.Trim();
            _selectedMember.Email = txtEmail.Text.Trim();

            _dataManager.UpdateMember(_selectedMember);
            MessageBox.Show("Cập nhật độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearInputs();
            LoadMembers();
        }
    }

    private void btnXoa_Click(object sender, EventArgs e)
    {
        if (_selectedMember == null)
        {
            MessageBox.Show("Vui lòng chọn độc giả cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa độc giả '{_selectedMember.HoTen}'?", 
            "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            _dataManager.DeleteMember(_selectedMember.Id);
            MessageBox.Show("Xóa độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearInputs();
            LoadMembers();
        }
    }

    private void btnTimKiem_Click(object sender, EventArgs e)
    {
        string keyword = txtTimKiem.Text.Trim();
        if (string.IsNullOrEmpty(keyword))
        {
            LoadMembers();
        }
        else
        {
            dgvMembers.DataSource = null;
            dgvMembers.DataSource = _dataManager.SearchMembers(keyword);
            dgvMembers.AutoResizeColumns();
        }
    }

    private void dgvMembers_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            DataGridViewRow row = dgvMembers.Rows[e.RowIndex];
            _selectedMember = row.DataBoundItem as Member;

            if (_selectedMember != null)
            {
                txtMaDocGia.Text = _selectedMember.MaDocGia;
                txtHoTen.Text = _selectedMember.HoTen;
                dtpNgaySinh.Value = _selectedMember.NgaySinh;
                cboGioiTinh.SelectedItem = _selectedMember.GioiTinh;
                txtDiaChi.Text = _selectedMember.DiaChi;
                txtSoDienThoai.Text = _selectedMember.SoDienThoai;
                txtEmail.Text = _selectedMember.Email;
            }
        }
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtMaDocGia.Text))
        {
            MessageBox.Show("Vui lòng nhập mã độc giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtMaDocGia.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtHoTen.Text))
        {
            MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtHoTen.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
        {
            MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSoDienThoai.Focus();
            return false;
        }

        return true;
    }

    private void ClearInputs()
    {
        txtMaDocGia.Clear();
        txtHoTen.Clear();
        dtpNgaySinh.Value = DateTime.Now.AddYears(-18);
        cboGioiTinh.SelectedIndex = 0;
        txtDiaChi.Clear();
        txtSoDienThoai.Clear();
        txtEmail.Clear();
        _selectedMember = null;
    }
}
