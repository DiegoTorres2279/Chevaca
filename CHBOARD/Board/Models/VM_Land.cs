using System;
using System.ComponentModel;

namespace Board.Models
{
    public class VM_Land
    {
        public long EstanciaCamposId { get; set; }
        [DisplayName("Nombre de la Aplicacion")]
        public string Application_Name { get; set; }
        [DisplayName("Descripcion")]
        public string Description { get; set; }
        public long AppOrganization_ID { get; set; }
        public Guid AppServiceProfileId { get; set; }

    }
}