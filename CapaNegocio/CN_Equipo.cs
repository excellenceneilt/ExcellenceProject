using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Equipo
    {
        private CD_Equipo objcd_Equipo = new CD_Equipo();

        public List<Equipo> Listar()
        {
            return objcd_Equipo.Listar();
        }
        //Procedimientos de mantenimiento
        public int Registrar(Equipo obj, out string Mensaje)
        {

            //Validaciones por si se dejan campos vacíos
            Mensaje = string.Empty;
            if (obj.CodigoEquipo == "")
            {
                Mensaje += "Es necesario definir un codigo de producto\n";
            }
            if (obj.Modelo == "")
            {
                Mensaje += "Es necesario definir un nombre de producto\n";
            }
            if (obj.SerialNumber == "")
            {
                Mensaje += "Es necesario definir una descripción del producto\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Equipo.Registrar(obj, out Mensaje);
            }

        }

        public bool Editar(Equipo obj, out string Mensaje)
        {

            //Validaciones
            Mensaje = string.Empty;

            if (obj.CodigoEquipo == "")
            {
                Mensaje += "Es necesario definir un codigo de producto\n";
            }
            if (obj.Modelo == "")
            {
                Mensaje += "Es necesario definir un nombre de producto\n";
            }
            if (obj.SerialNumber == "")
            {
                Mensaje += "Es necesario definir una descripción del producto\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Equipo.Editar(obj, out Mensaje);
            }





            //return objcd_Producto.Editar(obj, out Mensaje);
        }

        public bool Eliminar(Equipo obj, out string Mensaje)
        {
            return objcd_Equipo.Eliminar(obj, out Mensaje);
        }

    }
}
