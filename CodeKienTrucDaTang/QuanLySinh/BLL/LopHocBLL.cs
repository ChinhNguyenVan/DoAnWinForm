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
    public class LopHocBLL
    {
        public List<LopHoc>GetAllLop()
        {
            LopHocDAL dal = new LopHocDAL();
            return dal.getAllLop();
        }
        public bool ThemMoiLopHoc(LopHoc lop)
        {
            if (lop.MaLop.Length != 5)
                throw new LoiNhapMaLop("Mã Lớp Phải Chính Xác 5 ký tự");
            if (lop.TenLop.Length < 10)
                throw new LoiNhapTenLop("Tên Lớp phải >=10 ký tự");
            //gọi dal lưu mới
            LopHocDAL dal = new LopHocDAL();
            return dal.ThemMoiLopHoc(lop);
        }
        public bool SuaLopHoc(LopHoc lop)
        {
            return new LopHocDAL().SuaLopHoc(lop);
        }
    }
}
