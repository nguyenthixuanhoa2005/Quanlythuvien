using Quanlisachcoban.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace Quanlisachcoban
{
    public partial class QLDocGiaUserControl : UserControl
    {
        public QLDocGiaUserControl()
        {
            InitializeComponent();

            List<Users> data = LoadDataDocGia();
            this.dataGridViewDocGia.DataSource = null;
            dataGridViewDocGia.Columns.Clear();
            this.dataGridViewDocGia.DataSource = data;

            SetDataGridViewHeader();
            LoadDefaultGroupBoxThongTinDocGia();

        }
        private void SetDataGridViewHeader()
        {
            dataGridViewDocGia.Columns["user_id"].HeaderText = "Mã độc giả";
            dataGridViewDocGia.Columns["username"].HeaderText = "Tên đăng nhập";
            dataGridViewDocGia.Columns["name"].HeaderText = "Họ và tên";
            dataGridViewDocGia.Columns["email"].HeaderText = "Email";
            dataGridViewDocGia.Columns["password"].Visible = false;
            dataGridViewDocGia.Columns["phone"].HeaderText = "Số điện thoại";
            dataGridViewDocGia.Columns["role"].HeaderText = "Vai trò";
            dataGridViewDocGia.Columns["status"].HeaderText = "Trạng thái";
        }
        private bool IsValidPassword(string password)
        {
            if (password.Length <= 5) return false;
            bool coSo = Regex.IsMatch(password, @"\d");
            bool coKyTuDacBiet = Regex.IsMatch(password, @"\W");

            return coSo && coKyTuDacBiet;
        }


        private List<Users> LoadDataDocGia()
        {
            List<Users> listDocGia = new List<Users>();
            string query = @"SELECT User_id, Password, Username, Name, Email, Phone, Role, Status 
                            FROM Users 
                            WHERE role = @role";
            try
            {
                using (SqlConnection conn = Ketnoi.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@role", "member");
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var u = new Users
                            {
                                User_id = reader["user_id"] != DBNull.Value ? Convert.ToInt64(reader["user_id"]) : 0,
                                Username = reader["username"]?.ToString(),
                                Password = reader["password"]?.ToString(),
                                Name = reader["name"]?.ToString(),
                                Email = reader["email"]?.ToString(),
                                Phone = reader["phone"]?.ToString(),
                                Role = reader["role"]?.ToString(),
                                Status = reader["status"]?.ToString(),
                            };
                            listDocGia.Add(u);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu độc giả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Users>();
            }

            return listDocGia;
        }

        private void TimKiem()
        {
            string key = textBoxNhapTimKiem.Text.Trim().ToLower();  
            var data = LoadDataDocGia();

            if (string.IsNullOrEmpty(key))
            {
                dataGridViewDocGia.DataSource = data;
                return;
            }

            List<Users> result = new List<Users>();

            if (radioButtonTimMaDG.Checked)
            {
                foreach (var item in data)
                {
                    if (item.User_id.ToString().ToLower().Contains(key))
                        result.Add(item);
                }
            }
            else if (radioButtonTimTenDG.Checked)
            {
                foreach (var item in data)
                {
                    if (!string.IsNullOrEmpty(item.Name) &&
                        item.Name.ToLower().Contains(key)) 
                    {
                        result.Add(item);
                    }
                }
            }

            dataGridViewDocGia.DataSource = result;
        }

        private void textBoxNhapTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void LoadDefaultGroupBoxThongTinDocGia()
        {
            this.textBoxMaDocGia.ReadOnly = true;
            this.textBoxTenDangNhap.ReadOnly = true;
            this.textBoxMatKhau.ReadOnly = true;
            this.textBoxHoTen.ReadOnly = true;
            this.textBoxEmail.ReadOnly = true;
            this.textBoxSoDienThoai.ReadOnly = true;

            this.radioButtonHoatDong.Checked = false;
            this.radioButtonNgungHoatDong.Checked = false;

            this.radioButtonHoatDong.Enabled = false;
            this.radioButtonNgungHoatDong.Enabled = false;
            this.buttonLuu.Enabled = false;
            this.buttonHuy.Enabled = false;

            this.buttonThem.Enabled = true;
            this.buttonSua.Enabled = true;
            this.buttonXoa.Enabled = true;

            this.buttonLuu.Tag = null;
            this.dataGridViewDocGia.Enabled = true;
        }
        private void checkBoxHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxHienMatKhau.Checked == false)
            {
                this.textBoxMatKhau.UseSystemPasswordChar = true;
            }
            else
            {
                this.textBoxMatKhau.UseSystemPasswordChar = false;
            }
        }
        private void panelTimKiem_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridViewDocGia.CurrentRow != null) //ko chọn dòng nào thì ko làm gì
            {
                var row = this.dataGridViewDocGia.CurrentRow;

                this.textBoxMaDocGia.Text = row.Cells["user_id"].Value.ToString();
                this.textBoxTenDangNhap.Text = row.Cells["username"].Value.ToString();
                this.textBoxMatKhau.Text = row.Cells["password"].Value.ToString();
                this.textBoxHoTen.Text = row.Cells["name"].Value.ToString();
                this.textBoxEmail.Text = row.Cells["email"].Value.ToString();
                this.textBoxSoDienThoai.Text = row.Cells["phone"].Value.ToString();


                if (row.Cells["status"].Value.ToString() == "active")
                {
                    this.radioButtonHoatDong.Checked = true;
                }
                else
                {
                    this.radioButtonNgungHoatDong.Checked = true;
                }
            }
        }

        private void UpdateInforUser(long userId, string username,string password, string name, string email, string phone, string status)
        {
            if (!IsValidPassword(this.textBoxMatKhau.Text))
            {
                MessageBox.Show("Mật khẩu phải có độ dài lớn hơn 5 ký tự, bao gồm ít nhất một chữ số và một ký tự đặc biệt.");
                return;
            }
            try
            {
                using (SqlConnection conn = Ketnoi.GetConnection())
                using (var cmd = new SqlCommand("UpdateUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@status", status);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //Nhập sai reset dữ liệu
                if (dataGridViewDocGia.CurrentRow != null)
                {
                    var row = dataGridViewDocGia.CurrentRow;
                    textBoxMaDocGia.Text = row.Cells["user_id"].Value.ToString();
                    textBoxTenDangNhap.Text = row.Cells["username"].Value.ToString();
                    textBoxMatKhau.Text = row.Cells["password"].Value.ToString();
                    textBoxHoTen.Text = row.Cells["name"].Value.ToString();
                    textBoxEmail.Text = row.Cells["email"].Value.ToString();
                    textBoxSoDienThoai.Text = row.Cells["phone"].Value.ToString();
                    radioButtonHoatDong.Checked = row.Cells["status"].Value.ToString() == "active";
                    radioButtonNgungHoatDong.Checked = row.Cells["status"].Value.ToString() == "block";
                }
            }
        }

        private void AddUser(string username, string password, string name, string email, string phone, string status)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống!");
                return;
            }
            if (!IsValidPassword(this.textBoxMatKhau.Text))
            {
                MessageBox.Show("Mật khẩu phải có độ dài lớn hơn 5 ký tự, bao gồm ít nhất một chữ số và một ký tự đặc biệt.");
                return;
            }

            try
            {
                using (SqlConnection conn = Ketnoi.GetConnection())
                using (var cmd = new SqlCommand("AddUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@status", status);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                }

                MessageBox.Show("Thêm user thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridViewDocGia.DataSource = LoadDataDocGia();
                SetDataGridViewHeader();
                LoadDefaultGroupBoxThongTinDocGia();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi khi thêm user!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void buttonSua_Click(object sender, EventArgs e)
        {
            this.buttonLuu.Tag = "Change";
            this.textBoxMaDocGia.ReadOnly = true;

            this.textBoxMatKhau.ReadOnly = false;
            this.textBoxTenDangNhap.ReadOnly = false;
            this.textBoxHoTen.ReadOnly = false;
            this.textBoxSoDienThoai.ReadOnly = false;
            this.textBoxEmail.ReadOnly = false;

            this.buttonLuu.Enabled = true;
            this.buttonThem.Enabled = false;
            this.buttonXoa.Enabled = false;
            this.buttonSua.Enabled = false;
            this.buttonHuy.Enabled = true;
            this.dataGridViewDocGia.Enabled = false;
            this.radioButtonHoatDong.Enabled = true;
            this.radioButtonNgungHoatDong.Enabled = true;

        }
        private void buttonThem_Click(object sender, EventArgs e)
        {
            this.buttonLuu.Tag = "Add";

            this.textBoxMaDocGia.Text = " Tự động";
            this.textBoxTenDangNhap.Text = "";
            this.textBoxMatKhau.Text = "";
            this.textBoxHoTen.Text = "";
            this.textBoxEmail.Text = "";
            this.textBoxSoDienThoai.Text = "";
            this.radioButtonHoatDong.Checked = true;

            this.textBoxMaDocGia.ReadOnly = true;
            this.textBoxMatKhau.ReadOnly = false;
            this.textBoxTenDangNhap.ReadOnly = false;
            this.textBoxHoTen.ReadOnly = false;
            this.textBoxEmail.ReadOnly = false;
            this.textBoxSoDienThoai.ReadOnly = false;

            this.buttonLuu.Enabled = true;
            this.buttonHuy.Enabled = true;
            this.buttonThem.Enabled = false;
            this.buttonXoa.Enabled = false;
            this.buttonSua.Enabled = false;

            this.dataGridViewDocGia.Enabled = false;
            this.radioButtonHoatDong.Enabled = true;
            this.radioButtonNgungHoatDong.Enabled = true;

        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            string username = textBoxTenDangNhap.Text.Trim();
            string password = textBoxMatKhau.Text.Trim();
            string name = Ketnoi.Chuanhoa(textBoxHoTen.Text.Trim());
            string email = textBoxEmail.Text.Trim();
            string phone = textBoxSoDienThoai.Text.Trim();
            string status = radioButtonHoatDong.Checked ? "active" : "block";
            try
            {
                if (this.buttonLuu.Tag?.ToString() == "Add")
                {
                    if (dataGridViewDocGia.CurrentRow == null) return;
                    long userId = Convert.ToInt64(dataGridViewDocGia.CurrentRow.Cells["user_id"].Value);
                    AddUser(username, password, name, email, phone, status);
                    dataGridViewDocGia.DataSource = LoadDataDocGia();
                    SetDataGridViewHeader();
                    LoadDefaultGroupBoxThongTinDocGia();
                }
                else if (this.buttonLuu.Tag?.ToString() == "Change")
                {
                    if (dataGridViewDocGia.CurrentRow == null) return;
                    long userId = Convert.ToInt64(dataGridViewDocGia.CurrentRow.Cells["user_id"].Value);
                    UpdateInforUser(userId, username, password, name, email, phone, status);
                    dataGridViewDocGia.DataSource = LoadDataDocGia();
                    SetDataGridViewHeader();
                    LoadDefaultGroupBoxThongTinDocGia();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi thêm user: " + ex.Message);
            }
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            if (dataGridViewDocGia.Rows.Count > 0)
            {
                var row = dataGridViewDocGia.Rows[0];
                this.textBoxMaDocGia.Text = row.Cells["user_id"].Value.ToString();
                this.textBoxTenDangNhap.Text = row.Cells["username"].Value.ToString();
                this.textBoxMatKhau.Text = row.Cells["password"].Value.ToString();
                this.textBoxHoTen.Text = row.Cells["name"].Value.ToString();
                this.textBoxEmail.Text = row.Cells["email"].Value.ToString();
                this.textBoxSoDienThoai.Text = row.Cells["phone"].Value.ToString();
                if (row.Cells["status"].Value.ToString() == "active")
                    this.radioButtonHoatDong.Checked = true;
                else
                    this.radioButtonNgungHoatDong.Checked = true;
            }
            LoadDefaultGroupBoxThongTinDocGia();
        }
        private bool Confirm()
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc là muốn xoá người dùng này không ?!",
                "Xác nhận xoá",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            if (result == DialogResult.Yes) return true;
            return false;
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewDocGia.CurrentRow == null || !Confirm()) return;

            long userId = Convert.ToInt64(dataGridViewDocGia.CurrentRow.Cells["user_id"].Value);

            try
            {
                using (SqlConnection conn = Ketnoi.GetConnection())
                using (var cmd = new SqlCommand("DeleteUser", conn)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", userId);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewDocGia.DataSource = LoadDataDocGia();
                    SetDataGridViewHeader();
                    LoadDefaultGroupBoxThongTinDocGia();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Không thể xóa!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
