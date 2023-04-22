using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Proveedor
    {
        //Metodo para listar
        public List<Proveedor> Listar() //Se crea una funcion para que liste los proveedores
        {
            List<Proveedor> lista = new List<Proveedor>();                      //se crea el objeto lista que es una lista de los proveedores
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))//crea un objeto oconexion con la funcion SqlConexion y le agrega los parametros de la cadena que se encuentra en la capa presentacion en App.config
            {
                try
                {
                    StringBuilder query = new StringBuilder();  //crea un objeto query como una instancia de la clase StringBuilder
                    query.AppendLine("select IdProveedor,Documento,RazonSocial,Correo,Telefono,Estado from PROVEEDOR"); //Esa propiedad settea al final del objeto la cadena

                    //SQLCOMMAND ejecuta comandos y usa una acción "query" y la cadena de conexion
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);   //SQLCOMMAND ejecuta comandos y usa una acción "query" como la consulta y a oconexion como la cadena de conexion
                    cmd.CommandType = CommandType.Text;                             //La propiedad Text especifica que el cmd va a ser una consulta a la BD

                    oconexion.Open();                               //abre una conexion de datos con los valores que se especifica en SqlConnection
                    using (SqlDataReader dr = cmd.ExecuteReader())  //convierte cmd que es un SqlCommand a SqlDataReader que permite leer las filas que se ejecuto en la BD
                    {
                        while (dr.Read())   //"dr.Read()" vota true mientras se encuentre abierta la conexion
                        {
                            lista.Add(new Proveedor()   //Agrega los usuarios al objeto lista
                            {
                                IdProveedor = Convert.ToInt32(dr["IdProveedor"]),   //Convierte lo que se encuentra en Fila "IdUsuario" de la BD a int de 32bits y lo guarda en IdUsuario del objeto "lista"
                                Documento = dr["Documento"].ToString(),             //Convierte lo que se encuentra en Fila "Documento" de la BD a string y lo guarda en Documento del objeto "lista"
                                RazonSocial = dr["RazonSocial"].ToString(),         //Convierte lo que se encuentra en Fila "RazonSocial" de la BD a string y lo guarda en RazonSocial del objeto "lista"
                                Correo = dr["Correo"].ToString(),                   //Convierte lo que se encuentra en Fila "Correo" de la BD a string y lo guarda en Correo del objeto "lista"
                                Telefono = dr["Telefono"].ToString(),               //Convierte lo que se encuentra en Fila "Telefono" de la BD a string y lo guarda en Telefono del objeto "lista"
                                Estado = Convert.ToBoolean(dr["Estado"])            //Convierte lo que se encuentra en Fila "Estado" de la BD a boolean y lo guarda en Estado del objeto "lista"
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Proveedor>();  //deja la lista vacia
                }
            }
            return lista;   //retorna la lista
        }
        //Los parametros de Mensaje es un parametro de salida y Proveedor de entrada
        public int Registrar(Proveedor obj, out string Mensaje) //funcion para registrar los proveedores
        {
            int idProveedorgenerado = 0;    //se inicializa un entero a 0
            Mensaje = string.Empty;         //se settea el parametro en vacio
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))    //crea un objeto oconexion con la funcion SqlConexion y le agrega los parametros de la cadena que se encuentra en la capa presentacion en App.config
                {

                    //Declarando los parámetros de entrada
                    SqlCommand cmd = new SqlCommand("sp_RegistrarProveedor", oconexion);//inicializa una instancia con una consulta y una conexion
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);            //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);        //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);                  //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);              //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);                  //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar

                    //Declarando parámetros de salida
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;       //declara la variable de salida. "Resultado" es el nombre de la columna de la BD
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;//declara la variable de salida. "Mensaje" es el nombre de la columna de la BD

                    cmd.CommandType = CommandType.StoredProcedure;  //establece que la consulta va a ser un procedimiento almacenado
                    oconexion.Open();                               //abre una conexion de datos con los valores que se especifica en SqlConnection
                    cmd.ExecuteNonQuery();                          //ejecuta la instrucion en la conexion y devuelve el numero de filas afectadas

                    //Obtener parametros de salida después de ejecución
                    idProveedorgenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);   //settea lo antes declarado en idusuariogenerado, con su respectivo tipo de dato
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();                       //settea lo antes declarado en Mensaje, con su respectivo tipo de dato
                }

            }
            catch (Exception ex)
            {
                idProveedorgenerado = 0;    //settea el valor en 0
                Mensaje = ex.Message;       //settea el error en el parametro mensaje
            }

            return idProveedorgenerado; //retorna el idProveedorgenerado
        }

        public bool Editar(Proveedor obj, out string Mensaje)   //funcion para editar el proveedor
        {
            bool respuesta = false; //crea un bool y lo inicializa en false
            Mensaje = string.Empty; //settea el mensaje en un string vacio
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) //crea un objeto oconexion con la funcion SqlConexion y le agrega los parametros de la cadena que se encuentra en la capa presentacion en App.config   
                {

                    //Declarando los parámetros de entrada
                    SqlCommand cmd = new SqlCommand("sp_ModificarProveedor", oconexion);//inicializa una instancia con una consulta y una conexion
                    cmd.Parameters.AddWithValue("IdProveedor", obj.IdProveedor);        //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);            //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);        //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);                  //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);              //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);                  //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar

                    //Declarando parámetros de salida
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;       //declara la variable de salida. "Resultado" es el nombre de la columna de la BD
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;//declara la variable de salida. "Mensaje" es el nombre de la columna de la BD

                    cmd.CommandType = CommandType.StoredProcedure;  //establece que la consulta va a ser un procedimiento almacenado
                    oconexion.Open();                               //abre una conexion de datos con los valores que se especifica en SqlConnection
                    cmd.ExecuteNonQuery();                          //ejecuta la instrucion en la conexion y devuelve el numero de filas afectadas

                    //Obtener parametros de salida después de ejecución
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);   //settea lo antes declarado en respuesta, con su respectivo tipo de dato
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();               //settea lo antes declarado en Mensaje, con su respectivo tipo de dato
                }

            }
            catch (Exception ex)
            {
                respuesta = false;      //le da el valor de false
                Mensaje = ex.Message;   //settea la excepcion en Mensaje
            }

            return respuesta;   //retorna la respuesta
        }

        public bool Eliminar(Proveedor obj, out string Mensaje) //funcion para eliminar el proveedor
        {
            bool respuesta = false; //crea un bool y lo inicializa en false
            Mensaje = string.Empty; //settea el parametro en vacio
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))    //crea un objeto oconexion con la funcion SqlConexion y le agrega los parametros de la cadena que se encuentra en la capa presentacion en App.config
                {

                    //Declarando los parámetros de entrada
                    SqlCommand cmd = new SqlCommand("sp_EliminarProveedor", oconexion); //inicializa una instancia con una consulta y una conexion
                    cmd.Parameters.AddWithValue("IdProveedor", obj.IdProveedor);        //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar

                    //Declarando parámetros de salida
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;       
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;//establece que la consulta va a ser un procedimiento almacenado

                    oconexion.Open();       //abre una conexion de datos con los valores que se especifica en SqlConnection
                    cmd.ExecuteNonQuery();  //ejecuta la instrucion en la conexion y devuelve el numero de filas afectadas

                    //Obtener parametros de salida después de ejecución
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);   //settea lo antes declarado en respuesta, con su respectivo tipo de dato
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();               //settea lo antes declarado en Mensaje, con su respectivo tipo de dato
                }

            }
            catch (Exception ex)
            {
                respuesta = false;      //le da el valor de false
                Mensaje = ex.Message;   //settea la excepcion en el Mensaje
            }

            return respuesta;   //retorna la respuesta
        }

    }
}