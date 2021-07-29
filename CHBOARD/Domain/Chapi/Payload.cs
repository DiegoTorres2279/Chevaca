using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Domain.Chapi
{
    public partial class Payload
    {
        [Key]
        public int Payload_ID { get; set; }
        public int? Device_ID { get; set; }
        public DateTime Datetime_Inicio { get; set; }
        public DateTime Datetime_Fin { get; set; }
        [StringLength(50)]
        public string Alt { get; set; }
        [StringLength(50)]
        public string Hdop { get; set; }
        [StringLength(200)]
        public string Info { get; set; }
        [StringLength(50)]
        public string Latitud { get; set; }
        [StringLength(50)]
        public string Longitud { get; set; }
        [StringLength(50)]
        public string DeviceName { get; set; }
        [StringLength(100)]
        public string DevEUI { get; set; }
        [StringLength(100)]
        public string DevAddr { get; set; }
        [StringLength(50)]
        public string ApplicationID { get; set; }
        [StringLength(50)]
        public string ApplicationName { get; set; }
        [StringLength(50)]
        public string Gateway { get; set; }
        public int? Numeracion { get; set; }
    }
}
