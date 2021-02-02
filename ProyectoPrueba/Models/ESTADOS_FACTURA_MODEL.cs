using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoPrueba.Models
{
    public class ESTADOS_FACTURA_MODEL
    {
        [Display(Name = "Código de estado")]
        public decimal CODI_ESTADO { get; set; }
        [Display(Name = "Descripción")]
        [StringLength(20, ErrorMessage = "La longitud máxima es 20")]
        public string DESCRIPCION { get; set; }
    }
}