using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyTecniServer.Models
{
    public class ProveedorCP
    {
        //public int Id_Proveedor { get; set; }
        [Required]
        [Display(Name = "Ingrese Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Ingrese Apellido")]
        public string Apellido { get; set; }
        public string Direccion { get; set; }
    }
    [MetadataType(typeof(ProveedorCP))]
    public partial class Proveedor
    {
        public string NombreCompleto
        {
            get { return Nombre + " " + Apellido; }
        }
    }
}