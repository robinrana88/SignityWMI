using Microsoft.Management.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace SignityWMI.Services
{
    public class Software
    {
        public string UnInstallSoftware(string programName)
        {
            CimSession session = CimSession.Create("localHost");
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_Product ");

            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Product");
            foreach (var item in mos.Get())
            {
                if (item["Name"].ToString() == programName)
                {
                    //object hr = item.InvokeMethod("Uninstall", null);
                    // return (bool)hr;
                }
            }

            foreach (CimInstance cimObj in queryInstance)
            {
                //cimObj.Uninstall();
            }
            return "";
        }

        public string GetBIOScaption()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return "BIOS Caption: " + wmi.GetPropertyValue("Caption").ToString();
                }
                catch { }
            }
            return "BIOS Caption: Not found";
        }

        public string GetBIOSmaker()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return "BIOS Maker: " + wmi.GetPropertyValue("Manufacturer").ToString();
                }
                catch { }
            }
            return "BIOS maker not found";
        }

        public string GetBiosSerialNo()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return "BIOS Serial Number:" + wmi.GetPropertyValue("SerialNumber").ToString();
                }
                catch { }
            }
            return "BIOS serial number not found";
        }
    }
}
