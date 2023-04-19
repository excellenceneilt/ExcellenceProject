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
    }
}
