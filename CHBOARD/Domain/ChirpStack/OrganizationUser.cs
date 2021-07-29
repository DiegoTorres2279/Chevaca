using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.ChirpStack
{
    public partial class OrganizationUser
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long UserId { get; set; }
        public long OrganizationId { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDeviceAdmin { get; set; }
        public bool IsGatewayAdmin { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual Chirpstack_User ChirpstackUser { get; set; }
    }
}
