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
        public Equipo _Equipo { get; set; }
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
                    cbobusqueda.Items.Add(new OpcionCombo() 
                    {
                        Valor = columna.Name, Texto = columna.HeaderText
                    });
                }
            }

            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            dgvdata.Rows.Clear();
            List<Equipo> listaEquipo = new CN_Equipo().ListarSinST();

            foreach (Equipo item in listaEquipo)
            {
                string fec = new CN_Compra().ObtenerFecha(item.eCompra.IdCompra);
                dgvdata.Rows.Add(new object[]
                {
                    item.IdEquipo,
                    item.CodigoEquipo,
                    item.Modelo,
                    item.Marca,
                    item.SerialNumber,
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
                    IdEquipo = Convert.ToInt32(dgvdata.Rows[iRow].Cells["IdEquipo"].Value),
                    CodigoEquipo = dgvdata.Rows[iRow].Cells["Codigo"].Value.ToString(),
                    Modelo = dgvdata.Rows[iRow].Cells["Modelo"].Value.ToString(),
                    Marca = dgvdata.Rows[iRow].Cells["Marca"].Value.ToString(),
                    SerialNumber = dgvdata.Rows[iRow].Cells["Serie"].Value.ToString(),
                    FechaRegistro = dgvdata.Rows[iRow].Cells["Fecha"].Value.ToString()
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();

            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
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
    }
}
