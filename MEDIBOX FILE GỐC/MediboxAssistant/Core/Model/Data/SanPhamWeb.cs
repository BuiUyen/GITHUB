using System;
using System.Collections.Generic;
using System.Linq;

namespace Medibox.Model
{
    [Serializable()]
    public class SanPhamWeb
    {
        public int SanPhamWebID { get; set; }
        public string Alias { get; set; }
        public string TenSanPham { get; set; }
        public string NoiDung { get; set; }
        public string NhaCungCap { get; set; }
        public string Loai { get; set; }
        public string Tag { get; set; }
        public string HienThi { get; set; }
        public string ThuocTinh { get; set; }
        public string GiaTriThuocTinh { get; set; }
        //
        public string ThuocTinh2 { get; set; }
        public string GiaTriThuocTinh2 { get; set; }
        //
        public string ThuocTinh3 { get; set; }
        public string GiaTriThuocTinh3 { get; set; }
        //
        public string SKU { get; set; }
        public string QuanLyKho { get; set; }
        public string SoLuong { get; set; }
        public string ChoPhepBan { get; set; }

        public string Variant { get; set; }
        public string Gia { get; set; }
        public string GiaSoSanh { get; set; }
        public string YeuCauVanChuyen { get; set; }
        public string VAT { get; set; }
        public string MaVach { get; set; }
        public string AnhDaiDien { get; set; }
        public string ChuThich { get; set; }
        public string TheTieuDe { get; set; }
        public string TheMoTa { get; set; }
        public string CanNang { get; set; }
        public string DonViCan { get; set; }
        public string AnhPhienBan { get; set; }
        public string MoTaNgan { get; set; }
        public string ID { get; set; }
        public string IDTuyChon { get; set; }

        //thông số thêm
        
        public string TenPhienBan { get; set; }        
        public string MaNganhSenDo { get; set; }
        public string ThongSo { get; set; }
        public string CongDung { get; set; }
        public List<string> mListAnh { get; set; } = new List<string>();
        public List<SanPhamWeb> mListPhanLoai { get; set; } = new List<SanPhamWeb>();
        public List<SanPhamWeb> mListLinhKien { get; set; } = new List<SanPhamWeb>();
    }
}