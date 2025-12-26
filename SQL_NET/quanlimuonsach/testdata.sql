USE quanlimuonsach
GO

-- ============================
-- USERS (10 bản ghi)
-- ============================
INSERT INTO Users (username, name, password, email, phone, role, status) VALUES
(N'hoa123', N'Nguyễn Thị Xuân Hoa', '123', N'hoa@gmail.com', '0923123453', 'member', 'active'),
(N'hoa', N'Nguyễn Thị Xuân Hoa', '123', N'hoa@gmail.com', '0923134453', 'admin', 'active'), 
(N'nguyenvana', N'Nguyễn Văn A', '123456', N'nguyenvana@gmail.com', '0923134454', 'member', 'active'),
(N'lethib', N'Lê Thị B', 'abc123', N'lethib@gmail.com', '0923145356', 'member', 'active'),
(N'phamminhc', N'Phạm Minh C', 'pass789', N'phamminhc@gmail.com', '0913445356', 'admin', 'active'),
(N'dotand', N'Đỗ Tấn D', '123abc', N'dotand@gmail.com', '0903235330', 'member', 'active'),
(N'tranvane', N'Trần Văn E', 'passE', N'tranvane@gmail.com', '0905111222', 'member', 'active'),
(N'lythif', N'Lý Thị F', 'passF', N'lythif@gmail.com', '0905333444', 'member', 'active'),
(N'hoangvinhg', N'Hoàng Vĩnh G', 'passG', N'hoangvinhg@gmail.com', '0905555666', 'member', 'active'),
(N'daothih', N'Đào Thị H', 'passH', N'daothih@gmail.com', '0905777888', 'member', 'active'),
(N'vuminhk', N'Vũ Minh K', 'passK', N'vuminhk@gmail.com', '0905999000', 'member', 'active');
select * from users;
select * from Loans;
select * from LoanItems;
-- ============================
-- AUTHORS (10 bản ghi)
-- ============================
INSERT INTO Authors (name) VALUES
(N'Nguyễn Nhật Ánh'), -- id 1
(N'Tô Hoài'), -- id 2
(N'Nam Cao'), -- id 3
(N'Ngô Tất Tố'), -- id 4
(N'Vũ Trọng Phụng'), -- id 5
(N'Nguyễn Du'), -- id 6
(N'Ma Văn Kháng'), -- id 7
(N'Trần Đăng Khoa'), -- id 8
(N'Lê Minh Khuê'), -- id 9
(N'Phạm Tiến Duật'); -- id 10

-- ============================
-- CATEGORIES (10 bản ghi)
-- ============================
INSERT INTO Categories (name) VALUES
(N'Truyện thiếu nhi'), -- id 1
(N'Truyện ngắn'), -- id 2
(N'Tiểu thuyết'), -- id 3
(N'Ký sự'), -- id 4
(N'Thơ'), -- id 5
(N'Truyện cười'), -- id 6
(N'Văn học cổ điển'), -- id 7
(N'Giáo dục'), -- id 8
(N'Lịch sử'), 
(N'Tự truyện'); 

-- ============================
-- BOOKS (10 bản ghi)
-- ============================
INSERT INTO Books (title, cate_id, total, available, publishing_house, year) VALUES
(N'Mắt biếc', 3, 10, 10, N'NXB Kim Đồng', 1990), 
(N'Dế mèn phiêu lưu ký', 1, 8, 8, N'NXB AHIHI', 1930), 
(N'Lão Hạc', 2, 5, 5, N'NXB Tuổi trẻ', 1974), 
(N'Tắt đèn', 3, 7, 7, N'NXB Kim Đồng', 1990), 
(N'Số đỏ', 3, 6, 6, N'NXB Kim Đồng', 1990), 
(N'Truyện Kiều', 7, 9, 9, N'NXB Kim Đồng', 1990), -- id 6
(N'Mùa lá rụng trong vườn', 3, 5, 5, N'NXB Kim Đồng', 1990), -- id 7
(N'Hạt gạo làng ta', 5, 4, 4, N'NXB Kim Đồng', 1990), -- id 8
(N'Góc sân và khoảng trời', 5, 10, 10, N'NXB Giáo dục', 1989), -- id 9
(N'Những ngôi sao xa xôi', 2, 7, 7, N'NXB Văn học', 1971); -- id 10

-- ============================
-- BOOK AUTHORS (liên kết)
-- ============================
INSERT INTO BookAuthors (book_id, author_id) VALUES
(2, 4),
(1, 2),
(1, 1),
(2, 2), 
(3, 3), 
(4, 4), 
(5, 5), 
(6, 6), 
(7, 7), 
(8, 8), 
(9, 8),
(10, 9);

-- ============================
-- LOANS (10 bản ghi)
-- ============================
INSERT INTO Loans (user_id, loan_date, status) VALUES
(1, DATEADD(day, -10, GETDATE()), 'returned'), -- Giả lập các ngày mượn khác nhau
(2, DATEADD(day, -5, GETDATE()), 'borrowing'),
(3, DATEADD(day, -7, GETDATE()), 'returned'),
(4, DATEADD(day, -3, GETDATE()), 'borrowing'),
(5, DATEADD(day, -2, GETDATE()), 'borrowing'),
(6, DATEADD(day, -8, GETDATE()), 'returned'),
(7, DATEADD(day, -1, GETDATE()), 'borrowing'),
(8, DATEADD(day, -15, GETDATE()), 'returned'),
(9, DATEADD(day, -4, GETDATE()), 'borrowing'),
(10, DATEADD(day, -6, GETDATE()), 'borrowing');

-- ============================
-- LOAN ITEMS (Mỗi phiếu mượn có thể có 1 hoặc nhiều sách)
-- ============================
INSERT INTO LoanItems (loan_id, book_id, status_book) VALUES
(1, 1, 'returned'),
(2, 2, 'borrowing'),
(2, 3, 'borrowing'), -- Mượn 2 cuốn
(3, 4, 'returned'),
(4, 5, 'borrowing'),
(5, 6, 'borrowing'),
(6, 7, 'returned'),
(6, 1, 'returned'), -- Mượn 2 cuốn
(7, 8, 'borrowing'),
(8, 9, 'returned'),
(9, 10, 'borrowing'),
(9, 2, 'borrowing'), -- Mượn 2 cuốn
(10, 3, 'borrowing');

-- ============================
-- SELECTS
-- ============================
select * from Users;
select * from Authors;
select * from Categories;
select * from Books;
select * from BookAuthors;
select * from Loans;
select * from LoanItems;