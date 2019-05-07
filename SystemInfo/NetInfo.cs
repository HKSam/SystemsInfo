using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;


namespace Sam.SystemInfo
{
    /// <summary>
    /// ��������
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
    /// ����״̬
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
    /// ������Ϣ��
    /// </summary>
    public class NetInfo
    {
        public NetInfo()
        {
        }

        private string m_Name;
        /// <summary>
        /// ����
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        private uint m_Index;
        /// <summary>
        /// ��Ч���
        /// </summary>
        public uint Index
        {
            get { return m_Index; }
            set { m_Index = value; }
        }

        private NetType m_Type;
        /// <summary>
        /// ����
        /// </summary>
        public NetType Type
        {
            get { return m_Type; }
            set { m_Type = value; }
        }

        private uint m_Speed;
        /// <summary>
        /// �ٶ�
        /// </summary>
        public uint Speed
        {
            get { return m_Speed; }
            set { m_Speed = value; }
        }

        private uint m_InOctets;
        /// <summary>
        /// �ܽ����ֽ���
        /// </summary>
        public uint InOctets
        {
            get { return m_InOctets; }
            set { m_InOctets = value; }
        }

        private uint m_OutOctets;
        /// <summary>
        /// �ܷ����ֽ���
        /// </summary>
        public uint OutOctets
        {
            get { return m_OutOctets; }
            set { m_OutOctets = value; }
        }

        private NetState m_Status;
        /// <summary>
        /// ����״̬
        /// </summary>
        public NetState Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }

        private uint m_InErrors;
        /// <summary>
        /// �ܴ����ֽ���
        /// </summary>
        public uint InErrors
        {
            get { return m_InErrors; }
            set { m_InErrors = value; }
        }

        private uint m_OutErrors;
        /// <summary>
        /// �ܴ��ֽ���
        /// </summary>
        public uint OutErrors
        {
            get { return m_OutErrors; }
            set { m_OutErrors = value; }
        }

        private uint m_InUnknownProtos;
        /// <summary>
        /// δ֪Э�鹲���ֽ���
        /// </summary>
        public uint InUnknownProtos
        {
            get { return m_InUnknownProtos; }
            set { m_InUnknownProtos = value; }
        }

        private string m_PhysAddr;
        /// <summary>
        /// �����ַ
        /// </summary>
        public string PhysAddr
        {
            get { return m_PhysAddr; }
            set { m_PhysAddr = value; }
        }

    }
}
