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
    public partial class frmRecepcionServicioTecnico : Form
    {
        public frmRecepcionServicioTecnico()
        {
            InitializeComponent();
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnbuscarcliente_Click(object sender, EventArgs e)
        {
            using (var modal = new mdClienteST())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtcliente.Text = modal._Cliente.NombreCompleto;
                    txtruc.Text = modal._Cliente.RUC;
                    txtcontacto.Text = modal._Cliente.NombreContacto;
                    txtcorreo.Text = modal._Cliente.Correo1;
                    txtdni.Text = modal._Cliente.Documento;
                    txttelefono.Text = modal._Cliente.Telefono1;
                    txtcodproducto.Select();
                }
                else
                {
                    txtdni.Select();
                }
            }
        }
    }
}
