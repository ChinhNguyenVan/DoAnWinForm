using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class LoiNhapTenLop:ApplicationException
    {
        public string LoiChiTiet { get; set; }
        public LoiNhapTenLop(string msg)
        {
            LoiChiTiet = msg;
        }
    }
}
