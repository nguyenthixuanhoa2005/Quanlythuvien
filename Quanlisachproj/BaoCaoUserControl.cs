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
    public partial class BaoCaoUserControl : UserControl
    {
        public BaoCaoUserControl()
        {
            InitializeComponent();
            SetupEventHandlers();
            LoadReportData();

        }

        private void SetupEventHandlers()
        {
            buttonLamMoi.Click += buttonLamMoi_Click;
            tabControlBaoCao.SelectedIndexChanged += tabControlBaoCao_SelectedIndexChanged;
        }

        private void LoadReportData()
        {
            LoadTotalCounts();
            tabControlBaoCao_SelectedIndexChanged(this, EventArgs.Empty);
        }
        private int GetTotalCount(string tableName)
        {
            int count = 0;
            string sql = $"SELECT COUNT(*) FROM {tableName}"; // đếm tổng số bản ghi

            using (SqlConnection conn = Ketnoi.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            count = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi đếm dữ liệu {tableName}: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return count;
        }


        private void LoadTotalCounts()
        {
            int tongSach = GetTotalCount("Books");
            int tongDocGia = GetTotalCount("Users");
            int tongTheLoai = GetTotalCount("Categories"); 

            labelTSSach.Text = tongSach.ToString();
            labelTSDocGia.Text = tongDocGia.ToString();
            labelTheLoai.Text = tongTheLoai.ToString();
        }

        private void LoadDataGridViewData(string sqlQuery, DataGridView dataGridView)
        {
            using (SqlConnection conn = Ketnoi.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView.DataSource = dt;

                        // Format giao diện cơ bản cho DataGridView dễ nhìn hơn
                        dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridView.ClearSelection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi Cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void LoadDanhSachSach()
        {
            string sql = @"
                SELECT 
                    b.book_id AS [Mã sách], 
                    b.title AS [Tên sách], 
                    STRING_AGG(a.name, ', ') WITHIN GROUP (ORDER BY a.name) AS [Tác giả], 
                    b.year AS [Năm xuất bản], 
                    b.total AS [Số lượng tồn] 
                FROM Books b
                LEFT JOIN BookAuthors ba ON b.book_id = ba.book_id
                LEFT JOIN Authors a ON ba.author_id = a.author_id
                GROUP BY b.book_id, b.title, b.year, b.total";

            LoadDataGridViewData(sql, dataGridViewDanhSachSach);
        }

        private void LoadDanhSachDocGia()
        {

            string sql = @"
                SELECT 
                    u.user_id AS [Mã độc giả], 
                    u.name AS [Tên độc giả], 
                    u.email AS [Email], 
                    COUNT(l.loan_id) AS [Số sách đang mượn]
                FROM Users u
                LEFT JOIN Loans l ON u.user_id = l.user_id AND l.status = 'borrowing'
                GROUP BY u.user_id, u.name, u.email";

            LoadDataGridViewData(sql, dataGridViewDanhSachDocGia);
        }

        private void LoadDanhSachMuonTra()
        {
            string sql = @"
                SELECT 
                    l.loan_id AS [Mã phiếu], 
                    u.name AS [Tên độc giả], 
                    b.title AS [Sách mượn],
                    l.loan_date AS [Ngày mượn], 
                    l.due_date AS [Ngày hẹn trả], 
                    li.status_book AS [Trạng thái sách]
                FROM Loans l
                JOIN Users u ON l.user_id = u.user_id
                JOIN LoanItems li ON l.loan_id = li.loan_id
                JOIN Books b ON li.book_id = b.book_id
                ORDER BY l.loan_date DESC";

            LoadDataGridViewData(sql, dataGridViewDanhSachMuonTra);
        }

        private void tabControlBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControlBaoCao.SelectedIndex)
            {
                case 0:
                    LoadDanhSachSach();
                    break;
                case 1:
                    LoadDanhSachDocGia();
                    break;
                case 2:
                    LoadDanhSachMuonTra();
                    break;
            }
        }

        private void buttonLamMoi_Click(object sender, EventArgs e)
        {
            LoadReportData();
            MessageBox.Show("Dữ liệu đã được làm mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}