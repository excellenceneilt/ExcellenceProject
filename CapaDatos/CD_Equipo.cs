﻿using CapaEntidad;
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
                    query.AppendLine("select IdEquipo, CodigoEquipo, NombreEquipo, SerialNumber, c.IdCategoria,C.Descripcion[DescripcionCategoria],  e.Estado from Equipo e");
                    query.AppendLine("inner join CATEGORIA c on c.IdCategoria = e.IdCategoria");
                    
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
                                CodigoEquipo = Convert.ToInt32(dr["CodigoEquipo"]),
                                Modelo = dr["Modelo"].ToString(),
                                SerialNumber = dr["SerialNumber"].ToString(),
                                //Llave foránea
                                eCategoria = new Categoria() { IdCategoria = Convert.ToInt32(dr["IdCategoria"]), /*Añadiendo alias*/ Descripcion = dr["DescripcionCategoria"].ToString() },
                                
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
            int idProductogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    //Declarando los parámetros de entrada
                    SqlCommand cmd = new SqlCommand("SP_RegistrarEquipo", oconexion);
                    cmd.Parameters.AddWithValue("Codigo", obj.CodigoEquipo);//Los parametros entre "" se escriben sin arroba, referencian a los campos con @ dentro del procedimiento almacenado
                    cmd.Parameters.AddWithValue("Modelo", obj.Modelo);
                    cmd.Parameters.AddWithValue("Descripcion", obj.SerialNumber);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.eCategoria.IdCategoria);
                  //  cmd.Parameters.AddWithValue("IdEstadoEquipo", obj.oEstadoEquipo.IdEstadoEquipo);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);

                    //Declarando parámetros de salida
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    //Obtener parametros de salida después de ejecución
                    idProductogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                idProductogenerado = 0;
                Mensaje = ex.Message;
            }

            return idProductogenerado;
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
                    cmd.Parameters.AddWithValue("Descripcion", obj.SerialNumber);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.eCategoria.IdCategoria);
                    //  cmd.Parameters.AddWithValue("IdEstadoEquipo", obj.oEstadoEquipo.IdEstadoEquipo);
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