using CapaDatos;
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

namespace CapaPresentacion
{
    public partial class frmOrdenST : Form
    {
        public frmOrdenST()
        {
            InitializeComponent();
            ObtenerNumeroRST();
        }

        private void frmOrdenST_Load(object sender, EventArgs e)
        {
        }

        public void ObtenerNumeroRST()
        {
            List<IngresoRecepcionEquipos> listaRST = new CN_IngresoRecepcionEquipos().ListarSoloRST();

            foreach (IngresoRecepcionEquipos item in listaRST)
            {
                cboNrst.Items.Add(new OpcionCombo() { Valor = item.IdIre, Texto = item.CodOST });
            }
            cboNrst.DisplayMember = "Texto";
            cboNrst.ValueMember = "Valor";
            cboNrst.SelectedIndex = 0;
        }

        private void cboNrst_SelectedIndexChanged(object sender, EventArgs e)
        {
            IngresoRecepcionEquipos IRE = new CN_IngresoRecepcionEquipos().ListarUnIngresoRecepcionEquipo(((OpcionCombo)cboNrst.SelectedItem).Texto.ToString());
            txtNumero.Text = IRE.IdIre.ToString();
            txtRuc.Text = IRE.iCliente.Documento.ToString();
        }
    }
}
