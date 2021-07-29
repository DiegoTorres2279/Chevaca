using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Domain.Chevaca
{
    public partial class Land_Feeder
    {
        public int Land_farm_feeder_ID { get; set; }
        
        public int Land_ID { get; set; }
        public Land Land { get; set; }
    }
}
