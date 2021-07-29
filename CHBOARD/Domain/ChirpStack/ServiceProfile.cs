using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.ChirpStack
{
    public partial class ServiceProfile
    {
        //Necesarios para un GET
        public string id { get; set; }
        public string name { get; set; }
        public int networkServerID { get; set; }
        public string networkServerName { get; set; }
        public int organizationID { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime createdAt { get; set; }
        
        //Necesarios para un POST
        public bool addGWMetaData { get; set; }
        public bool nwkGeoLoc { get; set; }
        public int devStatusReqFreq { get; set; }
    }
}
