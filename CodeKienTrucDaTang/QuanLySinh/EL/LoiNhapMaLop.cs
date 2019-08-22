using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
   public class LoiNhapMaLop:ApplicationException
    {
        public string LoiChiTiet { get; set; }
        public LoiNhapMaLop(string msg)
        {
            LoiChiTiet = msg;
        }
    }
}
