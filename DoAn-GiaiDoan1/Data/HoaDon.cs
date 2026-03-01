using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_GiaiDoan1.Data
{
    public class HoaDon
    {
        public int ID {  get; set; }
        public int PhongID { get; set; }
        public int KHID { get; set; }
        public int NVID { get; set; }
       public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }

        public virtual ObservableCollectionListSource<ChiTietHoaDon> ChiTietHoaDon { get; } = new();

        public virtual KhachHang KhachHang { get; set; } = null!;
        public virtual NhanVien NhanVien { get; set; } = null!;
        public virtual Phong Phong { get; set; } = null!;
    }
    [NotMapped]
    public class DanhSachHoaDon
    {
        public int ID { get; set; }
        public int PhongID { get; set; }
        public string TenPhong { get; set; }
        public int KHID { get; set; }
        public string HoVaTenKhachHang { get; set; }
        public int NVID { get; set; }
        public string HoVaTenNhanVien { get; set; }
        public DateTime NgayLap { get; set; }
        public string? XemChiTiet { get; set; }
        public decimal TongTien { get; set; }
    }
}
