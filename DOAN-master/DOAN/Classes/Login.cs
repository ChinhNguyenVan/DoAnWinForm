using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN.Classes
{
    [Serializable] //chụp ảnh lưu vô bộ nhớ , chụp hình lưu vô ổ cứng

    public class Login
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public bool Save { get; set; }
    }
}
