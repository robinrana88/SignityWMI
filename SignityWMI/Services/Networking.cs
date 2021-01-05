using Microsoft.Management.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignityWMI.Services
{
    public class Networking
    {
        public string SerialNoOfsystem()
        {
            CimSession session = CimSession.Create("localHost");
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "Select * From Win32_NetworkAdapterConfiguration" + "Where IPEnabled = True");
            foreach (CimInstance cimObj in queryInstance)
            {
               // cimObj.ReleaseDHCPLease();
            }   
            return "";
        }

        public string MacAddress()
        {
            StringBuilder sb = new StringBuilder();
            CimSession session = CimSession.Create("localHost");
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "Select * From Win32_NetworkAdapterConfiguration" + "Where IPEnabled = True");
            foreach (CimInstance cimObj in queryInstance)
            {
                // cimObj.ReleaseDHCPLease();
                sb.Append("Mac address Name:" + cimObj.CimInstanceProperties["MACAddress"].ToString() + Environment.NewLine);
                //Console.WriteLine("Mac address Name: " + cimObj.CimInstanceProperties["MACAddress "].ToString());
            }
            return sb.ToString();
        }

        public string IPAddress()
        {
            StringBuilder sb = new StringBuilder();
            CimSession session = CimSession.Create("localHost");
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "Select * From Win32_NetworkAdapterConfiguration" + "Where IPEnabled = True");
            foreach (CimInstance cimObj in queryInstance)
            {
                // cimObj.ReleaseDHCPLease();
                sb.Append("IP address Name:" + cimObj.CimInstanceProperties["IPAddress"].ToString() + Environment.NewLine);
                //Console.WriteLine("IP address Name: " + cimObj.CimInstanceProperties["IPAddress "].ToString());
            }
            return sb.ToString();
        }

    }
}
