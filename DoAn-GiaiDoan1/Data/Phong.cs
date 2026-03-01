using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_GiaiDoan1.Data
{
    public class Phong
    {
        public int ID {  get; set; }
        public string TenPhong { get; set; }
        public int LoaiPhongID { get; set; }
        public decimal GiaGio { get; set; }
        public string? TrangThai { get; set; }
        public string? HinhAnh { get; set; } 


        public virtual ObservableCollectionListSource<HoaDon> HoaDon { get; } = new();
        public virtual ObservableCollectionListSource<DatPhong> DatPhong { get; } = new();
        
        public virtual LoaiPhong LoaiPhong { get; set; } = null!;

    }
    public class DanhSachPhong
    {
        public int ID { get; set; }
        public string TenPhong { get; set; }
        public int LoaiPhongID { get; set; }
        public string TenLoaiPhong { get; set; }
        public decimal GiaGio { get; set; }
        public string TrangThai { get; set; }
        public Image HinhAnh { get; set; }
    }
}
