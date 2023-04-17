using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //Acá se guardan los roles que existen de cada tipo de usuario(trabajador) que hay en la empresa
    public class Rol
    {
        public int IdRol { get; set; }              //se genera en la BD es un id del rol
        public string Descripcion { get; set; }     //es el nombre del rol
        public string FechaRegistro { get; set; }   //se registra la fecha en la que se creó el rol
    }
}
