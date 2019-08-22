using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN
{
    public partial class frmQuanLyNhanVien : Form
    {
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }

        public bool themmoi = false;
        NhanVien nv = new NhanVien(); // Khai báo lớp nhân viên mình đã tạo

        void HienThiNhanVien()
        {
            DataTable dt = nv.LayDSNhanVien(); //gọi dữ liệu từ trong CSDL vào datatable
            dgvNhanVien.DataSource = dt; // lấy dữ liệu ra.
        }
        void HienThiBangCap()
        {
            DataTable dt = nv.LayBangCap();
            cboBangCap.DataSource = dt; // combobox lấy dữ liệu trong datatable
            cboBangCap.DisplayMember = "TenBangCap"; //Hiển thị tên bằng cấp lên màn hình
            cboBangCap.ValueMember = "MaBangCap"; // lưu trữ bằng mã bằng cấp
        }
        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            setButton(true);
            setNull();
            HienThiNhanVien();
            HienThiBangCap();
        }

        void setNull()
        {
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";
            txtUserName.Text = "";
            txtTimKiem.Text = "";
            txtPassword.Text = "";

        }

        void setButton(bool val)
        {
            btnThem.Enabled = val;
            btnXoa.Enabled = val;
            btnSua.Enabled = val;
            btnLuu.Enabled = !val;
            btnHuy.Enabled = !val;
        }


        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public bool CheckData()
        {
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Bạn chưa nhập email !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDienThoai.Text))
            {
                MessageBox.Show("Bạn chưa nhập Số điện thoại !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienThoai.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text) && string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Bạn phải cấp username và password cho nhân viên mới !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return false;
            }

            if (!this.txtEmail.Text.Contains('@') || !this.txtEmail.Text.Contains('.'))
            {
                MessageBox.Show("Bạn nhập sai Email rồi. check lại đi nhé!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //if (!new EmailAddressAttribute().IsValid(txtEmail.Text))
            //{
            //    MessageBox.Show("Email không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtEmail.Focus();
            //    return false;
            //}


            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                themmoi = true;
                setButton(false);

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ngay = String.Format("{0:MM/dd/yyyy}", dtpNgaySinh.Value);
            if (themmoi)
            {
                nv.ThemNhanVien(txtHoTen.Text, ngay, txtDiaChi.Text, txtDienThoai.Text, txtEmail.Text, cboBangCap.SelectedValue.ToString(), txtUserName.Text, txtPassword.Text);
                MessageBox.Show("Thêm mới thành công!");
            }
            else
            {
                nv.CapNhatNhanVien(dgvNhanVien.SelectedRows[0].Cells[0].Value.ToString(), txtHoTen.Text, ngay, txtDiaChi.Text, txtDienThoai.Text, txtEmail.Text, cboBangCap.SelectedValue.ToString(), txtUserName.Text, txtPassword.Text);
                MessageBox.Show("Cập nhật thành công!");
            }
            HienThiNhanVien();
            setNull();
            setButton(true);
            txtHoTen.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setButton(true);
            setNull();
            txtHoTen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            bool flag = dgvNhanVien.CurrentRow.Selected;
            if (flag && CheckData())
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn cập nhật dòng này!", "Thông báo báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    themmoi = false;
                    setButton(false);
                }
            }
            else
                MessageBox.Show("Bạn phải lựa chọn mẩu tin cần cập nhật!", "Lưu ý!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {

                txtHoTen.Text = dgvNhanVien.Rows[index].Cells["HoTenNhanVien"].Value.ToString();
                dtpNgaySinh.Text = dgvNhanVien.Rows[index].Cells["NgaySinh"].Value.ToString();
                txtDiaChi.Text = dgvNhanVien.Rows[index].Cells["DiaChi"].Value.ToString();
                txtDienThoai.Text = dgvNhanVien.Rows[index].Cells["DienThoai"].Value.ToString();
                txtEmail.Text = dgvNhanVien.Rows[index].Cells["Email"].Value.ToString();
                cboBangCap.Text = dgvNhanVien.Rows[index].Cells["TenBangCap"].Value.ToString();
                txtUserName.Text = dgvNhanVien.Rows[index].Cells["UserName"].Value.ToString();
                txtPassword.Text = dgvNhanVien.Rows[index].Cells["Password"].Value.ToString();

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int flag = dgvNhanVien.SelectedRows.Count;
            if (flag > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa dòng này!", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    nv.XoaNhanVien(dgvNhanVien.CurrentRow.Cells[0].Value.ToString());
                    dgvNhanVien.Rows.RemoveAt(this.dgvNhanVien.SelectedRows[0].Index);
                    setNull();
                }
            }
            else
                MessageBox.Show("Bạn phải chọn dòng cần xóa!", "Thông báo", MessageBoxButtons.OK);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dt = nv.TimKiem(txtTimKiem.Text); //gọi dữ liệu từ trong CSDL vào datatable
            dgvNhanVien.DataSource = dt;
            //HienThiNhanVien();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                HienThiNhanVien();
            }
            else
            {
                DataTable dt = nv.TimKiem(txtTimKiem.Text); //gọi dữ liệu từ trong CSDL vào datatable
                dgvNhanVien.DataSource = dt;
            }
        }
    }
}
