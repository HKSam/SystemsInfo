using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Text;
using System.Management;
using System.Runtime.InteropServices;

namespace Sam.SystemInfo
{
    /// <summary>
    /// 系统信息类 - 获取CPU、内存、磁盘、进程信息
    /// </summary>
    public class SystemInfo
    {
        private int m_ProcessorCount = 0;   //CPU个数
        private PerformanceCounter pcCpuLoad;   //CPU计数器
        private long m_PhysicalMemory = 0;   //物理内存

        private const int GW_HWNDFIRST = 0;
        private const int GW_HWNDNEXT = 2;
        private const int GWL_STYLE = (-16);
        private const int WS_VISIBLE = 268435456;
        private const int WS_BORDER = 8388608;

        #region AIP声明
        [DllImport("IpHlpApi.dll")]
        extern static public uint GetIfTable(byte[] pIfTable, ref uint pdwSize, bool bOrder);

        [DllImport("User32")]
        private extern static int GetWindow(int hWnd, int wCmd);
        
        [DllImport("User32")]
        private extern static int GetWindowLongA(int hWnd, int wIndx);

        [DllImport("user32.dll")]
        private static extern bool GetWindowText(int hWnd, StringBuilder title, int maxBufSize);

        [DllImport("user32", CharSet = CharSet.Auto)]
        private extern static int GetWindowTextLength(IntPtr hWnd);
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数，初始化计数器等
        /// </summary>
        public SystemInfo()
        {
            //初始化CPU计数器
            pcCpuLoad = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            pcCpuLoad.MachineName = ".";
            pcCpuLoad.NextValue();

            //CPU个数
            m_ProcessorCount = Environment.ProcessorCount;

            //获得物理内存
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (mo["TotalPhysicalMemory"] != null)
                {
                    m_PhysicalMemory = long.Parse(mo["TotalPhysicalMemory"].ToString());
                }
            }            
        } 
        #endregion

        #region CPU个数
        /// <summary>
        /// 获取CPU个数
        /// </summary>
        public int ProcessorCount
        {
            get
            {
                return m_ProcessorCount;
            }
        }
        #endregion

        #region CPU占用率
        /// <summary>
        /// 获取CPU占用率
        /// </summary>
        public float CpuLoad
        {
            get
            {
                return pcCpuLoad.NextValue();
            }
        }
        #endregion

        #region 可用内存
        /// <summary>
        /// 获取可用内存
        /// </summary>
        public long MemoryAvailable
        {
            get
            {
                long availablebytes = 0;
                //ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_PerfRawData_PerfOS_Memory");
                //foreach (ManagementObject mo in mos.Get())
                //{
                //    availablebytes = long.Parse(mo["Availablebytes"].ToString());
                //}
                ManagementClass mos = new ManagementClass("Win32_OperatingSystem");
                foreach (ManagementObject mo in mos.GetInstances())
                {
                    if (mo["FreePhysicalMemory"] != null)
                    {
                        availablebytes = 1024 * long.Parse(mo["FreePhysicalMemory"].ToString());
                    }
                }
                return availablebytes;
            }
        }
        #endregion

        #region 物理内存
        /// <summary>
        /// 获取物理内存
        /// </summary>
        public long PhysicalMemory
        {
            get
            {
                return m_PhysicalMemory;
            }
        }
        #endregion

        #region 获得分区信息
        /// <summary>
        /// 获取分区信息
        /// </summary>
        public List<DiskInfo> GetLogicalDrives()
        {
            List<DiskInfo> drives = new List<DiskInfo>();
            ManagementClass diskClass = new ManagementClass("Win32_LogicalDisk");
            ManagementObjectCollection disks = diskClass.GetInstances();
            foreach (ManagementObject disk in disks)
            {
                // DriveType.Fixed 为固定磁盘(硬盘)
                if (int.Parse(disk["DriveType"].ToString()) == (int)DriveType.Fixed)
                {
                    drives.Add(new DiskInfo(disk["Name"].ToString(), long.Parse(disk["Size"].ToString()), long.Parse(disk["FreeSpace"].ToString())));
                }
            }
            return drives;
        }
        /// <summary>
        /// 获取特定分区信息
        /// </summary>
        /// <param name="DriverID">盘符</param>
        public List<DiskInfo> GetLogicalDrives(char DriverID)
        {
            List<DiskInfo> drives = new List<DiskInfo>();
            WqlObjectQuery wmiquery = new WqlObjectQuery("SELECT * FROM Win32_LogicalDisk WHERE DeviceID = '" + DriverID + ":'");
            ManagementObjectSearcher wmifind = new ManagementObjectSearcher(wmiquery);
            foreach (ManagementObject disk in wmifind.Get())
            {
                if (int.Parse(disk["DriveType"].ToString()) == (int)DriveType.Fixed)
                {
                    drives.Add(new DiskInfo(disk["Name"].ToString(), long.Parse(disk["Size"].ToString()), long.Parse(disk["FreeSpace"].ToString())));
                }
            }
            return drives;
        }
        #endregion

