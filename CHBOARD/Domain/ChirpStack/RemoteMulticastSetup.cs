using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.ChirpStack
{
    public partial class RemoteMulticastSetup
    {
        public byte[] DevEui { get; set; }
        public Guid MulticastGroupId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public short McGroupId { get; set; }
        public byte[] McAddr { get; set; }
        public byte[] McKeyEncrypted { get; set; }
        public long MinMcFCnt { get; set; }
        public long MaxMcFCnt { get; set; }
        public string State { get; set; }
        public bool StateProvisioned { get; set; }
        public DateTime RetryAfter { get; set; }
        public short RetryCount { get; set; }
        public long RetryInterval { get; set; }

        public virtual Device DevEuiNavigation { get; set; }
        public virtual MulticastGroup MulticastGroup { get; set; }
    }
}
