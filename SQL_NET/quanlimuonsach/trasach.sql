USE quanlimuonsach;
GO

-- Xóa proc cũ nếu có
IF OBJECT_ID('ReturnBook', 'P') IS NOT NULL
    DROP PROC ReturnBook;
GO

CREATE PROCEDURE ReturnBook
    @loan_id BIGINT,
    @book_id BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        ---------------------------------------------
        -- 1️⃣ Kiểm tra sách này có trong phiếu không
        ---------------------------------------------
        IF NOT EXISTS (
            SELECT 1 FROM LoanItems 
            WHERE loan_id = @loan_id AND book_id = @book_id
        )
            THROW 51010, N'Sách không thuộc phiếu mượn này!', 1;

        --------------------------------------------------
        -- 2️⃣ Lấy số lượng mượn để cộng trả vào Books
        --------------------------------------------------
        DECLARE @quantity INT;
        SELECT @quantity = quantity 
        FROM LoanItems 
        WHERE loan_id = @loan_id 
        AND book_id = @book_id;

        ---------------------------------------------
        -- 3️⃣ Cập nhật trạng thái sách → returned
        ---------------------------------------------
        UPDATE LoanItems
        SET status_book = 'returned'
        WHERE loan_id = @loan_id AND book_id = @book_id;

        ---------------------------------------------------
        -- 4️⃣ Cập nhật Books.available + số lượng trả
        ---------------------------------------------------
        UPDATE Books
        SET available = available + @quantity
        WHERE book_id = @book_id;

        ---------------------------------------------------
        -- 5️⃣ Kiểm tra xem tất cả sách đã được trả chưa
        ---------------------------------------------------
        IF NOT EXISTS (
            SELECT 1 FROM LoanItems 
            WHERE loan_id = @loan_id AND status_book = 'borrowing'
        )
        BEGIN
            -- cập nhật phiếu mượn → returned
            UPDATE Loans
            SET status = 'returned',
                return_date = GETDATE()
            WHERE loan_id = @loan_id;
        END

        COMMIT TRANSACTION;

        PRINT N'✅ Trả sách thành công!';
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

