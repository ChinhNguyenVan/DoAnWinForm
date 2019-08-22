using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class LopHocDAL:DatabaseService
    {
        public List<LopHoc>getAllLop()
        {
            SqlDataReader reader = ReadData("select * from LopHoc");
            List<LopHoc> dsLop = new List<LopHoc>();
            while(reader.Read())
            {
                string ma = reader.GetString(0);
                string ten = reader.GetString(1);
                LopHoc lh = new LopHoc();
                lh.MaLop = ma;
                lh.TenLop = ten;
                dsLop.Add(lh);
            }
            reader.Close();
            return dsLop;
        }
        public bool ThemMoiLopHoc(LopHoc lop)
        {
            //tương tác csdl để thêm mới
            string sql = "insert into LopHoc values(@ma,@ten)";
            SqlParameter parMa = new SqlParameter("@ma", SqlDbType.NVarChar);
            parMa.Value = lop.MaLop;
            SqlParameter parTen = new SqlParameter("@ten", SqlDbType.NVarChar);
            parTen.Value = lop.TenLop;
            bool kq = WriteData(sql, new[] { parMa, parTen });
            return kq;
        }
        public bool SuaLopHoc(LopHoc lop)
        {
            string sql = "update LopHoc set TenLop=@ten where MaLop=@ma";
            SqlParameter parTen = new SqlParameter("@ten", SqlDbType.NVarChar);
            parTen.Value = lop.TenLop;
            SqlParameter parMa = new SqlParameter("@ma", SqlDbType.NVarChar);
            parMa.Value = lop.MaLop;
            bool kq = WriteData(sql, new[] { parTen, parMa });
            return kq;
        }
    }
}
