using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //guarda los datos del ingreso de Recepción de Equipos, es la primera parte de servicio tecnico
    public class IngresoRecepcionEquipos
    {
        public int IdIRE { get; set; }              //es el id de la entidad, se genera en la BD
        public string CodIRE { get; set; }          //es el codigo de la entidad, se genera en el BackEnd
        public string fechaIRE { get; set; }        //es la fecha en la que se crea el IRE
        public string fecha { get; set; }           //es la fecha en la que se compro el equipo seleccionado
        public string OST { get; set; }             //es el codigo que se crea cuando se guarde la entidad
        public string cliente{ get; set; }          //es el cliente que compro el producto, por lo general vienen a ser razon social de empresas
        public string ruc { get; set; }             //es el ruc del cliente
        public string contacto { get; set; }        //es el nombre del contacto del cliente
        public string correo { get; set; }          //es el correo del cliente
        public string telefono { get; set; }        //es el telefono del cliente
        public string deja { get; set; }            //es quien dejo el equipo a servicio tecnico
        public string dni { get; set; }             //es el dni de la persona que deja el equipo
        public string marca { get; set; }           //es la marca del equipo
        public string equipo { get; set; }          //es el nombre del equipo
        public string serie { get; set; }           //es el numero de serie del equipo
        public int    codequipo { get; set; }       //es el codigo del equipo, es el que le pone la empresa fabricante
        public string fechacompra { get; set; }     //es la fecha en la que se compro el equipo
        public string garantia { get; set; }        //indica si el equipo tiene garantía o no
        public string costorev { get; set; }        //es el costo de la revision si es que lo tuviera
        public float  costo { get; set; }            //es el costo de la revision
        public string enciende { get; set; }        //selecciona si enciende o no el equipo
        public string situacion { get; set; }       //indica la situacion del equipo
        public string accesorios { get; set; }      //indica los accesorios con los que se está dejando el equipo
        public string observaciones { get; set; }   //indica las observaciones del equipo
        public string moneda { get; set; }          //indica si el pago es en dólares o soles
    }
}