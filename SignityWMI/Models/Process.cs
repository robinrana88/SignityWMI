using ORMi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignityWMI.Models
{
    [WMIClass("Win32_PerfRawData_PerfProc_Process")]
    public class Process
    {
        public string Name { get; set; }

        [WMIProperty("IdProcess")]
        public int Pid { get; set; }

        public long PercentProcessorTime { get; set; }
        public long TimeStamp_Sys100NS { get; set; }

        [WMIIgnore]
        public double CpuUsagePercent { get; set; }
    }
}
