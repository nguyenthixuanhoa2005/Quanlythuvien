using System.Text.Json;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Data;

public class DataManager
{
    private static DataManager? _instance;
    private readonly string _dataFolder;
    
    private List<Book> _books;
    private List<Member> _members;
    private List<Loan> _loans;
    
    private int _nextBookId = 1;
    private int _nextMemberId = 1;
    private int _nextLoanId = 1;

    public static DataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DataManager();
            }
            return _instance;
        }
    }

    private DataManager()
    {
        _dataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        if (!Directory.Exists(_dataFolder))
        {
            Directory.CreateDirectory(_dataFolder);
        }

        _books = new List<Book>();
        _members = new List<Member>();
        _loans = new List<Loan>();

        LoadData();
    }

    private void LoadData()
    {
        try
        {
            string booksFile = Path.Combine(_dataFolder, "books.json");
            if (File.Exists(booksFile))
            {
                string json = File.ReadAllText(booksFile);
                _books = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
                if (_books.Any())
                {
                    _nextBookId = _books.Max(b => b.Id) + 1;
                }
            }

            string membersFile = Path.Combine(_dataFolder, "members.json");
            if (File.Exists(membersFile))
            {
                string json = File.ReadAllText(membersFile);
                _members = JsonSerializer.Deserialize<List<Member>>(json) ?? new List<Member>();
                if (_members.Any())
                {
                    _nextMemberId = _members.Max(m => m.Id) + 1;
                }
            }

            string loansFile = Path.Combine(_dataFolder, "loans.json");
            if (File.Exists(loansFile))
            {
                string json = File.ReadAllText(loansFile);
                _loans = JsonSerializer.Deserialize<List<Loan>>(json) ?? new List<Loan>();
                if (_loans.Any())
                {
                    _nextLoanId = _loans.Max(l => l.Id) + 1;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SaveBooks()
    {
        try
        {
            string json = JsonSerializer.Serialize(_books, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Path.Combine(_dataFolder, "books.json"), json);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi lưu dữ liệu sách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SaveMembers()
    {
        try
        {
            string json = JsonSerializer.Serialize(_members, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Path.Combine(_dataFolder, "members.json"), json);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi lưu dữ liệu độc giả: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SaveLoans()
    {
        try
        {
            string json = JsonSerializer.Serialize(_loans, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Path.Combine(_dataFolder, "loans.json"), json);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi lưu dữ liệu mượn trả: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Book methods
    public List<Book> GetAllBooks() => new List<Book>(_books);

    public Book? GetBookById(int id) => _books.FirstOrDefault(b => b.Id == id);

    public void AddBook(Book book)
    {
        book.Id = _nextBookId++;
        _books.Add(book);
        SaveBooks();
    }

    public void UpdateBook(Book book)
    {
        var index = _books.FindIndex(b => b.Id == book.Id);
        if (index >= 0)
        {
            _books[index] = book;
            SaveBooks();
        }
    }

    public void DeleteBook(int id)
    {
        _books.RemoveAll(b => b.Id == id);
        SaveBooks();
    }

    public List<Book> SearchBooks(string keyword)
    {
        keyword = keyword.ToLower();
        return _books.Where(b => 
            b.MaSach.ToLower().Contains(keyword) ||
            b.TenSach.ToLower().Contains(keyword) ||
            b.TacGia.ToLower().Contains(keyword) ||
            b.TheLoai.ToLower().Contains(keyword)
        ).ToList();
    }

    // Member methods
    public List<Member> GetAllMembers() => new List<Member>(_members);

    public Member? GetMemberById(int id) => _members.FirstOrDefault(m => m.Id == id);

    public void AddMember(Member member)
    {
        member.Id = _nextMemberId++;
        _members.Add(member);
        SaveMembers();
    }

    public void UpdateMember(Member member)
    {
        var index = _members.FindIndex(m => m.Id == member.Id);
        if (index >= 0)
        {
            _members[index] = member;
            SaveMembers();
        }
    }

    public void DeleteMember(int id)
    {
        _members.RemoveAll(m => m.Id == id);
        SaveMembers();
    }

    public List<Member> SearchMembers(string keyword)
    {
        keyword = keyword.ToLower();
        return _members.Where(m => 
            m.MaDocGia.ToLower().Contains(keyword) ||
            m.HoTen.ToLower().Contains(keyword) ||
            m.SoDienThoai.Contains(keyword)
        ).ToList();
    }

    // Loan methods
    public List<Loan> GetAllLoans() => new List<Loan>(_loans);

    public List<Loan> GetLoansWithDetails()
    {
        var loansWithDetails = new List<Loan>();
        foreach (var loan in _loans)
        {
            var loanCopy = new Loan
            {
                Id = loan.Id,
                BookId = loan.BookId,
                MemberId = loan.MemberId,
                NgayMuon = loan.NgayMuon,
                NgayHenTra = loan.NgayHenTra,
                NgayTraThucTe = loan.NgayTraThucTe,
                TrangThai = loan.TrangThai,
                SoNgayQuaHan = loan.SoNgayQuaHan
            };

            var book = GetBookById(loan.BookId);
            var member = GetMemberById(loan.MemberId);
            
            loanCopy.TenSach = book?.TenSach;
            loanCopy.TenDocGia = member?.HoTen;
            loanCopy.TinhSoNgayQuaHan();
            
            loansWithDetails.Add(loanCopy);
        }
        return loansWithDetails;
    }

    public void AddLoan(Loan loan)
    {
        loan.Id = _nextLoanId++;
        _loans.Add(loan);
        
        // Giảm số lượng sách còn lại
        var book = GetBookById(loan.BookId);
        if (book != null && book.SoLuongConLai > 0)
        {
            book.SoLuongConLai--;
            UpdateBook(book);
        }
        
        SaveLoans();
    }

    public void ReturnBook(int loanId)
    {
        var loan = _loans.FirstOrDefault(l => l.Id == loanId);
        if (loan != null)
        {
            loan.NgayTraThucTe = DateTime.Now;
            loan.TrangThai = "Đã trả";
            loan.TinhSoNgayQuaHan();
            
            // Tăng số lượng sách còn lại
            var book = GetBookById(loan.BookId);
            if (book != null)
            {
                book.SoLuongConLai++;
                UpdateBook(book);
            }
            
            SaveLoans();
        }
    }

    public List<Loan> GetActiveLoans()
    {
        return GetLoansWithDetails().Where(l => l.TrangThai == "Đang mượn").ToList();
    }

    public List<Loan> GetOverdueLoans()
    {
        return GetLoansWithDetails()
            .Where(l => l.TrangThai == "Đang mượn" && DateTime.Now > l.NgayHenTra)
            .ToList();
    }
}
