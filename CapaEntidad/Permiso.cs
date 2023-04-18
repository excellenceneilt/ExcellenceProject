using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //Son los permisos que tiene cada usuario con respecto al menu del proyecto
    public class Permiso
    {
        public int IdPermiso { get; set; }          //es el id del permiso del 
        public Rol oRol { get; set; }               //es el id del Rol del Usuario, en la tabla indica quienes con ese idRol pueden acceder al menu que se le asigne
        public string NombreMenu { get; set; }      //es el nombre del menu al que tiene permiso
        public string FechaRegistro { get; set; }   //es la fecha de registo del permiso, se genera en la BD
            
    }
}
