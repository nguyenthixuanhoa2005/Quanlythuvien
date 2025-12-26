using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlisachcoban
{
    public partial class QuenMatKhau : Form
    {
        public QuenMatKhau()
        {
            InitializeComponent();
        }

        private void buttonLayMK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng lấy lại mật khẩu hiện chưa được hỗ trợ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
