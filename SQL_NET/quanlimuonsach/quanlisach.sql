use quanlimuonsach;

-- truy vấn với đầy đủ thong tin cho từng quyển sách
SELECT b.book_id, b.title,b.year,b.publishing_house,b.total,b.available, c.name AS category, STRING_AGG(a.name, ', ') AS authors
FROM Books b
LEFT JOIN Categories c ON b.cate_id = c.cate_id
LEFT JOIN BookAuthors ba ON b.book_id = ba.book_id
LEFT JOIN Authors a ON ba.author_id = a.author_id
GROUP BY b.book_id, b.title,b.year,b.publishing_house,b.total,b.available, c.name;

-- TRUY VẤN VỚI ĐẦY ĐỦ THONG TIN CỦA ĐỌC GIẢ
select * from Users;

-- Truy vấn thông tin mượn sách
select l.loan_id, l.user_id, l.loan_date, l.due_date, li.book_id, l.return_date, li.status_book, us.name
from Loans as l, LoanItems as li, Users as us
where li.loan_id = l.loan_id 
and us.user_id = l.user_id


-- xoa 1 quyen sach 
CREATE PROCEDURE DeleteBook
    @BookId BIGINT
AS
BEGIN
    SET NOCOUNT ON;
    -- Kiểm tra sách có tồn tại không
    IF NOT EXISTS (SELECT 1 FROM Books WHERE book_id = @BookId)
    BEGIN
        PRINT N'Sách không tồn tại.';
        RETURN;
    END
	IF EXISTS (SELECT 1 FROM LoanItems WHERE book_id = @BookId AND status_book = 'borrowing')
    BEGIN
        THROW 50001, 'Sách đang được mượn, không thể xóa.', 1;
        RETURN;
    END

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Xóa dữ liệu liên quan trong bảng con trước
        DELETE FROM LoanItems WHERE book_id = @BookId;
        DELETE FROM BookAuthors WHERE book_id = @BookId;

        -- Xóa chính quyển sách
        DELETE FROM Books WHERE book_id = @BookId;

        COMMIT TRANSACTION;
        PRINT N'Đã xóa sách thành công.';
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT N'Lỗi khi xóa sách: ' + ERROR_MESSAGE();
    END CATCH
END;
GO
exec DeleteBook 3
select * from Books;
drop proc DeleteBook;

-- update thông tin sách.
CREATE PROCEDURE UpdateInforBook
    @book_id BIGINT,
    @title NVARCHAR(100),
    @year INT,
    @publishing_house NVARCHAR(40), 
    @total INT,
    @available INT,
    @cate NVARCHAR(50),
    @AuthorsCSV NVARCHAR(MAX) -- 'Tác giả A,Tác giả B'
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRAN;

        -- Lấy cate_id trước để gộp UPDATE
        DECLARE @cate_id BIGINT;
        SELECT @cate_id = cate_id FROM Categories WHERE name = @cate; -- Dùng = thay vì LIKE

        IF @cate_id IS NULL
        BEGIN
            -- Nếu thể loại chưa có, tạo mới
            INSERT INTO Categories(name) VALUES (@cate);
            SET @cate_id = SCOPE_IDENTITY();
        END

        -- 1. Update thông tin sách cơ bản (gộp cả cate_id)
        UPDATE Books
        SET title = @title,
            year = @year,
            publishing_house = @publishing_house,
            total = @total,
            available = @available,
            cate_id = @cate_id -- Gộp vào đây
        WHERE book_id = @book_id;

        -- 2. Đồng bộ Authors 
        IF @AuthorsCSV IS NOT NULL AND LTRIM(RTRIM(@AuthorsCSV)) <> ''
        BEGIN
            -- Tạo bảng tạm chứa tên tác giả từ CSV
            DECLARE @tmp TABLE (Name NVARCHAR(200) PRIMARY KEY);

            INSERT INTO @tmp(Name)
            SELECT DISTINCT LTRIM(RTRIM(value))
            FROM STRING_SPLIT(@AuthorsCSV, ',')
            WHERE value IS NOT NULL AND LTRIM(RTRIM(value)) <> '';

            -- Thêm tác giả mới vào bảng Authors nếu chưa tồn tại
            INSERT INTO Authors(name)
            SELECT t.Name
            FROM @tmp t
            LEFT JOIN Authors a ON a.name = t.Name
            WHERE a.author_id IS NULL;

            -- Thêm các liên kết mới (sách - tác giả)
            INSERT INTO BookAuthors (book_id, author_id)
            SELECT DISTINCT
                @book_id, a.author_id
            FROM Authors a
            INNER JOIN @tmp t ON a.name = t.Name
            LEFT JOIN BookAuthors ba
                ON ba.book_id = @book_id AND ba.author_id = a.author_id
            WHERE ba.book_id IS NULL; -- Chỉ chèn những liên kết chưa tồn tại

            -- Xóa các liên kết cũ (tác giả không còn trong CSV)
            DELETE ba
            FROM BookAuthors ba
            INNER JOIN Authors a2 ON ba.author_id = a2.author_id
            LEFT JOIN @tmp t2 ON a2.name = t2.Name
            WHERE ba.book_id = @book_id AND t2.Name IS NULL; -- Tác giả có trong CSDL nhưng không có trong CSV mới
        END
        ELSE
        BEGIN
            -- Nếu CSV là rỗng => Xóa tất cả tác giả liên kết với sách này
            DELETE FROM BookAuthors WHERE book_id = @book_id;
        END

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
		ROLLBACK TRANSACTION;
        THROW; 
    END CATCH
END
GO


