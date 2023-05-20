using CapaPresentacion.Modales;
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
    public partial class frmRecepcionServicioTecnico : Form
    {
        public frmRecepcionServicioTecnico()
        {
            InitializeComponent();
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            #region COMBOBOX MONEDA

            //Moneda
            cbomoneda.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Soles" });
            cbomoneda.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Dólares" });
            cbomoneda.DisplayMember = "Texto";
            cbomoneda.ValueMember = "Valor";
            cbomoneda.SelectedIndex = 0;

            #endregion

            #region COMBOBOX ENCIENDE

            //Enciende
            cboenciende.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Si" });
            cboenciende.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No" });
            cboenciende.DisplayMember = "Texto";
            cboenciende.ValueMember = "Valor";
            cboenciende.SelectedIndex = 0;

            #endregion
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
                    
                }
                else
                {
                    txtdni.Select();
                }
            }
        }

        private void btnbuscarequipo_Click(object sender, EventArgs e)
        {
            using (var modal = new mdEquipoST())
            {
                var result = modal.ShowDialog();
            }
        }

        private void frmRecepcionServicioTecnico_Load(object sender, EventArgs e)
        {
            
        }

        private void cckseleccionarequipo_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
            {
                btnbuscarequipo.Enabled = true;
                txtmarca.Enabled = false;
                txtmodelo.Enabled = false;
                txtserie.Enabled = false;
                txtfechacompra.Enabled = false;
            }
            else
            {
                btnbuscarequipo.Enabled = false;
                txtmarca.Enabled = true;
                txtmodelo.Enabled = true;
                txtserie.Enabled = true;
                txtfechacompra.Enabled = true;
            }
        }

        private void cckgarantia_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
            {
                cckcostord.Checked = false;
                cckcostord.Enabled = false;
                cbomoneda.Enabled = false;
                txtcosto.Text = string.Empty;
                txtcosto.Enabled = false;
            }
            else
            {
                cckcostord.Enabled = true;
                cbomoneda.Enabled = false;
                txtcosto.Enabled = false;
            }
        }
        private void cckcostord_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
            {
                cbomoneda.Enabled = true;
                txtcosto.Enabled = true;
            }
            else
            {
                cbomoneda.Enabled = false;
                txtcosto.Enabled = false;
            }
        }

    }
}
