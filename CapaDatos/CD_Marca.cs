using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CapaDatos
{
    public class CD_Marca
    {
        public List<Marca> Listar()     //Se crea una funcion para que liste las marcas
        {
            List<Marca> lista = new List<Marca>();                                  //se crea el objeto lista que es una lista de marcas
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))    //crea un objeto oconexion con la funcion SqlConexion y le agrega los parametros de la cadena que se encuentra en la capa presentacion en App.config
            {
                try
                {
                    StringBuilder query = new StringBuilder();                          //crea un objeto query como una instancia de la clase StringBuilder
                    query.AppendLine("select IdMarca, Descripcion, Estado from Marca"); //Esa propiedad settea al final del objeto la cadena
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);       
                    
                    cmd.CommandType = CommandType.Text; //La propiedad Text especifica que el cmd va a ser una consulta a la BD
                    oconexion.Open();                   //abre una conexion de datos con los valores que se especifica en SqlConnection

                    using (SqlDataReader dr = cmd.ExecuteReader())  //convierte cmd que es un SqlCommand a SqlDataReader que permite leer las filas que se ejecuto en la BD
                    {
                        while (dr.Read())   //"dr.Read()" vota true mientras se encuentre abierta la conexion
                        {
                            lista.Add(new Marca()   //Agrega las marcas al objeto lista
                            {
                                IdMarca = Convert.ToInt32(dr["IdMarca"]),   //Convierte lo que se encuentra en Fila "IdMarca" de la BD a int de 32bits y lo guarda en IdMarca del objeto "lista"
                                Descripcion = dr["Descripcion"].ToString(), //Convierte lo que se encuentra en Fila "Descripcion" de la BD a string y lo guarda en Descripcion del objeto "lista"
                                Estado = Convert.ToBoolean(dr["Estado"])    //Convierte lo que se encuentra en Fila "Estado" de la BD a boolean y lo guarda en Estado del objeto "lista"
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Marca>();  //hace que lista tenga la lista vacia de las marcas
                }
            }
            return lista;   //retorna la lista
        }

        public int Registrar(Marca obj, out string Mensaje) //Se crea una funcion para que registrar las marcas
        {
            int idMarcagenerado = 0;    //Crea un entero y lo inicializa en 0
            Mensaje = string.Empty;     //inicializa el parámetro de salida en vacio
            try
            { 
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))    //crea un objeto oconexion con la funcion SqlConexion y le agrega los parametros de la cadena que se encuentra en la capa presentacion en App.config
                {
                    //Declarando los parámetros de entrada
                    SqlCommand cmd = new SqlCommand("SP_RegistrarMarca", oconexion);                            //inicializa una instancia con una consulta y una conexion
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);                                //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);                                          //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;       //declara la variable de salida. "Resultado" es el nombre de la columna de la BD
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;//declara la variable de salida. "Mensaje" es el nombre de la columna de la BD
                    cmd.CommandType = CommandType.StoredProcedure;                                              //establece que la consulta va a ser un procedimiento almacenado

                    oconexion.Open();       //abre una conexion de datos con los valores que se especifica en SqlConnection
                    cmd.ExecuteNonQuery();  //ejecuta la instrucion en la conexion y devuelve el numero de filas afectadas

                    //Obtener parametros de salida después de ejecución
                    idMarcagenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);   //settea lo antes declarado en idMarcagenerado, con su respectivo tipo de dato
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();                   //settea lo antes declarado en Mensaje, con su respectivo tipo de dato
                }
            }
            catch (Exception ex)
            {
                idMarcagenerado = 0;    //le da el valor de 0
                Mensaje = ex.Message;   //settea la excepcion en Mensaje
            }
            return idMarcagenerado; //retorna el id de la marca generado o lo que bota por defecto el catch
        }

        public bool Editar(Marca obj, out string Mensaje)   //Se crea una funcion para que Edite las marcas
        {
            bool respuesta = false; //se crea un bool y se inicializa en false
            Mensaje = string.Empty; //se settea Mensaje a vacio
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))    //crea un objeto oconexion con la funcion SqlConexion y le agrega los parametros de la cadena que se encuentra en la capa presentacion en App.config
                {
                    //Declarando los parámetros de entrada
                    SqlCommand cmd = new SqlCommand("SP_EditarMarca", oconexion);   //inicializa una instancia con una consulta y una conexion
                    cmd.Parameters.AddWithValue("IdMarca", obj.IdMarca);            //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);              //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);    //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;       //declara la variable de salida. "Resultado" es el nombre de la columna de la BD
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;//declara la variable de salida. "Mensaje" es el nombre de la columna de la BD

                    cmd.CommandType = CommandType.StoredProcedure;  //establece que la consulta va a ser un procedimiento almacenado


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
                Mensaje = ex.Message;   //settea el error del catch
            }
            return respuesta;   //retorna la respuesta
        }

        public bool Eliminar(Marca obj, out string Mensaje) //funcion que elimina las marcas
        {
            bool respuesta = false; //se crea un bool y se inicializa en false
            Mensaje = string.Empty; //se settea Mensaje a vacio
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))    //crea un objeto oconexion con la funcion SqlConexion y le agrega los parametros de la cadena que se encuentra en la capa presentacion en App.config
                {
                    //Declarando los parámetros de entrada
                    SqlCommand cmd = new SqlCommand("SP_EliminarMarca", oconexion); //inicializa una instancia con una consulta y una conexion
                    cmd.Parameters.AddWithValue("IdMarca", obj.IdMarca);            //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar

                    //Declarando parámetros de salida
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;       //declara la variable de salida. "Resultado" es el nombre de la columna de la BD
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;//declara la variable de salida. "Mensaje" es el nombre de la columna de la BD

                    cmd.CommandType = CommandType.StoredProcedure;  //establece que la consulta va a ser un procedimiento almacenado

                    oconexion.Open();       //abre una conexion de datos con los valores que se especifica en SqlConnection
                    cmd.ExecuteNonQuery();  //ejecuta la instrucion en la conexion y devuelve el numero de filas afectadas

                    //Obtener parametros de salida después de ejecución
                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);   //settea lo antes declarado en respuesta, con su respectivo tipo de dato
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();               //settea lo antes declarado en Mensaje, con su respectivo tipo de dato
                }
            }
            catch (Exception ex)
            {
                respuesta = false;      //le da el valor de false
                Mensaje = ex.Message;   //captura el error del mensaje
            }
            return respuesta;   //retorna la respuesta
        }
    }
}
