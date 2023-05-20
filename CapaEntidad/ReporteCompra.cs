using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //Son las compras de equipos que la empresa realizo 
    public class ReporteCompra
    {
        public string FechaRegistro { get; set; }       //es la fecha en la que se pide el reporte de compra
        public string TipoDocumento { get; set; }       //es el nombre del tipo de documento del cliente
        public string NumeroDocumento { get; set; }     //es el numero del tipo de documento del cliente
        public string MontoTotal { get; set; }          //es el MONTO TOTAL del reporte que se genere
        public string UsuarioRegistro { get; set; }     //Es el usuario que se encuentra registrado en el sistema al momento de generar un reporte
        public string DocumentoProveedor { get; set; }  //Es el numero del documento del proveedor
        public string RazonSocial { get; set; }         //es la razon social del proveedor
        public string CodigoProducto { get; set; }      //es el codigo del producto
        public string NombreProducto { get; set; }      //es el nombre del producto
        public string PrecioCompra { get; set; }        //es el precio de compra del producto
        public string PrecioVenta { get; set; }         //es el precio de venta que se le establece al producto
        public string Cantidad { get; set; }            //es la cantidad que se ha comprado del producto
        public string SubTotal { get; set; }            //es el producto de la cantidad con el precio de compra

    }
}
