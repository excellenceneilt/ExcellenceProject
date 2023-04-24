﻿using CapaEntidad;
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

namespace CapaPresentacion.Modales
{
    public partial class mdProductoE : Form
    {
        public Producto _Producto { get; set; }
        public mdProductoE()
        {
            InitializeComponent();
        }

        private void mdProductoE_Load(object sender, EventArgs e)
        {
            //Para filtrar datos en la tabla
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true)
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }

            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            //Mostrar todos los productos
            //Se crea la lista
            List<Producto> listaProducto = new CN_Producto().Listar();

            //Se recorre la lista
            foreach (Producto item in listaProducto)
            {//Colocar las columnas del datagrid
                dgvdata.Rows.Add(new object[]
                {
                    item.Codigo,
                    item.Nombre,
                    item.oMarca.Descripcion
                });
            }
        }
        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;
            if (iRow >= 0 && iColum >= 0)
            {
                _Producto = new Producto()
                {
                    Codigo = dgvdata.Rows[iRow].Cells["Codigo"].Value.ToString(),
                    Nombre = dgvdata.Rows[iRow].Cells["NombreProducto"].Value.ToString(),
                    oMarca = new Marca() { Descripcion = dgvdata.Rows[iRow].Cells["Marca"].Value.ToString() }
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
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
            if (e.KeyData == Keys.Enter)
            {
                buscar();
            }
        }

    }
}
