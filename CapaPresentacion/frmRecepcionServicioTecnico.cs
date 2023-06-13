using CapaEntidad;
using CapaNegocio;
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
            cbomoneda.Items.Add(new OpcionCombo() { Valor = 2, Texto = "Dólares" });
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

        private void frmRecepcionServicioTecnico_Load(object sender, EventArgs e)
        {
            List<IngresoRecepcionEquipos> listaIre = new CN_IngresoRecepcionEquipos().Listar();
            foreach (IngresoRecepcionEquipos item in listaIre)
            {
                //se obtiene la fecha que sale de la BD y se acorta para que en lineas más abajo cambie el formato de MM/dd/yyyy a dd/MM/yyyy
                string FechaIREOriginal = item.FechaIRE;
                FechaIREOriginal = FechaIREOriginal.Substring(0, 10);
                // Fecha recibida de la base de datos en formato "MM/dd/yyyy hh:mm:ss a. m."
                string fechaBaseDatos = FechaIREOriginal;

                // Analizar la fecha en el formato de entrada
                DateTime fecha = DateTime.ParseExact(fechaBaseDatos, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                // Formatear la fecha en el formato deseado "dd/MM/yyyy"
                string fechaFormateada = fecha.ToString("dd/MM/yyyy");

                dgvdata.Rows.Add(new object[]
                {
                    "",
                    item.IdIre,
                    item.CodOST,
                    item.Deja,
                    item.DniDeja,
                    item.TelefonoDeja,
                    item.iCliente.IdCliente,
                    item.iCliente.NombreContacto,
                    item.iCliente.RUC,
                    item.iCliente.Correo1,
                    item.iEquipo.IdEquipo,
                    item.iEquipo.Marca,
                    item.iEquipo.Modelo,
                    item.iEquipo.SerialNumber,
                    item.iEstadoEquipo.IdEstadoEquipo == 3 ? "Servicio Técnico" : "No ST",
                    item.Fecha,
                    item.Garantia == true ? "Tiene Garantía" : "No tiene garantía",
                    item.iMoneda.IdMoneda == 1 ? "Soles" : "Dólares",
                    item.Costo,
                    item.Enciende == true ? "Enciendo" : "No Enciende",
                    item.Situacion,
                    item.Accesorios,
                    item.Observaciones,
                    fechaFormateada//item.FechaIRE
                });
            }
        }

        #region BOTONES BUSCAR (CLIENTE - EQUIPO)

        private void btnbuscarcliente_Click(object sender, EventArgs e)
        {
            using (var modal = new mdClienteST())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtidcliente.Text = modal._Cliente.IdCliente.ToString();
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
                    txtdeja.Select();
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
                    txtidequipo.Text = modal._Equipo.IdEquipo.ToString();
                    txtmarca.Text = modal._Equipo.Marca;
                    txtserie.Text = modal._Equipo.SerialNumber;
                    txtmodelo.Text = modal._Equipo.Modelo;
                    txtfechacompra.Text = fechaFormateada;
                }
            }
        }

        #endregion

        #region CCK
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
                txtcosto.Text = "0.00";
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
                txtcosto.Text = "0.00";
            }
        }
        #endregion

        #region BOTONES GUARDAR, LIMPIAR

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            IngresoRecepcionEquipos objIre = new IngresoRecepcionEquipos()
            {
                //Asociando los atributos de la entidad (left)
                //con los datos obtenidos en cada entrada como: textbox, combobox, etc (right)
                IdIre = Convert.ToInt32(txtid.Text),
                CodOST = txtost.Text,
                Deja = txtdeja.Text,
                DniDeja = txtdni.Text,
                TelefonoDeja = txttelefono.Text,
                iCliente = new Cliente()
                {
                    IdCliente = Convert.ToInt32(txtidcliente.Text),
                    RUC = txtruc.Text,
                    NombreContacto = txtcontacto.Text,
                    Correo1 = txtcorreo.Text
                },
                iEquipo = new Equipo()
                {
                    IdEquipo = Convert.ToInt32(txtidequipo.Text),
                    Marca = txtmarca.Text,
                    Modelo = txtmodelo.Text,
                    SerialNumber = txtserie.Text
                },
                iEstadoEquipo = new EstadoEquipo()
                {
                    IdEstadoEquipo = 3
                },
                /*iCompra = new Compra()
                {
                    FechaRegistro = txtfechacompra.Text
                },*/
                Fecha = txtfechacompra.Text,
                Garantia = cckgarantia.Checked,
                iMoneda = new Moneda()
                {
                    IdMoneda = Convert.ToInt32(((OpcionCombo)cbomoneda.SelectedItem).Valor)
                },
                Costo = Convert.ToDecimal(txtcosto.Text),
                Enciende = Convert.ToInt32(((OpcionCombo)cboenciende.SelectedItem).Valor) == 1 ? true : false,
                Situacion = txtsituacion.Text,
                Accesorios = txtaccesorio.Text,
                Observaciones = txtobservaciones.Text,
                FechaIRE = txtfecha.Text
            };

            if (objIre.IdIre == 0)
            {
                int idIreGenerado = new CN_IngresoRecepcionEquipos().Registrar(objIre, out mensaje);
                string codOst = new CN_IngresoRecepcionEquipos().GetOst(idIreGenerado);

                if(idIreGenerado != 0)
                {
                    dgvdata.Rows.Add(new object[]
                    {
                        "",
                        idIreGenerado,
                        codOst,
                        txtdeja.Text,
                        txtdni.Text,
                        txttelefono.Text,
                        txtidcliente.Text,
                        txtcontacto.Text,
                        txtruc.Text,
                        txtcorreo.Text,
                        txtidequipo.Text,
                        txtmarca.Text,
                        txtmodelo.Text,
                        txtserie.Text,
                        3,
                        txtfechacompra.Text,
                        cckgarantia.Checked == true ? "Tiene Garantía" : "No tiene garantía",
                        ((OpcionCombo) cbomoneda.SelectedItem).Valor.ToString(),
                        txtcosto.Text,
                        ((OpcionCombo) cboenciende.SelectedItem).Valor.ToString(),
                        txtsituacion.Text,
                        txtaccesorio.Text,
                        txtobservaciones.Text,
                        txtfecha.Text
                    });
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool resultado = new CN_IngresoRecepcionEquipos().Editar(objIre, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }
        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        #endregion

        public void Limpiar()
        {
            txtnumero.Text = string.Empty;
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtidcliente.Text = string.Empty;
            txtcliente.Text = string.Empty;
            txtcontacto.Text = string.Empty;
            txtdeja.Text = string.Empty;
            txtost.Text = string.Empty;
            txtidcliente.Text = "-1";
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtidequipo.Text = "-1";
            txtruc.Text = string.Empty;
            txtcorreo.Text = string.Empty;
            txtdni.Text = string.Empty;
            txttelefono.Text = string.Empty;
            cckseleccionarequipo.Checked = true;
            txtmarca.Text = string.Empty;
            txtserie.Text = string.Empty;
            txtmodelo.Text = string.Empty;
            txtfechacompra.Text = string.Empty;
            cckgarantia.Checked = true;
            txtcosto.Text = "0.00";
            txtsituacion.Text = string.Empty;
            txtaccesorio.Text = string.Empty;
            txtobservaciones.Text = string.Empty;
        }
        #region Eventos KeyPress para DNI, TELEFONO Y COSTO
        private void txtdni_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o una tecla especial como retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla presionada
            }
        }

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o una tecla especial como retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla presionada
            }
        }

        private void txtcosto_KeyPress(object sender, KeyPressEventArgs e)
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
        #region TextChanged y Key Press 1000 caracteres para situación, accesorio y observaciones
        private const int MaxCharacters = 1000;
        private void txtsituacion_TextChanged(object sender, EventArgs e)
        {
            int remainingCharacters = MaxCharacters - txtsituacion.Text.Length;

            if (remainingCharacters >= 0)
            {
                lblsituacion.Text = $"Situación: ({remainingCharacters} caracteres)";
            }
            else
            {
                // Si se supera el límite, truncar el texto
                txtsituacion.Text = txtsituacion.Text.Substring(0, MaxCharacters);
            }
        }
        private void txtsituacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el límite de caracteres se alcanza o supera
            if (txtsituacion.Text.Length >= MaxCharacters && e.KeyChar != '\b')
            {
                e.Handled = true; // Ignorar la tecla presionada
            }
        }

        private void txtaccesorio_TextChanged(object sender, EventArgs e)
        {
            int remainingCharacters = MaxCharacters - txtaccesorio.Text.Length;

            if (remainingCharacters >= 0)
            {
                lblaccesorios.Text = $"Accesorios: ({remainingCharacters} caracteres)";
            }
            else
            {
                // Si se supera el límite, truncar el texto
                txtaccesorio.Text = txtaccesorio.Text.Substring(0, MaxCharacters);
            }
        }


        private void txtaccesorio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el límite de caracteres se alcanza o supera
            if (txtaccesorio.Text.Length >= MaxCharacters && e.KeyChar != '\b')
            {
                e.Handled = true; // Ignorar la tecla presionada
            }
        }
        private void txtobservaciones_TextChanged(object sender, EventArgs e)
        {
            int remainingCharacters = MaxCharacters - txtobservaciones.Text.Length;

            if (remainingCharacters >= 0)
            {
                lblobservaciones.Text = $"Observaciones: ({remainingCharacters} caracteres)";
            }
            else
            {
                // Si se supera el límite, truncar el texto
                txtobservaciones.Text = txtobservaciones.Text.Substring(0, MaxCharacters);
            }
        }

        private void txtobservaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el límite de caracteres se alcanza o supera
            if (txtobservaciones.Text.Length >= MaxCharacters && e.KeyChar != '\b')
            {
                e.Handled = true; // Ignorar la tecla presionada
            }
        }


        #endregion

    }
}
