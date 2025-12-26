using QuanLyThuVien.Data;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Forms;

public partial class ReturnBookForm : Form
{
    private DataManager _dataManager;
    private Loan? _selectedLoan;

    public ReturnBookForm()
    {
        InitializeComponent();
        _dataManager = DataManager.Instance;
        LoadActiveLoans();
    }

    private void LoadActiveLoans()
    {
        dgvActiveLoans.DataSource = null;
        dgvActiveLoans.DataSource = _dataManager.GetActiveLoans();
        dgvActiveLoans.AutoResizeColumns();
    }

    private void LoadOverdueLoans()
    {
        dgvOverdueLoans.DataSource = null;
        dgvOverdueLoans.DataSource = _dataManager.GetOverdueLoans();
        dgvOverdueLoans.AutoResizeColumns();
    }

    private void btnTraSach_Click(object sender, EventArgs e)
    {
        if (_selectedLoan == null)
        {
            MessageBox.Show("Vui lòng chọn phiếu mượn cần trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var result = MessageBox.Show($"Xác nhận trả sách '{_selectedLoan.TenSach}'?", 
            "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            _dataManager.ReturnBook(_selectedLoan.Id);
            
            if (_selectedLoan.SoNgayQuaHan > 0)
            {
                MessageBox.Show($"Trả sách thành công!\nSố ngày quá hạn: {_selectedLoan.SoNgayQuaHan} ngày", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Trả sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            _selectedLoan = null;
            LoadActiveLoans();
            LoadOverdueLoans();
        }
    }

    private void dgvActiveLoans_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            DataGridViewRow row = dgvActiveLoans.Rows[e.RowIndex];
            _selectedLoan = row.DataBoundItem as Loan;
        }
    }

    private void btnXemQuaHan_Click(object sender, EventArgs e)
    {
        LoadOverdueLoans();
    }
}
