using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //Esta entidad sirve para mostrar los datos de las provincias que ya se encuentran almacenadas
    public class Provincia
    {
        public int IdProvincia { get; set; }    //es el id de la provincia
        public string Descripcion { get;set; }  //es el nombre de la provincia
        public int IdDepartamento { get; set; } //es el id del DEPARTAMENTO, es la foránea que sirve para jalar las provincias que pertenezcan a un DEPARTAMENTO
        public bool Estado { get; set; }        //es el estado de la provincia, por lo default es ACTIVO
        
    }
}
