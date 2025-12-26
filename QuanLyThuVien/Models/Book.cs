namespace QuanLyThuVien.Models;

public class Book
{
    private int _soLuong;
    private int _soLuongConLai;

    public int Id { get; set; }
    public string MaSach { get; set; } = string.Empty;
    public string TenSach { get; set; } = string.Empty;
    public string TacGia { get; set; } = string.Empty;
    public string NhaXuatBan { get; set; } = string.Empty;
    public int NamXuatBan { get; set; }
    public string TheLoai { get; set; } = string.Empty;
    
    public int SoLuong 
    { 
        get => _soLuong;
        set
        {
            _soLuong = value;
            // Tự động cập nhật số lượng còn lại khi set số lượng mới
            if (_soLuongConLai == 0)
            {
                _soLuongConLai = value;
            }
        }
    }
    
    public int SoLuongConLai 
    { 
        get => _soLuongConLai;
        set => _soLuongConLai = value;
    }
    
    public string ViTri { get; set; } = string.Empty;
}
