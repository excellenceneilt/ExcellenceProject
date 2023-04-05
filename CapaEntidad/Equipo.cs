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
        public int CodigoEquipo { get; set;}
        public string Modelo { get; set; }
        public string SerialNumber { get; set; }
        public Categoria eCategoria { get; set; }
        public EstadoEquipo oEstadoEquipo { get; set; }
        public bool Estado {get; set;}
        public string FechaRegistro { get; set; }
    }
}
