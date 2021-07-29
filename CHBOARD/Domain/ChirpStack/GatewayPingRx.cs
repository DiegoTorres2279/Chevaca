using System;
using System.Collections.Generic;
using NpgsqlTypes;

#nullable disable

namespace Domain.ChirpStack
{
    public partial class GatewayPingRx
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public long PingId { get; set; }
        public byte[] GatewayMac { get; set; }
        public DateTime? ReceivedAt { get; set; }
        public int Rssi { get; set; }
        public decimal LoraSnr { get; set; }
        public NpgsqlPoint? Location { get; set; }
        public double? Altitude { get; set; }

        public virtual Gateway GatewayMacNavigation { get; set; }
        public virtual GatewayPing Ping { get; set; }
    }
}
