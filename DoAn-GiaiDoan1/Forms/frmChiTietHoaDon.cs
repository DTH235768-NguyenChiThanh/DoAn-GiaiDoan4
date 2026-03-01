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
        public frmChiTietHoaDon(int maHoaDon = 0)
        {
            InitializeComponent();
            id = maHoaDon;
        }
        QLQKOKDbContext context = new QLQKOKDbContext();
        int id;
        BindingList<DanhSachChiTietHoaDon> chiTietHoaDOn = new BindingList<DanhSachChiTietHoaDon>();

        public void LayNhanVien()
        {
            cbNhanVien.DataSource = context.NhanVien.ToList();
            cbNhanVien.ValueMember = "ID";
            cbNhanVien.DisplayMember = "TenNV";
        }
        public void LayKhachHang()
        {
            cbKhachHang.DataSource = context.KhachHang.ToList();
            cbKhachHang.ValueMember = "ID";
            cbKhachHang.DisplayMember = "TenKH";
        }
    }
}
