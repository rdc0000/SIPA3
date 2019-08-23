using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIPA.Models
{
    public class DetallePedido
    {
        internal static object articuloID,pedidoID;
        [Display(Name = "DetallePedidoID")]
        public int DetallePedidoID { get; set; }
        [Display(Name = "Articulo")]
        public int ArticuloID { get; set; }
        public Articulo Articulo { get; set; }
        [Display(Name = "Pedido")]
        public int PedidoID { get; set; }
        public Pedido Pedido { get; set; }
        public int Cantidad { get; set; }
        private int _Precio;
        public int Precio
        { get
            {
                _Precio = Articulo.PrecioVenta*Cantidad;
                return _Precio;
            }
          set
            {
                _Precio=value;
            }
        }

    }
}
