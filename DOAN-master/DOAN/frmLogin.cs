using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DOAN.Classes;
namespace DOAN
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        Database db = new Database();


        public bool CheckData()
        {
           if (String.IsNullOrWhiteSpace(txtUserName.Text))
            {
                txtUserName.Focus();
                MessageBox.Show("Vui lòng nhập tên tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtUserName.Focus();
                MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            string filelogin = Application.StartupPath + "\\login.dat";
            IOUtil iou = new IOUtil();
            object data = iou.DocFile(filelogin);
            if (data != null)
            {
                Login log = data as Login;
                if (log.Save)
                {
                    txtUserName.Text = log.UserName;
                    txtPassword.Text = log.PassWord;
                    chkSave.Checked = true;
                }
            }
        }

        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            if (db.KiemTraDangNhap(txtUserName.Text, txtPassword.Text))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK);
                DialogResult = DialogResult.OK;

                string fileLogin = Application.StartupPath + "\\login.dat";
                IOUtil iou = new IOUtil();
                Login log = new Login();
                log.UserName = txtUserName.Text;
                log.PassWord = txtPassword.Text;
                log.Save = chkSave.Checked;
                iou.LuuFile(log, fileLogin);
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại, vui lòng kiểm tra lại tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                txtPassword.Text = "";
                // DialogResult = DialogResult.Cancel;
            }
            db.sqlConn.Close();
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
