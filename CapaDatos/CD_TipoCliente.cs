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
    public class CD_Tipo_Cliente
    {
        //Metodo para listar
        public List<Tipo_Cliente> Listar()      //funcion para listar todos los tipos de clientes
        {
            List<Tipo_Cliente> lista = new List<Tipo_Cliente>();                    //crea un objeto del tipo lista con los tipos de clientes
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))    //crea un objeto oconexion con la funcion SqlConexion y le agrega los parametros de la cadena que se encuentra en la capa presentacion en App.config
            {
                try
                {
                    StringBuilder query = new StringBuilder();                                      //crea una nueva instancia StringBuilder
                    query.AppendLine("select IdTipoCliente, Descripcion, Estado from TIPOCLIENTE"); //Esa propiedad settea al final del objeto la cadena
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);                   //SQLCOMMAND ejecuta comandos y usa una acción "query" como la consulta y a oconexion como la cadena de conexion
                    cmd.CommandType = CommandType.Text;                                             //La propiedad Text especifica que el cmd va a ser una consulta a la BD

                    oconexion.Open();   //abre una conexion de datos con los valores que se especifica en SqlConnection

                    using (SqlDataReader dr = cmd.ExecuteReader())                      //convierte cmd que es un SqlCommand a SqlDataReader que permite leer las filas que se ejecuto en la BD
                    {
                        while (dr.Read())                                               //"dr.Read()" vota true mientras se encuentre abierta la conexion
                        {
                            lista.Add(new Tipo_Cliente()                                //Agrega los tipos de clientes al objeto lista
                            {
                                IdTipoCliente = Convert.ToInt32(dr["IdTipoCliente"]),   //Convierte lo que se encuentra en Fila "IdTipoCliente" de la BD a int de 32bits y lo guarda en IdTipoCliente del objeto "lista"
                                Descripcion = dr["Descripcion"].ToString(),             //Convierte lo que se encuentra en Fila "Descripcion" de la BD a string y lo guarda en Descripcion del objeto "lista"
                                Estado = Convert.ToBoolean(dr["Estado"])                //Convierte lo que se encuentra en Fila "Estado" de la BD a boolean y lo guarda en Estado del objeto "lista"

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Tipo_Cliente>();   //hace que lista tenga la lista vacia de los tipos de usuarios
                }
            }
            return lista;       //retorna la lista
        }


        //Los parametros de Mensaje es un parametro de salida y Tipo_Cliente de entrada
        /*
        public int Registrar(Tipo_Cliente obj, out string Mensaje)
        {
            int idTipo_Clientegenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    //Declarando los parámetros de entrada
                    SqlCommand cmd = new SqlCommand("SP_RegistrarTipo_Cliente", oconexion);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);//Los parametros entre "" se escriben sin arroba, referencian a los campos con @ dentro del procedimiento almacenado                 
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    //Obtener parametros de salida después de ejecución
                    idTipo_Clientegenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                idTipo_Clientegenerado = 0;
                Mensaje = ex.Message;
            }

            return idTipo_Clientegenerado;
        }

        public bool Editar(Tipo_Cliente obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    //Declarando los parámetros de entrada
                    SqlCommand cmd = new SqlCommand("SP_EditarTipo_Cliente", oconexion);
                    cmd.Parameters.AddWithValue("IdTipoCliente", obj.IdTipoCliente);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);//Los parametros entre "" se escriben sin arroba, referencian a los campos con @ dentro del procedimiento almacenado                 
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    //Obtener parametros de salida después de ejecución
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }

        public bool Eliminar(Tipo_Cliente obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    //Declarando los parámetros de entrada
                    SqlCommand cmd = new SqlCommand("SP_EliminarTipo_Cliente", oconexion);
                    cmd.Parameters.AddWithValue("IdTipoCliente", obj.IdTipoCliente);

                    //Declarando parámetros de salida
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    //Obtener parametros de salida después de ejecución
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }
        */

    }
}
