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
    public class CD_Equipo
    {
        //Metodo para listar
        public List<Equipo> Listar()
        {
            List<Equipo> lista = new List<Equipo>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdEquipo, CodigoEquipo, Modelo, SerialNumber,p.IdProducto,p.Nombre[NombreEquipo],  ed.IdEstadoEquipo, ed.Descripcion[DescripcionEquipo] from Equipo e");
                    query.AppendLine("inner join PRODUCTO p on p.IdProducto = e.IdProducto");
                    query.AppendLine("inner join EstadoEquipo ed on ed.IdEstadoEquipo = e.IdEstadoEquipo");
                    
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Equipo()
                            {
                                //Listar productos en tabla
                                IdEquipo = Convert.ToInt32(dr["IdEquipo"]),
                                CodigoEquipo = dr["CodigoEquipo"].ToString(),
                                Modelo = dr["Modelo"].ToString(),
                                SerialNumber = dr["SerialNumber"].ToString(),
                                //Llave foránea
                                eProducto = new Producto()
                                {
                                    IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                    Nombre = dr["NombreEquipo"].ToString()
                                },
                                oEstadoEquipo = new EstadoEquipo()
                                {
                                    IdEstadoEquipo = Convert.ToInt32(dr["IdEstadoEquipo"]),
                                    Descripcion = dr["DescripcionEquipo"].ToString()
                                },

                                
                                Estado = Convert.ToBoolean(dr["Estado"])

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Equipo>();
                }
            }
            return lista;
        }


        public int Registrar(Equipo obj, out string Mensaje)
        {
            int idEquipogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    //Declarando los parámetros de entrada
                    SqlCommand cmd = new SqlCommand("SP_RegistrarEquipo", oconexion);
                    cmd.Parameters.AddWithValue("CodigoEquipo", obj.CodigoEquipo);//Los parametros entre "" se escriben sin arroba, referencian a los campos con @ dentro del procedimiento almacenado
                    cmd.Parameters.AddWithValue("Modelo", obj.Modelo);
                    cmd.Parameters.AddWithValue("SerialNumber", obj.SerialNumber);

                    cmd.Parameters.AddWithValue("IdProducto",obj.eProducto.IdProducto);
                    cmd.Parameters.AddWithValue("IdEstadoEquipo", obj.oEstadoEquipo.IdEstadoEquipo);

                    cmd.Parameters.AddWithValue("Estado", obj.Estado);

                    //Declarando parámetros de salida
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    //Obtener parametros de salida después de ejecución
                    idEquipogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                idEquipogenerado = 0;
                Mensaje = ex.Message;
            }

            return idEquipogenerado;
        }

        public bool Editar(Equipo obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    //Declarando los parámetros de entrada
                    SqlCommand cmd = new SqlCommand("SP_ModificarProducto", oconexion);
                    cmd.Parameters.AddWithValue("IdEquipo", obj.IdEquipo);
                 //   cmd.Parameters.AddWithValue("CodigoEquipo", obj.eCodigoEquipo.Codigo);//Los parametros entre "" se escriben sin arroba, referencian a los campos con @ dentro del procedimiento almacenado
                    cmd.Parameters.AddWithValue("Modelo", obj.Modelo);
                    cmd.Parameters.AddWithValue("SerialNumber", obj.SerialNumber);

                    cmd.Parameters.AddWithValue("IdProducto", obj.eProducto.IdProducto);
                    cmd.Parameters.AddWithValue("IdEstadoEquipo", obj.oEstadoEquipo.IdEstadoEquipo);

                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
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


        //Eliminar incompleto
        public bool Eliminar(Equipo obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    //Declarando los parámetros de entrada
                    SqlCommand cmd = new SqlCommand("SP_EliminarEquipo", oconexion);
                    cmd.Parameters.AddWithValue("IdEquipo", obj.IdEquipo);

                    //Declarando parámetros de salida
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    //Obtener parametros de salida después de ejecución
                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
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
    }
}
