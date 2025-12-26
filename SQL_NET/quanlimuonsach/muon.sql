use quanlimuonsach;


--select lấy ctphieeus mượn
-- Select lấy chi tiết phiếu mượn theo user_id
CREATE PROC proc_SelectCTPM
    @user_id BIGINT
AS
BEGIN
    SELECT 
        l.loan_id,
        li.loan_item_id,
        b.book_id ,
        b.title,
        l.loan_date,
        l.due_date,
        li.quantity,
        l.status 
    FROM LoanItems li
    JOIN Loans l ON li.loan_id = l.loan_id
    JOIN Books b ON li.book_id = b.book_id
    WHERE l.status = 'borrowing'  
    AND l.user_id = @user_id;  
END

exec proc_SelectCTPM
	@user_id = 4;
drop proc proc_SelectCTPM;

--FILE NÀY CHƯA CHẠY GÌ HẾT---------------
-- =============================================
-- THÊM SÁCH VÀO PHIẾU MƯỢN (SỬ DỤNG BẢNG TẠM)--đây là của người dùng, chỉ bấm chọn sachs và nút
-- =============================================

CREATE TABLE TempBorrowItems (
    temp_id BIGINT IDENTITY(1,1) PRIMARY KEY,
    user_id BIGINT NOT NULL,
    book_id BIGINT NOT NULL,
    quantity INT NOT NULL DEFAULT 1 CHECK (quantity > 0),
    added_date DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES Users(user_id),
    FOREIGN KEY (book_id) REFERENCES Books(book_id)
);
drop proc proc_AddToTempBorrowItems;
drop proc proc_ConfirmBorrow;
drop proc proc_SelectTempBorrow;
drop proc proc_RemoveItemFromTempBorrow;
CREATE PROC proc_SelectTempBorrow
    @user_id BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        t.book_id,
        b.title AS TenSach,
        t.quantity AS SoLuongMuon
    FROM TempBorrowItems t
    INNER JOIN Books b ON t.book_id = b.book_id
    WHERE t.user_id = @user_id
END;
GO

CREATE OR ALTER proc proc_AddToTempBorrowItems
    @user_id BIGINT,
    @book_id BIGINT,
    @quantity INT
AS
BEGIN
    DECLARE @total INT;
    DECLARE @borrowed INT;
    DECLARE @old_quantity INT;

    -- Tổng sách hiện có
    SELECT @total = total FROM Books WHERE book_id = @book_id;

    -- Số lượng đang mượn (borrowing + overdue)
    SELECT @borrowed = ISNULL(SUM(quantity),0)
    FROM LoanItems
    WHERE book_id = @book_id
      AND status_book IN ('borrowing','overdue');

    -- Số lượng đã có trong giỏ tạm
    SELECT @old_quantity = ISNULL(quantity,0)
    FROM TempBorrowItems
    WHERE user_id = @user_id AND book_id = @book_id;

    -- Kiểm tra số lượng mượn có vượt quá tổng
    IF @old_quantity + @quantity + @borrowed > @total
    BEGIN
        THROW 51001, N'Số lượng mượn vượt quá số sách hiện có.', 1;
    END

    -- Nếu đã có trong giỏ, update
    IF @old_quantity > 0
    BEGIN
        UPDATE TempBorrowItems
        SET quantity = quantity + @quantity,
            added_date = GETDATE()
        WHERE user_id = @user_id AND book_id = @book_id;

        PRINT N'✅ Đã cập nhật số lượng trong giỏ mượn.';
    END
    ELSE -- Nếu chưa có, insert mới
    BEGIN
        INSERT INTO TempBorrowItems (user_id, book_id, quantity)
        VALUES (@user_id, @book_id, @quantity);

        PRINT N'✅ Đã thêm sách vào giỏ mượn.';
    END;
END
GO
select * from Books;
exec proc_AddToTempBorrowItems
@user_id = 13,
@book_id = 12
@quantity = 1;

