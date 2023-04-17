using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //Se guardan los datos de los tipos de documentos que tiene un cliente
    public class Tipo_Documento
    {
        public int IdTipoDocumento { get; set; }    //se guarda el Id del tipo de documento, se autogenera en la BD
        public int CodigoTipo { get; set; }         //????
        public string Descripcion { get; set; }     //Es el nombre del tipo de documento
        public bool Estado { get; set; }            //Es el estado del tipo de documento
        public string FechaRegistro { get; set; }   //Se regita la fecha en la que se crea un tipo de documento

    }
}
