Acreate database quanlimuonsach;
go 
use quanlimuonsach;

GRANT INSERT ON Users TO hoa;

IF OBJECT_ID(' trg_LoanItems_ValidateAndUpdate', 'TR') IS NOT NULL DROP TRIGGER  trg_LoanItems_ValidateAndUpdate;
IF OBJECT_ID('trg_LoanItems_PreventOverBorrow', 'TR') IS NOT NULL DROP TRIGGER trg_LoanItems_PreventOverBorrow;

-- Xóa bảng theo thứ tự khóa ngoại (bảng con trước, cha sau)
IF OBJECT_ID('LoanItems', 'U') IS NOT NULL DROP TABLE LoanItems;
IF OBJECT_ID('Loans', 'U') IS NOT NULL DROP TABLE Loans;
IF OBJECT_ID('BookAuthors', 'U') IS NOT NULL DROP TABLE BookAuthors;
IF OBJECT_ID('Books', 'U') IS NOT NULL DROP TABLE Books;
IF OBJECT_ID('Categories', 'U') IS NOT NULL DROP TABLE Categories;
IF OBJECT_ID('Authors', 'U') IS NOT NULL DROP TABLE Authors;
IF OBJECT_ID('Users', 'U') IS NOT NULL DROP TABLE Users;

CREATE TABLE Users (
    user_id BIGINT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(50) NOT NULL UNIQUE,
	name nvarchar (50) COLLATE Latin1_General_CS_AS NULL, --Ràng buộc cấp độ cột
    password VARCHAR(255) COLLATE Latin1_General_CS_AS NOT NULL,
    email NVARCHAR(50) CHECK (email LIKE '%_@__%.__%'),
	phone NVARCHAR(10) CHECK (phone NOT LIKE '%[^0-9]%'), -- Chỉ cho phép số
    role NVARCHAR(10) NOT NULL CHECK (role IN ('member', 'admin')),
    status NVARCHAR(10) NOT NULL DEFAULT 'active' CHECK (status IN ('active', 'block'))
);
-- Sửa đổi cột 'name'
ALTER TABLE USERS
ALTER COLUMN name NVARCHAR(50) COLLATE Latin1_General_CS_AS NOT NULL;

-- Sửa đổi cột 'password'
ALTER TABLE USERS
ALTER COLUMN password VARCHAR(255) COLLATE Latin1_General_CS_AS NOT NULL;

CREATE TABLE Authors (
    author_id BIGINT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(50) NOT NULL DEFAULT N'Unknown'
);

CREATE TABLE Categories (
    cate_id BIGINT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(50) NOT NULL
);

CREATE TABLE Books (
    book_id BIGINT IDENTITY(1,1) PRIMARY KEY,
    title NVARCHAR(100) NOT NULL,
    cate_id BIGINT,
    total INT NOT NULL DEFAULT 0 CHECK (total >= 0),
	year int not null check (year >= 1800 and year <2025),
	publishing_house nvarchar (40),
    available INT NOT NULL DEFAULT 0 CHECK (available >= 0),  
    FOREIGN KEY (cate_id) REFERENCES Categories(cate_id),
    CONSTRAINT CK_Books_Available_Total CHECK (available <= total)
);

CREATE TABLE BookAuthors (
    book_id BIGINT NOT NULL,
    author_id BIGINT NOT NULL,
    PRIMARY KEY (book_id, author_id),
    FOREIGN KEY (book_id) REFERENCES Books(book_id),
    FOREIGN KEY (author_id) REFERENCES Authors(author_id)
);

CREATE TABLE Loans (
    loan_id BIGINT IDENTITY(1,1) PRIMARY KEY,
    user_id BIGINT NOT NULL,
    loan_date DATE NOT NULL DEFAULT GETDATE(),
    return_date DATE NULL,
    CONSTRAINT CK_LoanItems_ReturnDate CHECK (
        return_date IS NULL OR return_date >= loan_date
    ),
    status NVARCHAR(10) NOT NULL DEFAULT 'borrowing' CHECK (status IN ('borrowing', 'returned')),
    due_date AS DATEADD(DAY, 30, loan_date),
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

CREATE TABLE LoanItems (
    loan_item_id BIGINT IDENTITY(1,1),
    loan_id BIGINT NOT NULL,
    book_id BIGINT NOT NULL,
	quantity bigint not null DEFAULT 1 CHECK (quantity > 0),
    status_book NVARCHAR(10) NOT NULL DEFAULT 'borrowing'
    CHECK (status_book IN ('borrowing', 'returned', 'overdue')),
    PRIMARY KEY (loan_id, book_id),
    FOREIGN KEY (loan_id) REFERENCES Loans(loan_id),
    FOREIGN KEY (book_id) REFERENCES Books(book_id)
);
go

CREATE OR ALTER TRIGGER trg_LoanItems_ValidateAndUpdate
ON LoanItems
FOR INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- CẬP NHẬT LẠI AVAILABLE = TOTAL – SỐ ĐANG MƯỢN
    UPDATE B
    SET available =
        B.total - ISNULL((
            SELECT SUM(LI.quantity)
            FROM LoanItems LI
            WHERE LI.book_id = B.book_id
              AND LI.status_book IN ('borrowing','overdue')
        ), 0)
    FROM Books B
    WHERE B.book_id IN (
        SELECT book_id FROM inserted
        UNION
        SELECT book_id FROM deleted
    );
END;
GO

-- ✅ Trigger 3: Tự động cập nhật trạng thái phiếu mượn
CREATE TRIGGER trg_LoanItems_SyncLoanStatus
ON LoanItems
FOR INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Khi tất cả sách trong phiếu đã trả
    UPDATE L
    SET L.status = 'returned',
        L.return_date = GETDATE()
    FROM Loans L
    WHERE L.loan_id IN (
        SELECT LI.loan_id
        FROM LoanItems LI
        GROUP BY LI.loan_id
        HAVING COUNT(*) = SUM(CASE WHEN LI.status_book = 'returned' THEN 1 ELSE 0 END)
    )
    AND L.status <> 'returned';

    -- Khi vẫn còn sách chưa trả
    UPDATE L
    SET L.status = 'borrowing',
        L.return_date = NULL
    FROM Loans L
    WHERE L.loan_id IN (
        SELECT DISTINCT LI.loan_id
        FROM LoanItems LI
        WHERE LI.status_book IN ('borrowing', 'overdue')
    )
    AND L.status <> 'borrowing';
END;
go 

