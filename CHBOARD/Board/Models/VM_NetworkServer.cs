using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Board.Models
{
    public class VM_NetworkServer
    {
        [Required]
        [DisplayName("Server Name")]
        public string name { get; set; }
        [Required]
        [DisplayName("Server Address")]
        public string address { get; set; }
    }
}