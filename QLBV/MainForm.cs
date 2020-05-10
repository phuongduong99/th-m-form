using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBV
{
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();
            customizeDesing();
            openChildForm(new frmChildFormHT());
        }

        #region code xử lý ẩn hiện subMenu

        private void customizeDesing()
        {
            panelNhanvienSubmenu.Visible = false;
            panelBenhnhanSubmenu.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelNhanvienSubmenu.Visible == true)
                panelNhanvienSubmenu.Visible = false;
            if (panelBenhnhanSubmenu.Visible == true)
                panelBenhnhanSubmenu.Visible = false;
        }

        private void showSubMenu(Panel SubMenu)
        {
            if (SubMenu.Visible == false)
            {
                hideSubMenu();
                SubMenu.Visible = true;
            }
            else
                SubMenu.Visible = false;
        }

        #endregion

        #region code hàm xử lý đóng mở form

        private Form activeForm = null;
        private void openChildForm(Form ChildForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            pnlChildForm.Controls.Add(ChildForm);
            pnlChildForm.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }

        #endregion

        #region code click button

        private void btnHethong_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new frmChildFormHT());
            
        }

        private void btnBacsi_Click_1(object sender, EventArgs e)
        {
            openChildForm(new frmChildFormBS());
        }

        private void btnKhac_Click_1(object sender, EventArgs e)
        {
            openChildForm(new frmChildFormKhac());
        }

        private void btnBenhnhan_Click_1(object sender, EventArgs e)
        {
            showSubMenu(panelBenhnhanSubmenu);
        }

        private void btnCoBHYT_Click_1(object sender, EventArgs e)
        {
            openChildForm(new frmcoBHYT());
        }

        private void btnKoBHYT_Click_1(object sender, EventArgs e)
        {
            openChildForm(new frmkoBHYT());
        }

        private void btnKhamchuabenh_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new frmChildFormKCB());
        }

        private void btnNhanvien_Click(object sender, EventArgs e)
        {
            showSubMenu(panelNhanvienSubmenu);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region code xử lý dòng trạng thái

        private void timer1_Tick(object sender, EventArgs e)
        {
            tSStime.Text = System.DateTime.Now.ToString();
        }

        private void frmMainForm_Resize(object sender, EventArgs e)
        {
            int x = this.Size.Width;
            int y = this.Size.Height;
            tSSxy.Text = x.ToString() + " : " + y.ToString();
        }

        #endregion

        private void frmMainForm_Load(object sender, EventArgs e)
        {

        }
       
        private void btnTrogiup_Click(object sender, EventArgs e)
        {

        }

    }
}
