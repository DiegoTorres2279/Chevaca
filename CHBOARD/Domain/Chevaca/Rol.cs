using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Domain.Chevaca
{
    public partial class Rol
    {
        public int Rol_ID { get; set; }
        public string Rol_Name { get; set; }
        public string Description { get; set; }
    }
}
