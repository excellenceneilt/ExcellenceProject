using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml.Linq;

namespace CapaDatos
{
    public class CD_Cliente
    {
        //Metodo para listar
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select IdCliente, CodigoCliente, td.IdTipoDocumento, td.Descripcion[Documentos], Documento, NombreCompleto, RazonSocial, Direccion, Departamento, Provincia, Distrito, ");
                    query.AppendLine("NombreComercial, DireccionComercial, Correo1, Correo2, Telefono1, Telefono2, DepartamentoComercial, ProvinciaComercial, DistritoComercial, ");
                    query.AppendLine("NombreContacto, DireccionContacto, DepartamentoContacto, ProvinciaContacto, DistritoContacto, c.IdTipoDocumentoContacto, tdd.Descripcion[TipoDocumentoContacto], ");
                    query.AppendLine("DocumentoContacto, CMP, TelefonofijoContacto, CelularContacto, CorreoContacto, c.Estado ");
                    query.AppendLine("from CLIENTE c inner join TIPODOCUMENTO td on td.IdTipoDocumento = c.IdTipoDocumento ");
                    query.AppendLine("inner join Departamento d on d.Descripcion = c.Departamento ");
                    query.AppendLine("inner join TIPODOCUMENTO tdd on tdd.IdTipoDocumento = c.IdTipoDocumentoContacto order by IdCliente");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cliente()
                            {
                                //Listar Clientes en tabla no necesariamente en orden
                                //Izquierda atributo de entidad y derecha es el nombre de la BD
                                //DATOS DE LA FACTURACION
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                CodigoCliente = dr["CodigoCliente"].ToString(),
                                oTipo_Documento = new Tipo_Documento()
                                {
                                    IdTipoDocumento = Convert.ToInt32(dr["IdTipoDocumento"]),
                                    Descripcion = dr["Documentos"].ToString()
                                },
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                RazonSocial = dr["RazonSocial"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                Departamento = dr["Departamento"].ToString(),
                                Provincia = dr["Provincia"].ToString(),
                                Distrito = dr["Distrito"].ToString(),
                                //DATOS DEL COMERCIO
                                NombreComercial = dr["NombreComercial"].ToString(),
                                DireccionComercial = dr["DireccionComercial"].ToString(),
                                Correo1 = dr["Correo1"].ToString(),
                                Correo2 = dr["Correo2"].ToString(),
                                Telefono1 = dr["Telefono1"].ToString(),
                                Telefono2 = dr["Telefono2"].ToString(),
                                DepartamentoComercial = dr["DepartamentoComercial"].ToString(),
                                ProvinciaComercial = dr["ProvinciaComercial"].ToString(),
                                DistritoComercial = dr["DistritoComercial"].ToString(),
                                //DATOS DEL CONTACTO
                                NombreContacto = dr["NombreContacto"].ToString(),
                                DireccionContacto = dr["DireccionContacto"].ToString(),
                                DepartamentoContacto = dr["DepartamentoContacto"].ToString(),
                                ProvinciaContacto = dr["ProvinciaContacto"].ToString(),
                                DistritoContacto = dr["DistritoContacto"].ToString(),
                                ocTipo_Documento = new Tipo_Documento()
                                {
                                    IdTipoDocumento = Convert.ToInt32(dr["IdTipoDocumentoContacto"]),
                                    Descripcion = dr["TipoDocumentoContacto"].ToString()
                                },
                                DocumentoContacto = dr["DocumentoContacto"].ToString(),
                                CMP = dr["CMP"].ToString(),
                                TelefonofijoContacto = dr["TelefonofijoContacto"].ToString(),
                                CelularContacto = dr["CelularContacto"].ToString(),
                                CorreoContacto = dr["CorreoContacto"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Cliente>();
                }
            }
            return lista;
        }
        /*HASTA ACA ESTA LISTO*/
        //Los parametros de Mensaje es un parametro de salida y Cliente de entrada
        public int Registrar(Cliente obj, out string Mensaje)
        {
            int idClientegenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    //Declarando los parámetros de entrada
                    SqlCommand cmd = new SqlCommand("SP_RegistrarCliente", oconexion);

                    cmd.Parameters.AddWithValue("IdTipoDocumento", obj.oTipo_Documento.IdTipoDocumento);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("Departamento", obj.Departamento);
                    cmd.Parameters.AddWithValue("Provincia", obj.Provincia);
                    cmd.Parameters.AddWithValue("Distrito", obj.Distrito);

                    cmd.Parameters.AddWithValue("NombreComercial", obj.NombreComercial);
                    cmd.Parameters.AddWithValue("DireccionComercial", obj.DireccionComercial);
                    cmd.Parameters.AddWithValue("Correo1", obj.Correo1);
                    cmd.Parameters.AddWithValue("Correo2", obj.Correo2);
                    cmd.Parameters.AddWithValue("Telefono1", obj.Telefono1);
                    cmd.Parameters.AddWithValue("Telefono2", obj.Telefono2);
                    cmd.Parameters.AddWithValue("DepartamentoComercial", obj.DepartamentoComercial);
                    cmd.Parameters.AddWithValue("ProvinciaComercial", obj.ProvinciaComercial);
                    cmd.Parameters.AddWithValue("DistritoComercial", obj.DistritoComercial);

                    cmd.Parameters.AddWithValue("NombreContacto", obj.NombreContacto);
                    cmd.Parameters.AddWithValue("DireccionContacto", obj.DireccionContacto);
                    cmd.Parameters.AddWithValue("DepartamentoContacto", obj.DepartamentoContacto);
                    cmd.Parameters.AddWithValue("ProvinciaContacto", obj.ProvinciaContacto);
                    cmd.Parameters.AddWithValue("DistritoContacto", obj.DistritoContacto);
                    cmd.Parameters.AddWithValue("IdTipoDocumentoContacto", obj.ocTipo_Documento.IdTipoDocumento);
                    cmd.Parameters.AddWithValue("DocumentoContacto", obj.DocumentoContacto);
                    cmd.Parameters.AddWithValue("CMP", obj.CMP);
                    cmd.Parameters.AddWithValue("TelefonofijoContacto", obj.TelefonofijoContacto);
                    cmd.Parameters.AddWithValue("CelularContacto", obj.CelularContacto);
                    cmd.Parameters.AddWithValue("CorreoContacto", obj.CorreoContacto);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    
                    //Declarando parámetros de salida
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    //Obtener parametros de salida después de ejecución
                    idClientegenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idClientegenerado = 0;
                Mensaje = ex.Message;
            }
            return idClientegenerado;
        }

