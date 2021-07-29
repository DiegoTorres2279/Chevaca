using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Domain.Chevaca
{
    public partial class Animal
    {
        public int Animal_ID { get; set; }
        
        public int Land_ID { get; set; }
        public Land Land { get; set; }
        
        public int Ch_Device_ID { get; set; }
        public Ch_Device Ch_Device { get; set; }
        
        public int MGAP_Tag_ID { get; set; }
        public MGAP_Tag Mgap_Tag { get; set; }
        public int List_animals_types_code { get; set; }
        public int List_animals_breeds_code { get; set; }
        public int List_animals_categories_code { get; set; }
        public int Code_Animal { get; set; }
        public string Gender_MF { get; set; }
        public DateTime? Date_Born { get; set; }

        public Animal()
        {
            
        }

        public Animal(Ch_Device chDevice, string genderMf)
        {
            Ch_Device = chDevice;
            Gender_MF = genderMf;
        }
    }
}
