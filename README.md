# Quản Lý Thư Viện (Library Management System)

Hệ thống quản lý thư viện được phát triển bằng C# WinForms.

## Tính năng

### 1. Quản lý sách
- Thêm, sửa, xóa thông tin sách
- Tìm kiếm sách theo mã, tên, tác giả, thể loại
- Quản lý số lượng sách và vị trí lưu trữ

### 2. Quản lý độc giả
- Thêm, sửa, xóa thông tin độc giả
- Tìm kiếm độc giả theo mã, tên, số điện thoại
- Lưu trữ thông tin cá nhân: họ tên, ngày sinh, giới tính, địa chỉ, email

### 3. Mượn sách
- Cho mượn sách với thông tin ngày mượn, ngày hẹn trả
- Kiểm tra số lượng sách còn lại
- Danh sách sách đang được mượn

### 4. Trả sách
- Xử lý trả sách
- Tính toán số ngày quá hạn tự động
- Hiển thị danh sách sách quá hạn

### 5. Thống kê
- Tổng số sách và bản sao
- Số lượng độc giả
- Số sách đang mượn, quá hạn, đã trả

## Công nghệ sử dụng

- **Framework**: .NET 8.0
- **UI**: Windows Forms
- **Lưu trữ dữ liệu**: JSON files
- **Ngôn ngữ**: C#

## Cấu trúc dự án

```
QuanLyThuVien/
├── Models/              # Các lớp mô hình dữ liệu
│   ├── Book.cs         # Mô hình sách
│   ├── Member.cs       # Mô hình độc giả
│   └── Loan.cs         # Mô hình phiếu mượn
├── Data/               # Quản lý dữ liệu
│   └── DataManager.cs  # Singleton quản lý dữ liệu
├── Forms/              # Các form giao diện
│   ├── BookManagementForm.cs
│   ├── MemberManagementForm.cs
│   ├── LoanManagementForm.cs
│   ├── ReturnBookForm.cs
│   └── StatisticsForm.cs
├── Program.cs          # Entry point
└── Form1.cs           # Form chính
```

## Cách chạy

### Yêu cầu
- .NET 8.0 SDK hoặc cao hơn
- Windows OS (để chạy WinForms)

### Cài đặt và chạy

1. Clone repository:
```bash
git clone https://github.com/nguyenthixuanhoa2005/Quanlythuvien.git
cd Quanlythuvien
```

2. Restore dependencies:
```bash
cd QuanLyThuVien
dotnet restore
```

3. Build project:
```bash
dotnet build
```

4. Chạy ứng dụng:
```bash
dotnet run
```

Hoặc mở file `.csproj` trong Visual Studio và nhấn F5 để chạy.

## Lưu trữ dữ liệu

Dữ liệu được lưu trữ trong các file JSON tại thư mục `QuanLyThuVien/Data/`:
- `books.json`: Danh sách sách
- `members.json`: Danh sách độc giả
- `loans.json`: Danh sách phiếu mượn

## Giao diện

### Màn hình chính
Hiển thị menu điều hướng đến các chức năng:
- Quản lý sách
- Quản lý độc giả
- Mượn sách
- Trả sách
- Thống kê

### Các màn hình chức năng
Mỗi chức năng có giao diện riêng với:
- Form nhập liệu
- DataGridView hiển thị dữ liệu
- Các nút thao tác (Thêm, Sửa, Xóa, Tìm kiếm)

## Tác giả

Nguyễn Thị Xuân Hoa

## License

MIT License

