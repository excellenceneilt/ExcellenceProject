using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CapaNegocio
{
    public class CN_Detalle_Compra
    {
        private CD_Detalle_Compra objcd_Detalle_Compra = new CD_Detalle_Compra();

        public int ObtenerIdDC(int idCompra, int idProducto)
        {
            return objcd_Detalle_Compra.ObtenerIdDC(idCompra, idProducto);
        }

        public List<Detalle_Compra> Listar()
        {
            return objcd_Detalle_Compra.Listar();
        }
    }
}
