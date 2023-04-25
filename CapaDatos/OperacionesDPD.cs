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
    public class OperacionesDPD
    {

        public List<Departamento> ObtenerDepartamento()     //funcion para obetener todos los departamentos
        {
            List<Departamento> olistaDepartamento = new List<Departamento>();       //crea un objeto del tipo lista con los departamentos
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))    //crea un objeto oconexion con la funcion SqlConexion y le agrega los parametros de la cadena que se encuentra en la capa presentacion en App.config
            {
                
                SqlCommand cmd = new SqlCommand("SP_ObtenerDepartamento", oconexion);   //inicializa una instancia con una consulta y una conexion
                cmd.CommandType = CommandType.StoredProcedure;                          //establece que la consulta va a ser un procedimiento almacenado
                cmd.CommandTimeout = 600;                                               //establece un tiempo para hacer la consulta, sino, lo toma como error
                oconexion.Open();                                                       //abre una conexion de datos con los valores que se especifica en SqlConnection

                SqlDataReader dr = cmd.ExecuteReader();                                 //convierte cmd que es un SqlCommand a SqlDataReader que permite leer las filas que se ejecuto en la BD

                while (dr.Read())                                                       //"dr.Read()" vota true mientras se encuentre abierta la conexion
                {
                    olistaDepartamento.Add(new Departamento                             //Agrega los departamentos al objeto olistaDepartamento
                    {
                        IdDepartamento = Convert.ToInt32(dr["IdDepartamento"]),         //Convierte lo que se encuentra en Fila "IdDepartamento" de la BD a int de 32bits y lo guarda en IdDepartamento del objeto "olistaDepartamento"
                        Descripcion = Convert.ToString(dr["Descripcion"])               //Convierte lo que se encuentra en Fila "Descripcion" de la BD a string y lo guarda en Descripcion del objeto "olistaDepartamento"
                    });
                }
                dr.Close();                                                             //cierra la conexion con la BD
            }
            return olistaDepartamento;                                                  //retorna la lista con los departamentos
        }

        public List<Provincia> ObtenerProvincia(int IdDepartamento)                     //funcion para obetener todos las provincias a las que pertenezcan "IdDepartamento" que se pasa como parámetro
        {
            List<Provincia> olistaProvincia = new List<Provincia>();                    //crea un objeto del tipo lista con las provincias
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))        //crea un objeto oconexion con la funcion SqlConexion y le agrega los parametros de la cadena que se encuentra en la capa presentacion en App.config
            {
               
                SqlCommand cmd = new SqlCommand("SP_ObtenerProvincia", oconexion);      //inicializa una instancia con una consulta y una conexion
                cmd.CommandType = CommandType.StoredProcedure;                          //establece que la consulta ca a ser un procedimiento almacenado
                cmd.Parameters.AddWithValue("IdDepartamento", IdDepartamento);          //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                cmd.CommandTimeout = 600;                                               //establece un tiempo para hacer la consulta, sino, lo toma como error
                oconexion.Open();                                                       //abre una conexion de datos con los valores que se especifica en SqlConnection

                SqlDataReader dr = cmd.ExecuteReader();                                 //convierte cmd que es un SqlCommand a SqlDataReader que permite leer las filas que se ejecuto en la BD

                while (dr.Read())                                                       //"dr.Read()" vota true mientras se encuentre abierta la conexion
                    {
                    olistaProvincia.Add(new Provincia                                   //Agrega las provincias al objeto olistaProvincia
                    {
                        IdProvincia = Convert.ToInt32(dr["IdProvincia"]),               //Convierte lo que se encuentra en Fila "IdProvincia" de la BD a int de 32bits y lo guarda en IdProvincia del objeto "olistaProvincia"
                        Descripcion = Convert.ToString(dr["Descripcion"])               //Convierte lo que se encuentra en Fila "Descripcion" de la BD a string y lo guarda en Descripcion del objeto "olistaProvincia"
                    });
                }
                dr.Close();                                                             //cierra la conexion con la BD
            }
            return olistaProvincia;                                                     //retorna la lista con las provincias
        }

        public List<Distrito> ObtenerDistrito(int IdProvincia)                          //funcion para obetener todos los distritos a las que pertenezcan "IdProvincia" que se pasa como parámetro
        {
            List<Distrito> olistaDistrito = new List<Distrito>();                       //crea un objeto del tipo lista con los distritos
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))        //crea un objeto oconexion con la funcion SqlConexion y le agrega los parametros de la cadena que se encuentra en la capa presentacion en App.config
            {
                SqlCommand cmd = new SqlCommand("SP_ObtenerDistrito", oconexion);       //inicializa una instancia con una consulta y una conexion
                cmd.CommandType = CommandType.StoredProcedure;                          //establece que la consulta ca a ser un procedimiento almacenado
                cmd.Parameters.AddWithValue("IdProvincia", IdProvincia);                //indica que se van a agregar valores al procedimiento almacenado. El primero es el nombre de la fila de la BD y el segundo es el valor que se le va agregar
                cmd.CommandTimeout = 600;                                               //establece un tiempo para hacer la consulta, sino, lo toma como error
                oconexion.Open();                                                       //abre una conexion de datos con los valores que se especifica en SqlConnection

                SqlDataReader dr = cmd.ExecuteReader();                                 //convierte cmd que es un SqlCommand a SqlDataReader que permite leer las filas que se ejecuto en la BD

                while (dr.Read())                                                       //"dr.Read()" vota true mientras se encuentre abierta la conexion
                {
                    olistaDistrito.Add(new Distrito                                     //Agrega las provincias al objeto olistaDistrito
                    {
                        IdDistrito = Convert.ToInt32(dr["IdDIstrito"]),                 //Convierte lo que se encuentra en Fila "IdDistrito" de la BD a int de 32bits y lo guarda en IdDistrito del objeto "olistaDistrito"
                        Descripcion = Convert.ToString(dr["Descripcion"].ToString())    //Convierte lo que se encuentra en Fila "Descripcion" de la BD a string y lo guarda en Descripcion del objeto "olistaDistrito"
                    });
                }
                dr.Close();                                                             //cierra la conexion con la BD
            }
            return olistaDistrito;                                                      //retorna la lista con los distritos
        }
    }
}
