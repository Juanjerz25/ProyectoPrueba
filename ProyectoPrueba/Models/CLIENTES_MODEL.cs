using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoPrueba.Models
{
    public class CLIENTES_MODEL
    {
        [Display(Name = "Número de documento")]
        [Required]
        public decimal NUME_DOC { get; set; }
        [Display(Name = "Nombre del Cliente")]
        [Required]
        public string NOMBRE { get; set; }
        [Display(Name = "Dirección")]
        [Required]
        public string DIRECCION { get; set; }

        //PROPIEDADES COMPLEMENTARIAS
        public string MensajeError { get; set; }
    }
}