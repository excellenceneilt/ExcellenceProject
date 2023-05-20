using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Detalle_Compra
    {
        //Metodo para obtener el id del detalle de compra mediante el id de la compra y el id del producto
        public int ObtenerIdDC(int idCompra, int idProducto)
        {
            int idDetalleCompra = 0;
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select IdDetalleCompra from DETALLE_COMPRA where IdCompraDC = @IdCompraDC and IdProductoDC = @IdProductoDC");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);

                    cmd.Parameters.AddWithValue("@IdCompraDC", idCompra);
                    cmd.Parameters.AddWithValue("@IdProductoDC", idProducto);

                    cmd.CommandType = System.Data.CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            idDetalleCompra = Convert.ToInt32(dr["IdDetalleCompra"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    idDetalleCompra = 0;
                }
            }
            return idDetalleCompra;
        }
        public List<Detalle_Compra> Listar()
        {
            List<Detalle_Compra> lista = new List<Detalle_Compra>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select IdDetalleCompra, IdProductoDC, Cantidad, PrecioCompra, PrecioVenta, Total from DETALLE_COMPRA");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Detalle_Compra()
                            {
                                //Listar Clientes en tabla no necesariamente en orden
                                //Izquierda atributo de entidad y derecha es el nombre de la BD

                                IdDetalleCompra = Convert.ToInt32(dr["IdDetalleCompra"]),
                                oProducto = new Producto() { IdProducto = Convert.ToInt32(dr["IdProductoDC"]) },
                                Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                PrecioCompra = Convert.ToInt32(dr["PrecioCompra"]),
                                PrecioVenta = Convert.ToInt32(dr["PrecioVenta"]),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Detalle_Compra>();
                }
            }
            return lista;
        }
    }

}
