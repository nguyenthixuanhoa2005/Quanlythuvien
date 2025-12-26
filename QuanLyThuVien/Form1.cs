using QuanLyThuVien.Forms;

namespace QuanLyThuVien;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        this.Text = "Hệ Thống Quản Lý Thư Viện";
        this.Size = new Size(1200, 700);
        this.StartPosition = FormStartPosition.CenterScreen;
    }

    private void btnQuanLySach_Click(object sender, EventArgs e)
    {
        var bookForm = new BookManagementForm();
        bookForm.ShowDialog();
    }

    private void btnQuanLyDocGia_Click(object sender, EventArgs e)
    {
        var memberForm = new MemberManagementForm();
        memberForm.ShowDialog();
    }

    private void btnMuonSach_Click(object sender, EventArgs e)
    {
        var loanForm = new LoanManagementForm();
        loanForm.ShowDialog();
    }

    private void btnTraSach_Click(object sender, EventArgs e)
    {
        var returnForm = new ReturnBookForm();
        returnForm.ShowDialog();
    }

    private void btnThongKe_Click(object sender, EventArgs e)
    {
        var statsForm = new StatisticsForm();
        statsForm.ShowDialog();
    }
}
