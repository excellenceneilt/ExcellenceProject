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
    public class CD_Departamento
    {

        public List<Departamento> Listar()
        {
            List<Departamento> lista = new List<Departamento>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdDepartamento, Descripcion, Estado from Departamento");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Departamento()
                            {
                                IdDepartamento = Convert.ToInt32(dr["IdDepartamento"]),
                                Descripcion = dr["Descripcion"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Departamento>();
                }
            }
            return lista;
        }
    }
}
