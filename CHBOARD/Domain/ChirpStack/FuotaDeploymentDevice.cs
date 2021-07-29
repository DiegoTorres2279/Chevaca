using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.ChirpStack
{
    public partial class FuotaDeploymentDevice
    {
        public Guid FuotaDeploymentId { get; set; }
        public byte[] DevEui { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string State { get; set; }
        public string ErrorMessage { get; set; }

        public virtual Device DevEuiNavigation { get; set; }
        public virtual FuotaDeployment FuotaDeployment { get; set; }
    }
}
