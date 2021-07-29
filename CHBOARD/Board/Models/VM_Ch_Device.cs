using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Board.Models
{
    public class VM_Ch_Device
    {
        [Required]
        [DisplayName("N�mero MGAP")]
        public string NumeroMinisterio { get; set; }
        [Required]
        [DisplayName("DevEui")]
        public string DevEui { get; set; }
        [Required]
        [DisplayName("Chirpstack Profile ID")]
        public string ChStProfileId { get; set; }
        [Required]
        [DisplayName("Chirpstack Application ID")]
        public string ChAppId { get; set; }
    }
}