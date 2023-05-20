using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //es la entidad que va a mostrar, agregar y editar un producto
    public class Producto
    {
        public int IdProducto { get; set; }         //es el id del producto, se genera en la BD
        public string Codigo { get; set; }          //es el codigo que el fabricante le da al producto
        public string Nombre { get; set; }          //es el nombre comercial del producto
        public string Descripcion { get; set; }     //es la descripción de lo que hace el producto
        public Marca oMarca { get; set; }           //la marca a la que pertenece el producto, es una foranea
        public int Stock { get; set; }              //es el stock que hay del producto
        public decimal PrecioCompra { get; set; }   //es la precio de compra del producto
        public decimal PrecioVenta { get; set; }    //es el precio de venta del producto
        public bool Estado { get; set; }            //es el estado del producto
        public string FechaRegistro { get; set; }   //es la fecha en que se registro el producto, se genera en la BD
        //LOS SIGUIENTES DATOS SON SÓLO PARA USO DE UNA TAREA EN ESPECÍFICO.
        //EN EL MODAL PRODUCTOE, SE TIENEN QUE LISTAR LOS PRODUCTOS CON ESTOS DATOS.
        public Detalle_Compra pDetalleCompra { get; set; }
        public Compra pCompra { get; set; }
    }
}
