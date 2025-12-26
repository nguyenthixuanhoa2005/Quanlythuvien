use quanlimuonsach;


--cua user. xem danh sach ctpm dang muon
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

--xem da tra

CREATE PROC proc_ReturnedCTPM
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
    WHERE l.status = 'returned'  
    AND l.user_id = @user_id;  
END

------ADMIN-----
--THEM, SUA, XOA PHIEU MUON 
CREATE PROCEDURE AddLoan
    @user_id BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Kiểm tra người dùng tồn tại và active
        IF NOT EXISTS (SELECT 1 FROM Users WHERE user_id = @user_id AND status = 'active')
            THROW 54001, N'Người dùng không tồn tại hoặc đang bị khóa!', 1;

        -- Thêm phiếu mượn mới
        INSERT INTO Loans (user_id)
        VALUES (@user_id);

        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

EXEC AddLoan
    @user_id = 5;
GO
select * from loans;
--------------------
-------------------
----THEM CHI TIET PHIEU MUON
CREATE PROCEDURE AddLoanItems
    @loan_id BIGINT,
    @book_id BIGINT,
    @quantity INT,
    @user_id BIGINT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Kiểm tra user tồn tại
        IF NOT EXISTS (SELECT 1 FROM Users WHERE user_id = @user_id)
            THROW 51000, N'Người dùng không tồn tại!', 1;

        -- Kiểm tra phiếu mượn thuộc về user này
        IF NOT EXISTS (SELECT 1 FROM Loans WHERE loan_id = @loan_id AND user_id = @user_id)
            THROW 52000, N'Phiếu mượn không thuộc về người dùng này!', 1;

        -- Kiểm tra sách tồn tại
        IF NOT EXISTS (SELECT 1 FROM Books WHERE book_id = @book_id)
            THROW 53000, N'Sách không tồn tại!', 1;

        -- Kiểm tra số lượng hợp lệ
        IF @quantity IS NULL OR @quantity <= 0
            THROW 54000, N'Vui lòng nhập số lượng hợp lệ (>=1)!', 1;

        -- Kiểm tra số lượng còn đủ
        DECLARE @available INT = (SELECT available FROM Books WHERE book_id = @book_id);
        IF @available < @quantity
            THROW 55000, N'Không đủ sách để mượn!', 1;

        -- Thêm chi tiết phiếu mượn
        INSERT INTO LoanItems (loan_id, book_id, quantity, status_book)
        VALUES (@loan_id, @book_id, @quantity, 'borrowing');
        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

EXEC AddLoanItems
    @loan_id = 5,
	@user_id = 1,
    @book_id = 1,
    @quantity = 2;
GO

DROP PROCEDURE AddLoanItems;
GO

select loan_id,user_id, loan_date, return_date,due_date, status
from loans;