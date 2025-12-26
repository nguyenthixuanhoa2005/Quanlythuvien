using Quanlisachcoban.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlisachcoban
{
    public partial class FormMuonSach : Form
    {
        public FormMuonSach()
        {
            InitializeComponent();

            LoadUsersIntoComboBox();
            LoadDefault();

            List<Books> data = LoadDataBooks();
            dataGridViewBooks.DataSource = null;
            dataGridViewBooks.DataSource = data;
            SetDataGridViewHeaderDanhSachSach();

            List<Loans> loan = LoadLoans();
            dataGridViewPhieuMuon.DataSource = null;
            dataGridViewPhieuMuon.DataSource = loan;
            SetDataGridViewHeaderDanhSachPhieuMuon();
        }
        private void LoadDataGridViewPhieuMuon()
        {
            List<Loans> loan = LoadLoans();
            dataGridViewPhieuMuon.DataSource = null;
            dataGridViewPhieuMuon.DataSource = loan;
            SetDataGridViewHeaderDanhSachPhieuMuon();
        }

        private void LoadDataGridViewBooks()
        {
            List<Books> data = LoadDataBooks();
            dataGridViewBooks.DataSource = null;
            dataGridViewBooks.DataSource = data;
            SetDataGridViewHeaderDanhSachSach();
        }
        private void SetDataGridViewHeaderDanhSachSach()
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
        private void SetDataGridViewHeaderDanhSachPhieuMuon()
        {
            dataGridViewPhieuMuon.Columns["Loan_ID"].HeaderText = "Mã phiếu mượn";
            dataGridViewPhieuMuon.Columns["User_ID"].HeaderText = "Mã độc giả";
            dataGridViewPhieuMuon.Columns["Loan_Date"].HeaderText = "Ngày mượn";
            dataGridViewPhieuMuon.Columns["Due_Date"].HeaderText = "Ngày đến hạn";
            dataGridViewPhieuMuon.Columns["Status"].HeaderText = "Trạng thái";
            dataGridViewPhieuMuon.Columns["Return_Date"].HeaderText = "Ngày trả";
        }
        private List<Books> LoadDataBooks(string keyword = "", string searchType = "")
        {
            List<Books> listBooks = new List<Books>();
            string query = "SELECT b.book_id, b.title,b.year,b.publishing_house,b.total,b.available, c.name AS category, STRING_AGG(a.name, ', ') AS authors " +
                "FROM Books b " +
                "LEFT JOIN Categories c ON b.cate_id = c.cate_id " +
                "LEFT JOIN BookAuthors ba ON b.book_id = ba.book_id " +
                "LEFT JOIN Authors a ON ba.author_id = a.author_id ";


            if (!string.IsNullOrEmpty(keyword))
            {
                if (searchType == "Mã sách")
                    query += "WHERE CAST(b.book_id AS NVARCHAR) LIKE @keyword ";
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
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
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

                SetDataGridViewHeaderDanhSachSach();
            }
        }
        private List<Loans> LoadLoans()
        {
            List<Loans> listloans = new List<Loans>();
            string query = "select loan_id,user_id, loan_date,due_date,status, return_date from loans;";
            try
            {
                using (SqlConnection conn = Ketnoi.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Loans loans = new Loans
                            {
                                Loan_ID = Convert.ToInt64(reader["loan_id"]),
                                User_ID = Convert.ToInt64(reader["user_id"]),
                                Loan_Date = reader["loan_date"] != DBNull.Value ? Convert.ToDateTime(reader["loan_date"]) : DateTime.Now,
                                Due_Date = reader["due_date"] != DBNull.Value ? Convert.ToDateTime(reader["due_date"]) : DateTime.Now,
                                Status = reader["status"]?.ToString(),
                                Return_Date = reader["return_date"] != DBNull.Value ? Convert.ToDateTime(reader["return_date"]) : DateTime.MinValue
                            }
                        ;
                            listloans.Add(loans);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi LoadLoans: " + ex.Message);
            }
            return listloans;
        }

        //Cell_click bang book
        private void dataGridViewBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                MessageBox.Show ("Bạn cần chọn 1 quyển sách!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (e.RowIndex >= 0) 
            {
                var row = dataGridViewBooks.Rows[e.RowIndex];
                textBoxMaSach.Text = row.Cells["book_id"].Value.ToString();
                textBoxTenSach.Text = row.Cells["title"].Value.ToString();
            }
        }
        private void dataGridViewPhieuMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                MessageBox.Show("Bạn cần chọn một phiếu mượn hợp lệ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (e.RowIndex >=0 )
            {
                var row = dataGridViewPhieuMuon.Rows[e.RowIndex];
                textBoxMaPhieuMuon.Text = row.Cells["Loan_ID"].Value.ToString();
                textBoxMaDocGia.Text = row.Cells["User_ID"].Value.ToString();
            }
        }

        private void LoadDefault()
        {
            this.textBoxMaDocGia.ReadOnly = true;
            this.textBoxMaPhieuMuon.ReadOnly = true;
            this.textBoxMaSach.ReadOnly = true;
            this.textBoxTenSach.ReadOnly = true;

            this.dataGridViewBooks.ReadOnly = true;
            this.dataGridViewPhieuMuon.ReadOnly = true;
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = Ketnoi.GetConnection())
                using (SqlCommand cmd = new SqlCommand ("AddLoan", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", Convert.ToInt64(comboBoxUser.SelectedValue));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Thêm phiếu mượn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridViewPhieuMuon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phiếu mượn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //----------COMBOX
        private void LoadUsersIntoComboBox()
        {
            DataTable dtUsers = new DataTable();

            string query = "SELECT user_id, name FROM Users";

            using (SqlConnection conn = Ketnoi.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                conn.Open();
                adapter.Fill(dtUsers);
            }

            // Gán DataTable vào ComboBox
            //comboBoxUser.DisplayMember = "name";
            comboBoxUser.ValueMember = "user_id";     // giá trị thực tế
            comboBoxUser.DataSource = dtUsers;
        }
        private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxUser.SelectedValue != null)
            {
                long selectedUserId = Convert.ToInt64(comboBoxUser.SelectedValue);
            }
        }

        //Muon
        private void buttonMuon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMaPhieuMuon.Text) || string.IsNullOrWhiteSpace(textBoxMaSach.Text) ||
            string.IsNullOrWhiteSpace(textBoxMaDocGia.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin để mượn sách!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxSoLuongMuon.Text) )
            {
                MessageBox.Show("Vui lòng nhập số lượng sách mượn!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToInt64(textBoxSoLuongMuon.Text) <=0 )
            {
                MessageBox.Show("Số lượng mượn phải lớn hơn 0!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection conn = Ketnoi.GetConnection())
                using (var cmd = new SqlCommand("AddLoanItems", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@loan_id", Convert.ToInt64(textBoxMaPhieuMuon.Text));
                    cmd.Parameters.AddWithValue("@book_id", Convert.ToInt64(textBoxMaSach.Text));
                    cmd.Parameters.AddWithValue("@quantity", Convert.ToInt64(textBoxSoLuongMuon.Text));
                    cmd.Parameters.AddWithValue("@user_id", Convert.ToInt64(textBoxMaDocGia.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();

                }
                MessageBox.Show("Mượn sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridViewBooks();
                }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mượn sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void buttonXem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMaPhieuMuon.Text))
            {
                MessageBox.Show("Bạn chưa chọn phiếu mượn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long loanid = Convert.ToInt64(dataGridViewPhieuMuon.CurrentRow.Cells["Loan_ID"].Value);
            FormXemChiTietPhieu formXemChiTietPhieuMuon = new FormXemChiTietPhieu(loanid );
            formXemChiTietPhieuMuon.ShowDialog();
        }
    }
}
