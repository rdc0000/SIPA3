using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIPA.Views.Home
{
    public class Model
    {
        private readonly SIPAContext _context;

        public Model(SIPAContext context)
        {
            _context = context;
        }
        public void Imprimir()
        {
            var nombre=(_context.Articulo,"Nombre");
            var cantidad = (_context.Articulo, "Cantidad");
        }
        






    }
}
