using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIPA.Models
{
    public class DetallePedido
    {
        public int DetallePedidoID { get; set; }
        public Articulo Articulo { get; set; }
        public Pedido Pedido { get; set; }
        public int Cantidad { get; set; }
        private decimal _Total;

        public decimal Total
        {
            get
            {
                _Total = (Articulo.PrecioVenta * Cantidad);
                return _Total;
            }
            set
            {
                _Total = value;
            }
        }
        public decimal PrecioTotal { get; set; }
    }
}
