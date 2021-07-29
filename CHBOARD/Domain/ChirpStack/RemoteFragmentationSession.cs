using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.ChirpStack
{
    public partial class RemoteFragmentationSession
    {
        public byte[] DevEui { get; set; }
        public short FragIndex { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public short[] McGroupIds { get; set; }
        public int NbFrag { get; set; }
        public short FragSize { get; set; }
        public byte[] FragmentationMatrix { get; set; }
        public short BlockAckDelay { get; set; }
        public short Padding { get; set; }
        public byte[] Descriptor { get; set; }
        public string State { get; set; }
        public bool StateProvisioned { get; set; }
        public DateTime RetryAfter { get; set; }
        public short RetryCount { get; set; }
        public long RetryInterval { get; set; }

        public virtual Device DevEuiNavigation { get; set; }
    }
}
