using Quanlisachcoban.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quanlisachcoban
{
    public partial class TaiKhoanUserControl : UserControl
    {
        private UserInfor Current_Member { get; set; }
        public TaiKhoanUserControl(UserInfor current_User)
        {
            InitializeComponent();
            Current_Member = new UserInfor(current_User);
            LoadUserInfor();
        }

        private void LoadUserInfor()
        {
            string query = @"SELECT user_id, username, name, email, phone
                     FROM Users
                     WHERE user_id = @uid";

            using (SqlConnection conn = Ketnoi.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@uid", Current_Member.User_Id);

                conn.Open();
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        Current_Member.Username = r["username"].ToString();
                        Current_Member.password = "";
                        Current_Member.Name = r["name"].ToString();
                        Current_Member.Email = r["email"].ToString();
                        Current_Member.Phone = r["phone"].ToString();
                    }
                }
            }

            textBoxTenDangNhap.Text = Current_Member.Name;
            textBoxMaTaiKhoan.Text = Current_Member.User_Id.ToString();
            textBoxTenNguoiDung.Text = Current_Member.Username;
            textBoxMatKhau.Text = "********";
            textBoxEmail.Text = Current_Member.Email;
            textBoxSoDienThoai.Text = Current_Member.Phone;
        }


        private void buttonSuaThongTin_Click(object sender, EventArgs e)
        {
            textBoxEmail.ReadOnly = false;
            textBoxSoDienThoai.ReadOnly = false;
            buttonSuaThongTin.Enabled = false;
            buttonLuuThongTin.Enabled = true;
            buttonXoaTaiKhoan.Enabled = false;
        }

        private void buttonLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = Ketnoi.GetConnection())
                using (SqlCommand cmd = new SqlCommand("UpdateUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@user_id", Current_Member.User_Id);
                    cmd.Parameters.AddWithValue("@username", Current_Member.Username);
                    cmd.Parameters.AddWithValue("@password", Current_Member.password); 
                    cmd.Parameters.AddWithValue("@name", Current_Member.Name);

                    cmd.Parameters.AddWithValue("@email", textBoxEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", textBoxSoDienThoai.Text.Trim());
                    cmd.Parameters.AddWithValue("@status", "active");

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cập nhật thông tin thành công!");

                buttonSuaThongTin.Enabled = true;
                buttonLuuThongTin.Enabled = false;
                buttonXoaTaiKhoan.Enabled = true;

                textBoxEmail.ReadOnly = true;
                textBoxSoDienThoai.ReadOnly = true;

                LoadUserInfor();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
        }

        private void buttonXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show(
                "Bạn có chắc muốn khóa tài khoản không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (r != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = Ketnoi.GetConnection())
                using (SqlCommand cmd = new SqlCommand("UpdateUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@user_id", Current_Member.User_Id);
                    cmd.Parameters.AddWithValue("@username", Current_Member.Username);
                    cmd.Parameters.AddWithValue("@password", Current_Member.password);
                    cmd.Parameters.AddWithValue("@name", Current_Member.Name);
                    cmd.Parameters.AddWithValue("@email", Current_Member.Email);
                    cmd.Parameters.AddWithValue("@phone", Current_Member.Phone);
                    cmd.Parameters.AddWithValue("@status", "block");

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Tài khoản đã bị khóa!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xoá: " + ex.Message);
            }
        }
    }
}
