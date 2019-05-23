using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyTecniServer.Models
{
    public class CategoriaCP
    {
        
       
        [Required]
        [Display(Name = "Ingrese Nombre")]
        public string Nombre_Categoria { get; set; }
        [Display(Name = "Ingrese Descripción")]
        public string detalle { get; set; }
    }
    [MetadataType(typeof(CategoriaCP))]
    public partial class Categoria
    {
       public int Estado { get; set; }
       
    }
}