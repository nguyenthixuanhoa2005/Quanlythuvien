use quanlimuonsach;
go
--
select * from Users;
--
INSERT INTO Users (username, name, password, email, phone, role, status) VALUES
(N'hoa', N'Nguyễn Thị Xuân Hoa', '123', N'hoa@gmail.com', '0923134453', 'admin', 'active'), 
--

--NGĂN K CHO XÓA ---> INSTEAD OF || ko dùng for deleter hay after delete vì nó là xử lý sau khi thực hiện
CREATE TRIGGER trg_PreventDeleteDocGia
ON Users
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON
    -- Kiểm tra độc giả có đang mượn sách
    IF EXISTS (
        SELECT 1
        FROM Loans
		--Join tu bang ao deleted --chua cac ban ghi da bi xoa--> join Users với deleted để xóa đúng bản ghi mà user muốn xóa
        INNER JOIN deleted ON Loans.user_id = deleted.user_id   
        WHERE Loans.return_date IS NULL
    )
    BEGIN
        -- Nếu có thì báo lỗi
        RAISERROR('Không thể xóa độc giả đang mượn sách!', 16, 1);
        RETURN;
    END

    -- Nếu không có độc giả nào đang mượn sách, thực hiện xóa
    DELETE Users
    FROM Users
    INNER JOIN deleted ON Users.user_id = deleted.user_id; --xoa thuc su
END;


drop trigger  trg_PreventDeleteDocGia;
create proc deleteUser
	@user_id bigint
as
begin
	set nocount on;
	DELETE FROM Users WHERE user_id = @user_id;
end

drop proc deleteUser;

------------------
-------------------
--Nói chung là viết if để bắt lỗi theo cơ sở dữ liệu r ném lỗi qua bên kia để nó bắt r hiển thị
CREATE PROCEDURE UpdateUser
    @user_id BIGINT,
    @username NVARCHAR(50),
    @name NVARCHAR(50),
	@password nvarchar (30),
    @email NVARCHAR(50),
    @phone NVARCHAR(10),
    @status NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Kiểm tra dữ liệu hợp lệ
        IF NOT EXISTS (SELECT 1 FROM Users WHERE user_id = @user_id)
            THROW 50000, 'Người dùng không tồn tại!', 1; 

        IF @email NOT LIKE '%_@__%.__%'
            THROW 50001, 'Email không hợp lệ!', 1;

		IF TRY_CAST(@phone AS BIGINT) IS NULL OR LEN(@phone) != 10 --try_cast: chuyển kiểu dữ liệu, nếu như mà ko chuyển được thì nó sẽ thành null chứ ko lỗi
			THROW 50003, 'Số điện thoại phải gồm 10 chữ số!', 1;


        -- Cập nhật thông tin
        UPDATE Users
        SET username = @username,
            name = @name,
            email = @email,
            phone = @phone,
            status = @status,
			password = @password
        WHERE user_id = @user_id;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        --Ném lỗi lại cho bên c# bắt ( ko có nó sẽ chỉ thấy rollback --> dữ liệu đúng --> nma lại  hiển thị cập nhật thành công)
		THROW;
	END CATCH
END

-----Mặc định role là member
drop proc UpdateUser;
EXEC UpdateUser
    @user_id = 5,
	@username = N'hihi',
    @name = N'Nguyen Van A',
	@password = '123',
    @email = 'vana@example.com',
    @phone = '0909123456',
    @status = 'active';


select * from Users;

-------------------------------
CREATE PROCEDURE AddUser
    @username NVARCHAR(50),
    @name NVARCHAR(50),
    @password NVARCHAR(30),
    @email NVARCHAR(50),
    @phone NVARCHAR(10),
    @status NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Kiểm tra trùng username
        IF EXISTS (SELECT 1 FROM Users WHERE username = @username)
            THROW 50010, 'Tên đăng nhập đã tồn tại!', 1;

        -- Kiểm tra email hợp lệ
        IF @email NOT LIKE '%_@__%.__%'
            THROW 50011, 'Email không hợp lệ!', 1;

        -- Kiểm tra định dạng số điện thoại
        IF TRY_CAST(@phone AS BIGINT) IS NULL OR LEN(@phone) != 10
            THROW 50012, 'Số điện thoại phải gồm 10 chữ số!', 1;

        -- Thêm người dùng mới
        INSERT INTO Users (username, name, password, email, phone, role, status)
        VALUES (@username, @name, @password, @email, @phone, 'member', @status);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END

drop proc adduser;
EXEC AddUser
    @username = N'thuy',
    @name = N'Nguyễn Thị Thúy',
    @password = N'123',
    @email = N'thuy@gmail.com',
    @phone = N'0912345678',
    @status = N'active';
