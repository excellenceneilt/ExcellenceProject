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
    public partial class mdClienteST : Form
    {
        public Cliente _Cliente { get; set; }
        public mdClienteST()
        {
            InitializeComponent();
        }

        private void mdClienteST_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true)
                {
                    cbobusqueda.Items.Add(new OpcionCombo() 
                    { 
                        Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            List<Cliente> lista = new CN_Cliente().Listar();

            foreach (Cliente item in lista)
            {
                if (item.Estado)
                    dgvdata.Rows.Add(new object[] 
                    {
                        item.NombreCompleto,
                        item.RUC,
                        item.NombreContacto,
                        item.Correo1,
                        item.Documento,
                        item.Telefono1
                    });
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

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;
            if (iRow >= 0 && iColum >= 0)
            {
                _Cliente = new Cliente()
                {
                    NombreCompleto = dgvdata.Rows[iRow].Cells["NombreCompleto"].Value.ToString(),
                    RUC = dgvdata.Rows[iRow].Cells["Ruc"].Value.ToString(),
                    NombreContacto = dgvdata.Rows[iRow].Cells["Contacto"].Value.ToString(),
                    Correo1 = dgvdata.Rows[iRow].Cells["Correo"].Value.ToString(),
                    Documento = dgvdata.Rows[iRow].Cells["Documento"].Value.ToString(),
                    Telefono1 = dgvdata.Rows[iRow].Cells["Telefono"].Value.ToString()
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
    }
}
