using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIPA.Models
{
    public class Articulo
    {
        internal static object proveedorID;
        [Display(Name = "ArticuloID")]
        public int ArticuloID { get; set; }

        [Display(Name = "Nombre")]
        public int ProveedorID { get; set; }
        public Proveedor Proveedor { get; set; }
        public string Nombre { get; set; }
        public string Cantidad { get; set; }
        public int PrecioProveedor { get; set; }
        public int PrecioVenta { get; set; }
        public string Imagen { get; set; }

    }
}
