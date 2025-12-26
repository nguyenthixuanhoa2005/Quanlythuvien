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
    public partial class FormXemChiTietPhieu : Form
    {
        public FormXemChiTietPhieu(long loanid)
        {
            InitializeComponent();
            LoadData(loanid);
        }

        //hiển thị chi tiết phiếu mượn theo phiếu mượn được chọn
        private DataTable LoadData(long loanid)
        {
            DataTable dt = new DataTable();

            string query = @"
                SELECT li.loan_item_id,
                b.title,
                li.quantity,
                li.status_book
                FROM LoanItems li
                INNER JOIN Books b ON li.book_id = b.book_id
                WHERE li.loan_id = @loan_id;";
            using (SqlConnection conn = Ketnoi.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@loan_id", loanid);

                conn.Open();
                adapter.Fill(dt);  
                // fill du lieu vao datatable vua tao
            }
            dataGridViewDanhSach.DataSource = dt;   
            return dt;

        }


    }
}
