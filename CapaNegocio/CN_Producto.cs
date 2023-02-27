using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Producto
    {

        private CD_Producto objcd_Producto = new CD_Producto();

        public List<Producto> Listar()
        {
            return objcd_Producto.Listar();
        }
        //Procedimientos de mantenimiento
        public int Registrar(Producto obj, out string Mensaje)
        {

            //Validaciones por si se dejan campos vacíos
            Mensaje = string.Empty;
            if (obj.Codigo == "")
            {
                Mensaje += "Es necesario definir un codigo de producto\n";
            }
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario definir un nombre de producto\n";
            }
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario definir una descripción del producto\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Producto.Registrar(obj, out Mensaje);
            }

        }

        public bool Editar(Producto obj, out string Mensaje)
        {

            //Validaciones
            Mensaje = string.Empty;

            if (obj.Codigo == "")
            {
                Mensaje += "Es necesario definir un codigo de producto\n";
            }
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario definir un nombre de producto\n";
            }
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario definir una descripción del producto\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Producto.Editar(obj, out Mensaje);
            }





            //return objcd_Producto.Editar(obj, out Mensaje);
        }

        public bool Eliminar(Producto obj, out string Mensaje)
        {
            return objcd_Producto.Eliminar(obj, out Mensaje);
        }
    }
}
