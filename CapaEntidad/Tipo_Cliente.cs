using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //Se guardan los tipos de cliente (PERSONA NATURAL - PERSONA JURIDICA)
    public class Tipo_Cliente
    {
        public int IdTipoCliente { get; set; }      //Se crea en la BD, el id del Tipo de cliente
        public string Descripcion { get; set;}      //Es el nombre del tipo de cliente que existe
        public bool Estado { get; set; }            //Es el estado del tipo de cliente
        public string FechaRegistro { get; set; }   //La fecha que se registro el tipo de cliente
    }
}
