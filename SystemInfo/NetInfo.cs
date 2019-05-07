using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;


namespace Sam.SystemInfo
{
    /// <summary>
    /// 网络类型
    /// </summary>
    public enum NetType
    {
        Other = 1,
        Ethernet = 6,
        Tokenring = 9,
        FDDI = 15,
        PPP = 23,
        Loopback = 24,
        Slip = 28
    };

    /// <summary>
    /// 网络状态
    /// </summary>
    public enum NetState
    {
        NotOperational = 0,
        Operational = 1,
        Disconnected = 2,
        Connecting = 3,
        Connected = 4,
        Unreachable = 5
    };

    /// <summary>
    /// 网络信息类
    /// </summary>
    public class NetInfo
    {
        public NetInfo()
        {
        }

        private string m_Name;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        private uint m_Index;
        /// <summary>
        /// 有效编号
        /// </summary>
        public uint Index
        {
            get { return m_Index; }
            set { m_Index = value; }
        }

        private NetType m_Type;
        /// <summary>
        /// 类型
        /// </summary>
        public NetType Type
        {
            get { return m_Type; }
            set { m_Type = value; }
        }

        private uint m_Speed;
        /// <summary>
        /// 速度
        /// </summary>
        public uint Speed
        {
            get { return m_Speed; }
            set { m_Speed = value; }
        }

        private uint m_InOctets;
        /// <summary>
        /// 总接收字节数
        /// </summary>
        public uint InOctets
        {
            get { return m_InOctets; }
            set { m_InOctets = value; }
        }

        private uint m_OutOctets;
        /// <summary>
        /// 总发送字节数
        /// </summary>
        public uint OutOctets
        {
            get { return m_OutOctets; }
            set { m_OutOctets = value; }
        }

        private NetState m_Status;
        /// <summary>
        /// 操作状态
        /// </summary>
        public NetState Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }

        private uint m_InErrors;
        /// <summary>
        /// 总错收字节数
        /// </summary>
        public uint InErrors
        {
            get { return m_InErrors; }
            set { m_InErrors = value; }
        }

        private uint m_OutErrors;
        /// <summary>
        /// 总错发字节数
        /// </summary>
        public uint OutErrors
        {
            get { return m_OutErrors; }
            set { m_OutErrors = value; }
        }

        private uint m_InUnknownProtos;
        /// <summary>
        /// 未知协议共收字节数
        /// </summary>
        public uint InUnknownProtos
        {
            get { return m_InUnknownProtos; }
            set { m_InUnknownProtos = value; }
        }

        private string m_PhysAddr;
        /// <summary>
        /// 物理地址
        /// </summary>
        public string PhysAddr
        {
            get { return m_PhysAddr; }
            set { m_PhysAddr = value; }
        }

    }
}
