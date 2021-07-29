using System;
using System.Collections.Generic;
using System.ComponentModel;
using Domain.Chevaca;
using Domain.ChirpStack;
using Services.Chevaca;
using Services.ChirpStack;

namespace Board.Models
{
    public class VM_EstOrg_CampoApp
    {
        private ServiceProfile_Service _serviceProfile_service = new ServiceProfile_Service();
        private Land_Service _landService = new Land_Service();
        private NetworkServer_Service _networkServer_service = new NetworkServer_Service();
        
        //Estancia Org Dedicated Section
        [DisplayName("Org. ID")]
        public int OrgID { get; set; }
        [DisplayName("Estancia ID")]
        public int Land_ID { get; set; }
        [DisplayName("Razon Social")]
        public string EstanciaOrgName { get; set; }
        [DisplayName ("Nombre Fantasia")]
        public string EstanciaOrgDisplayName { get; set; }

        //CampoAPP dedicated Section
        [DisplayName("ID de Campo")]
        public int CampoAppId { get; set; }
        [DisplayName("Nombre de Campo")]
        public string CampoAppName { get; set; }
        [DisplayName("Descripcion")]
        public string Description { get; set; }

        //Service Profile Dedicated Section
        [DisplayName("Nombre")]
        public string ChirpstackSPName { get; set; }
        //Lista de campos actuales para desplegar a medida que se les van agregando
        public ICollection<Land> CamposActuales { get; set; }

        //Necesario para el menu desplegable y que el usuario elija un Service Profile
        [DisplayName("Service Profile")]
        public Guid ChirpstackSPId { get; set; }
        public List<ServiceProfile> SpAvailables { get; set; }
        public int ChirpstackNsId { get; set; }
        public List<NetworkServer> NsAvailables { get; set; }
        
        // Posible Uso Futuro
        public string PayloadCodec { get; set; }
        [DisplayName("Decoder Script")]
        public string PayloadDecoderScript { get; set; }
        [DisplayName("Encoder Script")]
        public string PayloadEncoderScript { get; set; }
        public int ChirpstackApplicationId { get; set; }

        public VM_EstOrg_CampoApp()
        {
            SpAvailables = new List<ServiceProfile>();
            NsAvailables = new List<NetworkServer>();
        }

        public VM_EstOrg_CampoApp(int pOrgId, int pEstancia_ID, string pName, string pDisplayName)
        {
            OrgID = pOrgId;
            EstanciaOrgName = pName;
            Land_ID = pEstancia_ID;
            SpAvailables = _serviceProfile_service.ObtenerPorID_ServiceProfile(pOrgId);
            CamposActuales = _landService.ObtenerCamposPorID_EstanciaCampo(Land_ID);
            NsAvailables = _networkServer_service.Obtener_NetworkServer();
        }
    }
}