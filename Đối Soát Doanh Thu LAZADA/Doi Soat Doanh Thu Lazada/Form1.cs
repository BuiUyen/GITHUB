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

namespace Doi_Soat_Doanh_Thu_Lazada
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            using (var steam = File.Open("Giá Sản Phẩm Lazada.xlsx", FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(steam))
                {
                    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }

                    });
                    tableCollection = result.Tables;
                    System.Data.DataTable dt = tableCollection["template"];                   
                    mList_SanPham = (from DataRow dr in dt.Rows
                                 select new SanPham()
                                 {
                                     SKU = dr["SellerSku"].ToString(),
                                     Gia = Double.Parse( dr["Price"].ToString()),
                                     Ten_San_Pham = dr["Name"].ToString()                                     
                                 }).ToList();
                }
            }
        }

        public class SanPham
        {
            public string SKU { get; set; }
            public double Gia { get; set; }
            public string Ten_San_Pham { get; set; }
            
        }

        public class DonHang
        {
            public string Ma_Don_Hang { get; set; }
            public double Gia_Tri_Ban_Dau { get; set; }
            public double Gia_Tri_Hang_Hoa { get; set; }
            public double Tong_Cac_Loai_Phi { get; set; }
            public double Tien_Thuc_Te { get; set; }

            public List<GiaoDich> mList_GiaoDich = new List<GiaoDich>();

        }

        public class GiaoDich
        {
            public string Ngay_Giao_Dich { get; set; }
            public string Loai_Giao_Dich { get; set; }
            public string Ten_Giao_Dich { get; set; }
            public string Ma_Giao_Dich { get; set; }
            public string Ten_San_Pham { get; set; }
            public string Ma_SKU_San_Pham { get; set; }
            public string Ma_Lazada_San_Pham { get; set; }
            public string Tien_Giao_Dich { get; set; }
            public string VAT_Giao_Dich { get; set; }
            public string Ky_Giao_Dich { get; set; }
            public string Trang_Thai_Giao_Dich { get; set; }
            public string Ma_Don_Hang { get; set; }
            public string Order_Item { get; set; }

            public int STT { get; set; }

            //Tên giao dịch chuyển hóa
            public string TenGiaoDich { get; set; }

            public double Gia_San_Pham { get; set; }
        }

        List<SanPham> mList_SanPham = new List<SanPham>();

        List<GiaoDich> mList_Goc = new List<GiaoDich>();

        List<DonHang> mList_DonHang = new List<DonHang>();

        DataTableCollection tableCollection;


        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tbxLinkFile.Text = openFileDialog.FileName;
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
        }        

        private void LoadData()
        {
            //try
            {
                System.Data.DataTable dt = tableCollection[cbxSheet.SelectedItem.ToString()];
                dataGridViewDataInput.DataSource = dt;
                mList_Goc = (from DataRow dr in dt.Rows
                             select new GiaoDich()
                             {
                                 Ngay_Giao_Dich = dr["Transaction Date"].ToString(),
                                 Loai_Giao_Dich = dr["Transaction Type"].ToString(),
                                 Ten_Giao_Dich = dr["Fee Name"].ToString(),
                                 Ma_Giao_Dich = dr["Transaction Number"].ToString(),
                                 Ten_San_Pham = dr["Details"].ToString(),
                                 Ma_SKU_San_Pham = dr["Seller SKU"].ToString(),
                                 Ma_Lazada_San_Pham = dr["Lazada SKU"].ToString(),
                                 Tien_Giao_Dich = dr["Amount"].ToString(),
                                 VAT_Giao_Dich = dr["VAT in Amount"].ToString(),
                                 Ky_Giao_Dich = dr["Statement"].ToString(),
                                 Trang_Thai_Giao_Dich = dr["Paid Status"].ToString(),
                                 Ma_Don_Hang = dr["Order No."].ToString(),
                                 Order_Item = dr["Order Item No."].ToString()
                             }).ToList();

                foreach (GiaoDich gd in mList_Goc)
                {
                    int stt;
                    if (mList_DonHang.FirstOrDefault(v => v.Ma_Don_Hang == gd.Ma_Don_Hang) == null)
                    {
                        DonHang mdonhang = new DonHang();
                        mdonhang.Ma_Don_Hang = gd.Ma_Don_Hang;
                        mList_DonHang.Add(mdonhang);
                        stt = mList_DonHang.Count - 1;
                    }
                    else
                    {
                        stt = mList_DonHang.FindIndex(v => v.Ma_Don_Hang == gd.Ma_Don_Hang);
                    }

                    if (gd.Ma_SKU_San_Pham != "")
                    {
                        var _sanpham = mList_SanPham.FirstOrDefault(v => v.SKU == gd.Ma_SKU_San_Pham);
                        if (_sanpham == null)
                        {
                            gd.Gia_San_Pham = double.Parse(gd.Tien_Giao_Dich);
                        }
                        else
                        {
                            gd.Gia_San_Pham = _sanpham.Gia;
                        }                        
                    }

                    switch (gd.Ten_Giao_Dich)
                    {
                        case "Item Price Credit":
                            gd.TenGiaoDich = "Giá trị món hàng";
                            
                            gd.STT = 1;
                            mList_DonHang[stt].Tien_Thuc_Te += double.Parse(gd.Tien_Giao_Dich);//Tiền nhận thực tế của 1 đơn hàng
                            
                            mList_DonHang[stt].Gia_Tri_Ban_Dau += gd.Gia_San_Pham;//Tổng giá trị đơn hàng theo giá đăng sản phẩm lazada
                            

                            mList_DonHang[stt].Gia_Tri_Hang_Hoa += double.Parse(gd.Tien_Giao_Dich);//Tổng giá trị đơn hàng theo giá đã khuyến mại
                            break;
                        case "Shipping Fee (Paid By Customer)":
                            gd.STT = 2;
                            mList_DonHang[stt].Tien_Thuc_Te += double.Parse(gd.Tien_Giao_Dich);
                            gd.TenGiaoDich = "Phí vận chuyển (trả bởi khách hàng)";
                            break;
                        case "Payment Fee":
                            gd.STT = 3;
                            mList_DonHang[stt].Tien_Thuc_Te += double.Parse(gd.Tien_Giao_Dich);
                            gd.TenGiaoDich = "Phí thanh toán";
                            break;
                        case "Shipping Fee Paid by Seller":
                            gd.STT = 4;
                            mList_DonHang[stt].Tien_Thuc_Te += double.Parse(gd.Tien_Giao_Dich);
                            gd.TenGiaoDich = "Phí vận chuyển trả bởi nhà bán hàng";
                            break;
                        case "Shipping Fee Voucher (by Lazada)":
                            gd.STT = 5;
                            mList_DonHang[stt].Tien_Thuc_Te += double.Parse(gd.Tien_Giao_Dich);
                            gd.TenGiaoDich = "Voucher Phí Vận chuyển (của Lazada)";
                            break;
                        case "Reversal Item Price":
                            gd.STT = 6;
                            mList_DonHang[stt].Tien_Thuc_Te += double.Parse(gd.Tien_Giao_Dich);
                            gd.TenGiaoDich = "Hoàn lại giá trị sản phẩm";
                            break;
                        case "Reversal shipping Fee (Paid by Customer)":
                            gd.STT = 7;
                            mList_DonHang[stt].Tien_Thuc_Te += double.Parse(gd.Tien_Giao_Dich);
                            gd.TenGiaoDich = "Hoàn lại phí vận chuyển (trả bởi khách hàng)";
                            break;
                        case "Sponsored Product Fee":
                            gd.STT = 8;
                            mList_DonHang[stt].Tien_Thuc_Te += double.Parse(gd.Tien_Giao_Dich);
                            gd.TenGiaoDich = "Phí giới thiệu sản phẩm";
                            break;
                        case "Marketing solution /social media advertising":
                            gd.STT = 9;
                            mList_DonHang[stt].Tien_Thuc_Te += double.Parse(gd.Tien_Giao_Dich);
                            gd.TenGiaoDich = "Phí Dịch vụ Thương mại điện tử";
                            break;
                        case "Sponsored Affiliates":
                            gd.STT = 10;
                            mList_DonHang[stt].Tien_Thuc_Te += double.Parse(gd.Tien_Giao_Dich);
                            gd.TenGiaoDich = "Giải pháp Tiếp thị liên kết";
                            break;
                        case "Sponsored Search - Top up":
                            gd.STT = 11;
                            mList_DonHang[stt].Tien_Thuc_Te += double.Parse(gd.Tien_Giao_Dich);
                            gd.TenGiaoDich = "Sponsored Search - Top up";
                            break;
                        case "Promotional Charges Vouchers":
                            gd.STT = 12;
                            mList_DonHang[stt].Tien_Thuc_Te += double.Parse(gd.Tien_Giao_Dich);
                            gd.TenGiaoDich = "Phiếu giảm giá khuyến mại";
                            break;
                        case "Pick Up Fee":
                            gd.STT = 13;
                            mList_DonHang[stt].Tien_Thuc_Te += double.Parse(gd.Tien_Giao_Dich);
                            gd.TenGiaoDich = "Phí lấy hàng";
                            break;
                        case "Promotional Charges Flexi-Combo":
                            gd.STT = 14;
                            mList_DonHang[stt].Tien_Thuc_Te += double.Parse(gd.Tien_Giao_Dich);
                            gd.TenGiaoDich = "Phí khuyến mãi combo linh hoạt";
                            break;
                        case "Reversal Promotional Charges Flexi-Combo":
                            gd.STT = 15;
                            mList_DonHang[stt].Tien_Thuc_Te += double.Parse(gd.Tien_Giao_Dich);
                            gd.TenGiaoDich = "Hoàn lại phí khuyến mãi combo linh hoạt";
                            break;
                        case "Sponsored Affiliates Refund":
                            gd.STT = 16;
                            mList_DonHang[stt].Tien_Thuc_Te += double.Parse(gd.Tien_Giao_Dich);
                            gd.TenGiaoDich = "Hoàn trả chi phí Tiếp thị Liên kết";
                            break;
                        default:
                            gd.STT = 17;
                            mList_DonHang[stt].Tien_Thuc_Te += double.Parse(gd.Tien_Giao_Dich);
                            gd.TenGiaoDich = "Phí khác";
                            break;
                    }
                    mList_DonHang[stt].mList_GiaoDich.Add(gd);
                }
            }
            //catch
            //{
            //    MessageBox.Show("Bảng Excel đang được sử dụng bởi một ứng dụng khác", "Thông Báo");
            //}
        }

        private void cbxSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXuLi_Click(object sender, EventArgs e)
        {
            ShowDonHang();
        }

        public void ShowDonHang()
        {
            dataGridViewDataOutput.Rows.Clear();
            foreach (DonHang dh in mList_DonHang)
            {
                int n = dataGridViewDataOutput.Rows.Add();
                dataGridViewDataOutput.Rows[n].Cells[0].Value = dh.Ma_Don_Hang.ToString();
                dataGridViewDataOutput.Rows[n].Cells[1].Value = dh.Gia_Tri_Ban_Dau.ToString();
                dataGridViewDataOutput.Rows[n].Cells[2].Value = dh.Gia_Tri_Hang_Hoa.ToString();
                dataGridViewDataOutput.Rows[n].Cells[3].Value = dh.Tien_Thuc_Te.ToString();
                dataGridViewDataOutput.Rows[n].Cells[4].Value = dh.Tong_Cac_Loai_Phi.ToString();                
            }
        }
    }
}
