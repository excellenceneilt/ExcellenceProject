using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //Se guardan los datos de las marcas de los productos
    public class Marca
    {
        public int IdMarca { get; set; }            //es el id de la marca, se genera en la BD
        public string Descripcion { get; set; }     //es el nombre de la marca
        public bool Estado { get; set; }            //es el estado de la marca
        public string FechaRegistro { get; set; }   //es la fecha en la que se registro la marca, se genera en la BD

    }
}
