using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.ChirpStack
{
    public partial class FuotaDeployment
    {
        public FuotaDeployment()
        {
            FuotaDeploymentDevices = new HashSet<FuotaDeploymentDevice>();
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }
        public Guid? MulticastGroupId { get; set; }
        public char GroupType { get; set; }
        public short Dr { get; set; }
        public int Frequency { get; set; }
        public short PingSlotPeriod { get; set; }
        public byte[] FragmentationMatrix { get; set; }
        public byte[] Descriptor { get; set; }
        public byte[] Payload { get; set; }
        public short FragSize { get; set; }
        public short Redundancy { get; set; }
        public short MulticastTimeout { get; set; }
        public short BlockAckDelay { get; set; }
        public string State { get; set; }
        public long UnicastTimeout { get; set; }
        public DateTime NextStepAfter { get; set; }

        public virtual MulticastGroup MulticastGroup { get; set; }
        public virtual ICollection<FuotaDeploymentDevice> FuotaDeploymentDevices { get; set; }
    }
}
