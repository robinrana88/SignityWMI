using Microsoft.Management.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace SignityWMI.Services
{
    public class DateAndTime
    {
        public string ConnectingWMIRemotely()
        {

            CimSession session = CimSession.Create("localHost");
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_OperatingSystem");
             
            foreach (CimInstance cimObj in queryInstance)
            {
                //to useobject - SWbemDateTime
                //Console.WriteLine(cimObj.CimInstanceProperties["InstallDate"].ToString());
            }
            return "";
        }

        public string NameOfTimeZone() 
        {
            StringBuilder sb = new StringBuilder();
            CimSession session = CimSession.Create("localHost");
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_TimeZone");
            foreach (CimInstance cimObj in queryInstance)
            {
                sb.Append("Description :" + cimObj.CimInstanceProperties["Description"].ToString() + Environment.NewLine);
                sb.Append("Daylight Name :" + cimObj.CimInstanceProperties["DaylightName"].ToString() + Environment.NewLine);
                sb.Append("Standard Name :" + cimObj.CimInstanceProperties["StandardName"].ToString() + Environment.NewLine);
                //Console.WriteLine("Description :" + cimObj.CimInstanceProperties["Description"].ToString());
                //Console.WriteLine("Daylight Name: " + cimObj.CimInstanceProperties["DaylightName"].ToString());
                //Console.WriteLine("Standard Name: " + cimObj.CimInstanceProperties["StandardName"].ToString());
            }
            return sb.ToString();
        }
    }
}
