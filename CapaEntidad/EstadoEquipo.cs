using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //es la entidad que nos dice el estado del equipo
    public class EstadoEquipo
    {
        public int IdEstadoEquipo {  get; set; }    //es el id del estado del equipo, lo genera la BD
        public string Descripcion { get; set; }     //es la descripcion de como se encuentra el equipo
        public bool Estado { get; set; }            //es el nombre del estado del equipo
        public string FechaRegistro { get; set; }   //es la fecha en la que se registro el estado del equipo, lo genera la BD
    }
}
