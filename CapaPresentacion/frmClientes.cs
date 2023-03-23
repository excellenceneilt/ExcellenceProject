using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            foreach (DataGridViewColumn c in dgvdata.Columns)
            {
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
                c.Selected = false;
            }
            dgvdata.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
            dgvdata.Columns[0].Selected = true;

            this.dgvdata.ClipboardCopyMode =
        DataGridViewClipboardCopyMode.EnableWithoutHeaderText;

            

            this.dgvdata.MultiSelect = false;


            //Si la tabla tiene estados
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;
            //Se crea la lista del combobox a usar en el formulario
            List<Especialidad> listaEspecialidad = new CN_Especialidad().Listar();

            //Se recorre la listadel combobox usar después para leer Clientes foranea
            foreach (Especialidad item in listaEspecialidad)
            {   //cambiar aquí el combo box que se dispone
                cboespecialidad.Items.Add(new OpcionCombo() { Valor = item.IdEspecialidad, Texto = item.Descripcion });
            }
            cboespecialidad.DisplayMember = "Texto";
            cboespecialidad.ValueMember = "Valor";
            cboespecialidad.SelectedIndex = 0;




            //Para filtrar datos en la lista
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

            //Mostrar todos los Clientes
            //Se crea la lista
            List<Cliente> listaCliente = new CN_Cliente().Listar();

            //Se recorre la lista
            foreach (Cliente item in listaCliente)
            {//Colocar las columnas del datagrid
                dgvdata.Rows.Add(new object[] {
                     "",
                    item.IdCliente,
                    item.Documento,
                    item.NombreCompleto,
                    item.Correo1,
                    item.Telefono1,
                    item.RazonSocial,
                    item.CMP,
                    item.RUC,
                    item.oEspecialidad.IdEspecialidad,
                    item.oEspecialidad.Descripcion,
                    item.Correo2,
                    item.Telefono2,
                    item.Estado==true ?1 : 0,
                    item.Estado==true ?"Activo":"Inactivo",
            });
            }
            
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Cliente objCliente = new Cliente()
            {
                //Llenando atributos de la clase Cliente de los campos del formulario
                IdCliente = Convert.ToInt32(txtid.Text),
                Documento =txtdocumento.Text,
                NombreCompleto = txtnombrecompleto.Text,
                Correo1 = txtcorreo1.Text,
                Telefono1 = texttelefono1.Text,
                RazonSocial = textrazonsocial.Text,
                CMP = txtcmp.Text,
                RUC = txtruc.Text,
                oEspecialidad = new Especialidad() { IdEspecialidad = Convert.ToInt32(((OpcionCombo)cboespecialidad.SelectedItem).Valor) },
                Correo2 = txtcorreo2.Text,
                
                Telefono2 = texttelefono2.Text,
                
                
                
                
                

                //El item seleccionado se convierte a la clase opcioncombo, y se accede a su propiedad valor, si es igual a 1 será true caso contrario false
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            };


            if (objCliente.IdCliente == 0)
            {
                //Se usa el método registrar desde la capa negocio
                int idClientegenerado = new CN_Cliente().Registrar(objCliente, out mensaje);

                //El registro se hará siempre y cuando idClientegenerado sea diferente a cero, si es igual a cero indica que o se registró
                if (idClientegenerado != 0)
                {
                    //En el mismo orden que la tabla
                    dgvdata.Rows.Add(new object[] {"",
                        idClientegenerado,
                        txtdocumento.Text,
                        txtnombrecompleto.Text,
                        txtcorreo1.Text,
                        texttelefono1.Text,
                        textrazonsocial.Text,
                        txtcmp.Text,
                        txtruc.Text,
                        ((OpcionCombo) cboespecialidad.SelectedItem).Valor.ToString(),
                         ((OpcionCombo) cboespecialidad.SelectedItem).Texto.ToString(),
                        txtcorreo2.Text,
                        texttelefono2.Text,
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
                    row.Cells["Documento"].Value = txtdocumento.Text;
                    row.Cells["NombreCompleto"].Value = txtnombrecompleto.Text;
                    row.Cells["Correo1"].Value = txtcorreo1.Text;
                    row.Cells["Telefono1"].Value = texttelefono1.Text;
                    row.Cells["RazonSocial"].Value = textrazonsocial.Text;
                    row.Cells["CMP"].Value = txtcmp.Text;
                    row.Cells["RUC"].Value = txtruc.Text;
                    row.Cells["IdEspecialidad"].Value = ((OpcionCombo)cboespecialidad.SelectedItem).Texto.ToString();
                    row.Cells["Especialidad"].Value = ((OpcionCombo)cboespecialidad.SelectedItem).Texto.ToString();
                    row.Cells["Correo2"].Value = txtcorreo2.Text;
                    row.Cells["Telefono2"].Value = texttelefono2.Text;
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

        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtdocumento.Text = "";
            txtnombrecompleto.Text = "";
            txtcorreo1.Text = "";
            texttelefono1.Text = "";
            textrazonsocial.Text = "";
            txtcmp.Text = "";
            txtruc.Text = "";
            cboespecialidad.SelectedIndex = 0;
            cboestado.SelectedIndex = 0;
            txtcorreo2.Text = "";
            texttelefono2.Text = "";

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
                    //Setear en campos la información del Cliente
                    txtid.Text = dgvdata.Rows[indice].Cells["Id"].Value.ToString();
                    txtdocumento.Text = dgvdata.Rows[indice].Cells["Documento"].Value.ToString();
                    txtnombrecompleto.Text = dgvdata.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtcorreo1.Text = dgvdata.Rows[indice].Cells["Correo1"].Value.ToString();
                    texttelefono1.Text = dgvdata.Rows[indice].Cells["Telefono1"].Value.ToString();
                    textrazonsocial.Text = dgvdata.Rows[indice].Cells["RazonSocial"].Value.ToString();
                    txtcmp.Text = dgvdata.Rows[indice].Cells["CMP"].Value.ToString();


                    txtruc.Text = dgvdata.Rows[indice].Cells["RUC"].Value.ToString();
                    //Setear en el combobox el rol del Cliente oc es el elemento que recorre toda la lista
                    foreach (OpcionCombo oc in cboespecialidad.Items)
                    {

                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdEspecialidad"].Value))
                        {
                            int indice_combo = cboespecialidad.Items.IndexOf(oc);
                            cboespecialidad.SelectedIndex = indice_combo;
                            break; //Para cuando lo encuentre debe terminar
                        }
                    }
                    txtcorreo2.Text = dgvdata.Rows[indice].Cells["Correo2"].Value.ToString();
                    
                    texttelefono2.Text = dgvdata.Rows[indice].Cells["Telefono2"].Value.ToString();
                    
                    
                    

                    


                    

                    //Setear en el combobox el rol del Cliente oc es el elemento que recorre toda la lista
                    foreach (OpcionCombo oc in cboestado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = cboestado.Items.IndexOf(oc);
                            cboestado.SelectedIndex = indice_combo;
                            break; //Para cuando lo encuentre debe terminar
                        }
                    }

                }
            }
        }

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

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }

        private void txtbusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                buscar();
            }
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{LEFT}");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtindice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cboestado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cboespecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtcorreo1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnombrecompleto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdocumento_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnexportar_Click(object sender, EventArgs e)
        {

        }

        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbobusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtcorreo2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void texttelefono1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void texttelefono2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtcmp_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textrazonsocial_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtruc_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btncolumnselect_Click(object sender, EventArgs e)
        {

        }
    }
}
