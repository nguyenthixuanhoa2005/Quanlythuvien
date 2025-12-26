using Quanlisachcoban.Model;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Quanlisachcoban
{
    public partial class DangKy : Form
    {
        Database db = new Database();
        public DangKy()
        {
            InitializeComponent();
        }
        private bool IsValidPassword(string password)
        {
            if (password.Length <= 5) return false;
            bool coSo = Regex.IsMatch(password, @"\d");
            bool coKyTuDacBiet = Regex.IsMatch(password, @"\W");

            return coSo && coKyTuDacBiet;
        }
        private void DangKy_Load(object sender, EventArgs e)
        {

        }

        private bool CheckExistUsername(string username)
        {
            string query = "SELECT * FROM Users WHERE username = @Username";

            try
            {
                using (SqlConnection conn = Ketnoi.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))     
                {
                    cmd.Parameters.AddWithValue("@Username", username.Trim());
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd)) 
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);  // chay lenh ve do vao dt 

                        return dt.Rows.Count > 0; // neu co it nhat 1 dong thi username ton tai -> tra ve true
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi kiểm tra username: " + ex.Message);
                return true;
            }
        }

        private bool CheckEqualPassword()
        {
            if(this.textBoxMatKhau.Text.Equals(this.textBoxPasswordAgain.Text) == false)
            {
                MessageBox.Show("2 mật khẩu của bạn không khớp nhau");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckEmpty()
        {
            if (this.textBoxTaiKhoan.Text.Length == 0 || this.textBoxMatKhau.Text.Length == 0 || this.textBoxPasswordAgain.Text.Length == 0)
            {
                MessageBox.Show("Tên người dùng / mật khẩu không được để trống");
                return false;
            }
            return true;
        }

        private void buttonTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            if (CheckEmpty())
            {
                if (!IsValidPassword(this.textBoxMatKhau.Text))
                {
                    MessageBox.Show("Mật khẩu phải có độ dài lớn hơn 5 ký tự, bao gồm ít nhất một chữ số và một ký tự đặc biệt.");
                    return;
                }
                if (CheckEqualPassword() == true)
                {
                    if (CheckExistUsername(this.textBoxTaiKhoan.Text) == false)
                    {
                        try
                        {
                            string insertSql = "INSERT INTO Users (username, password, role, status) VALUES (@Username, @Password, 'member', 'active')";

                            using (SqlConnection conn = Ketnoi.GetConnection())
                            using (SqlCommand cmd = new SqlCommand(insertSql, conn))
                            {
                                string username = textBoxTaiKhoan.Text.Trim();
                                string password = textBoxMatKhau.Text.Trim();

                                cmd.Parameters.AddWithValue("@Username", username);
                                cmd.Parameters.AddWithValue("@Password", password); 

                                conn.Open();
                                int rows = cmd.ExecuteNonQuery();

                                if (rows > 0)
                                {
                                    MessageBox.Show("Tạo tài khoản thành công!");
                                    this.Close();
                                }
                                else
                                { 
                                    MessageBox.Show("Tạo tài khoản thất bại.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại"+ ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập này đã tồn tại. Vui lòng chọn tên khác.");
                    }
                }
            }
        }

        private void checkBoxHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if(this.checkBoxHienMatKhau.Checked == false)
            {
                this.textBoxMatKhau.UseSystemPasswordChar = true;
                this.textBoxPasswordAgain.UseSystemPasswordChar = true;
            }
            else
            {
                this.textBoxMatKhau.UseSystemPasswordChar = false;
                this.textBoxPasswordAgain.UseSystemPasswordChar = false;
            }
        }
    }
}
