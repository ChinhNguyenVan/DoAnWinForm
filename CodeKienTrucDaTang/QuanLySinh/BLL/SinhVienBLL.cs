using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using EL;
namespace BLL
{
    public class SinhVienBLL
    {
        public bool XoaSinhVien(string ma)
        {
            SinhVienDAL dal = new SinhVienDAL();
            return dal.XoaSinhVien(ma);
        }
        public bool XoaSinhVien(SinhVien sv)
        {
            return XoaSinhVien(sv.MaSinhVien);
        }
    }
}
