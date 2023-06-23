#region USING LIBRARIES
using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace CapaPresentacion
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            
            ListarDepartamento();

            #region COMBOBOX [ESTADO-TIPOS DE DOCUMENTOS]

            //Estados 
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

            //Listar TipoDocumento en Facturación
            List<Tipo_Documento> listaTipoDocumento = new CN_TipoDocumento().Listar();
            foreach (Tipo_Documento item in listaTipoDocumento)
            {
                cbotipodocumento.Items.Add(new OpcionCombo() { Valor = item.IdTipoDocumento, Texto = item.Descripcion });
            }
            cbotipodocumento.DisplayMember = "Texto";
            cbotipodocumento.ValueMember = "Valor";
            cbotipodocumento.SelectedIndex = 2;

            //Listar TipoDocumento en Contacto
            List<Tipo_Documento> listaTipoDocumentoContacto = new CN_TipoDocumento().Listar();
            foreach (Tipo_Documento item in listaTipoDocumentoContacto)
            {
                cbotipodocumentocontacto.Items.Add(new OpcionCombo() { Valor = item.IdTipoDocumento, Texto = item.Descripcion });
            }
            cbotipodocumentocontacto.DisplayMember = "Texto";
            cbotipodocumentocontacto.ValueMember = "Valor";
            cbotipodocumentocontacto.SelectedIndex = 0;
            #endregion

            #region COMBOBOX PARA BUSCAR DATOS
            //Para filtrar registros en el datagrid
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.Items.Add(new OpcionCombo() { Valor = "TODOS", Texto = "TODOS" });
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 4;
            #endregion

            #region LLENAR DATAGRID
            
            List<Cliente> listaCliente = new CN_Cliente().Listar();
            foreach (Cliente item in listaCliente)
            {
                dgvdata.Rows.Add(new object[] {

                    "",

                    item.IdCliente,
                    item.CodigoCliente,
                    item.oTipo_Documento.IdTipoDocumento,
                    item.oTipo_Documento.Descripcion,
                    item.Documento,
                    item.NombreCompleto,
                    item.RazonSocial,
                    item.Direccion,
                    item.Departamento,
                    item.Provincia,
                    item.Distrito,

                    item.NombreComercial,
                    item.DireccionComercial,
                    item.Correo1,
                    item.Correo2,
                    item.Telefono1,
                    item.Telefono2,
                    item.DepartamentoComercial,
                    item.ProvinciaComercial,
                    item.DistritoComercial,

                    item.NombreContacto,
                    item.DireccionContacto,
                    item.DepartamentoContacto,
                    item.ProvinciaContacto,
                    item.DistritoContacto,
                    item.ocTipo_Documento.IdTipoDocumento,
                    item.ocTipo_Documento.Descripcion,
                    item.DocumentoContacto,
                    item.CMP,
                    item.TelefonofijoContacto,
                    item.CelularContacto,
                    item.CorreoContacto,
                    item.Estado==true ?1 : 0,
                    item.Estado==true ?"Activo":"Inactivo",
                });
            }
            #endregion
        }
        #region LISTAR DEPARTAMENTOS PROVINCIAS Y DISTRITOS
        public void ListarDepartamento()
        {
            //Facturación
            cbodepartamento.DataSource = new OperacionesDPD().ObtenerDepartamento();
            cbodepartamento.ValueMember = "IdDepartamento";
            cbodepartamento.DisplayMember = "Descripcion";
            //Comercial
            cbodepartamentocomercial.DataSource = new OperacionesDPD().ObtenerDepartamento();
            cbodepartamentocomercial.ValueMember = "IdDepartamento";
            cbodepartamentocomercial.DisplayMember = "Descripcion";
            //Contacto
            cbodepartamentocontacto.DataSource = new OperacionesDPD().ObtenerDepartamento();
            cbodepartamentocontacto.ValueMember = "IdDepartamento";
            cbodepartamentocontacto.DisplayMember = "Descripcion";

            defaultindexcombo();
        }


        //Datos de facturación
        private void cbodepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
                Departamento odepartamentoSeleccionado = (Departamento)cbodepartamento.SelectedItem;
                cboprovincia.DataSource = new OperacionesDPD().ObtenerProvincia(odepartamentoSeleccionado.IdDepartamento);
                cboprovincia.ValueMember = "IdProvincia";
                cboprovincia.DisplayMember = "Descripcion";
        }
        private void cboprovincia_SelectedIndexChanged(object sender, EventArgs e)
        {
                Provincia oprovinciaSeleccionado = (Provincia)cboprovincia.SelectedItem;
                cbodistrito.DataSource = new OperacionesDPD().ObtenerDistrito(oprovinciaSeleccionado.IdProvincia);
                cbodistrito.ValueMember = "IdDistrito";
                cbodistrito.DisplayMember = "Descripcion";
        }


        //Datos comerciales
        private void cbodepartamentocomercial_SelectedIndexChanged(object sender, EventArgs e)
        {
            Departamento odepartamentoSeleccionado = (Departamento)cbodepartamentocomercial.SelectedItem;
            cboprovinciacomercial.DataSource = new OperacionesDPD().ObtenerProvincia(odepartamentoSeleccionado.IdDepartamento);
            cboprovinciacomercial.ValueMember = "IdProvincia";
            cboprovinciacomercial.DisplayMember = "Descripcion";
        }
        private void cboprovinciacomercial_SelectedIndexChanged(object sender, EventArgs e)
        {
            Provincia oprovinciaSeleccionado = (Provincia)cboprovinciacomercial.SelectedItem;
            cbodistritocomercial.DataSource = new OperacionesDPD().ObtenerDistrito(oprovinciaSeleccionado.IdProvincia);
            cbodistritocomercial.ValueMember = "IdDistrito";
            cbodistritocomercial.DisplayMember = "Descripcion";
        }


        //Datos de contacto
        private void cbodepartamentocontacto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Departamento odepartamentoSeleccionado = (Departamento)cbodepartamentocontacto.SelectedItem;
            cboprovinciacontacto.DataSource = new OperacionesDPD().ObtenerProvincia(odepartamentoSeleccionado.IdDepartamento);
            cboprovinciacontacto.ValueMember = "IdProvincia";
            cboprovinciacontacto.DisplayMember = "Descripcion";
        }
        private void cboprovinciacontacto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Provincia oprovinciaSeleccionado = (Provincia)cboprovinciacontacto.SelectedItem;
            cbodistritocontacto.DataSource = new OperacionesDPD().ObtenerDistrito(oprovinciaSeleccionado.IdProvincia);
            cbodistritocontacto.ValueMember = "IdDistrito";
            cbodistritocontacto.DisplayMember = "Descripcion";
        }

        #endregion

        #region CONTROLES  (Botones y checkbox)
        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar el cliente?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Cliente objCliente = new Cliente()
                    {
                        //Llenando atributos de la clase Cliente
                        IdCliente = Convert.ToInt32(txtid.Text),


                    };

                    bool respuesta = new CN_Cliente().Eliminar(objCliente, out mensaje);
                    if (respuesta)
                    {
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
        }
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }
        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Cliente objCliente = new Cliente()
            {
                IdCliente = Convert.ToInt32(txtid.Text),
                CodigoCliente= txtcodigocliente.Text,
                oTipo_Documento = new Tipo_Documento() { IdTipoDocumento = Convert.ToInt32(((OpcionCombo)cbotipodocumento.SelectedItem).Valor) },
                Documento = txtdocumento.Text,
                NombreCompleto = txtnombre.Text,
                RazonSocial = txtrazonsocial.Text,
                Direccion = txtdireccion.Text,
                Departamento = this.cbodepartamento.GetItemText(this.cbodepartamento.SelectedItem),
                Provincia = this.cboprovincia.GetItemText(this.cboprovincia.SelectedItem),
                Distrito = this.cbodistrito.GetItemText(this.cbodistrito.SelectedItem),

                NombreComercial = txtnombrecomercial.Text,
                DireccionComercial = txtdireccioncomercial.Text,
                Correo1 = txtcorreo1.Text,
                Correo2 = txtcorreo2.Text,
                Telefono1 = txttelefono1.Text,
                Telefono2 = txttelefono2.Text,
                DepartamentoComercial = this.cbodepartamentocomercial.GetItemText(this.cbodepartamentocomercial.SelectedItem),
                ProvinciaComercial = this.cboprovinciacomercial.GetItemText(this.cboprovinciacomercial.SelectedItem),
                DistritoComercial = this.cbodistritocomercial.GetItemText(this.cbodistritocomercial.SelectedItem),

                NombreContacto = txtnombrecontacto.Text,
                DireccionContacto = txtdireccioncontacto.Text,
                DepartamentoContacto = this.cbodepartamentocontacto.GetItemText(this.cbodepartamentocontacto.SelectedItem),
                ProvinciaContacto = this.cboprovinciacontacto.GetItemText(this.cboprovinciacontacto.SelectedItem),
                DistritoContacto = this.cbodistritocontacto.GetItemText(this.cbodistritocontacto.SelectedItem),
                ocTipo_Documento = new Tipo_Documento() { IdTipoDocumento = Convert.ToInt32(((OpcionCombo)cbotipodocumentocontacto.SelectedItem).Valor) },
                DocumentoContacto = txtdocumentocontacto.Text,
                CMP = txtcmp.Text,
                TelefonofijoContacto = txttlffijo.Text,
                CelularContacto = txtcelularcontacto.Text,
                CorreoContacto = txtcorreocontacto.Text,

                //El item seleccionado se convierte a la clase opcioncombo, y se accede a su propiedad valor, si es igual a 1 será true caso contrario false
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            };


            if (objCliente.IdCliente == 0)
            {
                //Se usa el método registrar desde la capa negocio
                int idClientegenerado = new CN_Cliente().Registrar(objCliente, out mensaje);

                //El registro se hará siempre y cuando idClientegenerado sea diferente a cero, si es igual a cero indica que no se registró
                if (idClientegenerado != 0)
                {
                    //En el mismo orden que la tabla por favor es acá
                    //No sé qué es lo que hace ._.

                    dgvdata.Rows.Add(new object[] {

                        "",

                        idClientegenerado,
                        txtcodigocliente.Text,
                        ((OpcionCombo) cbotipodocumento.SelectedItem).Valor.ToString(),
                        ((OpcionCombo) cbotipodocumento.SelectedItem).Texto.ToString(),
                        txtdocumento.Text,
                        txtnombre.Text,
                        txtrazonsocial.Text,
                        txtdireccion.Text,
                        cbodepartamento.Text,
                        cboprovincia.Text,
                        cbodistrito.Text,

                        txtnombrecomercial.Text,
                        txtdireccioncomercial.Text,
                        txtcorreo1.Text,
                        txtcorreo2.Text,
                        txttelefono1.Text,
                        txttelefono2.Text,
                        cbodepartamentocomercial.Text,
                        cboprovinciacomercial.Text,
                        cbodistritocomercial.Text,

                        txtnombrecontacto.Text,
                        txtdireccioncontacto.Text,
                        cbodepartamentocontacto.Text,
                        cboprovinciacontacto.Text,
                        cbodistritocontacto.Text,
                        ((OpcionCombo) cbotipodocumentocontacto.SelectedItem).Valor.ToString(),
                        ((OpcionCombo) cbotipodocumentocontacto.SelectedItem).Valor.ToString(),
                        txtdocumentocontacto.Text,
                        txtcmp.Text,
                        txttlffijo.Text,
                        txtcelularcontacto.Text,
                        txtcorreocontacto.Text,
                        ((OpcionCombo) cboestado.SelectedItem).Valor.ToString(),
                        ((OpcionCombo) cboestado.SelectedItem).Texto.ToString(),
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
                if (MessageBox.Show("¿Desea editar el cliente?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool resultado = new CN_Cliente().Editar(objCliente, out mensaje);
                    if (resultado)
                    {
                        DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                        row.Cells["Id"].Value = txtid.Text;
                        row.Cells["CodigoCliente"].Value = txtcodigocliente.Text;
                        row.Cells["IdTipoDocumento"].Value = ((OpcionCombo)cbotipodocumento.SelectedItem).Valor.ToString();
                        row.Cells["TipoDocumento"].Value = ((OpcionCombo)cbotipodocumento.SelectedItem).Texto.ToString();
                        row.Cells["Documento"].Value = txtdocumento.Text;
                        row.Cells["NombreCompleto"].Value = txtnombre.Text;
                        row.Cells["RazonSocial"].Value = txtrazonsocial.Text;
                        row.Cells["Direccion"].Value = txtdireccion.Text;
                        row.Cells["Departamento"].Value = this.cbodepartamento.GetItemText(this.cbodepartamento.SelectedItem);
                        row.Cells["Provincia"].Value = this.cboprovincia.GetItemText(this.cboprovincia.SelectedItem);
                        row.Cells["Distrito"].Value = this.cbodistrito.GetItemText(this.cbodistrito.SelectedItem);

                        row.Cells["NombreComercial"].Value = txtnombrecomercial.Text;
                        row.Cells["DireccionComercial"].Value = txtdireccioncomercial.Text;
                        row.Cells["Correo1"].Value = txtcorreo1.Text;
                        row.Cells["Correo2"].Value = txtcorreo2.Text;
                        row.Cells["Telefono1"].Value = txttelefono1.Text;
                        row.Cells["Telefono2"].Value = txttelefono2.Text;
                        row.Cells["DepartamentoComercial"].Value = this.cbodepartamentocomercial.GetItemText(this.cbodepartamentocomercial.SelectedItem);
                        row.Cells["ProvinciaComercial"].Value = this.cboprovinciacomercial.GetItemText(this.cboprovinciacomercial.SelectedItem);
                        row.Cells["DistritoComercial"].Value = this.cbodistritocomercial.GetItemText(this.cbodistritocomercial.SelectedItem);

                        row.Cells["NombreContacto"].Value = txtnombrecontacto.Text;
                        row.Cells["DireccionContacto"].Value = txtdireccioncontacto.Text;
                        row.Cells["DepartamentoContacto"].Value = this.cbodepartamentocontacto.GetItemText(this.cbodepartamentocontacto.SelectedItem);
                        row.Cells["ProvinciaContacto"].Value = this.cboprovinciacontacto.GetItemText(this.cboprovinciacontacto.SelectedItem);
                        row.Cells["DistritoContacto"].Value = this.cbodistritocontacto.GetItemText(this.cbodistritocontacto.SelectedItem);
                        row.Cells["IdTipoDocumentoContacto"].Value = ((OpcionCombo)cbotipodocumentocontacto.SelectedItem).Valor.ToString();
                        row.Cells["TipoDocumentoContacto"].Value = ((OpcionCombo)cbotipodocumentocontacto.SelectedItem).Texto.ToString();
                        row.Cells["NumeroDocumentoContacto"].Value = txtdocumentocontacto.Text;
                        row.Cells["Cmp"].Value = txtcmp.Text;
                        row.Cells["TelefonoContacto"].Value = txttlffijo.Text;
                        row.Cells["CelularContacto"].Value = txtcelularcontacto.Text;
                        row.Cells["CorreoContacto"].Value = txtcorreocontacto.Text;
                        row.Cells["EstadoValor"].Value = ((OpcionCombo)cboestado.SelectedItem).Valor.ToString();
                        row.Cells["Estado"].Value = ((OpcionCombo)cboestado.SelectedItem).Texto.ToString();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje);
                    }
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

        #endregion

        #region PROCEDIMIENTOS
        private void Limpiar()
        {
            txtcodigocliente.Text = "";
            txtindice.Text = "-1";
            txtid.Text = "0";
            cboestado.SelectedIndex = 0;
            cbotipodocumento.SelectedIndex = 2;
            txtdocumento.Text = "";
            txtnombre.Text = "";
            txtrazonsocial.Text = "";
            txtdireccion.Text = "";

            txtnombrecomercial.Text = "";
            txtdireccioncomercial.Text = "";
            txtcorreo1.Text = "";
            txtcorreo2.Text = "";
            txttelefono1.Text = "";
            txttelefono2.Text = "";

            txtnombrecontacto.Text = "";
            txtdireccioncontacto.Text = "";
            cbotipodocumentocontacto.SelectedIndex = 1;
            txtdocumentocontacto.Text = "";
            txtcmp.Text = "";
            txttlffijo.Text = "";
            txtcelularcontacto.Text = "";
            txtcorreocontacto.Text = "";

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            defaultindexcombo();
        }
        private void buscar()
        {
            if (((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString() == "TODOS")
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    row.Visible = false;
                    foreach (DataGridViewColumn column in dgvdata.Columns)
                    {
                        if (row.Cells[column.Index].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                        {
                            row.Visible = true;
                        }
                    }
                }
            }
            else
            {
                string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
                if (dgvdata.Rows.Count > 0)
                {

                    foreach (DataGridViewRow row in dgvdata.Rows)
                    {
                        if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }
                }
            }
        }
        private void txtbusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                buscar();
            }
        }
        private void frmClientes_Shown(object sender, EventArgs e)
        {
            txtdocumento.Focus();
        }
        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                //Obteniendo las dimensiones de la imagen
                var w = Properties.Resources.check20.Width;
                var h = Properties.Resources.check20.Height;
                //Centrando la imagen en la celda
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.check20, new Rectangle(x, y, w, h));
                //Si la acción del click puede continuar
                e.Handled = true;
            }
        }
        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();

                    txtid.Text = dgvdata.Rows[indice].Cells["Id"].Value.ToString();
                    txtcodigocliente.Text = dgvdata.Rows[indice].Cells["CodigoCliente"].Value.ToString();
                    foreach (OpcionCombo oc in cbotipodocumento.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdTipoDocumento"].Value))
                        {
                            int indice_combo = cbotipodocumento.Items.IndexOf(oc);
                            cbotipodocumento.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                    txtdocumento.Text = dgvdata.Rows[indice].Cells["Documento"].Value.ToString();
                    txtnombre.Text = dgvdata.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtrazonsocial.Text = dgvdata.Rows[indice].Cells["RazonSocial"].Value.ToString();
                    txtdireccion.Text = dgvdata.Rows[indice].Cells["Direccion"].Value.ToString();
                    cbodepartamento.SelectedIndex = cbodepartamento.FindStringExact(dgvdata.Rows[indice].Cells["Departamento"].Value.ToString());
                    cboprovincia.SelectedIndex = cboprovincia.FindStringExact(dgvdata.Rows[indice].Cells["Provincia"].Value.ToString());
                    cbodistrito.SelectedIndex = cbodistrito.FindStringExact(dgvdata.Rows[indice].Cells["Distrito"].Value.ToString());

                    txtnombrecomercial.Text = dgvdata.Rows[indice].Cells["NombreComercial"].Value.ToString();
                    txtdireccioncomercial.Text = dgvdata.Rows[indice].Cells["DireccionComercial"].Value.ToString();
                    txtcorreo1.Text = dgvdata.Rows[indice].Cells["Correo1"].Value.ToString();
                    txtcorreo2.Text = dgvdata.Rows[indice].Cells["Correo2"].Value.ToString();
                    txttelefono1.Text = dgvdata.Rows[indice].Cells["Telefono1"].Value.ToString();
                    txttelefono2.Text = dgvdata.Rows[indice].Cells["Telefono2"].Value.ToString();
                    cbodepartamentocomercial.SelectedIndex = cbodepartamentocomercial.FindStringExact(dgvdata.Rows[indice].Cells["DepartamentoComercial"].Value.ToString());
                    cboprovinciacomercial.SelectedIndex = cboprovinciacomercial.FindStringExact(dgvdata.Rows[indice].Cells["ProvinciaComercial"].Value.ToString());
                    cbodistritocomercial.SelectedIndex = cbodistritocomercial.FindStringExact(dgvdata.Rows[indice].Cells["DistritoComercial"].Value.ToString());

                    txtnombrecontacto.Text = dgvdata.Rows[indice].Cells["NombreContacto"].Value.ToString();
                    txtdireccioncontacto.Text = dgvdata.Rows[indice].Cells["DireccionContacto"].Value.ToString();
                    cbodepartamentocontacto.SelectedIndex = cbodepartamentocontacto.FindStringExact(dgvdata.Rows[indice].Cells["DepartamentoContacto"].Value.ToString());
                    cboprovinciacontacto.SelectedIndex = cboprovinciacontacto.FindStringExact(dgvdata.Rows[indice].Cells["ProvinciaContacto"].Value.ToString());
                    cbodistritocontacto.SelectedIndex = cbodistritocontacto.FindStringExact(dgvdata.Rows[indice].Cells["DistritoContacto"].Value.ToString());
                    foreach (OpcionCombo oc in cbotipodocumentocontacto.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdTipoDocumentoContacto"].Value))
                        {
                            int indice_combo = cbotipodocumentocontacto.Items.IndexOf(oc);
                            cbotipodocumentocontacto.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                    txtdocumentocontacto.Text = dgvdata.Rows[indice].Cells["NumeroDocumentoContacto"].Value.ToString();
                    txtcmp.Text = dgvdata.Rows[indice].Cells["CMP"].Value.ToString();
                    txttlffijo.Text = dgvdata.Rows[indice].Cells["TelefonoContacto"].Value.ToString();
                    txtcelularcontacto.Text = dgvdata.Rows[indice].Cells["CelularContacto"].Value.ToString();
                    txtcorreocontacto.Text = dgvdata.Rows[indice].Cells["CorreoContacto"].Value.ToString();
                    foreach (OpcionCombo oc in cboestado.Items)
                    {
                        if (oc.Valor == dgvdata.Rows[indice].Cells["EstadoValor"].Value)
                        {
                        int indice_combo = cboestado.Items.IndexOf(oc);
                        cboestado.SelectedIndex = indice_combo;
                        break;
                        }
                    }
                }
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) {

                txtdireccioncomercial.Text = txtdireccion.Text;
                txtnombrecomercial.Text = txtnombre.Text;
                cbodepartamentocomercial.SelectedIndex = cbodepartamento.SelectedIndex;
                cboprovinciacomercial.SelectedIndex=cboprovincia.SelectedIndex;
                cbodistritocomercial.SelectedIndex=cbodistrito.SelectedIndex;
            }
            else
            {
                txtdireccioncomercial.Text = "";
                cbodepartamentocomercial.SelectedIndex = 25;
               
                
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                txtdireccioncontacto.Text = txtdireccion.Text;
                cbodepartamentocontacto.SelectedIndex = cbodepartamento.SelectedIndex;
                cboprovinciacontacto.SelectedIndex = cboprovincia.SelectedIndex;
                cbodistritocontacto.SelectedIndex = cbodistrito.SelectedIndex;
            }
            else
            {
                txtdireccioncontacto.Text = "";
                
                cbodepartamentocontacto.SelectedIndex = 25;
                
            }
        }
        public void defaultindexcombo()
        {
            cbodepartamento.SelectedIndex = 25;
            cbodepartamentocomercial.SelectedIndex = 25;
            cbodepartamentocontacto.SelectedIndex = 25;
        }

        #endregion

        #region Restricciones de tamaño y numeros para los textbox que contengan número
        private void txtdocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
                return;
            }
            if (txtdocumento.Text.Length >= 20 && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void txttelefono1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
                return;
            }
            if (txttelefono1.Text.Length >= 20 && e.KeyChar != '\b')
            {
                txttelefono1.ShortcutsEnabled = false;
                e.Handled = true;
            }
        }
        private void txttelefono2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
                return;
            }
            if (txttelefono2.Text.Length >= 20 && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void txtdocumentocontacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
                return;
            }
            if (txtdocumentocontacto.Text.Length >= 20 && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void txttlffijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
                return;
            }
            if (txttlffijo.Text.Length >= 20 && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void txtcelularcontacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
                return;
            }
            if (txtcelularcontacto.Text.Length >= 20 && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void txtcmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
                return;
            }
            if (txtcmp.Text.Length >= 5 && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
