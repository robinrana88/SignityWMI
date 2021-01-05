using Microsoft.Management.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignityWMI.Services
{
    public class Registry
    {
        public string ReadRegistryKeyValue()
        {
            CimSession session = CimSession.Create("localHost");
            string strKeyPath = "Console";
            string strValueName = "HistoryBufferSize";
            string HKEY_CURRENT_USER = "&H80000001";
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM  StdRegProv");

            //session.
            //Console.WriteLine("Process:" + cimObj.CimInstanceProperties["Name"].ToString());
            
            return "";
        }
    }
}
