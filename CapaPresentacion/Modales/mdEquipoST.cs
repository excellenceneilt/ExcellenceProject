using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Modales
{
    public partial class mdEquipoST : Form
    {
        public Compra _Compra { get; set; }
        public Venta _Venta { get; set; }
        public Cliente _Cliente { get; set; }
        public Equipo _Equipo { get; set; }
        public Producto _Producto { get; set; }
        public mdEquipoST()
        {
            InitializeComponent();
        }

        private void mdEquipoST_Load(object sender, EventArgs e)
        {
            //Para filtrar los datos en la tabla
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true)
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText});
                }
            }

            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            dgvdata.Rows.Clear();
            List<Equipo> listaEquipo = new CN_Equipo().Listar();

            foreach (Equipo item in listaEquipo)
            {
                string fec = new CN_Compra().ObtenerFecha(item.eCompra.IdCompra);
                dgvdata.Rows.Add(new object[]
                {
                    item.CodigoEquipo,
                    item.Modelo,
                    item.Marca,
                    item.SerialNumber,
                    "",//numero de documento
                    item.IdEquipo,
                    item.eCompra.IdCompra,
                    "",//id de la venta
                    item.eProducto.IdProducto,
                    fec
                });
            }
        }

        private void dgvdata_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iCol = e.ColumnIndex;
            
            if  (iRow >= 0 && iCol >= 0)
            {
                _Equipo = new Equipo()
                {
                    CodigoEquipo = dgvdata.Rows[iRow].Cells["Codigo"].Value.ToString(),
                    Modelo = dgvdata.Rows[iRow].Cells["Modelo"].Value.ToString(),
                    Marca = dgvdata.Rows[iRow].Cells["Marca"].Value.ToString(),
                    SerialNumber = dgvdata.Rows[iRow].Cells["Serie"].Value.ToString(),
                    IdEquipo = Convert.ToInt32(dgvdata.Rows[iRow].Cells["IdEquipo"].Value)
                };
                /*Acá va el número de documento*/
                _Compra = new Compra()
                {
                    IdCompra = Convert.ToInt32(dgvdata.Rows[iRow].Cells["IdCompra"].Value),
                    /*NumeroDocumento = dgvdata.Rows[iRow].Cells["NumeroDocumento"].Value.ToString(),*/
                    FechaRegistro = dgvdata.Rows[iRow].Cells["Fecha"].Value.ToString(),
                };
                /*_Venta = new Venta()
                {
                    IdVenta = Convert.ToInt32(dgvdata.Rows[iRow].Cells["IdVenta"].Value)
                };*/
                _Producto = new Producto()
                {
                    IdProducto = Convert.ToInt32(dgvdata.Rows[iRow].Cells["IdProducto"].Value)
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