        #region 获得进程列表
        /// <summary>
        /// 获得进程列表
        /// </summary>
        public List<ProcessInfo> GetProcessInfo()
        {
            List<ProcessInfo> pInfo = new List<ProcessInfo>();
            Process[] processes = Process.GetProcesses();
            foreach (Process instance in processes)
            {
                try
                {
                    pInfo.Add(new ProcessInfo(instance.Id,
                        instance.ProcessName,
                        instance.TotalProcessorTime.TotalMilliseconds,
                        instance.WorkingSet64,
                        instance.MainModule.FileName));
                }
                catch { }
            }
            return pInfo;
        }
        /// <summary>
        /// 获得特定进程信息
        /// </summary>
        /// <param name="ProcessName">进程名称</param>
        public List<ProcessInfo> GetProcessInfo(string ProcessName)
        {
            List<ProcessInfo> pInfo = new List<ProcessInfo>();
            Process[] processes = Process.GetProcessesByName(ProcessName);
            foreach (Process instance in processes)
            {
                try
                {
                    pInfo.Add(new ProcessInfo(instance.Id,
                        instance.ProcessName,
                        instance.TotalProcessorTime.TotalMilliseconds,
                        instance.WorkingSet64,
                        instance.MainModule.FileName));
                }
                catch { }
            }
            return pInfo;
        }
        #endregion

        #region 结束指定进程
        /// <summary>
        /// 结束指定进程
        /// </summary>
        /// <param name="pid">进程的 Process ID</param>
        public static void EndProcess(int pid)
        {
            try
            {
                Process process = Process.GetProcessById(pid);
                process.Kill();
            }
            catch { }
        }
        #endregion

