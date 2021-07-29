using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Domain.Chevaca
{
    public partial class History_animal_vaccine
    {
        public int History_animals_vaccines_ID { get; set; }
        
        public int Animal_ID { get; set; }
        public Animal Animal { get; set; }
    }
}
