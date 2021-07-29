using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Api.Models
{
    public partial class paquetes_lora
    {
        [Key]
        public int Paquete_lora_ID { get; set; }
        public int? Payload_ID { get; set; }
        [StringLength(50)]
        public string ApplicationID { get; set; }
        [StringLength(50)]
        public string ApplicationName { get; set; }
        [StringLength(50)]
        public string DeviceName { get; set; }
        [StringLength(100)]
        public string DevEUI { get; set; }
        public bool Adr { get; set; }
        public int Dr { get; set; }
        public int FCnt { get; set; }
        public int FPort { get; set; }
        [StringLength(200)]
        public string Data { get; set; }
        public bool ConfirmedUplink { get; set; }
        [StringLength(100)]
        public string DevAddr { get; set; }
    }
}
