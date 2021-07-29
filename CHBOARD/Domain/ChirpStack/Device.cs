using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.ChirpStack
{
    public partial class Device
    {
        public Device()
        {
            DeviceMulticastGroups = new HashSet<DeviceMulticastGroup>();
            FuotaDeploymentDevices = new HashSet<FuotaDeploymentDevice>();
            RemoteFragmentationSessions = new HashSet<RemoteFragmentationSession>();
            RemoteMulticastClassCSessions = new HashSet<RemoteMulticastClassCSession>();
            RemoteMulticastSetups = new HashSet<RemoteMulticastSetup>();
        }

        public byte[] DevEui { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long ApplicationId { get; set; }
        public Guid DeviceProfileId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? LastSeenAt { get; set; }
        public decimal? DeviceStatusBattery { get; set; }
        public int? DeviceStatusMargin { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? Altitude { get; set; }
        public bool DeviceStatusExternalPowerSource { get; set; }
        public short? Dr { get; set; }
        public Dictionary<string, string> Variables { get; set; }
        public Dictionary<string, string> Tags { get; set; }
        public byte[] DevAddr { get; set; }
        public byte[] AppSKey { get; set; }

        public virtual Application Application { get; set; }
        public virtual DeviceProfile DeviceProfile { get; set; }
        public virtual DeviceKey DeviceKey { get; set; }
        public virtual ICollection<DeviceMulticastGroup> DeviceMulticastGroups { get; set; }
        public virtual ICollection<FuotaDeploymentDevice> FuotaDeploymentDevices { get; set; }
        public virtual ICollection<RemoteFragmentationSession> RemoteFragmentationSessions { get; set; }
        public virtual ICollection<RemoteMulticastClassCSession> RemoteMulticastClassCSessions { get; set; }
        public virtual ICollection<RemoteMulticastSetup> RemoteMulticastSetups { get; set; }
    }
}
