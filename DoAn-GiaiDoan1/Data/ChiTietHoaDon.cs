using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_GiaiDoan1.Data
{
    public class ChiTietHoaDon
    {
        public int ID { get; set; }
        public int HoaDonID {  get; set; }
        public int DVID { get; set; }
      
       
        public DateTime GioVao { get; set; }
        public DateTime GioRa { get; set; }
        public decimal DonGia { get; set; }

        public virtual HoaDon HoaDon { get; set; } = null!;
        public virtual DichVu DichVu { get; set; } = null!;
    

    }
    [NotMapped]
    public class  DanhSachChiTietHoaDon
    {
        public int ID { get; set; }
        public int HoaDonID { get; set; }
        public int DVID { get; set; }
        public string TenPhong { get; set; }
        public string LoaiPhong { get; set; }
        public string TenDV { get; set; }
        public DateTime GioVao { get; set; }
        public DateTime GioRa { get; set; }
        public decimal DonGia { get; set; }
    }
}
