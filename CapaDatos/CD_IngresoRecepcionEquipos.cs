using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;

namespace CapaDatos
{
   public class CD_IngresoRecepcionEquipos
    {
        //Método para listar los ingresos de recepcion de equipos
        public List<IngresoRecepcionEquipos> Listar()
        {
            List<IngresoRecepcionEquipos> lista = new List<IngresoRecepcionEquipos>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select IdIre,CodOst,Deja,DniDeja,Telefono, ");
                    query.AppendLine("IdCliente,Ruc,Contacto,Correo,IdEquipo, ");
                    query.AppendLine("Marca,Modelo,Serial,IdEstEqui,Fecha, ");
                    query.AppendLine("Garantia,IdMoneda,Costo,Enciende,Situacion, ");
                    query.AppendLine("Accesorios,Observaciones,FechaRegistro ");
                    query.AppendLine("from IngresoRecepcionEquipos");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new IngresoRecepcionEquipos()
                            {
                                IdIre = Convert.ToInt32(dr["IdIre"]),
                                CodOST = dr["CodOst"].ToString(),
                                Deja = dr["Deja"].ToString(),
                                DniDeja = dr["DniDeja"].ToString(),
                                TelefonoDeja = dr["Telefono"].ToString(),
                                iCliente = new Cliente()
                                {
                                    IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                    NombreContacto = dr["Contacto"].ToString(),
                                    Correo1 = dr["Correo"].ToString()
                                },
                                iEquipo = new Equipo()
                                {
                                    IdEquipo = Convert.ToInt32(dr["IdEquipo"]),
                                    Marca = dr["Marca"].ToString(),
                                    Modelo = dr["Modelo"].ToString(),
                                    SerialNumber = dr["Serial"].ToString()
                                },
                                iEstadoEquipo = new EstadoEquipo()
                                {
                                    IdEstadoEquipo = Convert.ToInt32(dr["IdEstEqui"])
                                },
                                iCompra = new Compra()
                                {
                                    FechaRegistro = dr["Fecha"].ToString()
                                },
                                Garantia = Convert.ToBoolean(dr["Garantia"]),
                                iMoneda = new Moneda()
                                {
                                    IdMoneda = Convert.ToInt32(dr["IdMoneda"])
                                },
                                Costo = Convert.ToDecimal(dr["Costo"]),
                                Enciende = Convert.ToBoolean(dr["Enciende"]),
                                Situacion = dr["Situacion"].ToString(),
                                Accesorios = dr["Accesorios"].ToString(),
                                Observaciones = dr["Observaciones"].ToString(),
                                FechaIRE = dr["FechaRegistro"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<IngresoRecepcionEquipos>();
                }
            }
            return lista;
        }

        public int Registrar(IngresoRecepcionEquipos obj, out string Mensaje)
        {
            int idIreGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarIre", oconexion);

                    cmd.Parameters.AddWithValue("@CodOst", obj.CodOST);
                    cmd.Parameters.AddWithValue("@Deja", obj.Deja);
                    cmd.Parameters.AddWithValue("@DniDeja", obj.DniDeja);
                    cmd.Parameters.AddWithValue("@Telefono", obj.TelefonoDeja);
                    cmd.Parameters.AddWithValue("@IdCliente", obj.iCliente.IdCliente);
                    cmd.Parameters.AddWithValue("@Contacto", obj.iCliente.NombreContacto);
                    cmd.Parameters.AddWithValue("@Correo", obj.iCliente.Correo1);
                    cmd.Parameters.AddWithValue("@IdEquipo", obj.iEquipo.IdEquipo);
                    cmd.Parameters.AddWithValue("@Marca", obj.iEquipo.Marca);
                    cmd.Parameters.AddWithValue("@Modelo", obj.iEquipo.Modelo);
                    cmd.Parameters.AddWithValue("@Serial", obj.iEquipo.SerialNumber);
                    cmd.Parameters.AddWithValue("@IdEstEqui", obj.iEstadoEquipo.IdEstadoEquipo);
                    cmd.Parameters.AddWithValue("@Fecha", obj.Fecha);
                    cmd.Parameters.AddWithValue("@Garantia", obj.Garantia);
                    cmd.Parameters.AddWithValue("@IdMoneda", obj.iMoneda.IdMoneda);
                    cmd.Parameters.AddWithValue("@Costo", obj.Costo);
                    cmd.Parameters.AddWithValue("@Enciende", obj.Enciende);
                    cmd.Parameters.AddWithValue("@Situacion", obj.Situacion);
                    cmd.Parameters.AddWithValue("@Accesorios", obj.Accesorios);
                    cmd.Parameters.AddWithValue("@Observaciones", obj.Observaciones);
                    cmd.Parameters.AddWithValue("@FechaRegistro", obj.FechaIRE);

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idIreGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch(Exception ex)
            {
                idIreGenerado = 0;
                Mensaje = ex.Message;
            }
            return idIreGenerado;
        }
        
        public bool Editar(IngresoRecepcionEquipos obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    //Declarando los parámetros de entrada
                    SqlCommand cmd = new SqlCommand("SP_ModificarIre", oconexion);

                    cmd.Parameters.AddWithValue("@CodOst", obj.CodOST);
                    cmd.Parameters.AddWithValue("@Deja", obj.Deja);
                    cmd.Parameters.AddWithValue("@DniDeja", obj.DniDeja);
                    cmd.Parameters.AddWithValue("@Telefono", obj.TelefonoDeja);
                    cmd.Parameters.AddWithValue("@IdCliente", obj.iCliente.IdCliente);
                    cmd.Parameters.AddWithValue("@Contacto", obj.iCliente.NombreContacto);
                    cmd.Parameters.AddWithValue("@Correo", obj.iCliente.Correo1);
                    cmd.Parameters.AddWithValue("@IdEquipo", obj.iEquipo.IdEquipo);
                    cmd.Parameters.AddWithValue("@Marca", obj.iEquipo.Marca);
                    cmd.Parameters.AddWithValue("@Modelo", obj.iEquipo.Modelo);
                    cmd.Parameters.AddWithValue("@Serial", obj.iEquipo.SerialNumber);
                    //cmd.Parameters.AddWithValue("@IdEstEqui", obj.iEstadoEquipo.IdEstadoEquipo);
                    cmd.Parameters.AddWithValue("@Fecha", obj.Fecha);
                    cmd.Parameters.AddWithValue("@Garantia", obj.Garantia);
                    cmd.Parameters.AddWithValue("@IdMoneda", obj.iMoneda.IdMoneda);
                    cmd.Parameters.AddWithValue("@Costo", obj.Costo);
                    cmd.Parameters.AddWithValue("@Enciende", obj.Enciende);
                    cmd.Parameters.AddWithValue("@Situacion", obj.Situacion);
                    cmd.Parameters.AddWithValue("@Accesorios", obj.Accesorios);
                    cmd.Parameters.AddWithValue("@Observaciones", obj.Observaciones);
                    cmd.Parameters.AddWithValue("@FechaRegistro", obj.FechaIRE);

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

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

        public string GetOst(int idIre)
        {
            string codOst = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select CodOst from IngresoRecepcionEquipos where IdIre = @idIre");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);

                    cmd.Parameters.AddWithValue("@idIre", idIre);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            codOst = dr["CodOst"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    codOst = string.Empty;
                }
            }
            return codOst;
        }
    }
}
