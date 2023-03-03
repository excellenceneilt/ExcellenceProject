using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Provincia
    {
        

        private CD_Provincia objcd_Provincia = new CD_Provincia();

        public List<Provincia> Listar()
        {
            return objcd_Provincia.Listar();
        }
    }
}
