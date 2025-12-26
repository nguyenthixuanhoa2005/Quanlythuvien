namespace QuanLyThuVien.Models;

public class Book
{
    public int Id { get; set; }
    public string MaSach { get; set; } = string.Empty;
    public string TenSach { get; set; } = string.Empty;
    public string TacGia { get; set; } = string.Empty;
    public string NhaXuatBan { get; set; } = string.Empty;
    public int NamXuatBan { get; set; }
    public string TheLoai { get; set; } = string.Empty;
    public int SoLuong { get; set; }
    public int SoLuongConLai { get; set; }
    public string ViTri { get; set; } = string.Empty;

    public Book()
    {
        SoLuongConLai = SoLuong;
    }
}
