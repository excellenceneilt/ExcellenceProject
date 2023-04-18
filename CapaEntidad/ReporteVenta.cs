using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //Se guardan los datos de los Reportes de las ventas
    public class ReporteVenta
    {
        public string FechaRegistro { get; set; }   //Se guarda la fecha en la que se pide el reporte, se obtiene desde el mismo Sistema
        public string TipoDocumento { get; set; }   //Se guarda el nombre del tipo de documento del cliente
        public string NumeroDocumento { get; set; } //Se guarda el numero del tipo de documento del cliente
        public string MontoTotal { get; set; }      //Se guarda el MONTO TOTAL del reporte que se genere
        public string UsuarioRegistro { get; set; } //Guarda el USUARIO que se registro para ingresar al sistema y que está generando el reporte
        public string DocumentoCliente { get; set; }//Se guarda el numero del documento del cliente
        public string NombreCliente { get; set; }   //se guarda el nombre del cliente
        public string CodigoProducto { get; set; }  //Se guarda el codigo del producto
        public string NombreProducto { get; set; }  //se guarda el nombre del producto, PRONTO SE DEBE DE CAMBIAR POR EQUIPO
        public string PrecioVenta { get; set; }     //es el precio de venta del equipo vendido
        public string Cantidad { get; set; }        //la cantidad de equipos vendidos
        public string SubTotal { get; set; }        //es el producto del precio de venta con el subtotal
    }
}
