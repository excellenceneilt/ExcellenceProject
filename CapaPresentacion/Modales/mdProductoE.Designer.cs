namespace CapaPresentacion.Modales
{
    partial class mdProductoE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SinNroSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtbusqueda = new System.Windows.Forms.TextBox();
            this.cbobusqueda = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnlimpiarbuscador = new FontAwesome.Sharp.IconButton();
            this.btnbuscar = new FontAwesome.Sharp.IconButton();
            this.txtcodigocompra = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnlimpiarbuscadorcompra = new FontAwesome.Sharp.IconButton();
            this.btnbuscarcompra = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 10);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.label10.Size = new System.Drawing.Size(737, 96);
            this.label10.TabIndex = 63;
            this.label10.Text = "Lista de productos:";
            // 
            // dgvdata
            // 
            this.dgvdata.AllowUserToAddRows = false;
            this.dgvdata.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.NombreProducto,
            this.Marca,
            this.CantidadTotal,
            this.SinNroSerie,
            this.IdProducto});
            this.dgvdata.Location = new System.Drawing.Point(10, 108);
            this.dgvdata.MultiSelect = false;
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.ReadOnly = true;
            this.dgvdata.RowTemplate.Height = 28;
            this.dgvdata.Size = new System.Drawing.Size(737, 330);
            this.dgvdata.TabIndex = 62;
            this.dgvdata.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdata_CellDoubleClick);
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 130;
            // 
            // NombreProducto
            // 
            this.NombreProducto.HeaderText = "Nombre producto";
            this.NombreProducto.Name = "NombreProducto";
            this.NombreProducto.ReadOnly = true;
            this.NombreProducto.Width = 260;
            // 
            // Marca
            // 
            this.Marca.HeaderText = "Marca";
            this.Marca.Name = "Marca";
            this.Marca.ReadOnly = true;
            // 
            // CantidadTotal
            // 
            this.CantidadTotal.HeaderText = "Cantidad total";
            this.CantidadTotal.Name = "CantidadTotal";
            this.CantidadTotal.ReadOnly = true;
            // 
            // SinNroSerie
            // 
            this.SinNroSerie.HeaderText = "Sin nro serie";
            this.SinNroSerie.Name = "SinNroSerie";
            this.SinNroSerie.ReadOnly = true;
            // 
            // IdProducto
            // 
            this.IdProducto.HeaderText = "IdProducto";
            this.IdProducto.Name = "IdProducto";
            this.IdProducto.ReadOnly = true;
            this.IdProducto.Visible = false;
            // 
            // txtbusqueda
            // 
            this.txtbusqueda.Location = new System.Drawing.Point(195, 73);
            this.txtbusqueda.Name = "txtbusqueda";
            this.txtbusqueda.Size = new System.Drawing.Size(135, 20);
            this.txtbusqueda.TabIndex = 71;
            this.txtbusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbusqueda_KeyDown);
            // 
            // cbobusqueda
            // 
            this.cbobusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbobusqueda.FormattingEnabled = true;
            this.cbobusqueda.Location = new System.Drawing.Point(93, 73);
            this.cbobusqueda.Name = "cbobusqueda";
            this.cbobusqueda.Size = new System.Drawing.Size(96, 21);
            this.cbobusqueda.TabIndex = 70;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(26, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 69;
            this.label11.Text = "Buscar por:";
            // 
            // btnlimpiarbuscador
            // 
            this.btnlimpiarbuscador.BackColor = System.Drawing.Color.SteelBlue;
            this.btnlimpiarbuscador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiarbuscador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiarbuscador.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnlimpiarbuscador.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnlimpiarbuscador.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnlimpiarbuscador.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlimpiarbuscador.IconSize = 16;
            this.btnlimpiarbuscador.Location = new System.Drawing.Point(383, 70);
            this.btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            this.btnlimpiarbuscador.Size = new System.Drawing.Size(45, 23);
            this.btnlimpiarbuscador.TabIndex = 73;
            this.btnlimpiarbuscador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnlimpiarbuscador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnlimpiarbuscador.UseVisualStyleBackColor = false;
            this.btnlimpiarbuscador.Click += new System.EventHandler(this.btnlimpiarbuscador_Click);
            // 
            // btnbuscar
            // 
            this.btnbuscar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnbuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnbuscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassPlus;
            this.btnbuscar.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnbuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscar.IconSize = 16;
            this.btnbuscar.Location = new System.Drawing.Point(336, 71);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(41, 23);
            this.btnbuscar.TabIndex = 72;
            this.btnbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnbuscar.UseVisualStyleBackColor = false;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // txtcodigocompra
            // 
            this.txtcodigocompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcodigocompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodigocompra.Location = new System.Drawing.Point(128, 42);
            this.txtcodigocompra.Name = "txtcodigocompra";
            this.txtcodigocompra.Size = new System.Drawing.Size(100, 20);
            this.txtcodigocompra.TabIndex = 157;
            this.txtcodigocompra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcodigocompra_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 156;
            this.label6.Text = "Código de compra:";
            // 
            // btnlimpiarbuscadorcompra
            // 
            this.btnlimpiarbuscadorcompra.BackColor = System.Drawing.Color.SteelBlue;
            this.btnlimpiarbuscadorcompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiarbuscadorcompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiarbuscadorcompra.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnlimpiarbuscadorcompra.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnlimpiarbuscadorcompra.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnlimpiarbuscadorcompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlimpiarbuscadorcompra.IconSize = 16;
            this.btnlimpiarbuscadorcompra.Location = new System.Drawing.Point(281, 39);
            this.btnlimpiarbuscadorcompra.Name = "btnlimpiarbuscadorcompra";
            this.btnlimpiarbuscadorcompra.Size = new System.Drawing.Size(45, 23);
            this.btnlimpiarbuscadorcompra.TabIndex = 159;
            this.btnlimpiarbuscadorcompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnlimpiarbuscadorcompra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnlimpiarbuscadorcompra.UseVisualStyleBackColor = false;
            this.btnlimpiarbuscadorcompra.Click += new System.EventHandler(this.btnlimpiarbuscadorcompra_Click);
            // 
            // btnbuscarcompra
            // 
            this.btnbuscarcompra.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnbuscarcompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarcompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarcompra.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnbuscarcompra.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassPlus;
            this.btnbuscarcompra.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnbuscarcompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscarcompra.IconSize = 16;
            this.btnbuscarcompra.Location = new System.Drawing.Point(234, 40);
            this.btnbuscarcompra.Name = "btnbuscarcompra";
            this.btnbuscarcompra.Size = new System.Drawing.Size(41, 23);
            this.btnbuscarcompra.TabIndex = 158;
            this.btnbuscarcompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbuscarcompra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnbuscarcompra.UseVisualStyleBackColor = false;
            this.btnbuscarcompra.Click += new System.EventHandler(this.btnbuscarcompra_Click);
            // 
            // mdProductoE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 450);
            this.Controls.Add(this.btnlimpiarbuscadorcompra);
            this.Controls.Add(this.btnbuscarcompra);
            this.Controls.Add(this.txtcodigocompra);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtbusqueda);
            this.Controls.Add(this.cbobusqueda);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnlimpiarbuscador);
            this.Controls.Add(this.btnbuscar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgvdata);
            this.Name = "mdProductoE";
            this.Text = "mdProductoE";
            this.Load += new System.EventHandler(this.mdProductoE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.TextBox txtbusqueda;
        private System.Windows.Forms.ComboBox cbobusqueda;
        private System.Windows.Forms.Label label11;
        private FontAwesome.Sharp.IconButton btnlimpiarbuscador;
        private FontAwesome.Sharp.IconButton btnbuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn SinNroSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProducto;
        private System.Windows.Forms.TextBox txtcodigocompra;
        private System.Windows.Forms.Label label6;
        private FontAwesome.Sharp.IconButton btnlimpiarbuscadorcompra;
        private FontAwesome.Sharp.IconButton btnbuscarcompra;
    }
}