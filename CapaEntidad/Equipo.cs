using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Equipo
    {
        public int IdEquipo { get; set; }
        public string CodigoEquipo { get; set;}
        public string  Marca { get; set; }
        public string Modelo { get; set; }
        
        public string SerialNumber { get; set; }
        public string Producto { get; set; }
        public EstadoEquipo eEstadoEquipo { get; set; }
        public bool Estado {get; set;}
        public string FechaRegistro { get; set; }
    }
}
