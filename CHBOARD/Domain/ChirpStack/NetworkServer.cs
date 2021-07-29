using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.ChirpStack
{
    public partial class NetworkServer
    {
        public DateTime createdAt { get; set; }
        public long id { get; set; }
        public string name { get; set; }
        public string server { get; set;}
        public DateTime updatedAt { get; set; }

    }
}
