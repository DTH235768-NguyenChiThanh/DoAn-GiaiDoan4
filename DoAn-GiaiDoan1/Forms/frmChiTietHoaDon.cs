using DoAn_GiaiDoan1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_GiaiDoan1.Forms
{
    public partial class frmChiTietHoaDon : Form
    {
        public frmChiTietHoaDon()
        {
            InitializeComponent();
        }
        QLQKOKDbContext context = new QLQKOKDbContext();
        int id;
    }
}
