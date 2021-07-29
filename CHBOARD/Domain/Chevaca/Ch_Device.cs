using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Domain.Chevaca
{
    public partial class Ch_Device
    {
        public int Ch_Device_ID { get; set; }
        
        public string Ch_Name { get; set; }
        
        public string Ch_Dev_Eui { get; set; }
        
        public Ch_Profile Chirpstack_Profile { get; set; }

        public string Ch_App_Key { get; set; }

        public Ch_Device()
        {
            
        }
    
        public Ch_Device(string chName, string chDevEui, Ch_Profile chirpstackProfile)
        {
            Ch_Name = chName;
            Ch_Dev_Eui = chDevEui;
            Chirpstack_Profile = chirpstackProfile;
        }

       }
}
