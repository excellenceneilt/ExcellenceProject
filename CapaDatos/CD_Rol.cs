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
    public class CD_Rol
    {

        public List<Rol> Listar()   //Se crea una funcion para que liste los roles
        {
            List<Rol> lista = new List<Rol>();                                      //se crea el objeto lista que es una lista de roles
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))    //crea un objeto oconexion con la funcion SqlConexion y le agrega los parametros de la cadena que se encuentra en la capa presentacion en App.config
            {
                try
                {
                    StringBuilder query = new StringBuilder();              //crea un objeto query como una instancia de la clase StringBuilder
                    query.AppendLine("select IdRol, Descripcion from ROL"); //Esa propiedad settea al final del objeto la cadena

                    //SQLCOMMAND ejecuta comandos y usa una acción "query" y la cadena de conexion
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);   //SQLCOMMAND ejecuta comandos y usa una acción "query" como la consulta y a oconexion como la cadena de conexion
                    cmd.CommandType = CommandType.Text;                             //La propiedad Text especifica que el cmd va a ser una consulta a la BD

                    oconexion.Open();                               //abre una conexion de datos con los valores que se especifica en SqlConnection
                    using (SqlDataReader dr = cmd.ExecuteReader())  //convierte cmd que es un SqlCommand a SqlDataReader que permite leer las filas que se ejecuto en la BD
                    {
                        while (dr.Read())   //"dr.Read()" vota true mientras se encuentre abierta la conexion
                        {
                            lista.Add(new Rol() //Agrega los usuarios al objeto lista
                            {
                                IdRol= Convert.ToInt32(dr["IdRol"]),        //Convierte lo que se encuentra en Fila "IdRol" de la BD a int de 32bits y lo guarda en IdRol del objeto "lista"
                                Descripcion = dr["Descripcion"].ToString()  //Convierte lo que se encuentra en Fila "Descripcion" de la BD a string y lo guarda en Descripcion del objeto "lista"
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Rol>();    //hace que lista tenga la lista vacia de los roles
                }
            }
            return lista;   //retorna la lista
        }
    }
}
