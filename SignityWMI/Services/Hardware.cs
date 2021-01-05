using Microsoft.Management.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignityWMI.Services
{
    public class Hardware
    {
        public string DetermineTheMemory()
        {

            CimSession session = CimSession.Create("localHost");
            StringBuilder sb = new StringBuilder();
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_OperatingSystem");
            foreach (CimInstance cimObj in queryInstance)
            {
                //Console.WriteLine("Free physical memory: " + cimObj.CimInstanceProperties["FreePhysicalMemory"].ToString());
                sb.Append("Free physical memory:  :" + cimObj.CimInstanceProperties["FreePhysicalMemory"].ToString() + Environment.NewLine);
            }
            return sb.ToString();
        }

        public string TotalPhysicalMemory()
        {
            StringBuilder sb = new StringBuilder();
            CimSession session = CimSession.Create("localHost");
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_ComputerSystem");
            foreach (CimInstance cimObj in queryInstance)
            {
                sb.Append("Total physical memory: " + cimObj.CimInstanceProperties["TotalPhysicalMemory"].ToString() + Environment.NewLine);
                //Console.WriteLine("Total physical memory: " + cimObj.CimInstanceProperties["TotalPhysicalMemory"].ToString());
            }
            return sb.ToString();
        }

        public string NumberOfProcessors()
        {
            StringBuilder sb = new StringBuilder();
            CimSession session = CimSession.Create("localHost");
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_ComputerSystem");
            foreach (CimInstance cimObj in queryInstance)
            {
                //Console.WriteLine("No of processors: " + cimObj.CimInstanceProperties["NumberOfProcessors"].ToString());
                sb.Append("No of processors: " + cimObj.CimInstanceProperties["NumberOfProcessors"].ToString() + Environment.NewLine);
            }
            return sb.ToString();
        }

        public string NoOfPCMCIASlot()
        {
            StringBuilder sb = new StringBuilder();
            CimSession session = CimSession.Create("localHost");
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_PCMCIAController");
            foreach (CimInstance cimObj in queryInstance)
            {
                //Console.WriteLine("No of PCMCIA slot: " + cimObj.CimInstanceProperties["Count"].ToString());
                sb.Append("No of PCMCIA slot: " + cimObj.CimInstanceProperties["Count"].ToString() + Environment.NewLine);
            }
            return sb.ToString();
        }

        public string DetermineSpeedOfProcessor()
        {
            StringBuilder sb = new StringBuilder();
            CimSession session = CimSession.Create("localHost");
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_Processor");
            foreach (CimInstance cimObj in queryInstance)
            {
                //Console.WriteLine("Max processor clock speed: " + cimObj.CimInstanceProperties["MaxClockSpeed"].ToString());
                sb.Append("Max processor clock speed:" + cimObj.CimInstanceProperties["MaxClockSpeed"].ToString() + Environment.NewLine);
            }
            return sb.ToString();
        }

        public string DetermineTypeOfSystem()
        {
            StringBuilder sb = new StringBuilder();
            CimSession session = CimSession.Create("localHost");
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_SystemEnclosure");
            foreach (CimInstance cimObj in queryInstance)
            {
                //Console.WriteLine("Type of system: " + cimObj.ToString());
                sb.Append("Type of system:" + cimObj.ToString() + Environment.NewLine);
            }
            return sb.ToString();
        }

        public string SerialNoOfsystem()
        {
            StringBuilder sb = new StringBuilder();
            CimSession session = CimSession.Create("localHost");
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_SystemEnclosure");
            foreach (CimInstance cimObj in queryInstance)
            {
               // Console.WriteLine("Part No Of system " + cimObj.CimInstanceProperties["PartNumber"].ToString());
                //Console.WriteLine("Serial no " + cimObj.CimInstanceProperties["SerialNumber"].ToString());
                //Console.WriteLine("Asset Tag " + cimObj.CimInstanceProperties["SMBIOSAssetTag"].ToString());
                sb.Append("Part No Of system:" + cimObj.CimInstanceProperties["PartNumber"].ToString() + Environment.NewLine);
                sb.Append("Serial no:" + cimObj.CimInstanceProperties["SerialNumber"].ToString() + Environment.NewLine);
                sb.Append("Asset Tag:" + cimObj.CimInstanceProperties["SMBIOSAssetTag"].ToString() + Environment.NewLine);
            }
            return sb.ToString();
        }

        public string DetarmineUSBType()
        {
            StringBuilder sb = new StringBuilder();
            CimSession session = CimSession.Create("localHost");
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_USBHub");
            foreach (CimInstance cimObj in queryInstance)
            {
                sb.Append("Device ID:" + cimObj.CimInstanceProperties["DeviceID"].ToString() + Environment.NewLine);
                sb.Append("PNP device ID:" + cimObj.CimInstanceProperties["PNPDeviceID"].ToString() + Environment.NewLine);
                sb.Append("Description:" + cimObj.CimInstanceProperties["Description"].ToString() + Environment.NewLine);
                //Console.WriteLine("Device ID " + cimObj.CimInstanceProperties["DeviceID"].ToString());
                //Console.WriteLine("PNP device ID " + cimObj.CimInstanceProperties["PNPDeviceID"].ToString());
                //Console.WriteLine("Description" + cimObj.CimInstanceProperties["Description"].ToString());

            }
            return sb.ToString();
        }

        public string GetHarddisk()
        {            
            CimSession session = CimSession.Create("localHost");
            IEnumerable queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_LogicalDisk");
            StringBuilder sb = new StringBuilder();
            foreach (CimInstance cimObj in queryInstance)
            {
                sb.Append("Device ID :" + cimObj.CimInstanceProperties["DeviceID"].ToString() + Environment.NewLine);
                sb.Append("Caption :" + cimObj.CimInstanceProperties["Caption"].ToString() + Environment.NewLine);
                sb.Append("Volume Serial Number: :" + cimObj.CimInstanceProperties["VolumeSerialNumber"].ToString() + Environment.NewLine);
                sb.Append("Free Space:" + cimObj.CimInstanceProperties["FreeSpace"].ToString() + Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
