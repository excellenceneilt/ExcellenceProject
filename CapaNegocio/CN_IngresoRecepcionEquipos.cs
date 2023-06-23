using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_IngresoRecepcionEquipos
    {
        private CD_IngresoRecepcionEquipos objcd_IRE = new CD_IngresoRecepcionEquipos();

        public List<IngresoRecepcionEquipos> Listar()
        {
            return objcd_IRE.Listar();
        }

        public int Registrar(IngresoRecepcionEquipos obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            /*if (obj.CodOST == "") SE GENERA EN LA BASE DE DATOS
                Mensaje += "Es necesario definir un codigo OST\n";*/
            if (obj.Deja == "")
                Mensaje += "Es necesario definir quien deja el equipo\n";
            if (obj.DniDeja == "")
                Mensaje += "Es necesario definir el dni de la persona que deja el equipo\n";
            if (obj.TelefonoDeja == "")
                Mensaje += "Es necesario definir el telefono de la persona que deja el equipo\n";
            if (obj.iCliente.IdCliente == -1)
                Mensaje += "Es necesario definir el id del cliente\n";
            if (obj.iCliente.NombreContacto == "")
                Mensaje += "Es necesario definir el nombre del cliente\n";
            if (obj.iCliente.Correo1 == "")
                Mensaje += "Es necesario definir el correo del cliente\n";
            if (obj.iEquipo.IdEquipo == -1)
                Mensaje += "Es necesario definir el id del equipo\n";
            if (obj.iEquipo.Marca == "")
                Mensaje += "Es necesario definir marca del equipo\n";
            if (obj.iEquipo.Modelo == "")
                Mensaje += "Es necesario definir el modelo del equipo\n";
            /*if (obj.iEquipo.SerialNumber == "") NO VA ESTA REGLA PORQUE POR DEFAULT SE CARGA EL 3 QUE ES INGRESO A SERVICIO TECNICO
                Mensaje += "Es necesario definir el número de serie del equipo\n";*/
            if (obj.Fecha == "")
                Mensaje += "Es necesario definir la fecha de venta del equipo\n";
            if (obj.iMoneda.IdMoneda == -1)
                Mensaje += "Es necesario definir la fecha de venta del equipo\n";
            if (obj.Costo == -1)
                Mensaje += "Es necesario definir el costo del servicio\n";
            /*if (obj.Enciende == true) ESTA REGLA SE OMITE PORQUE OBLIGATORIAMENTE VA UN VALOR POR DEFECTO
                Mensaje += "Es necesario definir si enciende o no el equipo\n";
            if (obj.Situacion == "") ESTE CAMPO ES OPCIONAL
                Mensaje += "Es necesario definir la situacion del equipo\n";
            if (obj.Accesorios == "") ESTE CAMPO ES OPCIONAL
                Mensaje += "Es necesario definir los accesorios del equipo\n";
            if (obj.Observaciones == "")ESTE CAMPO ES OPCIONAL
                Mensaje += "Es necesario definir las observaciones del equipo\n";*/
            if (obj.Fecha == "")
                Mensaje += "Es necesario definir la fecha de venta del equipo\n";
            if (Mensaje != string.Empty)
                return 0;
            else
                return objcd_IRE.Registrar(obj, out Mensaje);
        }

        public bool Editar(IngresoRecepcionEquipos obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            /*if (obj.CodOST == "") SE GENERA EN LA BASE DE DATOS
                Mensaje += "Es necesario definir un codigo OST\n";*/
            if (obj.Deja == "")
                Mensaje += "Es necesario definir quien deja el equipo\n";
            if (obj.DniDeja == "")
                Mensaje += "Es necesario definir el dni de la persona que deja el equipo\n";
            if (obj.TelefonoDeja == "")
                Mensaje += "Es necesario definir el telefono de la persona que deja el equipo\n";
            if (obj.iCliente.IdCliente == -1)
                Mensaje += "Es necesario definir el id del cliente\n";
            if (obj.iCliente.NombreContacto == "")
                Mensaje += "Es necesario definir el nombre del cliente\n";
            if (obj.iCliente.Correo1 == "")
                Mensaje += "Es necesario definir el correo del cliente\n";
            if (obj.iEquipo.IdEquipo == -1)
                Mensaje += "Es necesario definir el id del equipo\n";
            if (obj.iEquipo.Marca == "")
                Mensaje += "Es necesario definir marca del equipo\n";
            if (obj.iEquipo.Modelo == "")
                Mensaje += "Es necesario definir el modelo del equipo\n";
            /*if (obj.iEquipo.SerialNumber == "") NO VA ESTA REGLA PORQUE POR DEFAULT SE CARGA EL 3 QUE ES INGRESO A SERVICIO TECNICO
                Mensaje += "Es necesario definir el número de serie del equipo\n";*/
            if (obj.Fecha == "")
                Mensaje += "Es necesario definir la fecha de venta del equipo\n";
            if (obj.iMoneda.IdMoneda == -1)
                Mensaje += "Es necesario definir la fecha de venta del equipo\n";
            if (obj.Costo == -1)
                Mensaje += "Es necesario definir el costo del servicio\n";
            /*if (obj.Enciende == true) ESTA REGLA SE OMITE PORQUE OBLIGATORIAMENTE VA UN VALOR POR DEFECTO
                Mensaje += "Es necesario definir si enciende o no el equipo\n";
            if (obj.Situacion == "") ESTE CAMPO ES OPCIONAL
                Mensaje += "Es necesario definir la situacion del equipo\n";
            if (obj.Accesorios == "") ESTE CAMPO ES OPCIONAL
                Mensaje += "Es necesario definir los accesorios del equipo\n";
            if (obj.Observaciones == "")ESTE CAMPO ES OPCIONAL
                Mensaje += "Es necesario definir las observaciones del equipo\n";*/
            if (obj.Fecha == "")
                Mensaje += "Es necesario definir la fecha de venta del equipo\n";
            if (Mensaje != string.Empty)
                return false;
            else
                return objcd_IRE.Editar(obj, out Mensaje);
        }

        public string GetOst(int idIre)
        {
            return objcd_IRE.GetOst(idIre);
        }
    }
}
