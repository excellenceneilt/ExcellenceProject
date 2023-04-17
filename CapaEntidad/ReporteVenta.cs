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
        public string DocumentoCliente { get; set; }//
        public string NombreCliente { get; set; }   //
        public string CodigoProducto { get; set; }  //
        public string NombreProducto { get; set; }  //
        public string PrecioVenta { get; set; }     //
        public string Cantidad { get; set; }        //
        public string SubTotal { get; set; }        //
    }
}
