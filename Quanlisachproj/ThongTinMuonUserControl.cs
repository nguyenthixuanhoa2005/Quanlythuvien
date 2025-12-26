using Quanlisachcoban.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlisachcoban
{
    public partial class ThongTinMuonUserControl : UserControl
    {
        public UserInfor Current_User { get; set; }

        public ThongTinMuonUserControl(UserInfor user)
        {
            InitializeComponent();
            Current_User = user;

            List<LoanItems> data = LoadDataLoanItems();
            dataGridViewSachDaMuon.DataSource = null;
            dataGridViewSachDaMuon.DataSource = data;
            SetDataGridViewHeaderDanhSachPM();

            List<LoanItems> dataReturn = LoadDataReturnLoanItems();
            dataGridViewSachDaTra.DataSource = null;
            dataGridViewSachDaTra.DataSource = dataReturn;
            SetDataGridViewHeaderDanhSachPMDT();

        }

        //SET cho bảng danh sách sách đang mượn
        private void SetDataGridViewHeaderDanhSachPM()
        {
            // Sửa tất cả tên cột thành viết hoa chữ cái đầu như trong class LoanItems (giong trong model)
            dataGridViewSachDaMuon.Columns["Loan_ID"].HeaderText = "Mã phiếu mượn";
            dataGridViewSachDaMuon.Columns["LoanItem_ID"].HeaderText = "Mã chi tiết phiếu mượn";
            dataGridViewSachDaMuon.Columns["Book_ID"].HeaderText = "Mã sách";
            dataGridViewSachDaMuon.Columns["Title"].HeaderText = "Tên sách";
            dataGridViewSachDaMuon.Columns["Loan_Date"].HeaderText = "Ngày mượn";
            dataGridViewSachDaMuon.Columns["Due_Date"].HeaderText = "Ngày đến hạn";
            dataGridViewSachDaMuon.Columns["Quantity"].HeaderText = "Số lượng";
            dataGridViewSachDaMuon.Columns["Status"].HeaderText = "Trạng thái";
        }

        private void SetDataGridViewHeaderDanhSachPMDT()
        {
            dataGridViewSachDaTra.Columns["Loan_ID"].HeaderText = "Mã phiếu mượn";
            dataGridViewSachDaTra.Columns["LoanItem_ID"].HeaderText = "Mã chi tiết phiếu mượn";
            dataGridViewSachDaTra.Columns["Book_ID"].HeaderText = "Mã sách";
            dataGridViewSachDaTra.Columns["Title"].HeaderText = "Tên sách";
            dataGridViewSachDaTra.Columns["Loan_Date"].HeaderText = "Ngày mượn";
            dataGridViewSachDaTra.Columns["Due_Date"].HeaderText = "Ngày đến hạn";
            dataGridViewSachDaTra.Columns["Quantity"].HeaderText = "Số lượng";
            dataGridViewSachDaTra.Columns["Status"].HeaderText = "Trạng thái";
        }


        private List<LoanItems> LoadDataLoanItems()
        {
            List<LoanItems> loanItems = new List<LoanItems>();

            try
            {
                using (SqlConnection conn = Ketnoi.GetConnection())
                using (var cmd = new SqlCommand("proc_SelectCTPM", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    // @ giong ben proc
                    cmd.Parameters.AddWithValue("@user_id", Current_User.User_Id);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LoanItems li = new LoanItems()
                            {
                                //trc = phải giống trong model, trong [] thì giống tên cột trong db
                                // add dong nay vao list p giong trong model
                                Loan_ID = reader["loan_id"] != DBNull.Value ? Convert.ToInt64(reader["loan_id"]) : 0,
                                LoanItem_ID = reader["loan_item_id"] != DBNull.Value ? Convert.ToInt64(reader["loan_item_id"]) : 0,
                                Book_ID = reader["book_id"] != DBNull.Value ? Convert.ToInt64(reader["book_id"]) : 0,
                                Quantity = reader["quantity"] != DBNull.Value ? Convert.ToInt64(reader["quantity"]) : 0,
                                Title = reader["title"] != DBNull.Value ? reader["title"].ToString() : string.Empty,
                                Loan_Date = reader["loan_date"] != DBNull.Value ? Convert.ToDateTime(reader["loan_date"]) : DateTime.Now,
                                Due_Date = reader["due_date"] != DBNull.Value ? Convert.ToDateTime(reader["due_date"]) : DateTime.Now,
                                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty
                            };
                            loanItems.Add(li);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu chi tiết phiếu mượn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new List<LoanItems>();
            }
            return loanItems;
        }

        private List<LoanItems> LoadDataReturnLoanItems()
        {
            List<LoanItems> loanItems = new List<LoanItems>();

            try
            {
                using (SqlConnection conn = Ketnoi.GetConnection())
                using (var cmd = new SqlCommand("proc_ReturnedCTPM", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", Current_User.User_Id);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LoanItems li = new LoanItems()
                            {
                                //trc = phải giống trong model, trong [] thì giống tên cột trong db
                                // add dong nay vao list p giong trong model
                                Loan_ID = reader["loan_id"] != DBNull.Value ? Convert.ToInt64(reader["loan_id"]) : 0,
                                LoanItem_ID = reader["loan_item_id"] != DBNull.Value ? Convert.ToInt64(reader["loan_item_id"]) : 0,
                                Book_ID = reader["book_id"] != DBNull.Value ? Convert.ToInt64(reader["book_id"]) : 0,
                                Quantity = reader["quantity"] != DBNull.Value ? Convert.ToInt64(reader["quantity"]) : 0,
                                Title = reader["title"] != DBNull.Value ? reader["title"].ToString() : string.Empty,
                                Loan_Date = reader["loan_date"] != DBNull.Value ? Convert.ToDateTime(reader["loan_date"]) : DateTime.Now,
                                Due_Date = reader["due_date"] != DBNull.Value ? Convert.ToDateTime(reader["due_date"]) : DateTime.Now,
                                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty
                            };
                            loanItems.Add(li);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu chi tiết phiếu mượn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new List<LoanItems>();
            }
            return loanItems;
        }
    }
}
