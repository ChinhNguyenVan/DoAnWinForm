using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN
{
    class NhanVien
    {
        Database db;
        public NhanVien()
        {
            db = new Database();
        }

        public DataTable LayDSNhanVien()
        {
            string sqlStr = "SELECT MaNhanVien, HoTenNhanVien, NgaySinh, DiaChi, DienThoai, Email , TenBangCap,UserName,Password FROM NHANVIEN N, BANGCAP B WHERE N.MaBangCap = B.MaBangCap"; ;
            DataTable dt = db.Execute(sqlStr);
            return dt;
        }
        public DataTable LayBangCap()
        {
            string sqlStr = "SELECT * FROM BANGCAP";//chuỗi query để lấy dữ liệu
            DataTable dt = db.Execute(sqlStr); // truyền dữ liệu vào datatable
            return dt;
        }

        public void XoaNhanVien(string manv)
        {
            string sqlStr = "DELETE FROM NHANVIEN WHERE MaNhanVien = " + manv;
            db.ExecuteNonQuery(sqlStr);
        }

        public void ThemNhanVien(string ten, string ngaysinh, string diachi, string dienthoai, string email, string index_bc, string user, string pwd)
        {
            string sqlStr = string.Format("INSERT INTO NHANVIEN VALUES (N'{0}', '{1}', N'{2}', '{3}', '{4}','{5}','{6}','{7}')", ten, ngaysinh, diachi, dienthoai, email, index_bc, user, pwd);
            db.ExecuteNonQuery(sqlStr);
        }

        public void CapNhatNhanVien(string index_nv, string ten, string ngaysinh, string diachi, string dienthoai, string email, string index_bc, string user, string pwd)
        {
            string sqlStr = string.Format("UPDATE NHANVIEN SET HoTenNhanVien = N'{0}', NgaySinh = '{1}', DiaChi = N'{2}', DienThoai = '{3}',Email = '{4}' ,MaBangCap = {5},UserName = '{6}',Password='{7}' WHERE MaNhanVien = {8}", ten, ngaysinh, diachi, dienthoai, email, index_bc, user, pwd, index_nv);
            db.ExecuteNonQuery(sqlStr);
        }

        public DataTable TimKiem(string ten)
        {
            string sqlStr = string.Format("Select N.HoTenNhanVien, NgaySinh, DiaChi,DienThoai,Email,B.TenBangCap,UserName,Password from NHANVIEN N,BANGCAP B where N.MaBangCap = B.MaBangCap and HoTenNhanVien Like N'{0}%'", ten);
            DataTable dt = db.Execute(sqlStr);
            return dt;
        }
    }
}
