using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //Se crea, edita y mostra las compras
    public class Compra
    {
        public int IdCompra { get; set; }           //es el id de la compra, lo genera la BD
        public Usuario oUsuario { get; set; }       //es el usuario que esta logeado al momento de la compra realizada
        public Proveedor oProveedor { get; set; }   //es el proveedor al que se le esta comprando el producto
        public string TipoDocumento { get; set; }   //es el tipo de documento con el que se compra el producto
        public string NumeroDocumento { get; set; } //es el numero del documento de la compra
        public decimal MontoTotal { get; set; }     //es el monto total de la compra realizada
        public List <Detalle_Compra> oDetalleCompra { get; set; }   //acá van los productos que se han comprado
        public string FechaRegistro { get; set; }   //es la fecha que se genera la compra

    }
}
