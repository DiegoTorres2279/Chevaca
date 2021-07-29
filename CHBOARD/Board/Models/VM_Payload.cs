using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Board.Models
{
    public class VM_Payload
    {
        public int PayloadId { get; set; }
        public int? DeviceId { get; set; }
        public DateTime DatetimeInicio { get; set; }
        public DateTime DatetimeFin { get; set; }
        public string Alt { get; set; }
        public string Hdop { get; set; }
        public string Info { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string DeviceName { get; set; }
        public string DevEui { get; set; }
        public string DevAddr { get; set; }
        public string ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string Gateway { get; set; }

    }
}
