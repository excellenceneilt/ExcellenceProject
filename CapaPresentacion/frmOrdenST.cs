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
        public const string OPC_SOLES = "Soles";
        public const string OPC_DOLARES = "Dólares";
        public const string OPC_ESTADO_OST_PENDIENTE = "Pendiente";
        public const string OPC_ESTADO_OST_APROBADO = "Aprobado";
        public const string OPC_ESTADO_OST_FINANCIADO = "Financiado";
        public frmOrdenST()
        {
            InitializeComponent();
            ObtenerNumeroRST();
            #region COMBOBOX MONEDA - ESTADO OST

            //Moneda
            cboMoneda.Items.Add(new OpcionCombo() { Valor = 1, Texto = OPC_SOLES });
            cboMoneda.Items.Add(new OpcionCombo() { Valor = 2, Texto = OPC_DOLARES });
            cboMoneda.DisplayMember = "Texto";
            cboMoneda.ValueMember = "Valor";
            cboMoneda.SelectedIndex = 0;

            //Estado OST
            cboEstadoOst.Items.Add(new OpcionCombo() { Valor = 1, Texto = OPC_ESTADO_OST_PENDIENTE });
            cboEstadoOst.Items.Add(new OpcionCombo() { Valor = 2, Texto = OPC_ESTADO_OST_APROBADO });
            cboEstadoOst.Items.Add(new OpcionCombo() { Valor = 3, Texto = OPC_ESTADO_OST_FINANCIADO });
            cboEstadoOst.DisplayMember = "Texto";
            cboEstadoOst.ValueMember = "Valor";
            cboEstadoOst.SelectedIndex = 0;

            #endregion
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
        #region DIAGNOSTICO, INFORME Y ACCESORIOS - CAMBIO DE CARACTERES
        private const int MAX_CARACTERES_ACCESORIOS = 1000;
        private const int MAX_CARACTERES_DIAGNOSTICO = 2000;
        private const int MAX_CARACTERES_INFORME = 3000;
        private void txtDiagnostico_TextChanged(object sender, EventArgs e)
        {
            int remainingCharacters = MAX_CARACTERES_DIAGNOSTICO - txtDiagnostico.Text.Length;

            if (remainingCharacters >= 0)
            {
                lbldiagnostico.Text = $"Diagnóstico: ({remainingCharacters} caracteres)";
            }
            else
            {
                // Si se supera el límite, truncar el texto
                txtDiagnostico.Text = txtDiagnostico.Text.Substring(0, MAX_CARACTERES_DIAGNOSTICO);
            }
        }

        private void txtDiagnostico_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el límite de caracteres se alcanza o supera
            if (txtDiagnostico.Text.Length >= MAX_CARACTERES_DIAGNOSTICO && e.KeyChar != '\b')
            {
                e.Handled = true; // Ignorar la tecla presionada
            }
        }

        private void txtInforme_TextChanged(object sender, EventArgs e)
        {
            int remainingCharacters = MAX_CARACTERES_INFORME - txtInforme.Text.Length;

            if (remainingCharacters >= 0)
            {
                lblinforme.Text = $"Informe técnico de la entrega del equipo: ({remainingCharacters} caracteres)";
            }
            else
            {
                // Si se supera el límite, truncar el texto
                txtInforme.Text = txtInforme.Text.Substring(0, MAX_CARACTERES_INFORME);
            }
        }

        private void txtInforme_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el límite de caracteres se alcanza o supera
            if (txtInforme.Text.Length >= MAX_CARACTERES_INFORME && e.KeyChar != '\b')
            {
                e.Handled = true; // Ignorar la tecla presionada
            }
        }

        private void txtAccesorios_TextChanged(object sender, EventArgs e)
        {
            int remainingCharacters = MAX_CARACTERES_ACCESORIOS - txtAccesorios.Text.Length;

            if (remainingCharacters >= 0)
            {
                lblaccesorios.Text = $"Accesorios: ({remainingCharacters} caracteres)";
            }
            else
            {
                // Si se supera el límite, truncar el texto
                txtAccesorios.Text = txtAccesorios.Text.Substring(0, MAX_CARACTERES_ACCESORIOS);
            }
        }

        private void txtAccesorios_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el límite de caracteres se alcanza o supera
            if (txtAccesorios.Text.Length >= MAX_CARACTERES_ACCESORIOS && e.KeyChar != '\b')
            {
                e.Handled = true; // Ignorar la tecla presionada
            }
        }
        #endregion
        #region VALIDACIONES DE COSTO Y TIEMPO - NUMERO Y DECIMALES
        private void txtTiempo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o una tecla especial como retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla presionada
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o un punto
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Ignorar la tecla
            }

            // Permitir el uso del punto decimal solo si no hay otro punto ya presente
            if (e.KeyChar == '.' && ((TextBox)sender).Text.IndexOf('.') > -1)
            {
                e.Handled = true; // Ignorar la tecla
            }
        }
        #endregion
    }
}
