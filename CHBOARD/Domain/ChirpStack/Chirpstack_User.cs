using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.ChirpStack
{
    public partial class Chirpstack_User
    {
        public Chirpstack_User()
        {
            OrganizationUsers = new HashSet<OrganizationUser>();
        }

        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public long SessionTtl { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public string EmailOld { get; set; }
        public string Note { get; set; }
        public string ExternalId { get; set; }
        public bool EmailVerified { get; set; }

        public virtual ICollection<OrganizationUser> OrganizationUsers { get; set; }
    }
}
