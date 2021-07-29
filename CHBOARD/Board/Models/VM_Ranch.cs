using System;
using System.Collections.Generic;
using System.ComponentModel;
using Domain.Chevaca;

namespace Board.Models
{
    public class VM_Ranch
    {
        [DisplayName("Estancia ID")]
        public int Land_ID { get; set; }
        
        [DisplayName("Organizaci�n ID")]
        public int OrgId { get; set; }
        [DisplayName("Razon Social")]
        public string Name { get; set; }
        [DisplayName("Nombre")]
        public string DisplayName { get; set; }
        
        [DisplayName("RUT")]
        public string rut { get; set; }

        [DisplayName("Tel�fono")]
        public string telefono { get; set; }

        [DisplayName("Admite Gateways")]
        public bool CanHaveGateways { get; set; }
        
        [DisplayName("Cantidad m�xima nodos")]
        public int MaxDevice { get; set; }
        [DisplayName("Cantidad m�xima Gateways")]
        public int MaxGateway { get; set; }

    }
}