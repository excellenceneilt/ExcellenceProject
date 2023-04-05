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
   public class CD_IngresoRecepcionEquipos
    {
        

        public int Registrar(IngresoRecepcionEquipos obj, out string Mensaje)
        {
            int idClientegenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    //Declarando los parámetros de entrada
                    SqlCommand cmd = new SqlCommand("SP_RegistrarCliente", oconexion);

                    //  cmd.Parameters.AddWithValue("CodigoCliente", obj.CodigoCliente); desactivado porque se genera en bd
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);//Los parametros entre "" se escriben sin arroba, referencian a los campos con @ dentro del procedimiento almacenado, el de la derecha es la entidad
                    cmd.Parameters.AddWithValue("DocumentoContacto", obj.DocumentoContacto);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("NombreComercial", obj.NombreComercial);
                    cmd.Parameters.AddWithValue("NombreContacto", obj.NombreContacto);
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("DireccionComercial", obj.DireccionComercial);
                    cmd.Parameters.AddWithValue("DireccionContacto", obj.DireccionContacto);
                    cmd.Parameters.AddWithValue("IdTipoCliente", obj.oTipo_Cliente.IdTipoCliente);
                    cmd.Parameters.AddWithValue("IdTipoDocumento", obj.oTipo_Documento.IdTipoDocumento);
                    cmd.Parameters.AddWithValue("Departamento", obj.Departamento);
                    cmd.Parameters.AddWithValue("Provincia", obj.Provincia);
                    cmd.Parameters.AddWithValue("Distrito", obj.Distrito);
                    cmd.Parameters.AddWithValue("DepartamentoComercial", obj.DepartamentoComercial);
                    cmd.Parameters.AddWithValue("ProvinciaComercial", obj.ProvinciaComercial);
                    cmd.Parameters.AddWithValue("DistritoComercial", obj.DistritoComercial);
                    cmd.Parameters.AddWithValue("DepartamentoContacto", obj.DepartamentoContacto);
                    cmd.Parameters.AddWithValue("ProvinciaContacto", obj.ProvinciaContacto);
                    cmd.Parameters.AddWithValue("DistritoContacto", obj.DistritoContacto);
                    cmd.Parameters.AddWithValue("Correo1", obj.Correo1);
                    cmd.Parameters.AddWithValue("Correo2", obj.Correo2);
                    cmd.Parameters.AddWithValue("CorreoContacto", obj.CorreoContacto);
                    cmd.Parameters.AddWithValue("Telefono1", obj.Telefono1);
                    cmd.Parameters.AddWithValue("Telefono2", obj.Telefono2);
                    cmd.Parameters.AddWithValue("TelefonofijoContacto", obj.TelefonofijoContacto);
                    cmd.Parameters.AddWithValue("CelularContacto", obj.CelularContacto);
                    cmd.Parameters.AddWithValue("CMP", obj.CMP);
                    cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                    cmd.Parameters.AddWithValue("RUC", obj.RUC);
                    cmd.Parameters.AddWithValue("RUCContacto", obj.RUCContacto);
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

    }
}
