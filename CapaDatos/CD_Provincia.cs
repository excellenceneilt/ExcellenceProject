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

    public class CD_Provincia
    {

        public List<Provincia> Listar()
        {
            

            
            List<Provincia> lista = new List<Provincia>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdProvincia, Descripcion, Estado from Provincia");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);

                   // cmd.Parameters.AddWithValue("@IdDepartamento", IdDepartamento);
                    
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Provincia()
                            {
                                IdProvincia = Convert.ToInt32(dr["IdProvincia"]),
                                Descripcion = dr["Descripcion"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Provincia>();
                }
            }
            return lista;
        }
    }
}
