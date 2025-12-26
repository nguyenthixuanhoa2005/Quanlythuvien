namespace QuanLyThuVien.Models;

public class Loan
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int MemberId { get; set; }
    public DateTime NgayMuon { get; set; }
    public DateTime NgayHenTra { get; set; }
    public DateTime? NgayTraThucTe { get; set; }
    public string TrangThai { get; set; } = "Đang mượn";
    public int SoNgayQuaHan { get; set; }
    
    // Navigation properties
    public string? TenSach { get; set; }
    public string? TenDocGia { get; set; }

    public Loan()
    {
        NgayMuon = DateTime.Now;
        NgayHenTra = DateTime.Now.AddDays(14); // Mặc định cho mượn 14 ngày
    }

    public void TinhSoNgayQuaHan()
    {
        SoNgayQuaHan = 0; // Reset về 0 trước khi tính
        
        if (NgayTraThucTe.HasValue)
        {
            if (NgayTraThucTe > NgayHenTra)
            {
                SoNgayQuaHan = (NgayTraThucTe.Value - NgayHenTra).Days;
            }
        }
        else if (DateTime.Now > NgayHenTra)
        {
            SoNgayQuaHan = (DateTime.Now - NgayHenTra).Days;
        }
    }
}
