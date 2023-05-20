using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //Acá va a mostrar, editar y crear los equipos, por unidad
    public class Equipo
    {
        public int IdEquipo { get; set; }               //es el id del equipo, lo genera la BD
        public string CodigoEquipo { get; set;}         //es código que tiene el producto
        public string  Marca { get; set; }              //es la marca a la que pertenece el equipo
        public string Modelo { get; set; }              //es el modelo del equipo
        public string SerialNumber { get; set; }        //es el numero serial del equipo
        public EstadoEquipo eEstadoEquipo { get; set; } //es el estado del equipo, el equipo puede tener diferentes estados cuando pasa por servicio tecnico
        public bool Estado {get; set;}                  //es el estado del equipo, de manera general
        public string FechaRegistro { get; set; }       //es la fecha en la que se registra el equipo
        public Producto eProducto { get; set; }         //es el id del producto al que pertenece el equipo
        public Cliente Cliente { get; set; }            //es el id del cliente al que le va a pertenecer el equipo
        public Compra eCompra { get; set; }             //es el id de la compra donde se registró el equipo
        public Detalle_Compra eDetalle { get; set; }     //es el id del detalle de la compra donde se realizó la compra del equipo
    }
}
