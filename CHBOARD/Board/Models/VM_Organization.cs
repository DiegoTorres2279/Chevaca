using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Board.Models
{
    public class VM_Organization
    {
        [Required]
        [DisplayName("Nombre")]
        public string name { get; set; }
        [Required]
        [DisplayName("Razon Social")]
        public string displayName { get; set; }
        //public bool CanHaveGateways { get; set; }
        [DisplayName("Admite Gateways")]
        public bool canHaveGateways { get; set; }
        [DisplayName("Cantidad Maxima de Dispositivos")]
        public int maxDeviceCount { get; set; }
        [DisplayName("Cantidad Maxima de Gateways")]
        public int maxGatewayCount { get; set; }

        
    }
}