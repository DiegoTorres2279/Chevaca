using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Domain.Chevaca
{
    public partial class Logs
    {
        public int Log_ID { get; set; }

        // [Column(TypeName = "datetime")]
        public DateTime Date_created { get; set; }
        public int User_ID { get; set; }
        //public User User { get; set; }
        public string IP_client { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }
    }
}
