using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Reporte
    {
        //Crea una funcion para listar un reporte de compras que tiene como entrada la fecha de inicio, la fecha de fin y el proveedor
        public List<ReporteCompra> Compra(string fechainicio, string fechafin, int idproveedor)
        {
            List<ReporteCompra> lista = new List<ReporteCompra>();  //se crea el objeto lista que es una lista de los reportes de compra

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))    //crea un objeto oconexion con la funcion SqlConexion y le agrega los parametros de la cadena que se encuentra en la capa presentacion en App.config
            {
                try
                {
                    StringBuilder query = new StringBuilder();                      //crea un objeto query como una instancia de la clase StringBuilder
                    SqlCommand cmd = new SqlCommand("sp_ReporteCompras", oconexion);//inicializa una instancia con una consulta y una conexion
                    cmd.Parameters.AddWithValue("fechainicio", fechainicio);        //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("fechafin", fechafin);              //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("idproveedor", idproveedor);        //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.CommandType = CommandType.StoredProcedure;                  //establece que la consulta ca a ser un procedimiento almacenado

                    oconexion.Open();                               //abre una conexion de datos con los valores que se especifica en SqlConnection
                    using (SqlDataReader dr = cmd.ExecuteReader())  //convierte cmd que es un SqlCommand a SqlDataReader que permite leer las filas que se ejecuto en la BD
                    {
                        while (dr.Read())   //"dr.Read()" vota true mientras se encuentre abierta la conexion
                        {
                            lista.Add(new ReporteCompra() //Agrega los usuarios al objeto lista
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),             //Convierte lo que se encuentra en Fila "FechaRegistro" de la BD a string y lo guarda en FechaRegistro del objeto "lista"
                                TipoDocumento = dr["TipoDocumento"].ToString(),             //Convierte lo que se encuentra en Fila "TipoDocumento" de la BD a string y lo guarda en TipoDocumento del objeto "lista"
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),         //Convierte lo que se encuentra en Fila "NumeroDocumento" de la BD a string y lo guarda en NumeroDocumento del objeto "lista"
                                MontoTotal = dr["MontoTotal"].ToString(),                   //Convierte lo que se encuentra en Fila "MontoTotal" de la BD a string y lo guarda en MontoTotal del objeto "lista"
                                UsuarioRegistro = dr["UsuarioRegistro"].ToString(),         //Convierte lo que se encuentra en Fila "UsuarioRegistro" de la BD a string y lo guarda en UsuarioRegistro del objeto "lista"
                                DocumentoProveedor = dr["DocumentoProveedor"].ToString(),   //Convierte lo que se encuentra en Fila "DocumentoProveedor" de la BD a string y lo guarda en DocumentoProveedor del objeto "lista"
                                RazonSocial = dr["RazonSocial"].ToString(),                 //Convierte lo que se encuentra en Fila "RazonSocial" de la BD a string y lo guarda en RazonSocial del objeto "lista"
                                CodigoProducto = dr["CodigoProducto"].ToString(),           //Convierte lo que se encuentra en Fila "CodigoProducto" de la BD a string y lo guarda en CodigoProducto del objeto "lista"
                                NombreProducto = dr["NombreProducto"].ToString(),           //Convierte lo que se encuentra en Fila "NombreProducto" de la BD a string y lo guarda en NombreProducto del objeto "lista"
                                PrecioCompra = dr["PrecioCompra"].ToString(),               //Convierte lo que se encuentra en Fila "PrecioCompra" de la BD a string y lo guarda en PrecioCompra del objeto "lista"
                                PrecioVenta = dr["PrecioVenta"].ToString(),                 //Convierte lo que se encuentra en Fila "PrecioVenta" de la BD a string y lo guarda en PrecioVenta del objeto "lista"
                                Cantidad = dr["Cantidad"].ToString(),                       //Convierte lo que se encuentra en Fila "Cantidad" de la BD a string y lo guarda en Cantidad del objeto "lista"
                                SubTotal = dr["SubTotal"].ToString(),                       //Convierte lo que se encuentra en Fila "SubTotal" de la BD a string y lo guarda en SubTotal del objeto "lista"
                            });
                        }
                    }
                }
                catch(Exception ex)
                {
                    lista = new List<ReporteCompra>();  //hace que lista tenga la lista vacia de reporte de compra 
                }
            }
            return lista;   //retorna la lista
        }
        //Crea una funcion para listar un reporte de ventas que tiene como entrada la fecha de inicio, la fecha de fin
        public List<ReporteVenta> Venta(string fechainicio, string fechafin)
        {
            List<ReporteVenta> lista = new List<ReporteVenta>();    //se crea el objeto lista que es una lista de los reportes de venta

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))    //crea un objeto oconexion con la funcion SqlConexion y le agrega los parametros de la cadena que se encuentra en la capa presentacion en App.config
            {
                try
                {
                    StringBuilder query = new StringBuilder();                      //crea un objeto query como una instancia de la clase StringBuilder
                    SqlCommand cmd = new SqlCommand("sp_ReporteVentas", oconexion); //inicializa una instancia con una consulta y una conexion
                    cmd.Parameters.AddWithValue("fechainicio", fechainicio);        //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("fechafin", fechafin);              //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;      //establece que la consulta ca a ser un procedimiento almacenado

                    oconexion.Open();                               //abre una conexion de datos con los valores que se especifica en SqlConnection
                    using (SqlDataReader dr = cmd.ExecuteReader())  //convierte cmd que es un SqlCommand a SqlDataReader que permite leer las filas que se ejecuto en la BD
                    {
                        while (dr.Read())   //"dr.Read()" vota true mientras se encuentre abierta la conexion
                        {
                            lista.Add(new ReporteVenta()    //Agrega los Reporte de ventas al objeto lista
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),     //Convierte lo que se encuentra en Fila "FechaRegistro" de la BD a string y lo guarda en FechaRegistro del objeto "lista"
                                TipoDocumento = dr["TipoDocumento"].ToString(),     //Convierte lo que se encuentra en Fila "TipoDocumento" de la BD a string y lo guarda en TipoDocumento del objeto "lista"
                                NumeroDocumento = dr["NumeroDocumento"].ToString(), //Convierte lo que se encuentra en Fila "NumeroDocumento" de la BD a string y lo guarda en NumeroDocumento del objeto "lista"
                                MontoTotal = dr["MontoTotal"].ToString(),           //Convierte lo que se encuentra en Fila "MontoTotal" de la BD a string y lo guarda en MontoTotal del objeto "lista"
                                UsuarioRegistro = dr["UsuarioRegistro"].ToString(), //Convierte lo que se encuentra en Fila "UsuarioRegistro" de la BD a string y lo guarda en UsuarioRegistro del objeto "lista"
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),   //Convierte lo que se encuentra en Fila "DocumentoCliente" de la BD a string y lo guarda en DocumentoCliente del objeto "lista"
                                NombreCliente = dr["NombreCliente"].ToString(),     //Convierte lo que se encuentra en Fila "NombreCliente" de la BD a string y lo guarda en NombreCliente del objeto "lista"
                                CodigoProducto = dr["CodigoProducto"].ToString(),   //Convierte lo que se encuentra en Fila "CodigoProducto" de la BD a string y lo guarda en CodigoProducto del objeto "lista"
                                NombreProducto = dr["NombreProducto"].ToString(),   //Convierte lo que se encuentra en Fila "NombreProducto" de la BD a string y lo guarda en NombreProducto del objeto "lista"
                                Cantidad = dr["Cantidad"].ToString(),               //Convierte lo que se encuentra en Fila "Cantidad" de la BD a string y lo guarda en Cantidad del objeto "lista"
                                SubTotal = dr["SubTotal"].ToString(),               //Convierte lo que se encuentra en Fila "SubTotal" de la BD a string y lo guarda en SubTotal del objeto "lista"
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<ReporteVenta>();   //hace que lista tenga la lista vacia de los reportes de ventas
                }
            }
            return lista;   //retorna la lista
        }
    }
}