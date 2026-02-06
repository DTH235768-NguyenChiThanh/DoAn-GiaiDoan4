using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_GiaiDoan1.Data
{
    public class NhanVien
    {
        public int ID { get; set; }
        public string TenNV { get; set; }
        public string ChucVu { get; set; }
        public string SDT { get; set; }
         public string GioiTinh { get; set; }
        public virtual ObservableCollectionListSource<HoaDon> HoaDon { get; } = new();
        public virtual ObservableCollectionListSource<PhanCong> PhanCong { get; } = new();

        public TaiKhoan TaiKhoan { get; set; }
    }
}
