using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.ChirpStack
{
    public partial class Integration
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long ApplicationId { get; set; }
        public string Kind { get; set; }
        public string Settings { get; set; }

        public virtual Application Application { get; set; }
    }
}
