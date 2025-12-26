namespace QuanLyThuVien.Models;

public class Member
{
    public int Id { get; set; }
    public string MaDocGia { get; set; } = string.Empty;
    public string HoTen { get; set; } = string.Empty;
    public DateTime NgaySinh { get; set; }
    public string GioiTinh { get; set; } = string.Empty;
    public string DiaChi { get; set; } = string.Empty;
    public string SoDienThoai { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime NgayDangKy { get; set; }

    public Member()
    {
        NgayDangKy = DateTime.Now;
    }
}
