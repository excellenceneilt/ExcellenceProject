using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Departamento
    {

        private CD_Departamento objcd_Departamento = new CD_Departamento();

        public List<Departamento> Listar()
        {
            return objcd_Departamento.Listar();
        }
    }
}