CREATE OR ALTER PROCEDURE proc_ConfirmBorrow
    @user_id BIGINT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @loan_id BIGINT;
    BEGIN TRY
        BEGIN TRANSACTION;
        -- 1. Kiểm tra giỏ có rỗng không
        IF NOT EXISTS (SELECT 1 FROM TempBorrowItems WHERE user_id = @user_id)
            THROW 50010, N'Không có sách nào trong giỏ.', 1;
        -- 2. Tự kiểm tra tồn kho SIÊU CHUẨN — không lệ thuộc trigger
        IF EXISTS (
            SELECT 1
            FROM TempBorrowItems T
            JOIN Books B ON T.book_id = B.book_id
            WHERE T.user_id = @user_id
            AND T.quantity >
                (B.total -
                    ISNULL((
                        SELECT SUM(LI.quantity)
                        FROM LoanItems LI
                        WHERE LI.book_id = B.book_id
                          AND LI.status_book IN ('borrowing','overdue')
                    ), 0)
                )
        )
        BEGIN
            THROW 50011, N'Sách không đủ số lượng để mượn!', 1;
        END
        -- 3. Tạo phiếu mượn
        INSERT INTO Loans (user_id)
        VALUES (@user_id);
        SET @loan_id = SCOPE_IDENTITY();
        -- 4. Tạo LoanItems
        INSERT INTO LoanItems (loan_id, book_id, quantity, status_book)
        SELECT 
            @loan_id, book_id, quantity, 'borrowing'
        FROM TempBorrowItems
        WHERE user_id = @user_id;
        -- 5. Cập nhật tồn kho (available) — KHÔNG cần trigger
        UPDATE B
        SET available =
            B.total - ISNULL((
                SELECT SUM(LI.quantity)
                FROM LoanItems LI
                WHERE LI.book_id = B.book_id
                  AND LI.status_book IN ('borrowing','overdue')
            ), 0)
        FROM Books B
        WHERE B.book_id IN (SELECT book_id FROM TempBorrowItems WHERE user_id = @user_id);
        -- 6. Xóa giỏ
        DELETE FROM TempBorrowItems
        WHERE user_id = @user_id;


        COMMIT TRANSACTION;

        PRINT N'Xác nhận mượn thành công! Loan ID: ' + CAST(@loan_id AS NVARCHAR(20));
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

--xóa giỏ
CREATE PROCEDURE proc_ClearTempBorrow
    @user_id BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Kiểm tra có sách trong giỏ không
        IF NOT EXISTS (SELECT 1 FROM TempBorrowItems WHERE user_id = @user_id)
        BEGIN
            THROW 52000, N'Không có gì để xóa.', 1;
        END
        -- Xóa giỏ tạm
        DELETE FROM TempBorrowItems
        WHERE user_id = @user_id;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO
--xóa 1 sách
CREATE PROCEDURE proc_RemoveItemFromTempBorrow
    @user_id BIGINT,
    @book_id BIGINT
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        -- Thực hiện xóa mục sách khỏi bảng tạm
        DELETE FROM TempBorrowItems
        WHERE user_id = @user_id AND book_id = @book_id;

        COMMIT TRANSACTION;
        PRINT N'Đã xóa sách khỏi giỏ mượn thành công.';
        
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0
            ROLLBACK TRANSACTION;
        THROW; 
    END CATCH
END;
GO
======================================================

--CAP NHAT THONG TIN CHI TIẾT PHIEU MUON --ADMIN (KO CHO SUA TRANG THAI PHIEU VI DAY CHI LA SUA THONG TIN)

--hạn trả của 1 phiếu mượn sẽ là khi tất cả các sách trg ctpm đó được trả hết
--mã phiếu mượn sẽ là phiếu mượn của user (có thể trùng khi hiển thị vì 1 phiếu mượn được nhiều sách)

/*CREATE PROC UpdateLoans
	@loan_id bigint,
	@user_id bigint,
	@book_id bigint,
	@loan_date date,
	@quantity int
as*/

--status ko can vi co trigger tu cap nhat
--TRA SACH == CAP NHAT TRANG THAI PHIEU MUON
--ko cần check điều kiện vì trên form sẽ chỉ mở cho sửa trạng thái và loan_id sẽ đựoc giữ nguyên
CREATE PROCEDURE ReturnBook
    @loan_id BIGINT,
    @book_id BIGINT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
			UPDATE LoanItems
			SET status_book = 'returned'
			WHERE loan_id = @loan_id AND book_id = @book_id;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO
EXEC ReturnBook 
	@loan_id  = 3,
	@book_id = 4

drop proc ReturnBook;
--HIEN THONG TIN phiếu mượn đã được trả hết --> NO LA SELECT CAC PHIEU MUON VS STATUS = 'RETURNED'
SELECT 
    L.loan_id,
    U.name AS user_name,
    B.title AS book_title,
    LI.quantity AS quantity_borrowed,
    L.loan_date,
    L.return_date,
    L.status