        public bool Editar(Cliente obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    //Declarando los parámetros de entrada
                    SqlCommand cmd = new SqlCommand("SP_ModificarCliente", oconexion);
                    cmd.Parameters.AddWithValue("IdCliente", obj.IdCliente);

                    cmd.Parameters.AddWithValue("IdTipoDocumento", obj.oTipo_Documento.IdTipoDocumento);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("Departamento", obj.Departamento);
                    cmd.Parameters.AddWithValue("Provincia", obj.Provincia);
                    cmd.Parameters.AddWithValue("Distrito", obj.Distrito);

                    cmd.Parameters.AddWithValue("NombreComercial", obj.NombreComercial);
                    cmd.Parameters.AddWithValue("DireccionComercial", obj.DireccionComercial);
                    cmd.Parameters.AddWithValue("Correo1", obj.Correo1);
                    cmd.Parameters.AddWithValue("Correo2", obj.Correo2);
                    cmd.Parameters.AddWithValue("Telefono1", obj.Telefono1);
                    cmd.Parameters.AddWithValue("Telefono2", obj.Telefono2);
                    cmd.Parameters.AddWithValue("DepartamentoComercial", obj.DepartamentoComercial);
                    cmd.Parameters.AddWithValue("ProvinciaComercial", obj.ProvinciaComercial);
                    cmd.Parameters.AddWithValue("DistritoComercial", obj.DistritoComercial);

                    cmd.Parameters.AddWithValue("NombreContacto", obj.NombreContacto);
                    cmd.Parameters.AddWithValue("DireccionContacto", obj.DireccionContacto);
                    cmd.Parameters.AddWithValue("DepartamentoContacto", obj.DepartamentoContacto);
                    cmd.Parameters.AddWithValue("ProvinciaContacto", obj.ProvinciaContacto);
                    cmd.Parameters.AddWithValue("DistritoContacto", obj.DistritoContacto);
                    cmd.Parameters.AddWithValue("IdTipoDocumentoContacto", obj.ocTipo_Documento.IdTipoDocumento);
                    cmd.Parameters.AddWithValue("DocumentoContacto", obj.DocumentoContacto);
                    cmd.Parameters.AddWithValue("CMP", obj.CMP);
                    cmd.Parameters.AddWithValue("TelefonofijoContacto", obj.TelefonofijoContacto);
                    cmd.Parameters.AddWithValue("CelularContacto", obj.CelularContacto);
                    cmd.Parameters.AddWithValue("CorreoContacto", obj.CorreoContacto);
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

        public bool Eliminar(Cliente obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("delete from cliente where IdCliente =@id", oconexion);
                    cmd.Parameters.AddWithValue("@id", obj.IdCliente);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
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
