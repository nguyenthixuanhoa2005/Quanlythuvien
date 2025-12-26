using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Quanlisachcoban
{
    public partial class TrangChu : Form
    {
        private QLSachUserControl QLSUserControl = new QLSachUserControl();
        private UserControl QLDocGiaUserControl = new QLDocGiaUserControl();
        private UserControl ThongTinMuonAdminUserControl = new ThongTinMuonAdminUserControl();
        private UserControl ThongTinTraAdminUserControl = new ThongTinTraAdminUserControl();
        private ThongTinMuonUserControl ThongTinMuonUserControl;
        private TaiKhoanUserControl TaiKhoanUserControl;
        private UserControl BaoCaoUserControl = new BaoCaoUserControl();

        private UserInfor Current_User { get; set; }
        public TrangChu(UserInfor ui)
        {

            InitializeComponent();
            Current_User = ui;
        }

        private void QLSach_Load(object sender, EventArgs e)
        {
            LoadDefault();
        }

        private void LoadDefault()
        {
            if (Current_User.Role.Equals("admin"))
            {
                this.panelTra.Visible = true;
                this.panelQuanLySach.Visible = true;
                this.panelDocGia.Visible = true;
                this.panelBaoCao.Visible = true;
            }

            this.panelMuon.Visible = true;
            this.panelTaiKhoan.Visible = true;
            this.labelTenNguoiDung.Text = Current_User.Username;
            this.labelTenRole.Text = Current_User.Role;
            this.labelTenTieuDe.Text = "HỆ THỐNG QUẢN LÍ THƯ VIỆN";

            if(Current_User.Role.Equals("user"))
            {
                this.panelDocGia.Visible = true;
                this.panelQuanLySach.Visible=true;
                this.panelMuon.Visible=false;
            }
            
        }

        public void ChangePanel(UserControl uc)
        {
            this.panelMain.Controls.Clear();
            uc.Dock = DockStyle.Fill; //usercontrol giãn full lấy dầy panel
            this.panelMain.Controls.Add(uc);
        }

        private void buttonQuanLySach_Click(object sender, EventArgs e)
        {
            QLSUserControl = new QLSachUserControl();
            this.ChangePanel(QLSUserControl);
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        private void buttonTrangChu_Click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();
        }

        private void buttonDocGia_Click(object sender, EventArgs e)
        {
            this.ChangePanel(QLDocGiaUserControl);
            
        }

        private void buttonMuon_click(object sender, EventArgs e)
        {
            if (this.Current_User.Role.Equals("admin"))
            {
                ThongTinMuonAdminUserControl = new ThongTinMuonAdminUserControl();
                this.ChangePanel(ThongTinMuonAdminUserControl);

            }
            else
            {
                ThongTinMuonUserControl = new ThongTinMuonUserControl(Current_User);
                this.ChangePanel(ThongTinMuonUserControl);
            }
        }

        private void buttonTaiKhoan_Click(object sender, EventArgs e)
        {
            this.ChangePanel(TaiKhoanUserControl = new TaiKhoanUserControl(Current_User));
        }

        private void buttonBaoCao_Click(object sender, EventArgs e)
        {
             this.ChangePanel(BaoCaoUserControl);
        }
        private void buttonTra_Click(object sender, EventArgs e)
        {
            ThongTinTraAdminUserControl = new ThongTinTraAdminUserControl();
            this.ChangePanel(ThongTinTraAdminUserControl);
        }
    }
}
