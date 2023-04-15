﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        //crea un objeto de la capa de datos de usuario
        private CD_Usuario objcd_usuario = new CD_Usuario();

        //Lista los usuarios
        public List <Usuario> Listar()
        {
            return objcd_usuario.Listar();
        }
        //Procedimientos de mantenimiento
        public int Registrar(Usuario obj, out string Mensaje)
        {

            //Validaciones de que los campos tengan información





        



            Mensaje = string.Empty;
            if (obj.Documento == "")
            {
                Mensaje += "Es necesario definir un  usuario\n";
            }

            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre completo del usuario\n";
            }

            if (obj.Clave == "")
            {
                Mensaje += "Es necesario definir la clave del usuario\n";
            }


            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_usuario.Registrar(obj, out Mensaje);
            }
            
        }

        public bool Editar(Usuario obj, out string Mensaje)
        {

            //Validaciones
            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario definir un  usuario\n";
            }

            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre completo del usuario\n";
            }

            if (obj.Clave == "")
            {
                Mensaje += "Es necesario definir la clave del usuario\n";
            }


            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_usuario.Editar(obj, out Mensaje);
            }
            //return objcd_usuario.Editar(obj, out Mensaje);
        }

        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            return objcd_usuario.Eliminar(obj, out Mensaje);
        }

    }
}
