using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phan_mem_ban_hang_linh_kien
{
    public partial class Form3 : Form
    {        
        public List<FormMain.SanPham> ListSanPham = new List<FormMain.SanPham>();

        public Form3(List<FormMain.SanPham> ListInput)
        {            
            ListSanPham = ListInput;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource("DataSet1", ListSanPham);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
            ReportParameter RP = new ReportParameter("ReportParameterNgay", DateTime.Now.ToString("dd-MM-yyyy"));
            this.reportViewer1.LocalReport.SetParameters(RP);
            this.reportViewer1.RefreshReport();
        }
    }
}
