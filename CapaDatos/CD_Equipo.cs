using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    query.AppendLine("select IdEquipo, Modelo, SerialNumber, IdProducto from  Equipo");
                    
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
                                Modelo = dr["Modelo"].ToString(),
                                SerialNumber = dr["SerialNumber"].ToString(),
                                eProducto = new Producto() 
                                { 
                                    IdProducto = Convert.ToInt32(dr["IdProducto"])    
                                }
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
                    SqlCommand cmd = new SqlCommand("SP_RegistrarEquipos", oconexion);
                    cmd.Parameters.AddWithValue("CodigoEquipo", obj.CodigoEquipo);//Los parametros entre "" se escriben sin arroba, referencian a los campos con @ dentro del procedimiento almacenado
                    cmd.Parameters.AddWithValue("Marca", obj.Marca);
                    cmd.Parameters.AddWithValue("Modelo", obj.Modelo);
                    cmd.Parameters.AddWithValue("SerialNumber", obj.SerialNumber);
                    cmd.Parameters.AddWithValue("IdProducto", obj.eProducto.IdProducto);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("IdCompra", obj.eCompra.IdCompra);
                    cmd.Parameters.AddWithValue("IdDetalleCompra", obj.eDetalle.IdDetalleCompra);

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
                    cmd.Parameters.AddWithValue("CodigoEquipo", obj.CodigoEquipo);//Los parametros entre "" se escriben sin arroba, referencian a los campos con @ dentro del procedimiento almacenado
                    cmd.Parameters.AddWithValue("Modelo", obj.Modelo);
                    cmd.Parameters.AddWithValue("SerialNumber", obj.SerialNumber);
                    cmd.Parameters.AddWithValue("Marca", obj.Marca);
                    cmd.Parameters.AddWithValue("IdEstadoEquipo", obj.eEstadoEquipo.IdEstadoEquipo);
                    cmd.Parameters.AddWithValue("IdProducto", obj.eProducto.IdProducto);
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

        //Funcion para determinar cuantos equipos tienen un numero de serie agrupandolos por el id del producto
        public int ProductoConSerial(int idProducto, int idDetalleCompra, string numeroDocumento)
        {
            int cantidad = 0;
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*)[ProductoConSerial] ");
                    query.AppendLine("FROM Equipo ");
                    query.AppendLine("WHERE IdProducto = @IdProducto and IdDetalleCompra = @IdDetalleCompra and ");
                    query.AppendLine("IdCompra = (select IdCompra from COMPRA where NumeroDocumento =@NumeroDocumento)");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);

                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    cmd.Parameters.AddWithValue("@IdDetalleCompra", idDetalleCompra);
                    cmd.Parameters.AddWithValue("@NumeroDocumento", numeroDocumento);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cantidad = Convert.ToInt32(dr["ProductoConSerial"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    cantidad = 0;
                }
                return cantidad;
            }
        }

        /*public int ProductoConSerial(int idProducto)
        {
            int cantidad = 0;
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select count(*)[ProductoConSerial] from Equipo where IdProducto = @IdProducto group by IdProducto");
                    
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);

                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cantidad = Convert.ToInt32(dr["ProductoConSerial"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    cantidad = 0;
                }
                return cantidad;
            }
        }*/
    }
}
