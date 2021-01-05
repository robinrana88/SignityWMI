using Microsoft.Management.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignityWMI.Services
{
    public class WindowService
    {
        //to determine which service is running and which are not
        public string ServiceStatus()
        {
            CimSession session = CimSession.Create("localHost");
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_Service");
            foreach (CimInstance cimObj in queryInstance)
            {
                Console.WriteLine("Service Name " + cimObj.CimInstanceProperties["Name"].ToString());
                Console.WriteLine("State" + cimObj.CimInstanceProperties["State"].ToString());
            }
            return "";
        }

        public string StartOrStopService()
        {
            CimSession session = CimSession.Create("localHost");
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_Service where Name='servicename'");
            foreach (CimInstance cimObj in queryInstance)
            {
                //objService.StartService()
            }
            return "";
        }
    }
}
