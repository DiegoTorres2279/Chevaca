using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Domain.ChirpStack;
using Services.ChirpStack;

namespace Board.Models
{
    public class VM_ServiceProfile
    {
        [DisplayName("Nombre")]
        public string Name { get; set; }

        [DisplayName("Gateway Metadata")]
        public bool gatewayMetadata { get; set; }

        [DisplayName("Network Geolocation")]
        public bool networkGeoloc { get; set; }
        
        [DisplayName("SP. ID")]
        public int ServiceProfileID { get; set; }

        [DisplayName("Org. ID")]
        public int organizationID { get; set; }
        
        [DisplayName("Network Server")]
        public int networkServerID { get; set; }
        public List<NetworkServer> NSavailables { get; set; }

        public VM_ServiceProfile()
        {
            NetworkServer_Service ns = new NetworkServer_Service();
            NSavailables = ns.Obtener_NetworkServer();
        }
    }
}