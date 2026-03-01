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
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }
        QLQKOKDbContext context = new QLQKOKDbContext();
        int id;
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            List<DanhSachHoaDon> hd = new List<DanhSachHoaDon>();
            hd = context.HoaDon.Select(r => new DanhSachHoaDon
            {
                ID = r.ID,
                PhongID = r.PhongID,
                TenPhong = r.Phong.TenPhong,
                KHID = r.KHID,
                HoVaTenKhachHang = r.KhachHang.TenKH,
                NVID = r.NVID,
                HoVaTenNhanVien = r.NhanVien.TenNV,
                NgayLap = r.NgayLap,
                //TongTien = r.ChiTietHoaDon.Sum(r => (r.GioRa - r.GioVao) * r.DonGia),
                XemChiTiet = "Xem chi tiết"
            }).ToList();
            dataGridView1.DataSource = hd;
        }

        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            using (frmChiTietHoaDon chiTiet = new frmChiTietHoaDon())
            {
                chiTiet.ShowDialog();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
            using (frmChiTietHoaDon chiTiet = new frmChiTietHoaDon(id))
            {
                chiTiet.ShowDialog();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa hoá đơn?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
                HoaDon hd = context.HoaDon.Find(id);
                if (hd != null)
                {
                    context.HoaDon.Remove(hd);
                }
                context.SaveChanges();
                frmHoaDon_Load(sender, e);
            }
        }
    }
}
