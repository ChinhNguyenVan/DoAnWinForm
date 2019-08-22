using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using EL;
namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            LopHocBLL bll = new LopHocBLL();
            gvLopHoc.DataSource = bll.GetAllLop();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtMa, "");
            errorProvider1.SetError(txtTen, "");
            try
            {
                LopHocBLL bLL = new LopHocBLL();
                LopHoc lop = new LopHoc();
                lop.MaLop = txtMa.Text;
                lop.TenLop = txtTen.Text;
                bool kq = bLL.ThemMoiLopHoc(lop);
                if (kq == true)
                {
                    MessageBox.Show("LƯU OK");
                    button1.PerformClick();//nạp lại DataGridView
                }
                else
                    MessageBox.Show("Lỗi Um Sùm");
            }
            catch(LoiNhapMaLop ex)
            {
                MessageBox.Show(ex.LoiChiTiet);
                errorProvider1.SetError(txtMa, ex.LoiChiTiet);
            }
            catch(LoiNhapTenLop ex)
            {
                MessageBox.Show(ex.LoiChiTiet);
                errorProvider1.SetError(txtTen, ex.LoiChiTiet);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SinhVienBLL bll = new SinhVienBLL();
            bool kq = bll.XoaSinhVien(txtMaSinhVien.Text);
            if (kq)
                MessageBox.Show("Xóa SV OK");
            else
                MessageBox.Show("Ko xóa được thím ơi");
        }

        private void GvLopHoc_CellContentClick(object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = gvLopHoc.Rows[e.RowIndex];
            txtMa.Text = row.Cells[0].Value + "";
            txtTen.Text = row.Cells[1].Value + "";

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            LopHoc lop = new LopHoc();
            lop.MaLop = txtMa.Text;
            lop.TenLop = txtTen.Text;
            bool kq = new LopHocBLL().SuaLopHoc(lop);
            if (kq)
                button1.PerformClick();
            else
                MessageBox.Show("NO!");
        }
    }
}
