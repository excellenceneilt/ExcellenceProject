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

            #region COMBOBOX

            //Estados 
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

            //Listar TipoCliente en combobox
            List<Tipo_Cliente> listaTipoCliente = new CN_TipoCliente().Listar();
            foreach (Tipo_Cliente item in listaTipoCliente)
            {
                cbotipocliente.Items.Add(new OpcionCombo() { Valor = item.IdTipoCliente, Texto = item.Descripcion });
            }
            cbotipocliente.DisplayMember = "Texto";
            cbotipocliente.ValueMember = "Valor";
            cbotipocliente.SelectedIndex = 0;

            //Listar TipoDocumento en combobox
            List<Tipo_Documento> listaTipoDocumento = new CN_TipoDocumento().Listar();
            foreach (Tipo_Documento item in listaTipoDocumento)
            {
                cbotipodocumento.Items.Add(new OpcionCombo() { Valor = item.IdTipoDocumento, Texto = item.Descripcion });
            }
            cbotipodocumento.DisplayMember = "Texto";
            cbotipodocumento.ValueMember = "Valor";
            cbotipodocumento.SelectedIndex = 0;

            #endregion

            #region FILTRAR REGISTROS EN TABLA
            //Para filtrar registros en el datagrid
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;
            #endregion

            #region LLENAR DATAGRID
            
            List<Cliente> listaCliente = new CN_Cliente().Listar();
            foreach (Cliente item in listaCliente)
            {
             //Colocar los atributos en el mismo orden que el datagrid,
             //esto no influye en la integridad de la información
             //pero sí en su comportamiento en el datagrid,
             //los valores se mueven de una columna a otra,
             //procurar tener la misma cantidad de items que de columnas.

                dgvdata.Rows.Add(new object[] {
                     "",
                    item.IdCliente,
                    item.CodigoCliente,
                    item.oTipo_Documento.IdTipoDocumento,
                    item.oTipo_Documento.Descripcion,
                    item.Documento,
                    item.RUC,
                    item.RazonSocial,
                    item.oTipo_Cliente.IdTipoCliente,
                    item.oTipo_Cliente.Descripcion,
                    item.NombreCompleto,
                    item.Direccion,
                    item.CMP,
                    item.NombreComercial,
                    item.DireccionComercial,
                    item.Correo1,
                    item.Telefono1,
                    item.NombreContacto,
                    item.DireccionContacto,
                    item.DocumentoContacto,
                    item.RUCContacto,
                    item.TelefonofijoContacto,
                    item.CelularContacto,
                    item.CorreoContacto,
                    item.Correo2,
                    item.Telefono2,

                    item.Departamento,
                    item.Provincia,
                    item.Distrito,

                    item.DepartamentoComercial,
                    item.ProvinciaComercial,
                    item.DistritoComercial,

                    
                    item.DepartamentoContacto,
                    item.ProvinciaContacto,
                    item.DistritoContacto,

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
                //Asociando los atributos de la entidad (izquierda)
                //con los datos obtenidos en cada entrada como: textbox, combobox, etc (derecha)
                IdCliente = Convert.ToInt32(txtid.Text),
                CodigoCliente= txtcodigocliente.Text,
                Documento =txtdocumento.Text,
                DocumentoContacto = txtdocumentocontacto.Text,
                NombreCompleto = txtnombrecompleto.Text,
                NombreComercial = txtnombrecomercial.Text,
                NombreContacto = txtnombrecontacto.Text,
                Direccion = txtdireccion.Text,
                DireccionComercial = txtdireccioncomercial.Text,
                DireccionContacto = txtdireccioncontacto.Text,
                oTipo_Cliente = new Tipo_Cliente() { IdTipoCliente = Convert.ToInt32(((OpcionCombo)cbotipocliente.SelectedItem).Valor) },
                oTipo_Documento = new Tipo_Documento() { IdTipoDocumento = Convert.ToInt32(((OpcionCombo)cbotipodocumento.SelectedItem).Valor) },
                Departamento = this.cbodepartamento.GetItemText(this.cbodepartamento.SelectedItem),
                Provincia = this.cboprovincia.GetItemText(this.cboprovincia.SelectedItem),
                Distrito = this.cbodistrito.GetItemText(this.cbodistrito.SelectedItem),
                DepartamentoComercial = this.cbodepartamento.GetItemText(this.cbodepartamentocomercial.SelectedItem),
                ProvinciaComercial = this.cboprovincia.GetItemText(this.cboprovinciacomercial.SelectedItem),
                DistritoComercial = this.cbodistrito.GetItemText(this.cbodistritocomercial.SelectedItem),
                DepartamentoContacto = this.cbodepartamento.GetItemText(this.cbodepartamentocontacto.SelectedItem),
                ProvinciaContacto = this.cboprovincia.GetItemText(this.cboprovinciacontacto.SelectedItem),
                DistritoContacto = this.cbodistrito.GetItemText(this.cbodistritocontacto.SelectedItem),
                Correo1 = txtcorreo1.Text,
                Correo2 = txtcorreo2.Text,
                CorreoContacto = txtcorreocontacto.Text,
                Telefono1 = txttelefono1.Text,
                Telefono2 = txttelefono2.Text,
                TelefonofijoContacto = txttlffijo.Text,
                CelularContacto = txtcelularcontacto.Text,
                RazonSocial = txtrazonsocial.Text,
                CMP = txtcmp.Text,
                RUC = txtruc.Text,
                RUCContacto = txtruccontacto.Text,

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
                        txtruc.Text,
                        txtrazonsocial.Text,
                        ((OpcionCombo) cbotipocliente.SelectedItem).Valor.ToString(),
                        ((OpcionCombo) cbotipocliente.SelectedItem).Texto.ToString(),
                        txtnombrecompleto.Text,
                        txtdireccion.Text,
                        txtcmp.Text,
                        txtnombrecomercial.Text,
                        txtdireccioncomercial.Text,
                        txtcorreo1.Text,
                        txttelefono1.Text,
                        txtnombrecontacto.Text,
                        txtdireccioncontacto.Text,
                        txtdocumentocontacto.Text,
                        txtruccontacto.Text,
                        txttlffijo.Text,
                        txtcelularcontacto.Text,
                        txtcorreocontacto.Text,
                        txtcorreo2.Text,
                        txttelefono2.Text,
                        cbodepartamento.Text,
                        cboprovincia.Text,
                        cbodistrito.Text,
                        cbodepartamentocomercial.Text,
                        cboprovinciacomercial.Text,
                        cbodistritocomercial.Text,
                        cbodepartamentocontacto.Text,
                        cboprovinciacontacto.Text,
                        cbodistritocontacto.Text,
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
                bool resultado = new CN_Cliente().Editar(objCliente, out mensaje);

                if (resultado)
                {

                    
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["CodigoCliente"].Value = txtcodigocliente.Text;
                    row.Cells["IdTipoDocumento"].Value = ((OpcionCombo)cbotipodocumento.SelectedItem).Valor.ToString();
                    row.Cells["TipoDocumento"].Value = ((OpcionCombo)cbotipodocumento.SelectedItem).Texto.ToString();
                    row.Cells["Documento"].Value = txtdocumento.Text;
                    row.Cells["RUC"].Value = txtruc.Text;
                    row.Cells["RazonSocial"].Value = txtrazonsocial.Text;
                    row.Cells["IdTipoCliente"].Value = ((OpcionCombo)cbotipocliente.SelectedItem).Valor.ToString();
                    row.Cells["TipoCliente"].Value = ((OpcionCombo)cbotipocliente.SelectedItem).Texto.ToString();
                    row.Cells["NombreCompleto"].Value = txtnombrecompleto.Text;
                    row.Cells["Direccion"].Value =txtdireccion.Text;
                    row.Cells["CMP"].Value = txtcmp.Text;                
                    row.Cells["NombreComercial"].Value = txtnombrecomercial.Text;
                    row.Cells["DireccionComercial"].Value = txtdireccioncomercial.Text;
                    row.Cells["Correo1"].Value = txtcorreo1.Text;
                    row.Cells["Telefono1"].Value = txttelefono1.Text;
                    row.Cells["NombreContacto"].Value = txtnombrecontacto.Text;
                    row.Cells["DireccionContacto"].Value = txtdireccioncontacto.Text;
                    row.Cells["DocumentoContacto"].Value = txtdocumentocontacto.Text;
                    row.Cells["RucContacto"].Value = txtruccontacto.Text;
                    row.Cells["TelefonoContacto"].Value = txttlffijo.Text;
                    row.Cells["CelularContacto"].Value = txtcelularcontacto.Text;
                    row.Cells["Correo2"].Value = txtcorreo2.Text;
                    row.Cells["Telefono2"].Value = txttelefono2.Text;
                  
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboestado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cboestado.SelectedItem).Texto.ToString();
                    Limpiar();

                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }


            defaultindexcombo();
            
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
            txtindice.Text = "-1";
            txtid.Text = "0";

            txtdocumento.Text = "";
            txtdocumentocontacto.Text = "";
            txtnombrecompleto.Text = "";
            txtnombrecomercial.Text = "";
            txtnombrecontacto.Text = "";
            txtcorreo1.Text = "";
            txtcorreocontacto.Text = "";
            txttelefono1.Text = "";
            txttlffijo.Text = "";
            txtcelularcontacto.Text = "";
            txtrazonsocial.Text = "";
            txtcmp.Text = "";
            txtruc.Text = "";
            txtruccontacto.Text = "";
            cboestado.SelectedIndex = 0;
            txtcorreo2.Text = "";
            txttelefono2.Text = "";
            txtcodigocliente.Text = "";
            txtdireccion.Text = "";
            txtdireccioncomercial.Text = "";
            txtdireccioncontacto.Text = "";
            cbodepartamento.SelectedIndex= 0;
            cbodepartamentocomercial.SelectedIndex= 0;
            cbodepartamentocontacto.SelectedIndex = 0;

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;


        }
        private void buscar()
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

                    //.Text = dgvdata.Rows[indice].Cells[""].Value.ToString();

                    //No debe estar en orden necesariamente
                    txtindice.Text = indice.ToString();
                    //Setear en campos la información del Cliente (obtener los datos de una fila y ponerlos en edicion)
                    txtid.Text = dgvdata.Rows[indice].Cells["Id"].Value.ToString();
                    txtcodigocliente.Text = dgvdata.Rows[indice].Cells["CodigoCliente"].Value.ToString(); //No se edita, solo se muestra
                                                                                                          //TIPODOCUMENTO
                    txtdocumento.Text = dgvdata.Rows[indice].Cells["Documento"].Value.ToString();
                    txtruc.Text = dgvdata.Rows[indice].Cells["RUC"].Value.ToString();
                    txtrazonsocial.Text = dgvdata.Rows[indice].Cells["RazonSocial"].Value.ToString();
                    //TIPOCLIENTE
                    txtnombrecompleto.Text = dgvdata.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtdireccion.Text = dgvdata.Rows[indice].Cells["Direccion"].Value.ToString();
                    txtcmp.Text = dgvdata.Rows[indice].Cells["CMP"].Value.ToString();
                    txtnombrecomercial.Text = dgvdata.Rows[indice].Cells["NombreComercial"].Value.ToString();
                    txtdireccioncomercial.Text = dgvdata.Rows[indice].Cells["DireccionComercial"].Value.ToString();
                    txtcorreo1.Text = dgvdata.Rows[indice].Cells["Correo1"].Value.ToString();
                    txttelefono1.Text = dgvdata.Rows[indice].Cells["Telefono1"].Value.ToString();
                    txtnombrecontacto.Text = dgvdata.Rows[indice].Cells["NombreContacto"].Value.ToString();
                    txtdireccioncontacto.Text = dgvdata.Rows[indice].Cells["DireccionContacto"].Value.ToString();
                    txtdocumentocontacto.Text = dgvdata.Rows[indice].Cells["DocumentoContacto"].Value.ToString();
                    txtruccontacto.Text = dgvdata.Rows[indice].Cells["RucContacto"].Value.ToString();
                    txttlffijo.Text = dgvdata.Rows[indice].Cells["TelefonoContacto"].Value.ToString();
                    txtcelularcontacto.Text = dgvdata.Rows[indice].Cells["CelularContacto"].Value.ToString();
                    txtcorreocontacto.Text = dgvdata.Rows[indice].Cells["CorreoContacto"].Value.ToString();
                    txtcorreo2.Text = dgvdata.Rows[indice].Cells["Correo2"].Value.ToString();
                    txttelefono2.Text = dgvdata.Rows[indice].Cells["Telefono2"].Value.ToString();

                    cbodepartamento.SelectedIndex = cbodepartamento.FindStringExact(dgvdata.Rows[indice].Cells["Departamento"].Value.ToString());
                    cboprovincia.SelectedIndex = cboprovincia.FindStringExact(dgvdata.Rows[indice].Cells["Provincia"].Value.ToString());
                    cbodistrito.SelectedIndex = cbodistrito.FindStringExact(dgvdata.Rows[indice].Cells["Distrito"].Value.ToString());

                    cbodepartamentocomercial.SelectedIndex = cbodepartamentocomercial.FindStringExact(dgvdata.Rows[indice].Cells["DepartamentoComercial"].Value.ToString());
                    cboprovinciacomercial.SelectedIndex = cboprovinciacomercial.FindStringExact(dgvdata.Rows[indice].Cells["ProvinciaComercial"].Value.ToString());
                    cbodistritocomercial.SelectedIndex = cbodistritocomercial.FindStringExact(dgvdata.Rows[indice].Cells["DistritoComercial"].Value.ToString());

                    cbodepartamentocontacto.SelectedIndex = cbodepartamentocontacto.FindStringExact(dgvdata.Rows[indice].Cells["DepartamentoContacto"].Value.ToString());
                     cboprovinciacontacto.SelectedIndex = cboprovinciacontacto.FindStringExact(dgvdata.Rows[indice].Cells["ProvinciaContacto"].Value.ToString());
                     cbodistritocontacto.SelectedIndex = cbodistritocontacto.FindStringExact(dgvdata.Rows[indice].Cells["DistritoContacto"].Value.ToString());


                    foreach (OpcionCombo oc in cbotipodocumento.Items)
                    {

                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdTipoDocumento"].Value))
                        {
                            int indice_combo = cbotipodocumento.Items.IndexOf(oc);
                            cbotipodocumento.SelectedIndex = indice_combo;
                            break; //Para cuando lo encuentre debe terminar
                        }
                    }
                    foreach (OpcionCombo oc in cbotipocliente.Items)
                    {

                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdTipoCliente"].Value))
                        {
                            int indice_combo = cbotipocliente.Items.IndexOf(oc);
                            cbotipocliente.SelectedIndex = indice_combo;
                            break; //Para cuando lo encuentre debe terminar
                        }
                    }
                    

                    //Setear en el combobox el rol del Cliente oc es el elemento que recorre toda la lista
                    foreach (OpcionCombo oc in cboestado.Items)
                    {
                      //  if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["EstadoValor"].Value))
                            if (oc.Valor == dgvdata.Rows[indice].Cells["EstadoValor"].Value)
                            {
                            int indice_combo = cboestado.Items.IndexOf(oc);
                            cboestado.SelectedIndex = indice_combo;
                            break; //Para cuando lo encuentre debe terminar
                        }
                    }

                }
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) {

                txtdireccioncomercial.Text = txtdireccion.Text;
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
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                txtdocumentocontacto.Text = txtdocumento.Text;
                txtruccontacto.Text = txtruc.Text;
            }
            else
            {
                txtdocumentocontacto.Text = "";
                txtruccontacto.Text = "";
            }
        }
        public void defaultindexcombo()
        {
            cbodepartamento.SelectedIndex = 25;
            cbodepartamentocomercial.SelectedIndex = 25;
            cbodepartamentocontacto.SelectedIndex = 25;
        }

        #endregion

    }
}
