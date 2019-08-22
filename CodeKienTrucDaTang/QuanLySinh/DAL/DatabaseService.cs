using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
   public  class DatabaseService
    {
        public string connectionString = "server=DESKTOP-A2AA0FN\\SQLEXPRESS;database=hutech_qlsv;uid=sa;pwd=abc";
        public SqlConnection connection;
        public SqlCommand command;
        public DatabaseService()
        {
            connection = new SqlConnection(connectionString);
        }
        public void OpenConnection()
        {
            if (connection != null && connection.State == ConnectionState.Closed)
                connection.Open();
        }
        public void CloseConnection()
        {
            if (connection != null && connection.State == ConnectionState.Open)
                connection.Close();
        }
        public SqlDataReader ReadData(string sql)
        {
            command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = connection;
            OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }
        public bool WriteData(string sql,SqlParameter[]pars)
        {
            command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = connection;
            OpenConnection();
            command.Parameters.AddRange(pars);
            int kq = command.ExecuteNonQuery();
            return kq > 0;
        }
    }
}
