using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //Se usa para ingresar los datos del usuario,
    //junto con su ROL, como foránea
    public class Usuario
    {
        public int IdUsuario { get; set; }          //el ID de usuario, se autogenera desde la BD
        public string Documento { get; set; }       //Es el numero del documento del usuario
        public string NombreCompleto { get; set; }  //Es el nombre completo del usuario
        public string Correo { get; set; }          //Es el correo del usuario
        public string Clave { get; set; }           //Es la clave del usuario para ingresar al sistema
        public Rol oRol { get; set; }               //Se guardan los datos del rol del usuario, como foránea
        public bool Estado { get; set; }            //Se guarda el estado del usuario
        public string FechaRegistro { get; set; }   //Se guarda la fecha en la que se registra el usuario

    }
}