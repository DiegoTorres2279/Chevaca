using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.ChirpStack
{
    public partial class Application
    {
        public Application()
        {
            ApiKeys = new HashSet<ApiKey>();
            Devices = new HashSet<Device>();
            Integrations = new HashSet<Integration>();
        }

        public string description { get; set; }
        public long id { get; set; }
        public string name { get; set; }
        public long organizationID { get; set; }
        public Guid serviceProfileId { get; set; }
        
        public string PayloadCodec { get; set; }
        public string PayloadEncoderScript { get; set; }
        public string PayloadDecoderScript { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual ServiceProfile ServiceProfile { get; set; }
        public virtual ICollection<ApiKey> ApiKeys { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
        public virtual ICollection<Integration> Integrations { get; set; }
    }
}
