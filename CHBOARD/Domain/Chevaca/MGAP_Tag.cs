using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Domain.Chevaca
{
    public partial class MGAP_Tag
    {
        public int MGAP_Tag_ID { get; set; }
        public string MGAP_Key { get; set; }
        public string Description { get; set; }
    }
}
