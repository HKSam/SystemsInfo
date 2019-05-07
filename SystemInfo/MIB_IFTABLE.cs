using System;
using System.Collections.Generic;
using System.Text;

namespace Sam.SystemInfo
{
    /// <summary>
    /// IFTable
    /// </summary>
    public class MIB_IFTABLE : CustomMarshaler
    {
        public int dwNumEntries;
        [CustomMarshalAs(SizeField = "dwNumEntries")]
        public MIB_IFROW[] Table;

        public MIB_IFTABLE()
        {
            this.data = new byte[this.GetSize()];
        }

        public MIB_IFTABLE(int size)
        {
            this.data = new byte[size];
        }
    }
}
