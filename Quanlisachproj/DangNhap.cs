using Quanlisachcoban.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Metadata.Edm;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlisachcoban
{
    public partial class DangNhap : Form
    {
        public UserInfor loginUser { get; set; } = new UserInfor();

        public DangNhap()
        {
            InitializeComponent();
        }
   
        private bool Login()
        {
            string username = textBoxTaiKhoan.Text.Trim();
            string password = textBoxMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Tên đăng nhập / mật khẩu trống");
                return false;
            }

            string query = @"SELECT user_id, username, password, role, status
                     FROM Users
                     WHERE username = @Username AND password = @Password";
            try
            {
                using (SqlConnection conn = Ketnoi.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader()) // cái excutereader này trả về được nhiều bản ghi kiểu như 1 danh sách luôn chứ méo p 1 nhé
                    {
                        if (reader.Read()) // Nếu có 1 dòng (tức là cái query bên trên nó trả về 1 bản ghi đúng với cái vừa nhập vào) => đúng username & password
                        {
                            string status = reader["status"]?.ToString(); // cái này check xem status có null ko ko null thì chuyển sang string còn null thì trả về null chứ k chuyển (chuyển sẽ bị crash app)

                            if (status == "active")
                            {
                                loginUser.Username = reader["username"].ToString();
                                loginUser.Role = reader["role"].ToString();
                                loginUser.User_Id = Convert.ToInt64(reader["user_id"]);
                                return true;
                            }
                            else if (status == "block")
                            {
                                MessageBox.Show("Tài khoản của bạn đã bị khoá, hãy liên hệ với thủ thư để biết chi tiết");
                            }
                            else
                            {
                                MessageBox.Show("Tài khoản của bạn đang được chờ phê duyệt");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sai thông tin đăng nhập");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message);
            }

            return false;
        }


        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            if(Login())
            {
                MessageBox.Show("Đăng nhập thành công !!!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void checkBoxHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if(this.checkBoxHienMatKhau.Checked == false)
            {
                this.textBoxMatKhau.UseSystemPasswordChar = true;
            }
            else
            {
                this.textBoxMatKhau.UseSystemPasswordChar = false;
            }
        }

        private void labelQuenMatKhau_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ với admin để lấy lại mật khẩu");
        }

        private void buttonDangKy_Click(object sender, EventArgs e)
        {
            using (var DK = new DangKy())
            {
                DK.ShowDialog();
            }
        }
    }
}
