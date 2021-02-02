using AutoMapper;
using ProyectoPrueba.DataStorage;
using ProyectoPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrueba.Utilities
{
    public static class ConfigAutomapper
    {
        public static IMapper mapper { get; set; }
        public static void Config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ESTADOS_FACTURA, ESTADOS_FACTURA_MODEL>().ReverseMap();
                cfg.CreateMap<FACTURA, FACTURA_MODEL>().ReverseMap();
                cfg.CreateMap<CLIENTES, CLIENTES_MODEL>().ReverseMap();
            });

            mapper = config.CreateMapper();
        }
    }
}