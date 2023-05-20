using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //esta entidad sirve para mostrar los distritos guardados
    public class Distrito
    {
        public int IdDistrito { get; set; }     //es el id del distrito, se genera en la BD
        public string Descripcion { get; set; } //es el nombre del distrito
        public int IdProvincia { get; set; }    //es el id de la provincia a que pertenece el distrito
        public bool Estado { get; set; }        //es el estado del distrito
    }
}
