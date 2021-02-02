using ProyectoPrueba.DataStorage;
using ProyectoPrueba.Models;
using ProyectoPrueba.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoPrueba.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var bd = new PruebaEntities())
            {
                var listaFacturas = (from FACTURA in bd.FACTURA
                                     join CLIENTES in bd.CLIENTES
                                     on FACTURA.NUME_DOC equals CLIENTES.NUME_DOC
                                     join ESTADOS_FACTURA in bd.ESTADOS_FACTURA
                                     on FACTURA.CODI_ESTADO equals ESTADOS_FACTURA.CODI_ESTADO
                                     orderby CLIENTES.NOMBRE
                                     select new FACTURA_MODEL
                                     {
                                         ID_FACTURA = FACTURA.ID_FACTURA,
                                         NUME_DOC = FACTURA.NUME_DOC,
                                         CODI_ESTADO = FACTURA.CODI_ESTADO,
                                         VALOR_FAC = FACTURA.VALOR_FAC,
                                         FECHA_FAC = FACTURA.FECHA_FAC,
                                         NOMBRE_CLIENTE = CLIENTES.NOMBRE,
                                         DESCRIPCION_ESTADO = ESTADOS_FACTURA.DESCRIPCION
                                     }
                                     
                                      ).ToList();
                return View(listaFacturas);
            }
        }
        List<SelectListItem> listaClientes;
        public void ObtenerClientes()
        {
            using (var bd = new PruebaEntities())
            {
                listaClientes = (from CLIENTE in bd.CLIENTES
                                 select new SelectListItem
                                 {
                                     Text = CLIENTE.NOMBRE +"("+ CLIENTE.NUME_DOC.ToString()+")",
                                     Value = CLIENTE.NUME_DOC.ToString()
                                 }).ToList();
                listaClientes.Insert(0, new SelectListItem { Text = "--Seleccione", Value = "" });
                ViewBag.listaClientes = listaClientes;

            }
        }

        List<SelectListItem> listaEstadoFactura;
        public void ObtenerEstadosFactura()
        {
            using (var bd = new PruebaEntities())
            {
                listaEstadoFactura = (from ESTADOS_FACTURA in bd.ESTADOS_FACTURA
                                      select new SelectListItem
                                 {
                                     Text = ESTADOS_FACTURA.DESCRIPCION,
                                     Value = ESTADOS_FACTURA.CODI_ESTADO.ToString()
                                 }).ToList();
                listaEstadoFactura.Insert(0, new SelectListItem { Text = "--Seleccione", Value = "" });
                ViewBag.listaEstadoFactura = listaEstadoFactura;

            }
        }

        public void ObtenerCombos()
        {
            ObtenerEstadosFactura();
            ObtenerClientes();
        }

        public ActionResult AgregarFactura()
        {
            ObtenerCombos();

            return View();
        }

        [HttpPost]
        public ActionResult AgregarFactura(FACTURA_MODEL factura_model)
        {
            if (!ModelState.IsValid)
            {
                ObtenerCombos();
                return View(factura_model);
            }

            FACTURA factura = ConfigAutomapper.mapper.Map<FACTURA>(factura_model);
            using (var bd = new PruebaEntities())
            {
                bd.FACTURA.Add(factura);
                bd.SaveChanges();
                return RedirectToAction("Index");
            }            
        }
        //Diagramación Web
        public ActionResult About()
        {          

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}