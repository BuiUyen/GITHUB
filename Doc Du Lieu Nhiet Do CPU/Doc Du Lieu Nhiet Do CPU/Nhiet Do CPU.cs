using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace Doc_Du_Lieu_Nhiet_Do_CPU
{
    public partial class Nhiet_Do_CPU : Form
    {
        public Nhiet_Do_CPU()
        {
            InitializeComponent();
            Double temperature = 0;
            String instanceName = "";


            // Query the MSAcpi_ThermalZoneTemperature API
            // Note: run your app or Visual Studio (while programming) or you will get "Access Denied"
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\WMI", "SELECT * FROM MSAcpi_ThermalZoneTemperature");

            foreach (ManagementObject obj in searcher.Get())
            {
                temperature = Convert.ToDouble(obj["CurrentTemperature"].ToString());
                // Convert the value to celsius degrees
                temperature = (temperature - 2732) / 10.0;
                instanceName = obj["InstanceName"].ToString();
            }

            // Print the values e.g:

            // 29.8
            Console.WriteLine(temperature);

            // ACPI\ThermalZone\TZ01_0
            Console.WriteLine(instanceName);
        }        
    }
}
