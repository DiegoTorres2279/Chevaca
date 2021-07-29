using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.ChirpStack
{
    public partial class DeviceProfile
    {
        public DeviceProfile()
        {
            Devices = new HashSet<Device>();
        }

        public Guid DeviceProfileId { get; set; }
        public long NetworkServerId { get; set; }
        public long OrganizationId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }
        public string PayloadCodec { get; set; }
        public string PayloadEncoderScript { get; set; }
        public string PayloadDecoderScript { get; set; }
        public Dictionary<string, string> Tags { get; set; }
        public long UplinkInterval { get; set; }

        public virtual NetworkServer NetworkServer { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
    }
}
