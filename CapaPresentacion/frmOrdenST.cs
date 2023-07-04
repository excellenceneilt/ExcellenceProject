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
            txtIdCliente.Text = IRE.iCliente.IdCliente.ToString();
            txtNumero.Text = IRE.IdIre.ToString();
            txtFechaDiagnostico.Text = IRE.FechaIRE.ToString();
            txtNumeroDocumento.Text = IRE.iCliente.Documento.ToString();
            txtCliente.Text = IRE.iCliente.NombreCompleto.ToString();
            txtQuienDeja.Text = IRE.Deja.ToString();
            txtDocumento.Text = IRE.DniDeja.ToString();
            txtContacto.Text = IRE.iCliente.NombreContacto.ToString();
            txtCorreo.Text = IRE.iCliente.Correo1.ToString();
            txtTelefono.Text = IRE.TelefonoDeja.ToString();

            txtIdEquipo.Text = IRE.iEquipo.IdEquipo.ToString();
            txtMarca.Text = IRE.iEquipo.Marca.ToString();
            txtSerie.Text = IRE.iEquipo.SerialNumber.ToString();
            txtModelo.Text = IRE.iEquipo.Modelo.ToString();
            txtFechaCompra.Text = IRE.Fecha.ToString();

            txtAccesorios.Text = IRE.Accesorios.ToString();
        }
    }
}
