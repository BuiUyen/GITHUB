using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chỉnh_sửa_đồng_bộ_giá
{
    public partial class Form2 : Form
    {
        DataTableCollection tableCollection;
        public class LinhKien
        {
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
            public List<string> mListAnh { get; set; } = new List<string>();
            public string TenPhienBan { get; set; }
            public List<LinhKien> mListLinhKien { get; set; } = new List<LinhKien>();
        }

        public List<LinhKien> mList_Goc = new List<LinhKien>();
        public List<LinhKien> mList = new List<LinhKien>();

        public Form2()
        {
            InitializeComponent();
        }

        private void btnOpenFileExcel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                try
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        tbxFile.Text = openFileDialog.FileName;
                        using (var steam = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(steam))
                            {
                                DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }

                                });

                                tableCollection = result.Tables;
                                cbxSheet.Items.Clear();
                                foreach (System.Data.DataTable table in tableCollection)
                                    cbxSheet.Items.Add(table.TableName);
                            }
                        }
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Bảng Excel đang được sử dụng bởi một ứng dụng khác", "Thông Báo");
                    MessageBox.Show(Ex.ToString());
                }
            }
        }

        private void cbxSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable dt = tableCollection[cbxSheet.SelectedItem.ToString()];
                dataGridViewData.DataSource = dt;
                mList_Goc = (from DataRow dr in dt.Rows
                             select new LinhKien()
                             {
                                 Alias = dr["Đường dẫn / Alias"].ToString(),
                                 TenSanPham = dr["Tên sản phẩm"].ToString(),
                                 NoiDung = dr["Nội dung"].ToString(),
                                 NhaCungCap = dr["Nhà cung cấp"].ToString(),
                                 Loai = dr["Loại"].ToString(),
                                 Tag = dr["Tags"].ToString(),
                                 HienThi = dr["Hiển thị"].ToString(),
                                 ThuocTinh = dr["Thuộc tính 1(Option1 Name)"].ToString(),
                                 GiaTriThuocTinh = dr["Giá trị thuộc tính 1(Option1 Value)"].ToString(),
                                 ThuocTinh2 = dr["Thuộc tính 2(Option2 Name)"].ToString(),
                                 GiaTriThuocTinh2 = dr["Giá trị thuộc tính 2(Option2 Value)"].ToString(),
                                 ThuocTinh3 = dr["Thuộc tính 3(Option3 Name)"].ToString(),
                                 GiaTriThuocTinh3 = dr["Giá trị thuộc tính 1(Option3 Value)"].ToString(),
                                 SKU = dr["Mã (SKU)"].ToString(),
                                 QuanLyKho = dr["Quản lý kho"].ToString(),
                                 SoLuong = dr["Số lượng"].ToString(),
                                 ChoPhepBan = dr["Cho phép tiếp tục mua khi hết hàng(continue/deny)"].ToString(),
                                 Variant = dr["Variant Fulfillment Service"].ToString(),
                                 Gia = dr["Giá"].ToString(),
                                 GiaSoSanh = dr["Giá so sánh"].ToString(),
                                 YeuCauVanChuyen = dr["Yêu cầu vận chuyển"].ToString(),
                                 VAT = dr["VAT"].ToString(),
                                 MaVach = dr["Mã vạch(Barcode)"].ToString(),
                                 AnhDaiDien = dr["Ảnh đại diện"].ToString(),
                                 ChuThich = dr["Chú thích ảnh"].ToString(),
                                 TheTieuDe = dr["Thẻ tiêu đề(SEO Title)"].ToString(),
                                 TheMoTa = dr["Thẻ mô tả(SEO Description)"].ToString(),
                                 CanNang = dr["Cân nặng"].ToString(),
                                 DonViCan = dr["Đơn vị cân nặng"].ToString(),
                                 AnhPhienBan = dr["Ảnh phiên bản"].ToString(),
                                 MoTaNgan = dr["Mô tả ngắn"].ToString(),
                                 ID = dr["Id sản phẩm"].ToString(),
                                 IDTuyChon = dr["Id tùy chọn"].ToString()
                             }).ToList();


                for (int x = 0; x < mList_Goc.Count; x++)
                {
                    //xếp sản phẩm theo link
                    if (mList.FirstOrDefault(v => v.ID == mList_Goc[x].ID) == null)
                    {
                        LinhKien _linhkien = new LinhKien();
                        _linhkien = mList_Goc[x];
                        if (mList_Goc[x].AnhDaiDien == "")
                        {

                        }
                        else
                        {
                            _linhkien.mListAnh.Add(mList_Goc[x].AnhDaiDien);
                        }
                        mList.Add(_linhkien);
                    }
                    else
                    {
                        int stt = mList.FindIndex(v => v.ID == mList_Goc[x].ID);
                        mList[stt].mListAnh.Add(mList_Goc[x].AnhDaiDien);
                    }

                    //tạo tên phiên bản
                    if (mList_Goc[x].TenSanPham == "")
                    {
                        LinhKien lk = mList_Goc.FirstOrDefault(v => v.ID == mList_Goc[x].ID);
                        mList_Goc[x].TenPhienBan = lk.TenSanPham + " - " + mList_Goc[x].GiaTriThuocTinh;
                    }
                    else
                    {
                        mList_Goc[x].TenPhienBan = mList_Goc[x].TenSanPham;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Bảng Excel đang được sử dụng bởi một ứng dụng khác", "Thông Báo");
                MessageBox.Show(Ex.ToString());
            }
        }
        public string link = "";

        private void btnChaySKU_Click(object sender, EventArgs e)
        {
            string SKU = tbxSKU.Text;
            LinhKien _linhkien = new LinhKien();
            _linhkien = mList_Goc.FirstOrDefault(v => v.SKU == SKU);
            if(_linhkien == null)
            {

            }
            else
            {
                link = @"https://mualinhkien.vn/" + _linhkien.Alias;
                web_sapo.Navigate(link);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbxHTML2.Text = HTML_to_Text(tbxHTML.Text);
        }

        public static string HTML_to_Text(string sHTML)
        {
            //--------< HTML_to_Text() >--------

            //< remove blocks >

            sHTML = remove_script(sHTML);

            sHTML = remove_Head(sHTML);

            //</ remove blocks >



            //< remove Html-Tags >

            sHTML = remove_Tags(sHTML);

            //</ remove Html-Tags >



            //< remove Charaters >

            sHTML = remove_Control_Characters(sHTML);

            sHTML = remove_HTML_Characters(sHTML);

            sHTML = remove_Special_Characters(sHTML);

            sHTML = remove_Punctuation_Mark_Characters(sHTML);

            sHTML = remove_Brackets_Characters(sHTML);

            //</ remove Charaters >


            //< output >

            return sHTML;

            //</ output >

            //--------</ HTML_to_Text() >--------
        }
        public static string remove_HTML_Characters(string sHTML)
        {
            //--------< HTML_to_Text() >--------

            sHTML = sHTML.Replace("&gt;", " ");

            sHTML = sHTML.Replace("&lt;", " ");

            sHTML = sHTML.Replace("&nbsp;", " ");

            sHTML = sHTML.Replace("&gt;", " ");

            while (sHTML.IndexOf("  ") >= 0)

            { sHTML = sHTML.Replace("  ", " "); }

            //< output >
            return sHTML;
            //</ output >
            //--------</ HTML_to_Text() >--------
        }
        public static string remove_Special_Characters(string sHTML)
        {
            //--------< HTML_to_Text() >--------

            sHTML = sHTML.Replace("\\", " ");

            sHTML = sHTML.Replace("/", " ");

            while (sHTML.IndexOf("  ") >= 0)

            { sHTML = sHTML.Replace("  ", " "); }
            
            //< output >
            return sHTML;
            //</ output >
            //--------</ HTML_to_Text() >--------
        }
        public static string remove_Punctuation_Mark_Characters(string sHTML)
        {
            //--------< remove_Punctuation_Mark_Characters() >--------

            sHTML = sHTML.Replace(";", " ");

            sHTML = sHTML.Replace(".", " ");

            sHTML = sHTML.Replace(",", " ");

            sHTML = sHTML.Replace("'", " ");

            sHTML = sHTML.Replace(":", " ");

            sHTML = sHTML.Replace("*", " ");

            sHTML = sHTML.Replace("+", " ");

            sHTML = sHTML.Replace("=", " ");

            sHTML = sHTML.Replace("\"", " ");

            sHTML = sHTML.Replace("-", " ");

            sHTML = sHTML.Replace("_", " ");

            sHTML = sHTML.Replace("!", " ");

            sHTML = sHTML.Replace("?", " ");

            sHTML = sHTML.Replace("~", " ");

            sHTML = sHTML.Replace("#", " ");

            sHTML = sHTML.Replace("$", " ");

            sHTML = sHTML.Replace("%", " ");

            sHTML = sHTML.Replace("`", " ");

            sHTML = sHTML.Replace("´", " ");

            sHTML = sHTML.Replace("°", " ");

            sHTML = sHTML.Replace("^", " ");

            sHTML = sHTML.Replace("&", " ");

            while (sHTML.IndexOf("  ") >= 0)
            { sHTML = sHTML.Replace("  ", " "); }
            //< output >
            return sHTML;
            //</ output >
            //--------</ remove_Punctuation_Mark_Characters() >--------
        }
        public static string remove_Brackets_Characters(string sHTML)
        {
            //--------< remove_Brackets_Characters() >--------

            sHTML = sHTML.Replace("(", " ");

            sHTML = sHTML.Replace(")", " ");

            sHTML = sHTML.Replace("[", " ");

            sHTML = sHTML.Replace("]", " ");

            sHTML = sHTML.Replace("{", " ");

            sHTML = sHTML.Replace("}", " ");

            sHTML = sHTML.Replace("<", " ");

            sHTML = sHTML.Replace(">", " ");

            while (sHTML.IndexOf("  ") >= 0)

            { sHTML = sHTML.Replace("  ", " "); }

            //< output >

            return sHTML;

            //</ output >

            //--------</ remove_Brackets_Characters() >--------

        }
        public static string remove_Control_Characters(string sHTML)
        {
            //--------< HTML_to_Text() >--------

            sHTML = sHTML.Replace("\n", " ");

            sHTML = sHTML.Replace("\r", " ");

            sHTML = sHTML.Replace("\t", " ");

            while (sHTML.IndexOf("  ") >= 0)

            { sHTML = sHTML.Replace("  ", " "); }

            //< output >

            return sHTML;

            //</ output >

            //--------</ HTML_to_Text() >--------

        }
        public static string remove_Tags(string sHTML)
        {
            //--------< remove_Tags() >--------
            //----< @Loop: Search tags >----

            int intStart = -1;
            while (1 == 1)
            {

                //---< Search Tag >---
                //< check end >

                if (sHTML.Length <= intStart) break;
                //< check end >

                //< find open >

                int posOpenTag = sHTML.IndexOf("<", intStart + 1);

                if (posOpenTag < 0) break;

                //</ find open >
                //< find close >

                int posCloseTag = sHTML.IndexOf(">", posOpenTag);

                if (posCloseTag < 0) break; //no end tag

                //</ find close >
                //< cut Tag >

                string sLeft = sHTML.Substring(0, posOpenTag);

                string sRight = sHTML.Substring(posCloseTag + 1);

                sHTML = sLeft + " " + sRight;

                //</ cut Tag >
                intStart = sLeft.Length;

                //---</ Search Tag >---
            }
            //----</ @Loop: Search tags >----
            //< output >

            return sHTML;

            //</ output >

            //--------</ remove_Tags() >--------

        }
        public static string remove_script(string sHTML)
        {
            //--------< remove_script() >--------
            //----< @Loop: Search tags >----

            int intStart = 0;
            while (1 == 1)
            {
                //---< Search Tag >---
                //< check end >

                if (sHTML.Length <= intStart) break;
                //< check end >
                //< find open >

                int posscript_Open = sHTML.IndexOf("<script", intStart + 1, comparisonType: System.StringComparison.InvariantCultureIgnoreCase);
                if (posscript_Open < 0) break; //no open tag
                //</ find open >                
                //< find close >

                int posscript_Close = sHTML.IndexOf("</script", posscript_Open + 1, comparisonType: System.StringComparison.InvariantCultureIgnoreCase);
                if (posscript_Close < 0) break; //no end tag
                //</ find close >
                //< find close >
                int posCloseTag = sHTML.IndexOf(">", posscript_Close);
                if (posCloseTag < 0) break; //no end tag
                //</ find close >
                //< cut Tag >
                string sLeft = sHTML.Substring(0, posscript_Open);
                string sRight = sHTML.Substring(posCloseTag + 1);
                sHTML = sLeft + sRight;
                //</ cut Tag >
                intStart = sLeft.Length;
                //---</ Search Tag >---
            }

            //----</ @Loop: Search tags >----
            //< output >

            return sHTML;
            //</ output >
            //--------</ remove_script() >--------

        }
        public static string remove_Head(string sHTML)
        {
            //--------< remove_Head() >--------
            //----< @Loop: Search tags >----

            int intStart = 0;
            while (1 == 1)
            {
                //---< Search Tag >---
                //< check end >
                if (sHTML.Length <= intStart) break;
                //< check end >
                //< find open >
                
                int posHead_Open = sHTML.IndexOf("<head", intStart + 1, comparisonType: System.StringComparison.InvariantCultureIgnoreCase);
                if (posHead_Open < 0) break; //no open tag                
                //</ find open >
                //< find close >
                
                int posHead_Close = sHTML.IndexOf("</head", posHead_Open + 1, comparisonType: System.StringComparison.InvariantCultureIgnoreCase);
                if (posHead_Close < 0) break; //no end tag
                
                //</ find close >
                //< find close >

                int posCloseTag = sHTML.IndexOf(">", posHead_Close);
                if (posCloseTag < 0) break; //no end tag
                //</ find close >
                //< cut Tag >
                
                string sLeft = sHTML.Substring(0, posHead_Open);

                string sRight = sHTML.Substring(posCloseTag + 1);

                sHTML = sLeft + sRight;
                //</ cut Tag >
                intStart = sLeft.Length;
                //---</ Search Tag >---
            }
            
            //----</ @Loop: Search tags >----
            //< output >

            return sHTML;
            //</ output >
            //--------</ remove_Head() >--------

        }
    }
}
