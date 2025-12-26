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
    public partial class ThongTinTraAdminUserControl : UserControl
    {
        public ThongTinTraAdminUserControl()
        {
            InitializeComponent();
            LoadData();
            SetHeader();
            LoadDefault();
        }



        private void SetHeader()
        {
            dataGridViewTraSach.Columns["loan_id"].HeaderText = "Mã phiếu mượn";
            dataGridViewTraSach.Columns["user_id"].HeaderText = "Mã người dùng";
            dataGridViewTraSach.Columns["loan_item_id"].HeaderText = "Mã chi tiết phiếu mượn";
            dataGridViewTraSach.Columns["book_id"].HeaderText = "Mã sách";
            dataGridViewTraSach.Columns["title"].HeaderText = "Tên sách";
            dataGridViewTraSach.Columns["loan_date"].HeaderText = "Ngày mượn";
            dataGridViewTraSach.Columns["due_date"].HeaderText = "Hạn trả";
            dataGridViewTraSach.Columns["return_date"].HeaderText = "Ngày trả";
            dataGridViewTraSach.Columns["quantity"].HeaderText = "Số lượng mượn";
            dataGridViewTraSach.Columns["status_book"].HeaderText = "Trạng thái sách";
        }
        private void LoadData()
        {
            string sql =
               @"SELECT l.loan_id,
                    l.user_id,
                    li.loan_item_id,
                    b.book_id,  
                    b.title,
                    l.loan_date,
                    l.due_date,
                    l.return_date,
                    li.quantity,
                    li.status_book
                FROM LoanItems li
                JOIN Loans l ON li.loan_id = l.loan_id
                JOIN Books b ON li.book_id = b.book_id";

            using (SqlConnection conn = Ketnoi.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridViewTraSach.DataSource = table.DefaultView;
                }
            }
        }

        private void LoadDefault()
        {
            textBoxMaPhieuMuon.ReadOnly = true;
            textBoxMaSach.ReadOnly = true;
            textBoxSoLuongMuon.ReadOnly = true;
            // Bổ sung các control mới
            textBoxTenSach.ReadOnly = true;
            dateTimePickerNgayMuon.Enabled = false;
            dateTimePickerHanTra.Enabled = false;

            radioBorrowing.Enabled = false;
            radioReturned.Enabled = false;
            radioOverdue.Enabled = false;
        }

        private void dataGridViewTraSach_CellClick(object sender, DataGridViewCellEventArgs e)
        { 
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewTraSach.Rows.Count - 1)
                return;

            var row = dataGridViewTraSach.Rows[e.RowIndex];

            textBoxMaPhieuMuon.Text = row.Cells["loan_id"].Value.ToString();
            textBoxMaSach.Text = row.Cells["book_id"].Value.ToString();
            textBoxSoLuongMuon.Text = row.Cells["quantity"].Value.ToString();
            textBoxTenSach.Text = row.Cells["title"].Value.ToString();
            if (row.Cells["loan_date"].Value != DBNull.Value)
                dateTimePickerNgayMuon.Value = (DateTime)row.Cells["loan_date"].Value;
            else
                dateTimePickerNgayMuon.Value = DateTime.Today;
            if (row.Cells["due_date"].Value != DBNull.Value)
                dateTimePickerHanTra.Value = (DateTime)row.Cells["due_date"].Value;
            else
                dateTimePickerHanTra.Value = DateTime.Today;

            string status = row.Cells["status_book"].Value.ToString();
            radioBorrowing.Checked = status == "borrowing";
            radioReturned.Checked = status == "returned";
            radioOverdue.Checked = status == "overdue";
        }

        private void ReturnBook(long loanId, long bookId)
        {
            try
            {
                using (SqlConnection conn = Ketnoi.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("ReturnBook", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@loan_id", loanId);
                        cmd.Parameters.AddWithValue("@book_id", bookId);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Trả sách thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khác: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMaPhieuMuon.Text) ||
                string.IsNullOrWhiteSpace(textBoxMaSach.Text))
            {
                MessageBox.Show("Vui lòng chọn sách cần trả!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!radioBorrowing.Checked)
            {
                MessageBox.Show("Sách này không ở trạng thái 'Đang mượn'!",
                    "Không thể trả", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long loanId = long.Parse(textBoxMaPhieuMuon.Text);
            long bookId = long.Parse(textBoxMaSach.Text);
            ReturnBook(loanId, bookId);
            LoadData();
        }

        private void labelHanTra_Click(object sender, EventArgs e)
        {

        }

        private void textBoxSoLuongMuon_TextChanged(object sender, EventArgs e)
        {

        }
    }
}