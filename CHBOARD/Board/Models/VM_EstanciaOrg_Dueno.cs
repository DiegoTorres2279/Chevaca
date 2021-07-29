using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Services.Validations;

namespace Board.Models
{
    public class VM_EstanciaOrg_Dueno
    {
        [DisplayName("Nombre de cliente")]
        public string Nombre { get; set; }
        
        //[Remote(action: "clienteExist",controller: "Administrador")]
        [DisplayName("Documento de identidad")]
        public string Documento { get; set; }
        [DisplayName("Fecha de nacimiento")]
        //[ValidDate(ErrorMessage = "Debe tener mas de 18 años.")]
        [DisplayFormat(DataFormatString = "{0:d/M/yyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
    }
}