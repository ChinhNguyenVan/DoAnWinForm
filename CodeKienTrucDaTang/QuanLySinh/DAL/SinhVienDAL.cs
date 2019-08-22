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
   public class SinhVienDAL:DatabaseService
    {
        public bool XoaSinhVien(SinhVien sv)
        {
            return XoaSinhVien(sv.MaSinhVien);
        }
        public bool XoaSinhVien(string ma)
        {
            string sql = "delete from SinhVien where MaSinhVien=@ma";
            SqlParameter parMa = new SqlParameter("@ma", SqlDbType.NVarChar);
            parMa.Value = ma;
            bool kq = WriteData(sql, new[] { parMa });
            return kq;
        }
    }
}
