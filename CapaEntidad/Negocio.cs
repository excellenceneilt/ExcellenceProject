using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //se usa para guardar los datos de la empresa
    public class Negocio
    {
        public int IdNegocio { get; set; }      //es el id del negocio
        public string Nombre { get; set; }      //es el nombre comercial de la empresa
        public string RUC { get; set; }         //es el ruc de la empresa
        public string Direccion { get; set; }   //es la dirección de la empresa

    }
}
