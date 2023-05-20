using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //Se guardan los detalles de la venta de cada equipo individualmente
    public class Detalle_Venta
    {
        public int IdDetalleVenta { get; set; }     //es el id del detalle de la venta, de genera en la BD
        public Producto oProducto { get; set; }     //es el producto que se guarda en el detalle de la venta
        public decimal PrecioVenta { get; set; }    //es el precio del producto vendido
        public int Cantidad { get; set; }           //es la cantidad del producto vendido
        public decimal SubTotal { get; set; }       //es el subtotal del producto que se vendió
        public string FechaRegistro { get; set; }   //es la fecha que se crea el registro
    }
}
