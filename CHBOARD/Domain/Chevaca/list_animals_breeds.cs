using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Domain.Chevaca
{
    public partial class list_animals_breeds
    {
        public int List_animals_breeds_ID { get; set; }
        public int Breed_code { get; set; }
        [Required]
        [StringLength(30)]
        public string Breed_name { get; set; }
        [Required]
        [StringLength(30)]
        public string Breed_group { get; set; }
    }
}
