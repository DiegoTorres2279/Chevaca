using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.ChirpStack
{
    public partial class DeviceKey
    {
        public byte[] DevEui { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public byte[] NwkKey { get; set; }
        public int JoinNonce { get; set; }
        public byte[] AppKey { get; set; }
        public byte[] GenAppKey { get; set; }

        public virtual Device DevEuiNavigation { get; set; }
    }
}
