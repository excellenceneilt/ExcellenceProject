using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //Se guardan los detalles de la compra de cada equipo individualmente
    public class Detalle_Compra
    {
        public int IdDetalleCompra { get; set; }    //es el id del detalle de la compra, de genera en la BD
        public Producto oProducto { get; set; }     //es el producto que se guarda en el detalle de la compra
        public decimal PrecioCompra { get; set; }   //es el precio de compra del producto comprado
        public decimal PrecioVenta { get; set; }    //es el precio de venta del producto comprado
        public int Cantidad { get; set; }           //es la cantidad del producto comprado
        public decimal MontoTotal { get; set; }     //es el monto total de la compra realizada
        public string FechaRegistro { get; set; }   //es la fecha que se crea el registro
    }
}
