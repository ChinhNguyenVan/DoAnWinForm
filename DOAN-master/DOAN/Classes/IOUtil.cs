using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DOAN.Classes
{
    class IOUtil
    {
        public void LuuFile(object data, string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, data); //chụp đối tượng xuống ổ cứng
                fs.Close();//bắt buộc phải đóng file
            } 
            catch { }
        }
        public object DocFile(string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                object data = bf.Deserialize(fs); //nạp lại bộ nhớ
                fs.Close();
                return data;
            }
            catch { }
            return null;
        }
    }
}
