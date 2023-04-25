using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmProducto : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.110;Initial Catalog=DBSISTEMA_EXCELLENCE;User Id=sa;Password=1234;");

        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {

            #region COMBOBOX

            //Estados
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

            //Listar marcas
            List<Marca> listamarca = new CN_Marca().Listar();
            foreach (Marca item in listamarca)
            {
                cbomarca.Items.Add(new OpcionCombo() { Valor = item.IdMarca, Texto = item.Descripcion });
            }
            cbomarca.DisplayMember = "Texto";
            cbomarca.ValueMember = "Valor";
            cbomarca.SelectedIndex = 0;

            #endregion

            #region Filtrar registros en búsqueda

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
            #endregion

            #region Datagrid

            List<Producto> listaProducto = new CN_Producto().Listar();
            foreach (Producto item in listaProducto)
            {
                dgvdata.Rows.Add(new object[] {
                    "",
                   item.IdProducto,
                   item.Codigo,
                   item.Nombre,
                   item.Descripcion,
                   item.oMarca.IdMarca,
                   item.oMarca.Descripcion,
                   item.Stock,
                   item.PrecioCompra,
                   item.PrecioVenta,
                   item.Estado==true ?1 : 0,
                   item.Estado==true ?"Activo":"Inactivo"
                });
            }
            #endregion
        }


        #region BOTONES
        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar el producto?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Producto objproducto = new Producto()
                    {
                        //Llenando atributos de la clase Producto
                        IdProducto = Convert.ToInt32(txtid.Text),


                    };

                    bool respuesta = new CN_Producto().Eliminar(objproducto, out mensaje);
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
            Producto objproducto = new Producto()
            {
                //Llenando atributos de la clase Producto de los campos del formulario
                IdProducto = Convert.ToInt32(txtid.Text),
                Nombre = txtnombre.Text,
                Codigo = txtcodigo.Text,
                Descripcion = txtdescripcion.Text,
                //Para los combobox:
                //  oMarca = new Marca() { IdMarca = Convert.ToInt32(cbomarca.SelectedIndex)}, incorrecto
                oMarca = new Marca() { IdMarca = Convert.ToInt32(((OpcionCombo)cbomarca.SelectedItem).Valor) },
                //El item seleccionado se convierte a la clase opcioncombo, y se accede a su propiedad valor, si es igual a 1 será true caso contrario false
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            };


            if (objproducto.IdProducto == 0)
            {
                //Se usa el método registrar desde la capa negocio
                int idProductogenerado = new CN_Producto().Registrar(objproducto, out mensaje);

                //El registro se hará siempre y cuando idProductogenerado sea diferente a cero, si es igual a cero indica que o se registró
                if (idProductogenerado != 0)
                {
                    //Agregar nueva fila y declara nuevo objeto en el datagridview
                    dgvdata.Rows.Add(new object[] {"",
                        idProductogenerado,
                        txtcodigo.Text,
                        txtnombre.Text,
                        txtdescripcion.Text,
                        ((OpcionCombo) cbomarca.SelectedItem).Valor.ToString(),
                         ((OpcionCombo) cbomarca.SelectedItem).Texto.ToString(),
                          "0",
              "0.00", //Se establece por default
              "0.00",
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
                bool resultado = new CN_Producto().Editar(objproducto, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Codigo"].Value = txtcodigo.Text;
                    row.Cells["Nombre"].Value = txtnombre.Text;
                    row.Cells["Descripcion"].Value = txtdescripcion.Text;
                    row.Cells["IdMarca"].Value = ((OpcionCombo)cbomarca.SelectedItem).Valor.ToString();
                    row.Cells["Marca"].Value = ((OpcionCombo)cbomarca.SelectedItem).Texto.ToString();

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
        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }
        private void btnexportar_Click(object sender, EventArgs e)
        {
            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();

                foreach (DataGridViewColumn columna in dgvdata.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Visible)
                        dt.Rows.Add(new object[]{
                            row.Cells[2].Value.ToString(),
                            row.Cells[3].Value.ToString(),
                            row.Cells[4].Value.ToString(),

                            row.Cells[6].Value.ToString(),
                            row.Cells[7].Value.ToString(),
                            row.Cells[8].Value.ToString(),
                            row.Cells[9].Value.ToString(),
                            row.Cells[11].Value.ToString(),

                    });
                }
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = string.Format("RepoteProducto_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                saveFile.Filter = "Excel Files | *.xlsx"; //Sólo para ver arcvhios con ese formato

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //Crear archivo excel
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe"); //(dt son los datos, informe el nombre de archivo)
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(saveFile.FileName);
                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error al generar reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
        }
        #endregion

        #region ACCIONES
        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtdescripcion.Text = "";

            cbomarca.SelectedIndex = 0;

            cboestado.SelectedIndex = 0;
            txtcodigo.Select();

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
                    //Setear en campos la información del Producto
                    txtid.Text = dgvdata.Rows[indice].Cells["Id"].Value.ToString();
                    txtcodigo.Text = dgvdata.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtnombre.Text = dgvdata.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtdescripcion.Text = dgvdata.Rows[indice].Cells["Descripcion"].Value.ToString();

                    foreach (OpcionCombo oc in cbomarca.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdMarca"].Value))
                        {
                            int indice_combo = cbomarca.Items.IndexOf(oc);
                            cbomarca.SelectedIndex = indice_combo;
                            break; //Para cuando lo encuentre debe terminar
                        }
                    }

                    //Setear en el combobox el rol del Producto oc es el elemento que recorre toda la lista
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
        private void frmProducto_Shown(object sender, EventArgs e)
        {
            txtcodigo.Focus();
        }


        #endregion
    }
}
