using QuanLyThuVien.Data;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Forms;

public partial class LoanManagementForm : Form
{
    private DataManager _dataManager;

    public LoanManagementForm()
    {
        InitializeComponent();
        _dataManager = DataManager.Instance;
        LoadData();
    }

    private void LoadData()
    {
        cboBooks.DataSource = _dataManager.GetAllBooks().Where(b => b.SoLuongConLai > 0).ToList();
        cboBooks.DisplayMember = "TenSach";
        cboBooks.ValueMember = "Id";

        cboMembers.DataSource = _dataManager.GetAllMembers();
        cboMembers.DisplayMember = "HoTen";
        cboMembers.ValueMember = "Id";

        LoadLoans();
    }

    private void LoadLoans()
    {
        dgvLoans.DataSource = null;
        dgvLoans.DataSource = _dataManager.GetActiveLoans();
        dgvLoans.AutoResizeColumns();
    }

    private void btnMuon_Click(object sender, EventArgs e)
    {
        if (cboBooks.SelectedValue == null || cboMembers.SelectedValue == null)
        {
            MessageBox.Show("Vui lòng chọn sách và độc giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int bookId = (int)cboBooks.SelectedValue;
        int memberId = (int)cboMembers.SelectedValue;

        var book = _dataManager.GetBookById(bookId);
        if (book == null || book.SoLuongConLai <= 0)
        {
            MessageBox.Show("Sách không có sẵn để mượn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var loan = new Loan
        {
            BookId = bookId,
            MemberId = memberId,
            NgayMuon = dtpNgayMuon.Value,
            NgayHenTra = dtpNgayHenTra.Value
        };

        _dataManager.AddLoan(loan);
        MessageBox.Show("Mượn sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        LoadData();
    }

    private void cboBooks_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboBooks.SelectedValue is int bookId)
        {
            var book = _dataManager.GetBookById(bookId);
            if (book != null)
            {
                lblSoLuongConLai.Text = $"Số lượng còn lại: {book.SoLuongConLai}";
            }
        }
    }
}