EXEC UpdateInforBook
    @book_id = 3,
    @title = N'Cuốn sách cũ',
    @year = 2024,
    @publishing_house = N'NXB Kim Đồng',
    @total = 100,
    @available = 95,
    @cate = N'Thiếu nhi',
    @AuthorsCSV = N'Nguyen Van A,Tran Thi B';

drop proc UpdateInforBook

--thêm thông tin sách
CREATE PROCEDURE AddInforBook
    @title NVARCHAR(100),
    @year INT,
    @publishing_house NVARCHAR(40), 
    @total INT,
    @available INT,
    @cate NVARCHAR(50),
    @AuthorsCSV NVARCHAR(MAX) 
AS
BEGIN
    SET NOCOUNT ON;

    IF @title IS NULL OR LTRIM(RTRIM(@title)) = N''
        THROW 50004, N'Tiêu đề sách không được để trống.', 1;
        
    IF @cate IS NULL OR LTRIM(RTRIM(@cate)) = N''
        THROW 50005, N'Thể loại không được để trống.', 1;

    -- Các kiểm tra này khớp với CHECK constraints trong bảng của bạn
    IF @year < 1800 OR @year >= 2025
        THROW 50006, N'Năm xuất bản không hợp lệ (phải từ 1800-2024).', 1;
        
    IF @total < 0
        THROW 50007, N'Tổng số lượng không được âm.', 1;
        
    IF @available < 0
        THROW 50008, N'Số lượng có sẵn không được âm.', 1;

    IF @available > @total
        THROW 50009, N'Số lượng có sẵn không thể lớn hơn tổng số lượng.', 1;
  
    DECLARE @BookID BIGINT, @cate_id BIGINT;

    BEGIN TRY
        BEGIN TRANSACTION; 

        -- --- Bước 2a: Xử lý Thể loại (lấy ID hoặc tạo mới) ---
        -- Phải làm bước này TRƯỚC khi thêm sách
        SELECT @cate_id = cate_id FROM Categories WHERE name = @cate;
        
        IF @cate_id IS NULL
        BEGIN
            INSERT INTO Categories(name) VALUES (@cate);
            SET @cate_id = SCOPE_IDENTITY();
        END

        -- --Thêm sách mới ---
        INSERT INTO Books (Title, Year, publishing_house, Total, Available, cate_id)
        VALUES (@title, @year, @publishing_house, @total, @available, @cate_id);

        SET @BookID = SCOPE_IDENTITY(); -- Lấy ID sách vừa thêm

        -- --- Xử lý Tác giả ---
        IF @AuthorsCSV IS NOT NULL AND LTRIM(RTRIM(@AuthorsCSV)) <> ''
        BEGIN
            -- Dùng bảng tạm để chứa tên tác giả đã tách
            DECLARE @tmpAuthors TABLE (Name NVARCHAR(200) PRIMARY KEY);

            INSERT INTO @tmpAuthors(Name)
            SELECT DISTINCT LTRIM(RTRIM(value))
            FROM STRING_SPLIT(@AuthorsCSV, ',')
            WHERE value IS NOT NULL AND LTRIM(RTRIM(value)) <> '';

            -- Thêm tác giả mới vào bảng Authors (nếu chưa tồn tại)
            INSERT INTO Authors(name)
            SELECT t.Name
            FROM @tmpAuthors t
            LEFT JOIN Authors a ON a.name = t.Name
            WHERE a.author_id IS NULL;

            -- Gắn tác giả vào sách (bảng BookAuthors)
            INSERT INTO BookAuthors (book_id, author_id)
            SELECT DISTINCT
                @BookID, a.author_id
            FROM Authors a
            INNER JOIN @tmpAuthors t ON a.name = t.Name; -- Chỉ lấy ID của các tác giả có trong CSV
        END
        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH
		--cai nay hien thi trang thai trans
	--<> 0: không bằng 0
	-- 'Chỉ rollback nếu thực sự có một transaction đang mở (state = 1), cái này nó là 
	--kiểu bên trên trong try ví dụ có 1 cái if kiểm tra lỗi --> nó sẽ vẫn chạy hết nma ko commit 
	--> cái state nó = 1 --> 
    -- 'hoặc transaction đang bị lỗi (state = -1).
	--giả sử nếu bên có điều kiện trước khi begin trans thì MỚI CẦN THIẾT DÙNG KO THÌ DÙNG ROLLBACK TRANSACTION LÀ OK
        IF XACT_STATE() <> 0
        ROLLBACK TRANSACTION;
        THROW; 
    END CATCH
END
GO
drop proc addinforbook;
--test điều kiện thì để chuỗi rỗng 
EXEC AddInforBook 
    @title = N'ahihi',
    @year = 2024,
    @publishing_house = N'NXB thanhhoa',
    @total = 30,
    @available = 30,
    @cate = N'12doidep',
    @AuthorsCSV = N'Trần Văn Meo, Kiwwi';

SELECT 
    b.title, 
    c.name AS category, 
    -- HÀM NÀY SẼ GỘP TẤT CẢ TÊN TÁC GIẢ VÀO 1 Ô, NGĂN CÁCH BẰNG DẤU ','
    STRING_AGG(a.name, ', ') AS authors
FROM 
    Books b
LEFT JOIN 
    Categories c ON b.cate_id = c.cate_id
LEFT JOIN 
    BookAuthors ba ON b.book_id = ba.book_id
LEFT JOIN 
    Authors a ON ba.author_id = a.author_id
-- PHẢI GROUP BY ĐỂ NÉN TẤT CẢ CÁC DÒNG CỦA CÙNG 1 QUYỂN SÁCH LẠI
GROUP BY 
    b.book_id, b.title, c.name;