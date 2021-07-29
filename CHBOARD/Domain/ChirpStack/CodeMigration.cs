using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.ChirpStack
{
    public partial class CodeMigration
    {
        public string Id { get; set; }
        public DateTime AppliedAt { get; set; }
    }
}
