using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Domain.Chevaca
{
    public partial class Land
    {
        
        public int Land_ID { get; set; }
        public string Chirpstack_App_ID { get; set; }
        public string Land_Name { get; set; }
        
        public int Ranch_ID { get; set; }
        public Ranch Ranch { get; set; }
        public string Description { get; set; }

        public List<Animal> Animals { get; set; }

        public Land()
        {
            Animals = new List<Animal>();
        }

        public Land(string chirpstackAppId, string landName, Ranch ranch, string description)
        {
            Chirpstack_App_ID = chirpstackAppId;
            Land_Name = landName;
            Ranch = ranch;
            Description = description;
            Animals = new List<Animal>();
        }

        public Land(string chirpstackAppId, string landName, string description)
        {
            Chirpstack_App_ID = chirpstackAppId;
            Land_Name = landName;
            Description = description;
            Animals = new List<Animal>();
        }
    }
}
