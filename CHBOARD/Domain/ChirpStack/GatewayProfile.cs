using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.ChirpStack
{
    public partial class GatewayProfile
    {
        public GatewayProfile()
        {
            Gateways = new HashSet<Gateway>();
        }

        public Guid GatewayProfileId { get; set; }
        public long NetworkServerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }
        public long StatsInterval { get; set; }

        public virtual NetworkServer NetworkServer { get; set; }
        public virtual ICollection<Gateway> Gateways { get; set; }
    }
}
