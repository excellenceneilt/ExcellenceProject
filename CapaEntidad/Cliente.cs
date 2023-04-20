using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //con esta entidad se van a poder mostrar, editar y crear clientes 
    public class Cliente
    {
        public int IdCliente { get; set; }                  //es el id de cliente, lo crea la BD
        public string CodigoCliente { get; set; }           //es el codigo del cliente que le damos para poder identificarlo
        public string Documento { get; set; }               //es el numero del documento con el que se va a guardar la facturacion
        public string DocumentoContacto { get; set; }       //es el numero del documento del contacto que se da
        public string NombreCompleto { get; set; }          //es el nombre completo de la persona del documento
        public string NombreComercial { get; set; }         //es el nombre comercial de la empresa
        public string NombreContacto { get; set; }          //es el nombre del contacto
        public string Direccion { get; set; }               //es la direccion de la facturacion
        public string DireccionComercial { get; set; }      //es la direccion del comercio
        public string DireccionContacto { get; set; }       //es la direccion del contacto
        public Tipo_Cliente oTipo_Cliente { get; set; }     //persona natural o persona juridica
        public Tipo_Documento oTipo_Documento { get; set; } //es el tipo del documento del cliente
        public string Departamento { get; set; }            //es el departamento de la facturacion
        public string Provincia { get; set; }               //es la provincia de la facturacion
        public string Distrito { get; set; }                //es el distrito de la facturacion
        public string DepartamentoComercial { get; set; }   //es el departamento del comercio
        public string ProvinciaComercial { get; set; }      //es la provincia del comercio
        public string DistritoComercial { get; set; }       //es el distrito del comercio
        public string DepartamentoContacto { get; set; }    //es el departamento del contacto
        public string ProvinciaContacto { get; set; }       //es la provincia del contacto
        public string DistritoContacto { get; set; }        //es el distrito del contacto
        public string Correo1 { get; set; }                 //es el correo1 del comercio
        public string Correo2 { get; set; }                 //es el correo2 del comercio
        public string CorreoContacto { get; set; }          //es el correo del contacto
        public string Telefono1 { get; set; }               //es el telefono1 del comercio
        public string Telefono2 { get; set; }               //es el telefono2 del comercio
        public string TelefonofijoContacto { get; set; }    //es el telefono del contacto
        public string CelularContacto { get; set; }         //es el celular del contacto
        public string CMP { get; set; }                     //es el CMP del doctor
        public string RazonSocial { get; set; }             //es la razon social de la empresa del cliente
        public string RUC { get; set; }                     //es el RUC de la empresa del cliente
        public string RUCContacto { get; set; }             //es el RUC del contacto
        public bool Estado { get; set; }                    //es el estado del cliente
        public string FechaRegistro { get; set; }           //es la fecha en que se registro el cliente
    }
}
