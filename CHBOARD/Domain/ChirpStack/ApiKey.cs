using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.ChirpStack
{
    public partial class ApiKey
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public long? OrganizationId { get; set; }
        public long? ApplicationId { get; set; }

        public virtual Application Application { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
