using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.ChirpStack
{
    public partial class MulticastGroup
    {
        public MulticastGroup()
        {
            DeviceMulticastGroups = new HashSet<DeviceMulticastGroup>();
            FuotaDeployments = new HashSet<FuotaDeployment>();
            RemoteMulticastClassCSessions = new HashSet<RemoteMulticastClassCSession>();
            RemoteMulticastSetups = new HashSet<RemoteMulticastSetup>();
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }
        public Guid ServiceProfileId { get; set; }
        public byte[] McAppSKey { get; set; }
        public byte[] McKey { get; set; }

        public virtual ServiceProfile ServiceProfile { get; set; }
        public virtual ICollection<DeviceMulticastGroup> DeviceMulticastGroups { get; set; }
        public virtual ICollection<FuotaDeployment> FuotaDeployments { get; set; }
        public virtual ICollection<RemoteMulticastClassCSession> RemoteMulticastClassCSessions { get; set; }
        public virtual ICollection<RemoteMulticastSetup> RemoteMulticastSetups { get; set; }
    }
}
