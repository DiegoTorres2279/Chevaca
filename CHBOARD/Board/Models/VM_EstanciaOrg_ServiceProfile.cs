using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Domain.ChirpStack;
using Services.ChirpStack;

namespace Board.Models
{
    public class VM_EstanciaOrg_ServiceProfile
    {
        //Service Profile   
        [DisplayName("Nombre del SP")]
        public string Name { get; set; }
        
        public int ServiceProfileID { get; set; }

        public List<Organization> organizations { get; set; }
        
        public List<NetworkServer> NetworkServersInChirpstack { get; set; }

        public VM_EstanciaOrg_ServiceProfile()
        {
            NetworkServer_Service ns = new NetworkServer_Service();
            NetworkServersInChirpstack = ns.Obtener_NetworkServer(); 
        }
        
        // public IEnumerable<SelectListItem> JSMNetworkServerToSelectListItem( List<JSM_NetworkServer> jsmNsList)
        // {
        //     IEnumerable<SelectListItem> list = new List<SelectListItem>();
        //     if (jsmNsList != null)
        //     {
        //         foreach (JSM_NetworkServer jsm in jsmNsList)
        //         {
        //             SelectListItem sitem = new SelectListItem()
        //             {
        //                 Text = jsm.name,
        //                 Value = jsm.id.ToString()
        //             };
        //
        //             list.Append(sitem);
        //         }
        //     }
        //
        //     return list;
        // }
        
    
        //public Guid ServiceProfileId { get; set; }
        
        //public long Organization_ID { get; set; }
        //public long NetworkServerId { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }

        //public virtual NetworkServer NetworkServer { get; set; }
        //public virtual Organization Organization { get; set; }
        
        
        //Para hacer una Application en el ChirpStack y un Estancia Campo en la BD de Chevaca
        
        //[DisplayName("Payload Codec")]
        //public string PayloadCodec { get; set; }
        //[DisplayName("Payload Encoder Script")]
        //public string PayloadEncoderScript { get; set; }
        //[DisplayName("Payload Encoder Script")]
        //public string PayloadDecoderScript { get; set; }
        
        
        // public virtual Organization Organization { get; set; }
        // public virtual ServiceProfile ServiceProfile { get; set; }

    }
}