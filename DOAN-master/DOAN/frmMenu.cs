using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DOAN
{
    public partial class frmMenu : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        public frmMenu()
        {
            InitializeComponent();
        }

        private void BtnSlide_Click(object sender, EventArgs e)
        {
            if (menuVertical.Width == 250)
            {
                menuVertical.Width = 70;
                lblVersion.Visible = false;
            } else
            {
                menuVertical.Width = 250;
                lblVersion.Visible = true;
            }
            
        }

        private void BtnCLose_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void BtnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnRestore.Visible = true;
            btnMaximize.Visible = false;
        }

        private void BtnRestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestore.Visible = false;
            btnMaximize.Visible = true;
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PanelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle,0x112,0xf012,0);
        }


        // Hàm gọi form tới containter panel ở dạng dock fill
        private void CallChildFormToPanel(object childForm)
        {
            if (this.panelContainer.Controls.Count > 0)
                this.panelContainer.Controls.RemoveAt(0);
            Form fr = childForm as Form;
            fr.TopLevel = false;
            fr.Dock = DockStyle.Fill;
            this.panelContainer.Controls.Add(fr);
            this.panelContainer.Tag = fr;
            fr.Show();
        }
        private void BtnThongTin_Click(object sender, EventArgs e)
        {
            CallChildFormToPanel(new frmThongTin());
        }

        private void BtnSach_Click(object sender, EventArgs e)
        {
            CallChildFormToPanel(new frmSach());
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            CallChildFormToPanel(new Background());
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            CallChildFormToPanel(new Background());
        }

        private void BtnNhanVien_Click(object sender, EventArgs e)
        {
            CallChildFormToPanel(new frmQuanLyNhanVien());
        }
    }
}
