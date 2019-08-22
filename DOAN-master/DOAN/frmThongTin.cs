using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN
{
    public partial class frmThongTin : Form
    {
        public frmThongTin()
        {
            InitializeComponent();
        }

        private void FrmThongTin_SizeChanged(object sender, EventArgs e)
        {
            panel.Location = new Point(
                this.ClientSize.Width / 2 - panel.Size.Width / 2,
                this.ClientSize.Height / 2 - panel.Size.Height / 2);
            panel.Anchor = AnchorStyles.None;
        }
    }
}
