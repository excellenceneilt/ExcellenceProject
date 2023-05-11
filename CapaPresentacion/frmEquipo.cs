using CapaDatos;
using CapaEntidad;
using CapaNegocio;
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
    public partial class frmEquipo : Form
    {
        public frmEquipo()
        {
            InitializeComponent();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProductoE())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtcodigo.Text = modal._Producto.Codigo;
                    txtmodelo.Text = modal._Producto.Nombre;
                    txtmarca.Text = modal._Producto.oMarca.Descripcion;
                    txtidproducto.Text = modal._Producto.IdProducto.ToString();
                    txtidcompra.Text = modal._Compra.IdCompra.ToString();
                    txtnumerodocumento.Text = modal._Compra.NumeroDocumento;
                    txtserial.Select();
                }
            }
        }

        private void frmEquipo_Load(object sender, EventArgs e)
        {
            #region LLENAR DATAGRID

            List<Equipo> listaEquipo = new CN_Equipo().Listar();
            foreach (Equipo item in listaEquipo)
            {
                //Colocar los atributos en el mismo orden que el datagrid,
                //esto no influye en la integridad de la información
                //pero sí en su comportamiento en el datagrid,
                //los valores se mueven de una columna a otra,
                //procurar tener la misma cantidad de items que de columnas.

                dgvdata.Rows.Add(new object[] {
                    item.IdEquipo,
                    item.Modelo,
                    item.SerialNumber,
                   
                });
            }
            #endregion
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Equipo objEquipo = new Equipo()
            {
                IdEquipo = Convert.ToInt32(txtid.Text),
                CodigoEquipo = txtcodigo.Text,
                Marca = txtmarca.Text,
                Modelo = txtmodelo.Text,
                SerialNumber = txtserial.Text,
                eProducto = new Producto() { IdProducto = Convert.ToInt32(txtidproducto.Text) },
            };
            if (objEquipo.IdEquipo == 0)
            {
                //Se usa el método registrar desde la capa negocio
                int idEquipogenerado = new CN_Equipo().Registrar(objEquipo, out mensaje);

                //El registro se hará siempre y cuando idClientegenerado sea diferente a cero, si es igual a cero indica que no se registró
                if (idEquipogenerado != 0)
                {
                    //En el mismo orden que la tabla por favor es acá
                    //No sé qué es lo que hace ._.

                    dgvdata.Rows.Add(new object[] {
                        txtidproducto.Text,
                        txtcodigo.Text,
                        txtmarca.Text,
                        txtmodelo.Text,
                        txtidproducto.Text,
                        txtserial.Text

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
                bool resultado = new CN_Equipo().Editar(objEquipo, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["CodigoEquipo"].Value = txtcodigo.Text;
                    row.Cells["Marca"].Value = txtmarca.Text;
                    row.Cells["Modelo"].Value = txtmodelo.Text;
                    row.Cells["Serial"].Value = txtserial.Text;
                    row.Cells["IdProducto"].Value = txtidproducto.Text;
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
            txtcodigo.Text = string.Empty;
            txtmarca.Text = string.Empty;
            txtmodelo.Text = string.Empty;
            txtserial.Text = string.Empty;
            txtidproducto.Text = string.Empty;
            txtmodelo.Focus();
        }

        private void txtidproducto_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtidproducto.Text))
            {
                btnguardar.Enabled = false;
            }
            else
            {
                btnguardar.Enabled = true;
            }
        }
    }
}
