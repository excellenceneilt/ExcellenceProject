using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Cliente
    {

        //public string  {get;set;}
        public int IdCliente { get; set; }
        public string CodigoCliente {get;set;}
        public string Documento { get; set; } //DNI
        public string NombreCompleto { get; set; }
        public string NombreComercial { get; set; }
        public string Direccion {get;set;}
        public string DireccionComercial {get;set;}
        public Tipo_Cliente oTipo_Cliente { get; set;}
        public Tipo_Documento oTipo_Documento { get; set; }
        public int IdDepartamento {get;set;}
        public Provincia oProvincia {get;set;}
        public Distrito oDistrito {get;set;}
        public Departamento oDepartamentoComercial { get; set; }
        public Provincia oProvinciaComercial { get; set; }
        public Distrito oDistritoComercial { get; set; }
        public string Correo1 { get; set; }
        public string Correo2  { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string CMP  { get; set; }
        public string RazonSocial { get; set; }
        public string RUC { get; set; }
        public Especialidad oEspecialidad { get; set; }
        public bool Estado { get; set; }
        public string FechaRegistro { get; set; }
    }
}
