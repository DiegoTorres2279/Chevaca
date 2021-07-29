using System;
using System.Collections.Generic;

namespace Domain.Chevaca
{
    public class Ch_Profile
    {
        public Guid DeviceProfileId { get; set; }
        public long OrganizationId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }
        
        public string Version { get; set; }
        public string PayloadCodec { get; set; }
        public string PayloadEncoderScript { get; set; }
        public string PayloadDecoderScript { get; set; }
        public string UplinkInterval { get; set; }

        //public virtual NetworkServer NetworkServer { get; set; }

        public virtual ICollection<Ch_Device> Devices { get; set; }
        
        
        public Ch_Profile()
        {
            Devices = new HashSet<Ch_Device>();
        }
        
        public Ch_Profile(Guid deviceProfileId, string name, string uplinkInterval)
        {
            DeviceProfileId = deviceProfileId;
            CreatedAt = DateTime.Now;
            Name = name;
            UplinkInterval = uplinkInterval;
            Devices = new List<Ch_Device>();
        }

        public Ch_Profile(Guid deviceProfileId, string name, string payloadCodec, string payloadEncoderScript, string payloadDecoderScript, string uplinkInterval)
        {
            DeviceProfileId = deviceProfileId;
            CreatedAt = DateTime.Now;
            Name = name;
            PayloadCodec = payloadCodec;
            PayloadEncoderScript = payloadEncoderScript;
            PayloadDecoderScript = payloadDecoderScript;
            UplinkInterval = uplinkInterval;
            Devices = new List<Ch_Device>();
        }
        
    }
}