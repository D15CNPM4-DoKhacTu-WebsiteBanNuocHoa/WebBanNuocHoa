using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_NUOCHOA_TQ.Models
{
    public class ItemGioHang
    {
        public int IDSanPham { get; set; }
        public string TenSp { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public string HinhAnh { get; set; }

        public decimal ThanhTien { get; set; }
        public ItemGioHang(int IMaSP)
        {
            using (WebNuocHoa_TQEntities4 db = new WebNuocHoa_TQEntities4())
            {
                this.IDSanPham = IMaSP;
                SanPham sp = db.SanPham.Single(n => n.ID == IDSanPham);
                this.TenSp = sp.Ten;
                this.HinhAnh = sp.Anh;
                this.Gia = sp.Gia.Value;
                this.SoLuong = 1;
                this.ThanhTien = Gia * SoLuong;
            }
        }
        public ItemGioHang(int IMaSP, int sl)
        {
            using (WebNuocHoa_TQEntities4 db = new WebNuocHoa_TQEntities4())
            {
                this.IDSanPham = IMaSP;
                SanPham sp = db.SanPham.Single(n => n.ID == IDSanPham);
                TenSp = sp.Ten;
                HinhAnh = sp.Anh;
                Gia = sp.Gia.Value;
                this.SoLuong = sl;
                ThanhTien = Gia * SoLuong;

            }
        }
        public ItemGioHang()
        {

        }
    }
}