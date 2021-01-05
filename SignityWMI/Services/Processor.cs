using Microsoft.Management.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignityWMI.Services
{
    public class Processor
    {
        public string DetermineWindowsActivation()
        {
            CimSession session = CimSession.Create("localHost");
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_Process");
            foreach (CimInstance cimObj in queryInstance)
            {
                Console.WriteLine("Process:" + cimObj.CimInstanceProperties["Name"].ToString());
                Console.WriteLine("Process ID:" + cimObj.CimInstanceProperties["ProcessID"].ToString());
                Console.WriteLine("Thread Count:" + cimObj.CimInstanceProperties["ThreadCount"].ToString());
                Console.WriteLine("Page File Size:" + cimObj.CimInstanceProperties["PageFileUsage"].ToString());
                Console.WriteLine("Page Faults :" + cimObj.CimInstanceProperties["PageFaults"].ToString());
                Console.WriteLine("Working Set Size: :" + cimObj.CimInstanceProperties["WorkingSetSize"].ToString());
            }
            return "";
        }
    }
}
