using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using System.Collections;

namespace CapaDatos
{
    public class CD_Usuario
    {
        //Metodo para listar
        public List<Usuario> Listar()                                               //Se crea una funcion para que liste los usuarios
        {
            List<Usuario> lista = new List<Usuario>();                              //se crea el objeto lista que es una lista de usuarios
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))    //crea un objeto oconexion con la funcion SqlConexion y le agrega los parametros de la cadena que se encuentra en la capa presentacion en App.config
            {
                try
                {
                    StringBuilder query = new StringBuilder();                      //crea un objeto query como una instancia de la clase StringBuilder
                    query.AppendLine("select u.IdUsuario, u.Documento, u.NombreCompleto, u.Correo, u.Clave, u.Estado, r.IdRol, r.Descripcion from usuario u");  //Esa propiedad settea al final del objeto la cadena
                    query.AppendLine("inner join rol r on r.IdRol = u.IdRol");      //Esa propiedad settea al final del objeto la cadena

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);   //SQLCOMMAND ejecuta comandos y usa una acción "query" como la consulta y a oconexion como la cadena de conexion
                    cmd.CommandType = CommandType.Text;                             //La propiedad Text especifica que el cmd va a ser una consulta a la BD         
                                                            
                    oconexion.Open();                                               //abre una conexion de datos con los valores que se especifica en SqlConnection
                    using (SqlDataReader dr = cmd.ExecuteReader())                  //convierte cmd que es un SqlCommand a SqlDataReader que permite leer las filas que se ejecuto en la BD
                    {
                        while (dr.Read())                                           //"dr.Read()" vota true mientras se encuentre abierta la conexion
                        {
                            lista.Add(new Usuario()                                 //Agrega los usuarios al objeto lista
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),       //Convierte lo que se encuentra en Fila "IdUsuario" de la BD a int de 32bits y lo guarda en IdUsuario del objeto "lista"
                                Documento = dr["Documento"].ToString(),             //Convierte lo que se encuentra en Fila "Documento" de la BD a string y lo guarda en Documento del objeto "lista"
                                NombreCompleto = dr["NombreCompleto"].ToString(),   //Convierte lo que se encuentra en Fila "NombreCompleto" de la BD a string y lo guarda en NombreCompleto del objeto "lista"
                                Correo = dr["Correo"].ToString(),                   //Convierte lo que se encuentra en Fila "Correo" de la BD a string y lo guarda en Correo del objeto "lista"
                                Clave = dr["Clave"].ToString(),                     //Convierte lo que se encuentra en Fila "Clave" de la BD a string y lo guarda en Clave del objeto "lista"
                                Estado = Convert.ToBoolean(dr["Estado"]),           //Convierte lo que se encuentra en Fila "Estado" de la BD a boolean y lo guarda en Estado del objeto "lista"
                                //Columnas de rol
                                oRol = new Rol()                                    //Settea los datos que se encuentra en la tabla Rol de la BD a oRol
                                { 
                                    IdRol= Convert.ToInt32(dr["IdRol"]),            //Convierte lo que se encuentra en Fila "IdRol" de la BD a int de 32bits y lo guarda en IdRol del objeto "lista"
                                    Descripcion = dr["Descripcion"].ToString()      //Convierte lo que se encuentra en Fila "Descripcion" de la BD a string y lo guarda en Descripcion del objeto "lista"
                                }
                            });
                        }
                    }
                }catch(Exception ex)
                {
                    lista = new List<Usuario>();    //hace que lista tenga la lista vacia de los usuarios
                }
            }
            return lista;                                       //retorna la lista
        }
        
        public int Registrar(Usuario obj, out string Mensaje)   //Los parametros de Mensaje es un parametro de salida y Usuario de entrada
        {
            int idusuariogenerado = 0;                          //Crea un entero y lo inicializa en 0
            Mensaje = string.Empty;                             //inicializa el parámetro de salida en vacio
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))//crea un objeto oconexion con la funcion SqlConexion y le agrega los parametros de la cadena que se encuentra en la capa presentacion en App.config
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARUSUARIO", oconexion);  //inicializa una instancia con una consulta y una conexion
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);            //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("NombreCompleto",obj.NombreCompleto);   //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);                  //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);                    //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);               //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);                  //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar

                    //Declarando parámetros de salida
                    cmd.Parameters.Add("IdUsuarioResultado", SqlDbType.Int).Direction = ParameterDirection.Output;  //declara la variable de salida. "IdUsuarioResultado" es el nombre de la columna de la BD
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;     //declara la variable de salida. "Mensaje" es el nombre de la columna de la BD

                    cmd.CommandType = CommandType.StoredProcedure;  //establece que la consulta ca a ser un procedimiento almacenado
                    oconexion.Open();                               //abre una conexion de datos con los valores que se especifica en SqlConnection
                    cmd.ExecuteNonQuery();                          //ejecuta la instrucion en la conexion y devuelve el numero de filas afectadas

                    //Obtener parametros de salida después de ejecución
                    idusuariogenerado = Convert.ToInt32(cmd.Parameters["IdUsuarioResultado"].Value);    //settea lo antes declarado en idusuariogenerado, con su respectivo tipo de dato
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();                               //settea lo antes declarado en Mensaje, con su respectivo tipo de dato
                }
            }
            catch(Exception ex)
            {
                idusuariogenerado = 0;  //le da el valor de 0
                Mensaje = ex.Message;   //settea la excepcion en Mensaje
            }
            return idusuariogenerado;   //retorna el id del usuario generado o lo que bota por defecto el catch
        }
        public bool Editar(Usuario obj, out string Mensaje)
        {
            bool respuesta = false; //crea el bool respuesta y lo inicializa en false
            Mensaje = string.Empty; //el mensaje de salida lo inicializa en vacio
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))    //crea un objeto oconexion con la funcion SqlConexion y le agrega los parametros de la cadena que se encuentra en la capa presentacion en App.config
                {
                    //Declarando los parámetros de entrada
                    SqlCommand cmd = new SqlCommand("SP_EDITARUSUARIO", oconexion);     //inicializa una instancia con una consulta y una conexion
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);            //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);            //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);  //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);                  //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);                    //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);               //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);                  //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar

                    //Declarando parámetros de salida
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;       //declara la variable de salida. "Respuesta" es el nombre de la columna de la BD
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output; //declara la variable de salida. "Mensaje" es el nombre de la columna de la BD

                    cmd.CommandType = CommandType.StoredProcedure;  //establece que la consulta ca a ser un procedimiento almacenado
                    oconexion.Open();                               //abre una conexion de datos con los valores que se especifica en SqlConnection
                    cmd.ExecuteNonQuery();                          //ejecuta la instrucion en la conexion y devuelve el numero de filas afectadas

                    //Obtener parametros de salida después de ejecución
                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);   //settea lo antes declarado en respuesta, con su respectivo tipo de dato
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();               //settea lo antes declarado en Mensaje, con su respectivo tipo de dato
                }
            }
            catch (Exception ex)
            {
                respuesta = false;      //le da el valor de false
                Mensaje = ex.Message;   //settea la excepcion en Mensaje
            }
            return respuesta;   //retorna la respuesta si llega a editar, retorna true, pero si entra al catch retorna false
        }
        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            bool respuesta = false; //crea el bool respuesta y lo inicializa en false
            Mensaje = string.Empty; //el mensaje de salida lo inicializa en vacio
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))    //crea un objeto oconexion con la funcion SqlConexion y le agrega los parametros de la cadena que se encuentra en la capa presentacion en App.config
                {
                    //Declarando los parámetros de entrada
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARUSUARIO", oconexion);   //inicializa una instancia con una consulta y una conexion
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);            //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar

                    //Declarando parámetros de salida
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;       //declara la variable de salida. "Respuesta" es el nombre de la columna de la BD
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output; //declara la variable de salida. "Mensaje" es el nombre de la columna de la BD
                    cmd.CommandType = CommandType.StoredProcedure;                                              //establece que la consulta ca a ser un procedimiento almacenado
                    oconexion.Open();                                                                           //abre una conexion de datos con los valores que se especifica en SqlConnection
                    cmd.ExecuteNonQuery();                                                                      //ejecuta la instrucion en la conexion y devuelve el numero de filas afectadas

                    //Obtener parametros de salida después de ejecución
                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);   //settea lo antes declarado en respuesta, con su respectivo tipo de dato
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();               //settea lo antes declarado en Mensaje, con su respectivo tipo de dato
                }
            }
            catch (Exception ex)
            {
                respuesta = false;      //le da el valor de false
                Mensaje = ex.Message;   //settea la excepcion en Mensaje
            }
            return respuesta;   //retorna la respuesta si llega a eliminar, retorna true, pero si entra al catch retorna false
        }
    }
}
