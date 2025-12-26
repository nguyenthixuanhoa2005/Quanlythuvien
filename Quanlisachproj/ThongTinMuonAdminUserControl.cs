using Quanlisachcoban.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlisachcoban
{
    public partial class ThongTinMuonAdminUserControl : UserControl
    {
        private FormMuonSach formMuonSach = new FormMuonSach();
        public ThongTinMuonAdminUserControl()
        {
            InitializeComponent();            
        }

        private void MuonTraUserControl_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadDefault();
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

                    DataView dv = table.DefaultView; // tạo DataView
                    dataGridViewDanhSach.DataSource = dv;
                }
            }
        }

        private void LoadDefault()
        {
            this.textBoxMaDocGia.ReadOnly = true;
            this.textBoxMaPhieuMuon.ReadOnly = true;
            this.textBoxMaSach.ReadOnly = true;
            this.textBoxSoLuongMuon.ReadOnly = true;
            this.dateTimePickerNgayHenTra.Enabled = false;
            this.dateTimePickerNgayMuon.Enabled = false;
            this.radioButtonDangMuon.Enabled = false;
            this.radioButtonDaTra.Enabled = false;
            this.radioButtonQuaHan.Enabled= false;

            checkBoxDangMuon.Checked = true;
            checkBoxDaTra.Checked = true;
            checkBoxQuaHan.Checked = true;

            if (dataGridViewDanhSach.Rows.Count == 0)
                return;

            var row = dataGridViewDanhSach.Rows[0];

            textBoxMaPhieuMuon.Text = row.Cells["loan_id"].Value.ToString();
            textBoxMaSach.Text = row.Cells["book_id"].Value.ToString();
            textBoxSoLuongMuon.Text = row.Cells["quantity"].Value.ToString();

            dateTimePickerNgayMuon.Value = (DateTime)row.Cells["loan_date"].Value;
            dateTimePickerNgayHenTra.Value = (DateTime)row.Cells["due_date"].Value;

            string status = row.Cells["status_book"].Value.ToString();
            radioButtonDangMuon.Checked = status == "borrowing";
            radioButtonDaTra.Checked = status == "returned";
            radioButtonQuaHan.Checked = status == "overdue";
        }

        private void Filter()
        {
            DataView dv = (DataView)dataGridViewDanhSach.DataSource;
            List<string> statusList = new List<string>();
            // 1 cái list để lưu trạng thái được chọn

            if (checkBoxDangMuon.Checked) statusList.Add("borrowing");
            if (checkBoxDaTra.Checked) statusList.Add("returned");
            if (checkBoxQuaHan.Checked) statusList.Add("overdue");

            if (statusList.Count > 0)
                //  Vì người dùng có thể chọn nhiều trạng thái cùng lúc (ví dụ vừa xem sách Đang mượn, vừa xem sách Quá hạn),
                //  nên em dùng một List để gom tất cả các lựa chọn đó lại."

                //tại sao dùng Or mà ko phải And? vì 1 chi tiết mượn sách chỉ có 1 trạng thái thôi 
                dv.RowFilter = string.Join(" OR ", statusList.Select(s => $"status_book = '{s}'"));
            else
                dv.RowFilter = ""; 
        }



        private void checkBoxDaTra_CheckedChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void checkBoxDangMuon_CheckedChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void checkBoxQuaHan_CheckedChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void dataGridViewDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(this.dataGridViewDanhSach.SelectedCells.Count > 0)
            {
                var row = this.dataGridViewDanhSach.CurrentRow;

                this.textBoxMaPhieuMuon.Text = row.Cells["loan_id"].Value.ToString();
                this.textBoxMaDocGia.Text = row.Cells["user_id"].Value.ToString();
                this.textBoxMaSach.Text = row.Cells["book_id"].Value.ToString();
                this.textBoxSoLuongMuon.Text = row.Cells["quantity"].Value.ToString();
                this.dateTimePickerNgayMuon.Value = (DateTime)row.Cells["loan_date"].Value;
                this.dateTimePickerNgayHenTra.Value = (DateTime)row.Cells["due_date"].Value;
                if (row.Cells["status_book"].Value.ToString().Equals("borrowing"))
                {
                    this.radioButtonDangMuon.Checked = true;
                }
                else if (row.Cells["status_book"].Value.ToString().Equals("returned"))
                {
                    this.radioButtonDaTra.Checked = true;
                }
                else
                {
                    this.radioButtonQuaHan.Checked = true;
                }
            }
        }
        private void Sort()
        {
            DataView dv = (DataView)dataGridViewDanhSach.DataSource;
            if (dv == null) return;

            if (radioButtonMaDocGia.Checked)
                dv.Sort = "user_id ASC";
            else if (radioButtonMaSach.Checked)
                dv.Sort = "book_id ASC";
        }


        private void radioButtonMaDocGia_CheckedChanged(object sender, EventArgs e)
        {
            Sort();
        }

        private void radioButtonMaSach_CheckedChanged(object sender, EventArgs e)
        {
            Sort();
        }

        private void buttonMuonSach_Click(object sender, EventArgs e)
        {
            formMuonSach.ShowDialog();
        }
    }



}
