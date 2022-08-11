using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Sanita.Utility.Database.BaseDao;
using Sanita.Utility.Database.Utility;
using Medibox.Model;

namespace Medibox.Database
{
    public class SanPhamWebDB : BaseDB
    {
        //Constant
        private const String TAG = "SanPhamWebDB";
        //Singleton
        private static SanPhamWebDB _instance;
        public static SanPhamWebDB mInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SanPhamWebDB();
                }
                return _instance;
            }
        }
        public IList<SanPhamWeb> GetSanPhamWebs()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_sanphamweb ");
            DataTable dt = baseDAO.DoGetDataTable(sql.ToString());
            return (MakeSanPhamWebs(dt));
        }
        public SanPhamWeb GetSanPhamWeb()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_sanphamweb ");
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeSanPhamWeb(row));
        }
        public SanPhamWeb GetSanPhamWeb(int SanPhamWebID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_sanphamweb ");
            sql.Append(" WHERE SanPhamWebID = " + SanPhamWebID.Escape());
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeSanPhamWeb(row));
        }
        public int UpdateSanPhamWeb(IDbConnection connection, IDbTransaction trans, SanPhamWeb data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }

                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE tb_SanPhamWeb ");
                sql.Append("  SET  ");
                sql.Append("      Alias = " + data.Alias.Escape()).Append(", ");
                sql.Append("      TenSanPham = " + data.TenSanPham.Escape()).Append(", ");
                sql.Append("      NoiDung = " + data.NoiDung.Escape()).Append(", ");
                sql.Append("      NhaCungCap = " + data.NhaCungCap.Escape()).Append(", ");
                sql.Append("      Loai = " + data.Loai.Escape()).Append(", ");
                sql.Append("      Tag = " + data.Tag.Escape()).Append(", ");
                sql.Append("      HienThi = " + data.HienThi.Escape()).Append(", ");
                sql.Append("      ThuocTinh = " + data.ThuocTinh.Escape()).Append(", ");
                sql.Append("      GiaTriThuocTinh = " + data.GiaTriThuocTinh.Escape()).Append(", ");
                sql.Append("      ThuocTinh2 = " + data.ThuocTinh2.Escape()).Append(", ");
                sql.Append("      GiaTriThuocTinh2 = " + data.GiaTriThuocTinh2.Escape()).Append(", ");
                sql.Append("      ThuocTinh3 = " + data.ThuocTinh3.Escape()).Append(", ");
                sql.Append("      GiaTriThuocTinh3 = " + data.GiaTriThuocTinh3.Escape()).Append(", ");
                sql.Append("      SKU = " + data.SKU.Escape()).Append(", ");
                sql.Append("      QuanLyKho = " + data.QuanLyKho.Escape()).Append(", ");
                sql.Append("      SoLuong = " + data.SoLuong.Escape()).Append(", ");
                sql.Append("      ChoPhepBan = " + data.ChoPhepBan.Escape()).Append(", ");
                sql.Append("      Variant = " + data.Variant.Escape()).Append(", ");
                sql.Append("      Gia = " + data.Gia.Escape()).Append(", ");
                sql.Append("      GiaSoSanh = " + data.GiaSoSanh.Escape()).Append(", ");
                sql.Append("      YeuCauVanChuyen = " + data.YeuCauVanChuyen.Escape()).Append(", ");
                sql.Append("      VAT = " + data.VAT.Escape()).Append(", ");
                sql.Append("      MaVach = " + data.MaVach.Escape()).Append(", ");
                sql.Append("      AnhDaiDien = " + data.AnhDaiDien.Escape()).Append(", ");
                sql.Append("      ChuThich = " + data.ChuThich.Escape()).Append(", ");
                sql.Append("      TheTieuDe = " + data.TheTieuDe.Escape()).Append(", ");
                sql.Append("      TheMoTa = " + data.TheMoTa.Escape()).Append(", ");
                sql.Append("      CanNang = " + data.CanNang.Escape()).Append(", ");
                sql.Append("      DonViCan = " + data.DonViCan.Escape()).Append(", ");
                sql.Append("      AnhPhienBan = " + data.AnhPhienBan.Escape()).Append(", ");
                sql.Append("      MoTaNgan = " + data.MoTaNgan.Escape()).Append(", ");
                sql.Append("      ID = " + data.ID.Escape()).Append(", ");
                sql.Append("      IDTuyChon = " + data.IDTuyChon.Escape()).Append(", ");
                sql.Append("      TenPhienBan = " + data.TenPhienBan.Escape()).Append(", ");
                sql.Append("      MaNganhSenDo = " + data.MaNganhSenDo.Escape()).Append(", ");
                sql.Append("      ThongSo = " + data.ThongSo.Escape()).Append(", ");
                sql.Append("      CongDung = " + data.CongDung.Escape());
                sql.Append("  WHERE SanPhamWebID = " + data.SanPhamWebID);
                return baseDAO.DoUpdate(connection, trans, sql.ToString());
            }
        }
        public int InsertSanPhamWeb(IDbConnection connection, IDbTransaction trans, SanPhamWeb data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO tb_sanphamweb (");
                sql.Append("            Alias,");
                sql.Append("            TenSanPham,");
                sql.Append("            NoiDung,");
                sql.Append("            NhaCungCap,");
                sql.Append("            Loai,");
                sql.Append("            Tag,");
                sql.Append("            HienThi,");
                sql.Append("            ThuocTinh,");
                sql.Append("            GiaTriThuocTinh,");
                sql.Append("            ThuocTinh2,");
                sql.Append("            GiaTriThuocTinh2,");
                sql.Append("            ThuocTinh3,");
                sql.Append("            GiaTriThuocTinh3,");
                sql.Append("            SKU,");
                sql.Append("            QuanLyKho,");
                sql.Append("            SoLuong,");
                sql.Append("            ChoPhepBan,");
                sql.Append("            Variant,");
                sql.Append("            Gia,");
                sql.Append("            GiaSoSanh,");
                sql.Append("            YeuCauVanChuyen,");
                sql.Append("            VAT,");
                sql.Append("            MaVach,");
                sql.Append("            AnhDaiDien,");
                sql.Append("            ChuThich,");
                sql.Append("            TheTieuDe,");
                sql.Append("            TheMoTa,");
                sql.Append("            CanNang,");
                sql.Append("            DonViCan,");
                sql.Append("            AnhPhienBan,");
                sql.Append("            MoTaNgan,");
                sql.Append("            ID,");
                sql.Append("            IDTuyChon,");
                sql.Append("            TenPhienBan,");
                sql.Append("            MaNganhSenDo,");
                sql.Append("            ThongSo,");
                sql.Append("            CongDung)");
                sql.Append("  VALUES( ");
                sql.Append("          " + data.Alias.Escape()).Append(", ");
                sql.Append("          " + data.TenSanPham.Escape()).Append(", ");
                sql.Append("          " + data.NoiDung.Escape()).Append(", ");
                sql.Append("          " + data.NhaCungCap.Escape()).Append(", ");
                sql.Append("          " + data.Loai.Escape()).Append(", ");
                sql.Append("          " + data.Tag.Escape()).Append(", ");
                sql.Append("          " + data.HienThi.Escape()).Append(", ");
                sql.Append("          " + data.ThuocTinh.Escape()).Append(", ");
                sql.Append("          " + data.GiaTriThuocTinh.Escape()).Append(", ");
                sql.Append("          " + data.ThuocTinh2.Escape()).Append(", ");
                sql.Append("          " + data.GiaTriThuocTinh2.Escape()).Append(", ");
                sql.Append("          " + data.ThuocTinh3.Escape()).Append(", ");
                sql.Append("          " + data.GiaTriThuocTinh3.Escape()).Append(", ");
                sql.Append("          " + data.SKU.Escape()).Append(", ");
                sql.Append("          " + data.QuanLyKho.Escape()).Append(", ");
                sql.Append("          " + data.SoLuong.Escape()).Append(", ");
                sql.Append("          " + data.ChoPhepBan.Escape()).Append(", ");
                sql.Append("          " + data.Variant.Escape()).Append(", ");
                sql.Append("          " + data.Gia.Escape()).Append(", ");
                sql.Append("          " + data.GiaSoSanh.Escape()).Append(", ");
                sql.Append("          " + data.YeuCauVanChuyen.Escape()).Append(", ");
                sql.Append("          " + data.VAT.Escape()).Append(", ");
                sql.Append("          " + data.MaVach.Escape()).Append(", ");
                sql.Append("          " + data.AnhDaiDien.Escape()).Append(", ");
                sql.Append("          " + data.ChuThich.Escape()).Append(", ");
                sql.Append("          " + data.TheTieuDe.Escape()).Append(", ");
                sql.Append("          " + data.TheMoTa.Escape()).Append(", ");
                sql.Append("          " + data.CanNang.Escape()).Append(", ");
                sql.Append("          " + data.DonViCan.Escape()).Append(", ");
                sql.Append("          " + data.AnhPhienBan.Escape()).Append(", ");
                sql.Append("          " + data.MoTaNgan.Escape()).Append(", ");
                sql.Append("          " + data.ID.Escape()).Append(", ");
                sql.Append("          " + data.IDTuyChon.Escape()).Append(", ");
                sql.Append("          " + data.TenPhienBan.Escape()).Append(", ");
                sql.Append("          " + data.MaNganhSenDo.Escape()).Append(", ");
                sql.Append("          " + data.ThongSo.Escape()).Append(", ");
                sql.Append("          " + data.CongDung.Escape()).Append(") ");
                int newId = baseDAO.DoInsert(connection, trans, sql.ToString());
                data.SanPhamWebID = newId;
                if (newId > 0)
                {
                    return newId;
                }
                else
                {
                    return DataTypeModel.RESULT_NG;
                }
            }
        }
        public int DeleteSanPhamWeb(SanPhamWeb data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM tb_sanphamweb  ");
                sql.Append("  WHERE SanPhamWebID = " + DatabaseUtility.Escape(data.SanPhamWebID));
                return baseDAO.DoUpdate(sql.ToString());
            }
        }

        public int DeleteAllSanPhamWeb()
        {
            lock (lockObject)
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" TRUNCATE tb_sanphamweb; ");
                sql.Append("  DELETE FROM tb_sanphamweb; ");
                return baseDAO.DoUpdate(sql.ToString());
            }
        }

        #region Utility
        private IList<SanPhamWeb> MakeSanPhamWebs(DataTable dt)
        {
            IList<SanPhamWeb> list = new List<SanPhamWeb>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MakeSanPhamWeb(row));
                }
            }
            return list;
        }
        private SanPhamWeb MakeSanPhamWeb(DataRow row)
        {
            SanPhamWeb record = new SanPhamWeb();
            if (row != null)
            {
                record.SetProperty(row);
            }
            return record;
        }
        #endregion
    }
}