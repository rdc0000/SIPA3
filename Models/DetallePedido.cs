using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIPA.Models
{
    public class DetallePedido
    {
        internal static object articuloID, pedidoID;
        [Display(Name = "DetallePedidoID")]
        public int DetallePedidoID { get; set; }

        [Display(Name = "Articulo")]
        public int ArticuloID { get; set; }
        public int PrecioVenta { get; set; }
        public Articulo Articulo { get; set; }

        [Display(Name = "Pedido")]
        public int PedidoID { get; set; }
        public Pedido Pedido { get; set; }

        public int Cantidad { get; set; }
        
        public int Monto { get; set; }
        
    }
}
