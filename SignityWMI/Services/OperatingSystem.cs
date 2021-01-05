using Microsoft.Management.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignityWMI.Services
{
    public class OperatingSystem
    {
        public string SerialNoOfsystem()
        {

            CimSession session = CimSession.Create("localHost");
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_OperatingSystem");
            foreach (CimInstance cimObj in queryInstance)
            {
                Console.WriteLine("Service Pack major version " + cimObj.CimInstanceProperties["ServicePackMajorVersion"].ToString());
                Console.WriteLine("Service Pack Minor Version " + cimObj.CimInstanceProperties["ServicePackMinorVersion"].ToString());
            }
            return "";
        }

        public string DetermineOSInstallDate()
        {
            CimSession session = CimSession.Create("localHost");
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_OperatingSystem");
            foreach (CimInstance cimObj in queryInstance)
            {
                Console.WriteLine("Install date" + cimObj.CimInstanceProperties["InstallDate"].ToString());                
            }
            return "";
        }

        public string OSVersion()
        {
            CimSession session = CimSession.Create("localHost");
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_OperatingSystem");
            foreach (CimInstance cimObj in queryInstance)
            {
                Console.WriteLine("Window :" + cimObj.CimInstanceProperties["Caption"].ToString());
                Console.WriteLine("Version" + cimObj.CimInstanceProperties["Version"].ToString());
            }
            return "";
        }

        public string WindowDIrectoryPath() 
        {
            CimSession session = CimSession.Create("localHost");
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_OperatingSystem");
            foreach (CimInstance cimObj in queryInstance)
            {
                Console.WriteLine("Windows folder :" + cimObj.CimInstanceProperties["WindowsDirectory"].ToString());                
            }
            return "";
        }

        public string DetermineWindowsActivation()
        {
            CimSession session = CimSession.Create("localHost");
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_OperatingSystem");
            foreach (CimInstance cimObj in queryInstance)
            {
                //Console.WriteLine("Activation required :" + cimObj.CimInstanceProperties["ActivationRequired"].ToString());
                //Console.WriteLine("Remaining Evaluation Period :" + cimObj.CimInstanceProperties["RemainingEvaluationPeriod"].ToString());
                //Console.WriteLine("Remaining Grace Period :" + cimObj.CimInstanceProperties["RemainingGracePeriod"].ToString());
            }
            return "";
        }
    }
}
