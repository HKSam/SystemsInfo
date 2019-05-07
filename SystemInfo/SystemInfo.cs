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
    /// ϵͳ��Ϣ�� - ��ȡCPU���ڴ桢���̡�������Ϣ
    /// </summary>
    public class SystemInfo
    {
        private int m_ProcessorCount = 0;   //CPU����
        private PerformanceCounter pcCpuLoad;   //CPU������
        private long m_PhysicalMemory = 0;   //�����ڴ�

        private const int GW_HWNDFIRST = 0;
        private const int GW_HWNDNEXT = 2;
        private const int GWL_STYLE = (-16);
        private const int WS_VISIBLE = 268435456;
        private const int WS_BORDER = 8388608;

        #region AIP����
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

        #region ���캯��
        /// <summary>
        /// ���캯������ʼ����������
        /// </summary>
        public SystemInfo()
        {
            //��ʼ��CPU������
            pcCpuLoad = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            pcCpuLoad.MachineName = ".";
            pcCpuLoad.NextValue();

            //CPU����
            m_ProcessorCount = Environment.ProcessorCount;

            //��������ڴ�
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

        #region CPU����
        /// <summary>
        /// ��ȡCPU����
        /// </summary>
        public int ProcessorCount
        {
            get
            {
                return m_ProcessorCount;
            }
        }
        #endregion

        #region CPUռ����
        /// <summary>
        /// ��ȡCPUռ����
        /// </summary>
        public float CpuLoad
        {
            get
            {
                return pcCpuLoad.NextValue();
            }
        }
        #endregion

        #region �����ڴ�
        /// <summary>
        /// ��ȡ�����ڴ�
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

        #region �����ڴ�
        /// <summary>
        /// ��ȡ�����ڴ�
        /// </summary>
        public long PhysicalMemory
        {
            get
            {
                return m_PhysicalMemory;
            }
        }
        #endregion

        #region ��÷�����Ϣ
        /// <summary>
        /// ��ȡ������Ϣ
        /// </summary>
        public List<DiskInfo> GetLogicalDrives()
        {
            List<DiskInfo> drives = new List<DiskInfo>();
            ManagementClass diskClass = new ManagementClass("Win32_LogicalDisk");
            ManagementObjectCollection disks = diskClass.GetInstances();
            foreach (ManagementObject disk in disks)
            {
                // DriveType.Fixed Ϊ�̶�����(Ӳ��)
                if (int.Parse(disk["DriveType"].ToString()) == (int)DriveType.Fixed)
                {
                    drives.Add(new DiskInfo(disk["Name"].ToString(), long.Parse(disk["Size"].ToString()), long.Parse(disk["FreeSpace"].ToString())));
                }
            }
            return drives;
        }
        /// <summary>
        /// ��ȡ�ض�������Ϣ
        /// </summary>
        /// <param name="DriverID">�̷�</param>
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

        #region ��ý����б�
        /// <summary>
        /// ��ý����б�
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
        /// ����ض�������Ϣ
        /// </summary>
        /// <param name="ProcessName">��������</param>
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

        #region ����ָ������
        /// <summary>
        /// ����ָ������
        /// </summary>
        /// <param name="pid">���̵� Process ID</param>
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

        #region ��ȡ IP ��ַ��Ϣ
        /// <summary>
        /// ��ȡ IP ��ַ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static List<IpInfo> GetIpInfo()
        {
            //���巶��
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

        #region ���������ַ��ȡ IP ��ַ
        /// <summary>
        /// ���������ַ��ȡ IP ��ַ
        /// </summary>
        /// <param name="MACAddress"�����ַ></param>
        /// <returns>IP ��ַ</returns>
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

        #region ���� IP ��ַ��ȡ�����ַ
        /// <summary>
        /// ���� IP ��ַ��ȡ�����ַ
        /// </summary>
        /// <param name="IPAddress"IP ��ַ></param>
        /// <returns>�����ַ</returns>
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

        #region ��ȡ����������Ϣ
        /// <summary>
        /// ��ȡ���е�������Ϣ
        /// </summary>
        /// <returns>NetInfo ������Ϣ����</returns>
        public static List<NetInfo> GetAllNetInfo()
        {
            //���巶��
            List<NetInfo> ninfos = new List<NetInfo>();

            //���壬��ȡ MIB_IFTABLE ����
            MIB_IFTABLE tbl = GetAllIfTable();

            //����ɹ�
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

        #region ��ȡָ�����͵�������Ϣ
        /// <summary>
        /// ��ȡָ�����͵�������Ϣ
        /// </summary>
        /// <param name="nettype">��������</param>
        /// <returns>NetInfo ������Ϣ����</returns>
        public static List<NetInfo> GetNetInfoByType(NetType nettype)
        {
            //���巶��
            List<NetInfo> ninfos = new List<NetInfo>();

            //���壬��ȡ MIB_IFTABLE ����
            MIB_IFTABLE tbl = GetAllIfTable();

            //����ɹ�
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

        #region ��ȡָ�������ַ��������Ϣ
        /// <summary>
        /// ��ȡָ�������ַ��������Ϣ
        /// </summary>
        /// <param name="MACAddress">�����ַ</param>
        /// <returns>NetInfo ������Ϣ����</returns>
        public static NetInfo GetNetInfoByMac(string MACAddress)
        {
            //���壬��ȡ MIB_IFTABLE ����
            MIB_IFTABLE tbl = GetAllIfTable();

            //����ɹ�
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

        #region ��ȡָ�� ip ��ַ��������Ϣ
        /// <summary>
        /// ��ȡָ�� ip ��ַ��������Ϣ
        /// </summary>
        /// <param name="IPAddress">ip ��ַ</param>
        /// <returns>NetInfo ������Ϣ����</returns>
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

        #region ��������Ӧ�ó������
        /// <summary>
        /// ��������Ӧ�ó������
        /// </summary>
        /// <returns>Ӧ�ó�����ⷶ��</returns>
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
            //��������С
            uint dwSize = 0;

            //��ȡ��������С
            uint ret = GetIfTable(null, ref dwSize, false);
            if (ret == 50)
            {
                //�˺�����֧���� win98/nt ϵͳ
                return null;
            }

            //���壬��ȡ MIB_IFTABLE ����
            MIB_IFTABLE tbl = new MIB_IFTABLE((int)dwSize);
            ret = GetIfTable(tbl.ByteArray, ref dwSize, false);

            //������ɹ�
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
        /// ��ȡ��ʽ���������ַ
        /// </summary>
        /// <param name="b">�ֽ�����</param>
        /// <param name="len">����</param>
        /// <returns>���ĵ�ַ</returns>
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
