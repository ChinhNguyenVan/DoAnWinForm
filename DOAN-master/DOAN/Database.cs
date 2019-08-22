using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN
{
    class Database
    {
        public SqlConnection sqlConn; // Khởi tạo đối tượng kết nối DB SqlConnection trong thư viện SqlClient
        SqlDataAdapter da; // Khởi tạo bộ điều phối dữ liệu (Data Adapter)
        DataSet ds; // Khởi tạo đói tượng chứa dữ liệu khi giao tiếp trong thư viện Data

        // Khởi tạo Constuctor Database tạo lập kết nối
        public string srvName = "DESKTOP-A2AA0FN\\SQLEXPRESS"; // Chỉ định tên Server
        public string dbName = "QLTHUVIEN_DOAN"; // Chỉ định tên DB
        public string dbUID = "sa";
        public string dbPWD = "abc"; // Mật khẩu Authentication
        public Database()
        {
            string strConn = "Data source=" + srvName + ";database=" + dbName + ";uid=" + dbUID + ";pwd = " + dbPWD + ";";
            sqlConn = new SqlConnection(strConn);
        }

        // Khởi tạo phương thức thực hiện truy vấn dữ liệu thông qua QUERY là tham số đầu vào sqlStr, kết quả trả về là một table, dùng cho các truy vấn Select...
        public System.Data.DataTable Execute(string sqlStr)
        {
            da = new SqlDataAdapter(sqlStr, sqlConn);
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        // Khởi tạo phương thức thực hiện các thao tác không trả về bao gồm Insert, Delete, Update ...
        public void ExecuteNonQuery(string sqlStr)
        {
            SqlCommand sqlcmd = new SqlCommand(sqlStr, sqlConn);
            sqlConn.Open(); // Mở kết nối
            sqlcmd.ExecuteNonQuery(); // THực thi lệnh
            sqlConn.Close(); // Đóng kết nối
        }

        public bool KiemTraDangNhap(string username, string password)
        {
            string query = "select * from NHANVIEN where UserName = @user and Password = @pwd";
            sqlConn.Open(); // Mở kết nối
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Connection = sqlConn;
            cmd.Parameters.Add("@user", SqlDbType.NVarChar).Value = username;
            cmd.Parameters.Add("@pwd", SqlDbType.NVarChar).Value = password;
            SqlDataReader reader = cmd.ExecuteReader();

            return reader.Read();
        }
    }
}
