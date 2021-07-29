using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Domain.Chevaca
{
    public partial class Person
    {
        public int Person_ID { get; set; }
        public string Full_Name { get; set; }
        public string Email { get; set; }
        public string Identification { get; set; }
        public DateTime? Date_born { get; set; }
        
        public int Land_ID { get; set; }
        public Land Land { get; set; }
        
        public int User_ID { get; set; }
        public User User { get; set; }
        public bool IsOwner { get; set; }
        


    }
}
