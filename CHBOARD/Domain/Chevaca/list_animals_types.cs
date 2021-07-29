using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Domain.Chevaca
{
    public partial class list_animals_types
    {
        public int List_animals_type_ID { get; set; }
        public int Type_code { get; set; }
        public string Type_name { get; set; }
        public string Type_group { get; set; }
    }
}
