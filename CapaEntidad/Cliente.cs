using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Documento { get; set; }
        public string NombreCompleto { get; set; }
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