        #region 获取 IP 地址信息
        /// <summary>
        /// 获取 IP 地址信息
        /// </summary>
        /// <returns></returns>
        public static List<IpInfo> GetIpInfo()
        {
            //定义范型
            List<IpInfo> ipinfos = new List<IpInfo>();

            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                try
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        string mac = mo["MacAddress"].ToString().Replace(':', '-');
                        System.Array ar = (System.Array)(mo.Properties["IpAddress"].Value);
                        string ip = ar.GetValue(0).ToString();
                        ipinfos.Add(new IpInfo(ip, mac));
                    }
                }
                catch { }
            }

            return ipinfos;
        } 
        #endregion

        #region 根据物理地址获取 IP 地址
        /// <summary>
        /// 根据物理地址获取 IP 地址
        /// </summary>
        /// <param name="MACAddress"物理地址></param>
        /// <returns>IP 地址</returns>
        public static string GetIpByMac(string MACAddress)
        {
            List<IpInfo> ipinfos = SystemInfo.GetIpInfo();
            foreach (IpInfo ipinfo in ipinfos)
            {
                if (string.Compare(ipinfo.MACAddress, MACAddress, true) == 0)
                {
                    return ipinfo.IPAddress;
                }
            }

            return "";
        } 
        #endregion

        #region 根据 IP 地址获取物理地址
        /// <summary>
        /// 根据 IP 地址获取物理地址
        /// </summary>
        /// <param name="IPAddress"IP 地址></param>
        /// <returns>物理地址</returns>
        public static string GetMacByIp(string IPAddress)
        {
            List<IpInfo> ipinfos = SystemInfo.GetIpInfo();
            foreach (IpInfo ipinfo in ipinfos)
            {
                if (string.Compare(ipinfo.IPAddress, IPAddress, true) == 0)
                {
                    return ipinfo.MACAddress;
                }
            }
            return "";
        }
        #endregion

        #region 获取所有网络信息
        /// <summary>
        /// 获取所有的网络信息
        /// </summary>
        /// <returns>NetInfo 网络信息范型</returns>
        public static List<NetInfo> GetAllNetInfo()
        {
            //定义范型
            List<NetInfo> ninfos = new List<NetInfo>();

            //定义，获取 MIB_IFTABLE 对象
            MIB_IFTABLE tbl = GetAllIfTable();

            //如果成功
            if (tbl != null)
            {
                tbl.Deserialize();
                for (int i = 0; i < tbl.Table.Length; i++)
                {
                    ninfos.Add(GetNetInfo(tbl.Table[i]));
                }
            }

            return ninfos;
        }
        #endregion

        #region 获取指定类型的网络信息
        /// <summary>
        /// 获取指定类型的网络信息
        /// </summary>
        /// <param name="nettype">网络类型</param>
        /// <returns>NetInfo 网络信息范型</returns>
        public static List<NetInfo> GetNetInfoByType(NetType nettype)
        {
            //定义范型
            List<NetInfo> ninfos = new List<NetInfo>();

            //定义，获取 MIB_IFTABLE 对象
            MIB_IFTABLE tbl = GetAllIfTable();

            //如果成功
            if (tbl != null)
            {
                tbl.Deserialize();
                for (int i = 0; i < tbl.Table.Length; i++)
                {
                    NetInfo ninfo = GetNetInfo(tbl.Table[i]);
                    if (ninfo.Type == nettype)
                    {
                        ninfos.Add(ninfo);
                    }
                }
            }

            return ninfos;
        } 
        #endregion

        #region 获取指定物理地址的网络信息
        /// <summary>
        /// 获取指定物理地址的网络信息
        /// </summary>
        /// <param name="MACAddress">物理地址</param>
        /// <returns>NetInfo 网络信息范型</returns>
        public static NetInfo GetNetInfoByMac(string MACAddress)
        {
            //定义，获取 MIB_IFTABLE 对象
            MIB_IFTABLE tbl = GetAllIfTable();

            //如果成功
            if (tbl != null)
            {
                tbl.Deserialize();
                for (int i = 0; i < tbl.Table.Length; i++)
                {
                    NetInfo ninfo = GetNetInfo(tbl.Table[i]);
                    if (string.Compare(MACAddress, ninfo.PhysAddr, true) == 0)
                    {
                        return ninfo;
                    }
                }
            }

            return null;
        } 
        #endregion

        #region 获取指定 ip 地址的网络信息
        /// <summary>
        /// 获取指定 ip 地址的网络信息
        /// </summary>
        /// <param name="IPAddress">ip 地址</param>
        /// <returns>NetInfo 网络信息范型</returns>
        public static NetInfo GetNetInfoByIp(string IPAddress)
        {
            string MACAddress = GetMacByIp(IPAddress);
            if (string.IsNullOrEmpty(MACAddress))
            {
                return null;
            }
            else
            {
                return GetNetInfoByMac(MACAddress);
            }
        } 
        #endregion

        #region 查找所有应用程序标题
        /// <summary>
        /// 查找所有应用程序标题
        /// </summary>
        /// <returns>应用程序标题范型</returns>
        public static List<string> FindAllApps(int Handle)
        {
            List<string> Apps = new List<string>();

            int hwCurr;
            hwCurr = GetWindow(Handle, GW_HWNDFIRST);

            while (hwCurr > 0)
            {
                int IsTask = (WS_VISIBLE | WS_BORDER);
                int lngStyle = GetWindowLongA(hwCurr, GWL_STYLE);
                bool TaskWindow = ((lngStyle & IsTask) == IsTask);
                if (TaskWindow)
                {
                    int length = GetWindowTextLength(new IntPtr(hwCurr));
                    StringBuilder sb = new StringBuilder(2 * length + 1);
                    GetWindowText(hwCurr, sb, sb.Capacity);
                    string strTitle = sb.ToString();
                    if (!string.IsNullOrEmpty(strTitle))
                    {
                        Apps.Add(strTitle);
                    }
                }
                hwCurr = GetWindow(hwCurr, GW_HWNDNEXT);
            }

            return Apps;
        }
        #endregion

        /// <summary>
        /// Get IFTable
        /// </summary>
        /// <returns>MIB_IFTABLE Class</returns>
        private static MIB_IFTABLE GetAllIfTable()
        {
            //缓冲区大小
            uint dwSize = 0;

            //获取缓冲区大小
            uint ret = GetIfTable(null, ref dwSize, false);
            if (ret == 50)
            {
                //此函数仅支持于 win98/nt 系统
                return null;
            }

            //定义，获取 MIB_IFTABLE 对象
            MIB_IFTABLE tbl = new MIB_IFTABLE((int)dwSize);
            ret = GetIfTable(tbl.ByteArray, ref dwSize, false);

            //如果不成功
            if (ret != 0)
            {
                return null;
            }

            return tbl;
        }

        /// <summary>
        /// Get NetInfo Class
        /// </summary>
        /// <param name="row">MIB_IFROW Class</param>
        /// <returns>NetInfo Class</returns>
        private static NetInfo GetNetInfo(MIB_IFROW row)
        {
            NetInfo ninfo = new NetInfo();
            ninfo.Index = row.dwIndex;
            ninfo.Name = Encoding.ASCII.GetString(row.bDescr, 0, (int)row.dwDescrLen);
            ninfo.PhysAddr = GetPhysAddr(row.bPhysAddr, (int)row.dwPhysAddrLen);
            ninfo.Type = (NetType)row.dwType;
            ninfo.Status = (NetState)row.dwOperStatus;
            ninfo.Speed = row.dwSpeed;
            ninfo.InErrors = row.dwInErrors;
            ninfo.InOctets = row.dwInOctets;
            ninfo.InUnknownProtos = row.dwInUnknownProtos;
            ninfo.OutErrors = row.dwOutErrors;
            ninfo.OutOctets = row.dwOutOctets;
            return ninfo;
        }

        /// <summary>
        /// 获取格式化的物理地址
        /// </summary>
        /// <param name="b">字节数组</param>
        /// <param name="len">长度</param>
        /// <returns>无聊地址</returns>
        private static string GetPhysAddr(byte[] b, int len)
        {
            string[] pa = new string[len];
            for (int i = 0; i < len; i++)
            {
                pa[i] = ((int)b[i]).ToString("X2"); 
            }
            return string.Join("-", pa);
        }
        
        
    }
}
