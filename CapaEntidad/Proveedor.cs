using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //Esta entidad sirve para mostrar, guardar y editar los datos del PROVEEDOR
    public class Proveedor
    {
        public int IdProveedor { get; set; }        //es el Id del proveedor, se genera de manera automática en la BD
        public string Documento { get; set; }       //Es el numero del documento del proveedor, por lo general es el RUC
        public string RazonSocial { get; set; }     //Es la razon social del proveedor
        public string Correo { get; set; }          //es el correo electronico del proveedor
        public string Telefono { get; set; }        //es el telefono del proveedor
        public bool Estado { get; set; }            //es el estado del proveedor
        public string FechaRegistro { get; set; }   //es la fecha en la que se registra el proveedor, se genera en la BD
    }
}
