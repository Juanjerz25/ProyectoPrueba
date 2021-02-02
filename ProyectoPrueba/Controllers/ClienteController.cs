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
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            using (var bd = new PruebaEntities())
            {
                var listaClientes = bd.CLIENTES.ToList();
                return View(listaClientes);
            }
        }

        public ActionResult AgregarCliente()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarCliente(CLIENTES_MODEL clientes_model)
        {
            if (!ModelState.IsValid)
            {
                return View(clientes_model);
            }
            else
            {
                using(var bd = new PruebaEntities())
                {
                    var registrosEncontrados = bd.CLIENTES.Where(x => x.NUME_DOC == clientes_model.NUME_DOC).Count();
                    if (registrosEncontrados > 0)
                    {
                        clientes_model.MensajeError = "El Número de documento registrado ya existe";
                        return View(clientes_model);
                    }
                    CLIENTES clientes = ConfigAutomapper.mapper.Map<CLIENTES>(clientes_model);
                    bd.CLIENTES.Add(clientes);
                    bd.SaveChanges();
                    return RedirectToAction("Index");
                }
            }           
        }
    }
}