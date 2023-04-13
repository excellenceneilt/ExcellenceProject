﻿using CapaDatos;
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
                     "",
                     item.IdEquipo,
                    item.CodigoEquipo,
                    item.Modelo,
                    item.Marca,
                    item.SerialNumber,
                    item.Producto,
                    item.eEstadoEquipo.Descripcion,
                    

                    item.Estado==true ?1 : 0,
                    item.Estado==true ?"Activo":"Inactivo",
                });
            }
            #endregion
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtmodelo.Text = string.Empty;
            txtcodigo.Text = string.Empty;
            txtserial.Text = string.Empty;
            txtmodelo.Focus();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Equipo objEquipo = new Equipo()
            {
                IdEquipo = Convert.ToInt32(txtid.Text),
                CodigoEquipo = txtcodigo.Text,
                Modelo = txtmodelo.Text,
                Marca = txtmarca.Text,
                Producto = txtmodelo.Text,
                SerialNumber = txtserial.Text
               
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
                        "",
                        idEquipogenerado,
                        objEquipo.IdEquipo,
                        txtcodigo.Text,
                        txtmodelo.Text,
                        txtmarca.Text,
                        txtserial.Text

                });

                   // Limpiar();

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
                  //  Limpiar();

                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }



        }
    }
}
