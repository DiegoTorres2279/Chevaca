using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.ChirpStack
{
    public partial class DeviceMulticastGroup
    {
        public byte[] DevEui { get; set; }
        public Guid MulticastGroupId { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Device DevEuiNavigation { get; set; }
        public virtual MulticastGroup MulticastGroup { get; set; }
    }
}
