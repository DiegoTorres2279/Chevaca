using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.ChirpStack
{
    public partial class Gateway
    {
        public Gateway()
        {
            GatewayPingRxes = new HashSet<GatewayPingRx>();
            GatewayPings = new HashSet<GatewayPing>();
        }

        public byte[] Mac { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long OrganizationId { get; set; }
        public bool Ping { get; set; }
        public long? LastPingId { get; set; }
        public DateTime? LastPingSentAt { get; set; }
        public long NetworkServerId { get; set; }
        public Guid? GatewayProfileId { get; set; }
        public DateTime? FirstSeenAt { get; set; }
        public DateTime? LastSeenAt { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public Dictionary<string, string> Tags { get; set; }
        public Dictionary<string, string> Metadata { get; set; }

        public virtual GatewayProfile GatewayProfile { get; set; }
        public virtual GatewayPing LastPing { get; set; }
        public virtual NetworkServer NetworkServer { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<GatewayPingRx> GatewayPingRxes { get; set; }
        public virtual ICollection<GatewayPing> GatewayPings { get; set; }
    }
}
