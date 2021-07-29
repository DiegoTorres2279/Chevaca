using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Domain.Chevaca
{
    public partial class Animal_Horse
    {
        public int Animal_Horse_ID { get; set; }
        public Animal Animal { get; set; }
    }
}
