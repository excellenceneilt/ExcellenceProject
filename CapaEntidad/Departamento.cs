using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //Esta entidad sirve para mostrar los datos de los departamentos que ya se encuentran almacenados
    public class Departamento
    {
        public int IdDepartamento {set;get; }    //es el id del departamento, se genera en la BD
        public string Descripcion { set;get;}   //es el nombre del departamento
        public bool Estado { get; set; }        //es el estado del departamento
    }
}
