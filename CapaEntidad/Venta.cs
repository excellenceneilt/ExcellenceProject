using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //La entidad venta se encarga de recopilar los datos generales de la venta,
    //junto con los datos del USUARIOS y del DETALLE DE LA VENTA de manera foránea
    public class Venta
    {
        public int IdVenta { get; set; }            //Primary Key, autogenerado
        public Usuario oUsuario { get; set; }       //Datos del USUARIO
        public string TipoDocumento { get; set; }   //Tipo de documento BOLETA - FACTURA
        public string NumeroDocumento { get; set; } //Numero del documento de la venta
        public string DocumentoCliente { get; set; }//Numero del documento del cliente
        public string NombreCliente { get; set; }   //Nombre del cliente
        public decimal MontoPago { get; set; }      //Monto con el que paga el cliente
        public decimal MontoCambio { get; set; }    //MontoPago-MontoTotal
        public decimal MontoTotal { get; set; }     //Monto total del valor de la venta
        public List <Detalle_Venta>  oDetalleVenta { get; set; }//Datos del Detalle de la venta
        public string FechaRegistro { get; set; }   //Fecha del registro de la venta
    }
}