FROM Loans L
JOIN Users U ON L.user_id = U.user_id
JOIN LoanItems LI ON L.loan_id = LI.loan_id
JOIN Books B ON LI.book_id = B.book_id
WHERE L.status = 'returned';

--Hiển thị thông tin các sách đã trả
SELECT * from LoanItems
where status_book = 'returned'

SELECT COUNT(DISTINCT book_id) FROM TempBorrowItems WHERE user_id = 2
select * from LoanItems
select * from users;
--XOA PHIEU MUON (1. CAC SACH TRG CTPHIEU MUON PHAI DC RETURNED HET---> VI DA CO TRIGGER CHUYEN TRANG THAI---> CHI CAN XOA PHIEU VOI STATUS = 'RETURNED' LA OK)
CREATE PROC DeleteLoan
	@loan_id BIGINT
AS
BEGIN 
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION;

		DECLARE @status NVARCHAR (10);
		SELECT @status = status from Loans where loan_id = @loan_id; --tìm phiếu mượn dựa trên loan_id truyền vào
		--xem cột status và gán vào @status
		--nếu ko tìm thấy phiếu mượn nào ---> status = null

		--IF @status IS NULL
			--THROW 50014, N'Phiếu mượn không tồn tại!!', 1; 
		-- that ra cai nay 0 can vì bên kia sẽ lấy luôn phiếu mượn đang click vào --> auto có
		IF @status <> 'returned'
			THROW 50015, N'Chỉ được xóa phiếu khi đã trả hết sách!!', 1;
		DELETE FROM LoanItems where loan_id = @loan_id;
		DELETE FROM Loans where loan_id = @loan_id;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
		THROW;
	END CATCH
END;
GO

DROP PROC DeleteLoan;
EXEC DeleteLoan
	@loan_id = 2;


-----XOA PHIEU TRONG CTPHIEUMUON----
CREATE PROCEDURE DeleteLoanItem
    @loan_id BIGINT,
    @book_id BIGINT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        DECLARE @status_book NVARCHAR(10);
        SELECT @status_book = status_book 
        FROM LoanItems 
        WHERE loan_id = @loan_id AND book_id = @book_id;

        IF @status_book <> 'returned'
            THROW 50022, N'Chỉ được xóa sách đã được trả!', 1;

        DELETE FROM LoanItems 
        WHERE loan_id = @loan_id AND book_id = @book_id;

        -- Nếu phiếu không còn sách → xóa luôn phiếu
        IF NOT EXISTS (SELECT 1 FROM LoanItems WHERE loan_id = @loan_id)
            DELETE FROM Loans WHERE loan_id = @loan_id;
            PRINT N'Chi tiết phiếu mượn rỗng --> Đã xóa phiéu mượn của người dùng';
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW; -- ném lỗi cho C# hoặc app bắt
    END CATCH
END;
GO
DROP PROC DeleteLoanItem;
EXEC DeleteLoanItem 
    @loan_id = 3, 
    @book_id = 4;



--ADMIN---
--HIẺN THỊ BẢNG--
    SELECT 
        l.loan_id,
        li.loan_item_id,
        b.book_id ,
        b.title,
        l.loan_date,
        l.due_date,
        li.quantity,
        l.status 
    FROM LoanItems li
    JOIN Loans l ON li.loan_id = l.loan_id
    JOIN Books b ON li.book_id = b.book_id  
	SELECT * FROM TempBorrowItems WHERE user_id = 13 AND book_id = 12;
SELECT available FROM Books WHERE book_id = 12;

SELECT 
    b.book_id,
    b.title,
    b.total,
    b.available,
    ISNULL(SUM(li.quantity), 0) AS quantity_borrowed
FROM Books b
LEFT JOIN LoanItems li ON b.book_id = li.book_id AND li.status_book IN ('borrowing', 'overdue')
WHERE b.book_id = 12
GROUP BY b.book_id, b.title, b.total, b.available;


UPDATE Books
SET available = total - ISNULL((
    SELECT SUM(quantity)
    FROM LoanItems
    WHERE book_id = Books.book_id
      AND status_book IN ('borrowing', 'overdue')
), 0)
WHERE book_id = 12;

SELECT * FROM LoanItems WHERE book_id = 12;

