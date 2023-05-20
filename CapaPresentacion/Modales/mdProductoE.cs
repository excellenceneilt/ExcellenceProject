using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using DocumentFormat.OpenXml.Drawing;
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
    public partial class mdProductoE : Form
    {
        public Producto _Producto { get; set; }
        public Compra _Compra { get; set; }
        public Detalle_Compra _Detalle_Compra { get; set; }
        public mdProductoE()
        {
            InitializeComponent();
        }

        private void mdProductoE_Load(object sender, EventArgs e)
        {
            //Para filtrar datos en la tabla
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true)
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }

            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            
        }
        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;
            int _idDetalleCompra;
            Compra _CN_Compra = new CN_Compra().ObtenerIdCompra(txtcodigocompra.Text);
            if (iRow >= 0 && iColum >= 0)
            {
                if (Convert.ToInt32(dgvdata.Rows[iRow].Cells["SinNroSerie"].Value) > 0)
                {
                    _Producto = new Producto()
                    {
                        Codigo = dgvdata.Rows[iRow].Cells["Codigo"].Value.ToString(),
                        Nombre = dgvdata.Rows[iRow].Cells["NombreProducto"].Value.ToString(),
                        oMarca = new Marca() { Descripcion = dgvdata.Rows[iRow].Cells["Marca"].Value.ToString() },
                        IdProducto = int.Parse(dgvdata.Rows[iRow].Cells["IdProducto"].Value.ToString())
                    };
                    _Compra = new Compra()
                    {
                        IdCompra = _CN_Compra.IdCompra,
                        NumeroDocumento = txtcodigocompra.Text
                    };
                    _idDetalleCompra = new CN_Detalle_Compra().ObtenerIdDC(_Compra.IdCompra, _Producto.IdProducto);
                    _Detalle_Compra = new Detalle_Compra()
                    {
                        IdDetalleCompra = _idDetalleCompra,
                    };
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se puede agregar número de serie a este producto" +
                        " debido a que no hay stock disponible sin número de serie o ya todos tienen número de serie",
                        "Mensaje informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }
        private void buscar()
        {
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }

        private void txtbusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                buscar();
            }
        }

        private void btnbuscarcompra_Click(object sender, EventArgs e)
        {
            dgvdata.Rows.Clear();
            //Mostrar todos los productos
            //Se crea la lista
            List<Producto> listaProducto = new CN_Producto().ListarConId(txtcodigocompra.Text.ToString());

            //Se recorre la lista
            foreach (Producto item in listaProducto)
            {//Colocar las columnas del datagrid
                int cantidad = new CN_Equipo().ProductoConSerial(item.IdProducto, item.pDetalleCompra.IdDetalleCompra, item.pCompra.NumeroDocumento);
                int equiposSinSerial = item.Stock - cantidad;
                dgvdata.Rows.Add(new object[]
                {
                    item.Codigo,
                    item.Nombre,
                    item.oMarca.Descripcion,
                    item.Stock,
                    equiposSinSerial,
                    item.IdProducto,
                });
            }
            if (listaProducto.Count < 1) 
            {
                MessageBox.Show("Este número de boleta no tiene productos para mostrar",
                    "Mensaje informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtcodigocompra.Text = string.Empty;
                txtcodigocompra.Focus();
            }
        }

        private void btnlimpiarbuscadorcompra_Click(object sender, EventArgs e)
        {
            txtcodigocompra.Text = string.Empty;
            txtbusqueda.Text = string.Empty;
            dgvdata.Rows.Clear();
            txtcodigocompra.Focus();
        }

        private void txtcodigocompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnbuscarcompra_Click(sender, e);
            }
        }
    }
}
