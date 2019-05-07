using System;
using System.Collections.Generic;
using System.Text;

namespace Sam.SystemInfo
{
    public class MIB_IFROW : CustomMarshaler
    {
        [CustomMarshalAs(SizeConst = MAX_INTERFACE_NAME_LEN)]
        public string wszName;
        public uint dwIndex; // index of the interface
        public uint dwType; // type of interface
        public uint dwMtu; // max transmission unit 
        public uint dwSpeed; // speed of the interface 
        public uint dwPhysAddrLen; // length of physical address
        [CustomMarshalAs(SizeConst = MAXLEN_PHYSADDR)]
        public byte[] bPhysAddr; // physical address of adapter
        public uint dwAdminStatus; // administrative status
        public uint dwOperStatus; // operational status
        public uint dwLastChange; // last time operational status changed 
        public uint dwInOctets; // octets received
        public uint dwInUcastPkts; // unicast packets received 
        public uint dwInNUcastPkts; // non-unicast packets received 
        public uint dwInDiscards; // received packets discarded 
        public uint dwInErrors; // erroneous packets received 
        public uint dwInUnknownProtos; // unknown protocol packets received 
        public uint dwOutOctets; // octets sent 
        public uint dwOutUcastPkts; // unicast packets sent 
        public uint dwOutNUcastPkts; // non-unicast packets sent 
        public uint dwOutDiscards; // outgoing packets discarded 
        public uint dwOutErrors; // erroneous packets sent 
        public uint dwOutQLen; // output queue length 
        public uint dwDescrLen; // length of bDescr member 
        [CustomMarshalAs(SizeConst = MAXLEN_IFDESCR)]
        public byte[] bDescr; // interface description 		

        private const int MAX_INTERFACE_NAME_LEN = 256;
        private const int MAXLEN_PHYSADDR = 8;
        private const int MAXLEN_IFDESCR = 256;
        private const int MAX_ADAPTER_NAME = 128;
    }
}
