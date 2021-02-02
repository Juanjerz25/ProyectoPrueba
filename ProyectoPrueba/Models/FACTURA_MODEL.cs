using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoPrueba.Models
{
    public class FACTURA_MODEL
    {
        [Display(Name = "Id Factura")]
        [Required]
        public decimal ID_FACTURA { get; set; }
        [Display(Name = "Número de documento")]
        [Required]
        public decimal NUME_DOC { get; set; }
        [Display(Name = "Código de estado")]
        [Required]        
        public decimal CODI_ESTADO { get; set; }
        [Display(Name = "Valor Factura")]
        [Required]
        public decimal VALOR_FAC { get; set; }
        [Display(Name = "Fecha Facturación")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime FECHA_FAC { get; set; }
        //Propiedades Complementarias
        [Display(Name = "Nombre del Cliente")]
        public string NOMBRE_CLIENTE { get; set; }
        [Display(Name = "Descripción")]
        public string DESCRIPCION_ESTADO { get; set; }
       

    }
}