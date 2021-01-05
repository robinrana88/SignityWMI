using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Management.Infrastructure;
using Microsoft.Management.Infrastructure.Options;
using SignityWMI.Services.Interfaces;

namespace SignityWMI.Services
{
    public class Accounts : IWMIAccount
    {
        public string GetAccounts()
        {
            //CimSession session = CimSession.Create("ROBINDEVIL");
            string computer = "ROBINDEVIL";
            DComSessionOptions DComOptions = new DComSessionOptions();
            DComOptions.Impersonation = ImpersonationType.Impersonate;
            CimSession session = CimSession.Create(computer, DComOptions);


            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_ComputerSystem");

            StringBuilder sb = new StringBuilder();
            foreach (CimInstance cimObj in queryInstance)
            {
                sb.Append("computer name :" + cimObj.CimInstanceProperties["Name"].ToString() + Environment.NewLine);
                sb.Append("computer Domain :" + cimObj.CimInstanceProperties["Domain"].ToString() + Environment.NewLine);
                //Console.WriteLine(cimObj.CimInstanceProperties["Name"].ToString());// to get computer name
                //Console.WriteLine(cimObj.CimInstanceProperties["Domain"].ToString());// to get domain name
            }
            return sb.ToString();
        }

        //public string connectionToRemoteComputer()
        //{
        //    string Namespace = @"root\cimv2";
        //    string OSQuery = "SELECT * FROM Win32_OperatingSystem";
        //    CimSession mySession = CimSession.Create("localHost");//my computer name
        //    IEnumerable<CimInstance> queryInstance = mySession.QueryInstances(Namespace, "WQL", OSQuery);
        //    return "";
        //}

        //public string ComputerName()
        //{
        //    CimSession session = CimSession.Create("localHost");
        //    IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_ComputerSystem");
        //    foreach (CimInstance cimObj in queryInstance)
        //    {
        //        Console.WriteLine(cimObj.CimInstanceProperties["Name"].ToString());
        //    }
        //    return "";
        //}

        public string NameOfPersonLoggedIn()
        {
            StringBuilder sb = new StringBuilder();
            DComSessionOptions DComOptions = new DComSessionOptions();
            DComOptions.Impersonation = ImpersonationType.Impersonate;
            CimSession session = CimSession.Create("localHost", DComOptions); 
            
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_ComputerSystem");
            foreach (CimInstance cimObj in queryInstance)
            {
                sb.Append("User Name:" + cimObj.CimInstanceProperties["UserName"].ToString() + Environment.NewLine);
                //Console.WriteLine("User Name: " + cimObj.CimInstanceProperties["UserName"].ToString());
            }
            return sb.ToString();
        }

        public string RenameTheComputer()
        {

            CimSession session = CimSession.Create("localHost");
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_ComputerSystem");
            foreach (CimInstance cimObj in queryInstance)
            {
                //cimObj.rename() -- need to invoke rename method to change the name
                //Console.WriteLine("User Name: " + cimObj.CimInstanceProperties["Name"].ToString());
            }
            return "";
        }

        //public string CreatingClient()
        //{

        //    CimSession session = CimSession.Create("localHost");
        //    IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_ComputerSystem");
        //    foreach (CimInstance cimObj in queryInstance)
        //    {
        //        Console.WriteLine(cimObj.CimInstanceProperties["Name"].ToString());
        //    }
        //    return "";
        //}

        //public string ConnectingWMIRemotely()
        //{

        //    CimSession session = CimSession.Create("localHost");
        //    IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_ComputerSystem");
        //    foreach (CimInstance cimObj in queryInstance)
        //    {
        //        //Console.WriteLine(cimObj.CimInstanceProperties["Name"].ToString());
        //    }
        //    return "";
        //}

    }
}
