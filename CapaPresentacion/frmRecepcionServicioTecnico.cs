using CapaPresentacion.Modales;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
                    txtcliente.Text = modal._Cliente.RazonSocial;
                    txtruc.Text = modal._Cliente.RUC;
                    txtcontacto.Text = modal._Cliente.NombreContacto;
                    txtcorreo.Text = modal._Cliente.Correo1;
                    /*Estos datos se tienen que llenar con los datos de la persona encargada de dejar el equipo
                     * txtdni.Text = modal._Cliente.Documento;
                    txttelefono.Text = modal._Cliente.Telefono1;
                    txtdeja.Text = modal._Cliente.NombreContacto;*/
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

                //Las siguientes dos líneas sirven para convertir un formato de fecha en otro formato de fecha, ambos en string, bota error
                /*DateTime fecha = DateTime.ParseExact(modal._Compra.FechaRegistro, "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                string fechaFormateada = fecha.ToString("dd/MM/yyyy");*/
                if (result == DialogResult.OK)
                {
                    //este codigo muestra la fecha, solo hasta el caracter numero 10, es el tamaño correcto para mostrar la fecha en el formato correcto
                    string fechaFormateada = modal._Equipo.FechaRegistro.Substring(0, Math.Min(modal._Equipo.FechaRegistro.Length, 10));
                    txtmarca.Text = modal._Equipo.Marca;
                    txtserie.Text = modal._Equipo.SerialNumber;
                    txtmodelo.Text = modal._Equipo.Modelo;
                    txtfechacompra.Text = fechaFormateada;
                }
            }
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
