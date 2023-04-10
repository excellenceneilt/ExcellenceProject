using CapaEntidad;
using CapaPresentacion.Modales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmEquipo : Form
    {
        public frmEquipo()
        {
            InitializeComponent();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProductoE())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtcategoria.Text = modal._Producto.oCategoria.Descripcion;
                    txtcodigo.Text = modal._Producto.Codigo;
                    txtmodelo.Select();
                }
                else
                {
                    txtcategoria.Select();
                }
            }
        }

        private void frmEquipo_Load(object sender, EventArgs e)
        {

        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtcategoria.Text = string.Empty;
            txtmodelo.Text = string.Empty;
            txtcodigo.Text = string.Empty;
            txtserial.Text = string.Empty;
            txtcategoria.Focus();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Equipo obj = new Equipo()
            {

            };
        }
    }
}
