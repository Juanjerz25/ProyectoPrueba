//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoPrueba.DataStorage
{
    using System;
    using System.Collections.Generic;
    
    public partial class FACTURA
    {
        public decimal ID_FACTURA { get; set; }
        public decimal NUME_DOC { get; set; }
        public decimal CODI_ESTADO { get; set; }
        public decimal VALOR_FAC { get; set; }
        public System.DateTime FECHA_FAC { get; set; }
    
        public virtual CLIENTES CLIENTES { get; set; }
        public virtual ESTADOS_FACTURA ESTADOS_FACTURA { get; set; }
    }
}
