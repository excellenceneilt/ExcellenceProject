using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //Aca se van a guardar los datos de la especialidad de los doctores que están registrados
    public class Especialidad
    {
        public int IdEspecialidad { get; set; }     //es el id de la especialidad, se genera en la BD
        public string Descripcion { get; set; }     //es el nombre de la especialidad
        public bool Estado { get; set; }            //es el estado la especialidad
        public string FechaRegistro { get; set; }   //es la fecha en la que se registra la especialidad

    }
}
