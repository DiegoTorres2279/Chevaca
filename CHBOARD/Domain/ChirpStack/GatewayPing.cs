using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.ChirpStack
{
    public partial class GatewayPing
    {
        public GatewayPing()
        {
            GatewayPingRxes = new HashSet<GatewayPingRx>();
            Gateways = new HashSet<Gateway>();
        }

        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public byte[] GatewayMac { get; set; }
        public int Frequency { get; set; }
        public int Dr { get; set; }

        public virtual Gateway GatewayMacNavigation { get; set; }
        public virtual ICollection<GatewayPingRx> GatewayPingRxes { get; set; }
        public virtual ICollection<Gateway> Gateways { get; set; }
    }
}
