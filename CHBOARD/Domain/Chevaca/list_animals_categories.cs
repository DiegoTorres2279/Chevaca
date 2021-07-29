using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Domain.Chevaca
{
    public partial class list_animals_categories
    {
        public int List_animals_categories_ID { get; set; }
        public int Category_code { get; set; }
        public string Category_name { get; set; }
        public string Category_group { get; set; }
    }
}
