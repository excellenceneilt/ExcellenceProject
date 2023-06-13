using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //guarda los datos del ingreso de Recepción de Equipos, es la primera parte de servicio tecnico
    public class IngresoRecepcionEquipos
    {
        public int IdIre { get; set; }              //es el id de la entidad, se genera en la BD
        public string CodOST { get; set; }          //es el codigo de la entidad, se genera en el BackEnd
        public string Deja { get; set; }            //es quien dejo el equipo a servicio tecnico
        public string DniDeja { get; set; }         //es el dni de la persona que deja el equipo
        public string TelefonoDeja { get; set; }    //es el telefono de la persona que deja el equipo
        public Cliente iCliente { get; set; }       /* son los datos del cliente a quien le pertenece el equipo
                                                     * idcliente
                                                     * ruc
                                                     * Contacto
                                                     * Correo
                                                     */
        public Equipo iEquipo { get; set; }         /*son los datos del equipo que está entrando a servicio tecnico
                                                     * idequipo
                                                     * codigo
                                                     * marca
                                                     * modelo
                                                     * serial
                                                     * Estado
                                                     */
        public EstadoEquipo iEstadoEquipo { get; set; } //son los datos del estado del equipo al momento de ingresar a servicio tecnico
        //public Producto iProducto { get; set; } //son los datos del producto al momento de jalar el equipo. Solo es para el idProducto
        public Compra iCompra { get; set; }     //son los datos de la compra al momento de jalar el equipo. Solo es para el idCompra
        public string Fecha { get; set; }
        //public Detalle_Compra iDC { get; set; } //son los datos del detalle de compra al momento de jalar el equipo. Solo es para el idDetalleCompra
        //public Detalle_Venta iDV { get; set; }  /*son los datos del detalle de compra al momento de jalar el equipo. Solo es para el idDetalleCompra
        //                                       * idDetalleVenta
        //                                       * fecha de registro de la venta
        //                                       */
        public bool Garantia { get; set; }  //si el producto tiene garantia al momento de ingresar a IRE
        public Moneda iMoneda { get; set; } //registra el tipo de moneda en la que se cobra la reparacion. Solo es para el idMoneda
        public decimal Costo { get; set; }    //registra el costo del servicio
        public bool Enciende { get; set; }    //registra si el equipo enciende
        public string Situacion { get; set; }       //informacion que escribe el personal de ST, tiene como maximo 1000 caracteres
        public string Accesorios { get; set; }      //informacion que escribe el personal de ST, tiene como maximo 1000 caracteres
        public string Observaciones { get; set; }   //informacion que escribe el personal de ST, tiene como maximo 1000 caracteres
        public string FechaIRE { get; set; }        //es la fecha en la que se crea el IRE

    }
}