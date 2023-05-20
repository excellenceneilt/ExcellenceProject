using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CapaDatos
{
    public class CD_Permiso
    {
        public List<Permiso> Listar(int idusuario)  //funcion para listar los permisos
        {
            List<Permiso> lista = new List<Permiso>();                          //se crea el objeto lista que es una lista de permisos
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))//crea un objeto oconexion con la funcion SqlConexion y le agrega los parametros de la cadena que se encuentra en la capa presentacion en App.config
            {
                try
                {

                    StringBuilder query = new StringBuilder();                      //crea un objeto query como una instancia de la clase StringBuilder
                    query.AppendLine("select p.IdRol,p.NombreMenu from PERMISO p"); //Esa propiedad settea al final del objeto la cadena
                    query.AppendLine("inner join ROL r ON r.IdRol = p.IdRol");      //Esa propiedad settea al final del objeto la cadena
                    query.AppendLine("inner join USUARIO u on u.IdRol = r.IdRol");  //Esa propiedad settea al final del objeto la cadena
                    query.AppendLine("where u.IdUsuario = @idusuario");             //Esa propiedad settea al final del objeto la cadena

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);   //SQLCOMMAND ejecuta comandos y usa una acción "query" y la cadena de conexion

                    cmd.Parameters.AddWithValue("@idusuario", idusuario);   //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                    cmd.CommandType = CommandType.Text;                     //La propiedad Text especifica que el cmd va a ser una consulta a la BD

                    oconexion.Open();   //abre una conexion de datos con los valores que se especifica en SqlConnection

                    using (SqlDataReader dr = cmd.ExecuteReader())  //convierte cmd que es un SqlCommand a SqlDataReader que permite leer las filas que se ejecuto en la BD
                    {
                        while (dr.Read())   //"dr.Read()" vota true mientras se encuentre abierta la conexion
                        {
                            lista.Add(new Permiso() //Agrega los usuarios al objeto lista
                            {
                                oRol = new Rol()                        //Se va agregar el objeto rol
                                { 
                                    IdRol = Convert.ToInt32(dr["IdRol"])//Convierte lo que se encuentra en Fila "IdRol" de la BD a string y lo guarda en IdRol del objeto "lista"
                                },  
                                NombreMenu = dr["NombreMenu"].ToString(),//Convierte lo que se encuentra en Fila "IdRol" de la BD a string y lo guarda en IdRol del objeto "lista"
                            }) ;
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Permiso>();    //deja la lista vacía
                }
            }
            return lista;   //retorna la lista
        }
    }
}
