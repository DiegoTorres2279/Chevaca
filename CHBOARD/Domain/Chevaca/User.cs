using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Domain.Chevaca
{
    public partial class User
    {
        public int User_ID { get; set; }

        public int Person_ID { get; set; }
        public Person Person { get; set; }
        
        public int Rol_ID { get; set; }
        public Rol Rol { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public string Image_Url { get; set; }
    }
}
