using QuanLyThuVien.Data;

namespace QuanLyThuVien.Forms;

public partial class StatisticsForm : Form
{
    private DataManager _dataManager;

    public StatisticsForm()
    {
        InitializeComponent();
        _dataManager = DataManager.Instance;
        LoadStatistics();
    }

    private void LoadStatistics()
    {
        var books = _dataManager.GetAllBooks();
        var members = _dataManager.GetAllMembers();
        var loans = _dataManager.GetAllLoans();
        var activeLoans = _dataManager.GetActiveLoans();
        var overdueLoans = _dataManager.GetOverdueLoans();

        lblTongSach.Text = $"Tổng số sách: {books.Count}";
        lblTongBanSao.Text = $"Tổng bản sao: {books.Sum(b => b.SoLuong)}";
        lblSachConLai.Text = $"Sách còn lại: {books.Sum(b => b.SoLuongConLai)}";
        lblTongDocGia.Text = $"Tổng độc giả: {members.Count}";
        lblDangMuon.Text = $"Đang mượn: {activeLoans.Count}";
        lblQuaHan.Text = $"Quá hạn: {overdueLoans.Count}";
        lblDaTra.Text = $"Đã trả: {loans.Count(l => l.TrangThai == "Đã trả")}";
    }

    private void btnLamMoi_Click(object sender, EventArgs e)
    {
        LoadStatistics();
        MessageBox.Show("Đã cập nhật thống kê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
