using System.Collections.Generic;
using System.ComponentModel;
using Domain.Chevaca;
using Services.Chevaca;

namespace Board.Models
{
    public class VM_List_Ranchs
    {
        private readonly Ranch_Service _ranchService = new Ranch_Service();
        private readonly ViewModel_Service _ViewModel_Service = new ViewModel_Service();
        
        public List<Ranch> lands { get; set; }
        
        [DisplayName("Estancia ID")]
        public int EstanciaID { get; set; }
        
        [DisplayName("Org ID")]
        public int OrganizacionID { get; set; }
        
        [DisplayName("Rut")]
        public string RUT { get; set; }

        [DisplayName("R.Social")]
        public string Razon_social { get; set; }
        
        [DisplayName("Display Name")]
        public string Nombre { get; set; }
        
        [DisplayName("Admite Gateways")]
        public bool AdmiteGateways { get; set; }

        public VM_List_Ranchs()
        {
            lands = _ranchService.Obtener_estancias();
        }

        public bool UsuarioAutorizado()
        {
            return _ViewModel_Service.UsuarioAutorizado();
        }
    }
}