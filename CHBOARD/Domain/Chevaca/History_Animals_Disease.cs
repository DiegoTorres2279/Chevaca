using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Domain.Chevaca
{
    public partial class History_Animal_Disease
    {
        public int History_animals_diseases_ID { get; set; }
        
        public int Animal_ID { get; set; }
        public Animal Animal { get; set; }
    }
}
