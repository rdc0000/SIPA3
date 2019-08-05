using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIPA.Models
{
    public class DetallePedido
    {
        internal static object articuloID;
        [Display(Name = "DetallePEdidoID")]
        public int DetallePedidoID { get; set; }
        [Display(Name = "Articulo")]
        public int ArticuloID { get; set; }
        public Articulo Articulo { get; set; }

    }
}
