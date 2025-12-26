using Quanlisachcoban.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;



namespace Quanlisachcoban
{
    public partial class QLSachUserControl : UserControl
    {
        public QLSachUserControl()
        {
            InitializeComponent();
            List<Books> data = LoadDataBooks();
            dataGridViewBooks.DataSource = null;
            dataGridViewBooks.Columns.Clear();
            dataGridViewBooks.DataSource = data;
            SetDataGridViewHeader();
            LoadDefaultGroupBoxThongTinSach();
        }

        //valid
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(this.textBoxTenSach.Text) ||
                string.IsNullOrWhiteSpace(this.textBoxTacGia.Text) ||
                string.IsNullOrWhiteSpace(this.textBoxTheLoai.Text) ||
                string.IsNullOrWhiteSpace(this.textBoxNhaXuatBan.Text) ||
                string.IsNullOrWhiteSpace(this.textBoxNamXuatBan.Text) ||
                string.IsNullOrWhiteSpace(this.textBoxTongSoSach.Text) ||
                string.IsNullOrWhiteSpace(this.textBoxSoLuongTon.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            try
            {
                int year = int.Parse(this.textBoxNamXuatBan.Text);
                long total = long.Parse(this.textBoxTongSoSach.Text);
                long available = long.Parse(this.textBoxSoLuongTon.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Năm xuất bản, Tổng số sách và Số lượng tồn phải là số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        //cái này phải đặt trùng tên với tên cột trong model
        private void SetDataGridViewHeader()
        {
            dataGridViewBooks.Columns["book_id"].HeaderText = "Mã sách";
            dataGridViewBooks.Columns["title"].HeaderText = "Tên sách";
            dataGridViewBooks.Columns["year"].HeaderText = "Năm xuất bản";
            dataGridViewBooks.Columns["publishing_house"].HeaderText = "Nhà xuất bản";
            dataGridViewBooks.Columns["total"].HeaderText = "Tổng số sách";
            dataGridViewBooks.Columns["available"].HeaderText = "Số lượng tồn";
            dataGridViewBooks.Columns["category"].HeaderText = "Thể loại";
            dataGridViewBooks.Columns["authors"].HeaderText = "Tác giả";
        }

        private List<Books> LoadDataBooks(string keyword = "", string searchType = "")
        {
            List<Books> listBooks = new List<Books>();
            string query = "SELECT b.book_id, b.title,b.year,b.publishing_house,b.total,b.available, c.name AS category, STRING_AGG(a.name, ', ') AS authors " +
                "FROM Books b " +
                "LEFT JOIN Categories c ON b.cate_id = c.cate_id " +
                "LEFT JOIN BookAuthors ba ON b.book_id = ba.book_id " +
                "LEFT JOIN Authors a ON ba.author_id = a.author_id ";

            //Thêm điều kiện tìm kiếm nếu có  2 tham số được truyền vào 
            if (!string.IsNullOrEmpty(keyword))
            {
                if (searchType == "Mã sách")
                    query += "WHERE CAST(b.book_id AS NVARCHAR) LIKE @keyword ";
                //cast để ép kiểu book id từ int sang nvarchar để so sánh với keyword kiểu string
                else if (searchType == "Tên sách")
                    query += "WHERE b.title LIKE @keyword ";
            }
            query += "GROUP BY b.book_id, b.title, b.year, b.publishing_house, b.total, b.available, c.name";
            try
            {
                using (SqlConnection conn = Ketnoi.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(keyword))
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())  // trả về 1 bảng
                    {
                        while (reader.Read()) // đọc từng dòng trong bảng
                        {
                            var b = new Books
                            {
                                //[] : phai trung ten cot trong query
                                book_id = reader["book_id"] != DBNull.Value ? Convert.ToInt64(reader["book_id"]) : 0,
                                title = reader["title"]?.ToString(),
                                year = reader["year"] != DBNull.Value ? Convert.ToInt32(reader["year"]) : 0,
                                publishing_House = reader["publishing_house"]?.ToString(),
                                total = reader["total"] != DBNull.Value ? Convert.ToInt64(reader["total"]) : 0,
                                available = reader["available"] != DBNull.Value ? Convert.ToInt64(reader["available"]) : 0,
                                category = reader["category"]?.ToString(),
                                authors = reader["authors"]?.ToString()
                            };
                            listBooks.Add(b);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new List<Books>();   
            }
            return listBooks;
        }

        private void LoadDefaultGroupBoxThongTinSach() // load form mặc định cho group box lúc mới mở
        {
            this.buttonChonAnh.Enabled = false;
            this.buttonThem.Enabled = false;
            this.buttonLuu.Enabled = false;
            this.checkBoxConSach.Enabled = false;
            this.checkBoxMuonHet.Enabled = false;
            this.buttonLuu.Enabled = false;

            this.buttonThem.Enabled = true;
            this.buttonSua.Enabled = true;
            this.buttonXoa.Enabled = true;
            this.dataGridViewBooks.Enabled = true;


            this.textBoxTenSach.ReadOnly = true;
            this.textBoxTacGia.ReadOnly = true;
            this.textBoxTheLoai.ReadOnly = true;
            this.textBoxNhaXuatBan.ReadOnly = true;
            this.textBoxNamXuatBan.ReadOnly = true;
            this.textBoxTongSoSach.ReadOnly = true;
            this.textBoxSoLuongTon.ReadOnly = true;
            this.textBoxSoLuongMuon.ReadOnly = true;

            // load mac dinh la quyen dau tien, neu khong co thi ko load
            if (dataGridViewBooks.Rows.Count > 0)
            {
                var row = dataGridViewBooks.Rows[0];
                this.textBoxMaSach.Text = row.Cells["book_id"].Value.ToString();
                this.textBoxTenSach.Text = row.Cells["title"].Value.ToString();
                this.textBoxTacGia.Text = row.Cells["authors"].Value.ToString();
                this.textBoxTheLoai.Text = row.Cells["category"].Value.ToString();
                this.textBoxNhaXuatBan.Text = row.Cells["publishing_house"].Value.ToString();
                this.textBoxNamXuatBan.Text = row.Cells["year"].Value.ToString();
                this.textBoxTongSoSach.Text = row.Cells["total"].Value.ToString();
                this.textBoxSoLuongTon.Text = row.Cells["available"].Value.ToString();

                int TongSach = Convert.ToInt32(this.textBoxTongSoSach.Text);
                int SoTon = Convert.ToInt32(this.textBoxSoLuongTon.Text);
                this.textBoxSoLuongMuon.Text = (TongSach - SoTon).ToString();

                //hien thi trang thai sach
                if (SoTon > 0)
                {
                    this.checkBoxConSach.Checked = true;
                    this.checkBoxMuonHet.Checked = false;
                }
                else
                {
                    this.checkBoxConSach.Checked = false;
                    this.checkBoxMuonHet.Checked = true;
                }
            }
        }


        private void dataGridViewBooks_CellClick(object sender, DataGridViewCellEventArgs e) //event chọn hàng để hiện thông tin sách
        {
            if (dataGridViewBooks.CurrentRow != null)
            {
                var row = dataGridViewBooks.CurrentRow;
                this.textBoxMaSach.Text = row.Cells["book_id"].Value.ToString();
                this.textBoxTenSach.Text = row.Cells["title"].Value.ToString();
                this.textBoxTacGia.Text = row.Cells["authors"].Value.ToString();

                this.textBoxTheLoai.Text = row.Cells["category"].Value.ToString();
                this.textBoxNhaXuatBan.Text = row.Cells["publishing_house"].Value.ToString();
                this.textBoxNamXuatBan.Text = row.Cells["year"].Value.ToString();
                this.textBoxTongSoSach.Text = row.Cells["total"].Value.ToString();
                this.textBoxSoLuongTon.Text = row.Cells["available"].Value.ToString();

                int TongSach = Convert.ToInt32(this.textBoxTongSoSach.Text); 
                int SoTon = Convert.ToInt32(this.textBoxSoLuongTon.Text);
                this.textBoxSoLuongMuon.Text = (TongSach - SoTon).ToString();

                //hien thi trang thai sach
                if (SoTon > 0)
                {
                    this.checkBoxConSach.Checked = true;
                    this.checkBoxMuonHet.Checked = false;
                }
                else
                {
                    this.checkBoxConSach.Checked = false;
                    this.checkBoxMuonHet.Checked = true;
                }
            }
        }
        private void UpdateInforBook(long Book_id, string Title, int Year, String Publishing_house, long Total, long Available, String Category, String Author)
        {
            try
            {
                using (SqlConnection conn = Ketnoi.GetConnection())
                using (var cmd = new SqlCommand("UpdateInforBook", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@book_id", Book_id);
                    cmd.Parameters.AddWithValue("@title", Title);
                    cmd.Parameters.AddWithValue("@year", Year);
                    cmd.Parameters.AddWithValue("@publishing_house", Publishing_house);
                    cmd.Parameters.AddWithValue("@total", Total);
                    cmd.Parameters.AddWithValue("@available", Available);
                    cmd.Parameters.AddWithValue("@cate", Category);
                    cmd.Parameters.AddWithValue("@AuthorsCSV", Author);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //Nhập sai reset dữ liệu
                if (dataGridViewBooks.CurrentRow != null)
                {
                    var row = dataGridViewBooks.CurrentRow;
                    this.textBoxMaSach.Text = row.Cells["book_id"].Value.ToString();
                    this.textBoxTenSach.Text = row.Cells["title"].Value.ToString();
                    this.textBoxTacGia.Text = row.Cells["authors"].Value.ToString();
                    this.textBoxTheLoai.Text = row.Cells["category"].Value.ToString();
                    this.textBoxNhaXuatBan.Text = row.Cells["publishing_house"].Value.ToString();
                    this.textBoxNamXuatBan.Text = row.Cells["year"].Value.ToString();
                    this.textBoxTongSoSach.Text = row.Cells["total"].Value.ToString();
                    this.textBoxSoLuongTon.Text = row.Cells["available"].Value.ToString();
                }
            }
        }


        private void AddInforBook(string Title, int Year, String Publishing_house, long Total, long Available, String Category, String Author)
        {
            try
            {
                using (SqlConnection conn = Ketnoi.GetConnection())
                using (var cmd = new SqlCommand("AddInforBook", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@title", Title);
                    cmd.Parameters.AddWithValue("@year", Year);
                    cmd.Parameters.AddWithValue("@publishing_house", Publishing_house);
                    cmd.Parameters.AddWithValue("@total", Total);
                    cmd.Parameters.AddWithValue("@available", Available);
                    cmd.Parameters.AddWithValue("@cate", Category);
                    cmd.Parameters.AddWithValue("@AuthorsCSV", Author);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                }
                MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridViewBooks.DataSource = LoadDataBooks();
                SetDataGridViewHeader();
                LoadDefaultGroupBoxThongTinSach();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi khi thêm sách!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            this.buttonLuu.Tag = "Change";

            this.buttonThem.Enabled = false;
            this.buttonSua.Enabled = false;
            this.buttonXoa.Enabled = false;
            this.dataGridViewBooks.Enabled = false;
            this.buttonLuu.Enabled = true;
            this.textBoxSoLuongMuon.ReadOnly = true;
            this.textBoxSoLuongTon.ReadOnly = true;

            this.textBoxTenSach.ReadOnly = false;
            this.textBoxTacGia.ReadOnly = false;
            this.textBoxTheLoai.ReadOnly = false;
            this.textBoxNhaXuatBan.ReadOnly = false;
            this.textBoxNamXuatBan.ReadOnly = false;
            this.textBoxTongSoSach.ReadOnly = false;


        }
        //Nút thêm sách
        public void buttonThem_Click(object sender, EventArgs e)
        {
            this.buttonLuu.Tag = "Add";

            this.textBoxMaSach.Enabled = false;

            this.textBoxTenSach.ReadOnly = false;
            this.textBoxTacGia.ReadOnly = false;
            this.textBoxTheLoai.ReadOnly = false;
            this.textBoxNhaXuatBan.ReadOnly = false;
            this.textBoxNamXuatBan.ReadOnly = false;
            this.textBoxTongSoSach.ReadOnly = false;
            this.textBoxSoLuongTon.ReadOnly = false;
            this.textBoxSoLuongMuon.ReadOnly = false;

            this.textBoxSoLuongMuon.Enabled = false;


            this.textBoxMaSach.Text = "";
            this.textBoxTenSach.Text = "";
            this.textBoxTacGia.Text = "";
            this.textBoxTheLoai.Text = "";
            this.textBoxNhaXuatBan.Text = "";
            this.textBoxNamXuatBan.Text = "";
            this.textBoxTongSoSach.Text = "";
            this.textBoxSoLuongTon.Text = "";
            this.textBoxSoLuongMuon.Text = "";

            this.checkBoxConSach.Checked = true;
            this.checkBoxMuonHet.Checked = false;

            this.buttonThem.Enabled = false;
            this.buttonLuu.Enabled = true;
            this.buttonSua.Enabled = false;
            this.buttonXoa.Enabled = false;
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return; 
            }
            string title = Ketnoi.Chuanhoa(this.textBoxTenSach.Text.Trim());
            int year = int.Parse(this.textBoxNamXuatBan.Text.Trim());
            string publishing_house = Ketnoi.Chuanhoa(this.textBoxNhaXuatBan.Text.Trim());
            long total = long.Parse(this.textBoxTongSoSach.Text.Trim());
            long available = long.Parse(this.textBoxSoLuongTon.Text.Trim());
            string category = Ketnoi.Chuanhoa(this.textBoxTheLoai.Text.Trim());
            string authors = Ketnoi.Chuanhoa(this.textBoxTacGia.Text.Trim());

            try
            {
                if (this.buttonLuu.Tag?.ToString() == "Add")
                {
                    AddInforBook( title, year, publishing_house, total, available, category, authors);
                    SetDataGridViewHeader();
                    LoadDefaultGroupBoxThongTinSach();
                }
                else if (this.buttonLuu.Tag?.ToString() == "Change")
                {
                    if (string.IsNullOrEmpty(this.textBoxMaSach.Text)) return;
                    long book_id = Convert.ToInt64(this.textBoxMaSach.Text);
                    UpdateInforBook(book_id, title, year, publishing_house, total, available, category, authors);
                    dataGridViewBooks.DataSource = LoadDataBooks();
                    SetDataGridViewHeader();
                    LoadDefaultGroupBoxThongTinSach();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi thêm user: " + ex.Message);
            }
        }

        private bool Confirm()
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc là muốn xoá quyển sách này không ?!",
                "Xác nhận xoá",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            if (result == DialogResult.Yes) return true;
            return false;
        }


        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.CurrentRow == null || !Confirm()) return;

            long book_id = Convert.ToInt64(dataGridViewBooks.CurrentRow.Cells["book_id"].Value);

            try
            {
                using (SqlConnection conn = Ketnoi.GetConnection())
                using (var cmd = new SqlCommand("DeleteBook", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", book_id);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewBooks.DataSource = LoadDataBooks();
                    SetDataGridViewHeader();
                    LoadDefaultGroupBoxThongTinSach();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Không thể xóa!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void buttonHuy_Click(object sender, EventArgs e)
        {
            this.textBoxTenSach.ReadOnly = true;
            this.textBoxTacGia.ReadOnly = true;
            this.textBoxTheLoai.ReadOnly = true;
            this.textBoxNhaXuatBan.ReadOnly = true;
            this.textBoxNamXuatBan.ReadOnly = true;
            this.textBoxTongSoSach.ReadOnly = true;
            this.textBoxSoLuongTon.ReadOnly = true;
            this.textBoxSoLuongMuon.ReadOnly = true;

            this.buttonThem.Enabled = true;
            this.buttonSua.Enabled = true;
            this.buttonXoa.Enabled = true;
            this.buttonLuu.Enabled = false;


            this.dataGridViewBooks.Enabled = true;

            LoadDefaultGroupBoxThongTinSach();
        }

        // Tìm kiếm khi bấm Enter 
        private void textBoxTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string keyword = textBoxTimKiem.Text.Trim();
                string searchType = comboBoxTimKiem.SelectedItem.ToString();
                List<Books> data = LoadDataBooks(keyword, searchType);
                dataGridViewBooks.DataSource = null;
                dataGridViewBooks.Columns.Clear();
                dataGridViewBooks.DataSource = data;

                SetDataGridViewHeader();
            }
        }


    }

}
