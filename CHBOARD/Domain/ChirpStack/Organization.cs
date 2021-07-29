using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


#nullable disable

namespace Domain.ChirpStack
{
    public partial class Organization
    {
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public bool canHaveGateways { get; set; }
        public int maxDeviceCount { get; set; }
        public int maxGatewayCount { get; set; }

        public Organization()
        {
            
        }

        // public Organization(string pName, string pDisplayName, bool pCanHaveGateways, int pMaxDevice, int pMaxGateway)
        // {
        //     name = pName;
        //     displayName = pDisplayName;
        //     canHaveGateways = pCanHaveGateways;
        //     maxDeviceCount = pMaxDevice;
        //     maxGatewayCount = pMaxGateway;
        // }
        //
        // public Organization()
        // {
        //     
        // }
    }
    
    
}
