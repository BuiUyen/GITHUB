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

            //Tên giao dịch chuyển hóa
            public string TenGiaoDich { get; set; }
        }

        List<GiaoDich> mList_Goc = new List<GiaoDich>();

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
            try
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
                foreach(GiaoDich gd in mList_Goc)
                {
                    switch (gd.Tien_Giao_Dich)
                    {
                        case "Payment Fee":
                            gd.TenGiaoDich = "Phí thanh toán";
                            break;
                        case "Shipping Fee Paid by Seller":
                            gd.TenGiaoDich = "Phí vận chuyển trả bởi nhà bán hàng";
                            break;
                        case "Shipping Fee (Paid By Customer)":
                            gd.TenGiaoDich = "Phí vận chuyển (trả bởi khách hàng)";
                            break;
                        case "Item Price Credit":
                            gd.TenGiaoDich = "Giá trị món hàng";
                            break;
                        case "Reversal Item Price":
                            gd.TenGiaoDich = "Hoàn lại giá trị sản phẩm";
                            break;
                        case "Sponsored Product Fee":
                            gd.TenGiaoDich = "Phí giới thiệu sản phẩm ";
                            break;
                        case "Promotional Charges Vouchers":
                            gd.TenGiaoDich = "Phiếu giảm giá khuyến mại";
                            break;
                        case "Pick Up Fee":
                            gd.TenGiaoDich = "Phí lấy hàng";
                            break;
                        case "Reversal shipping Fee (Paid by Customer)":
                            gd.TenGiaoDich = "Hoàn lại phí vận chuyển (trả bởi khách hàng)";
                            break;
                        case "Marketing solution /social media advertising":
                            gd.TenGiaoDich = "Phí Dịch vụ Thương mại điện tử";
                            break;
                        case "Promotional Charges Flexi-Combo":
                            gd.TenGiaoDich = "Phí khuyến mãi combo linh hoạt";
                            break;
                        case "Reversal Promotional Charges Flexi-Combo":
                            gd.TenGiaoDich = "PHoàn lại phí khuyến mãi combo linh hoạthí";
                            break;
                        case "Shipping Fee Voucher (by Lazada)":
                            gd.TenGiaoDich = "Voucher Phí Vận chuyển (của Lazada)";
                            break;
                        case "Sponsored Affiliates":
                            gd.TenGiaoDich = "Giải pháp Tiếp thị liên kết";
                            break;
                        case "Sponsored Affiliates Refund":
                            gd.TenGiaoDich = "Hoàn trả chi phí Tiếp thị Liên kết";
                            break;
                        case "Sponsored Search - Top up":
                            gd.TenGiaoDich = "Sponsored Search - Top up";
                            break;
                        default:
                            gd.TenGiaoDich = "Phí khác";
                            break;
                    }
                }    



                for (int x = 0; x < mList_Goc.Count; x++)
                {
                    if (mList.FirstOrDefault(v => v.ID == mList_Goc[x].ID) == null)
                    {
                        LinhKien _linhkien = new LinhKien();
                        _linhkien.ID = mList_Goc[x].ID;
                        if (mList_Goc[x].LinkAnh == "")
                        {

                        }
                        else
                        {
                            _linhkien.mListAnh.Add(mList_Goc[x].LinkAnh);
                        }
                        mList.Add(_linhkien);
                    }
                    else
                    {
                        int stt = mList.FindIndex(v => v.ID == mList_Goc[x].ID);
                        mList[stt].mListAnh.Add(mList_Goc[x].LinkAnh);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Bảng Excel đang được sử dụng bởi một ứng dụng khác", "Thông Báo");
            }
        }

        private void cbxSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
