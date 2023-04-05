namespace CapaPresentacion
{
    partial class frmHistorialIncidencias
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaRst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaOst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resultado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Garantia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Soles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.dgvdata);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1315, 590);
            this.groupBox1.TabIndex = 120;
            this.groupBox1.TabStop = false;
            // 
            // dgvdata
            // 
            this.dgvdata.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cliente,
            this.FechaRst,
            this.Rst,
            this.FechaOst,
            this.Ost,
            this.Resultado,
            this.Garantia,
            this.Comprobante,
            this.Soles,
            this.Dolares});
            this.dgvdata.Location = new System.Drawing.Point(6, 51);
            this.dgvdata.MultiSelect = false;
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.ReadOnly = true;
            this.dgvdata.RowTemplate.Height = 28;
            this.dgvdata.Size = new System.Drawing.Size(1303, 533);
            this.dgvdata.TabIndex = 123;
            // 
            // Cliente
            // 
            this.Cliente.HeaderText = "Aún estan por definirse las columnas";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            this.Cliente.Width = 370;
            // 
            // FechaRst
            // 
            this.FechaRst.HeaderText = "Fecha RST";
            this.FechaRst.Name = "FechaRst";
            this.FechaRst.ReadOnly = true;
            this.FechaRst.Visible = false;
            // 
            // Rst
            // 
            this.Rst.HeaderText = "RST";
            this.Rst.Name = "Rst";
            this.Rst.ReadOnly = true;
            this.Rst.Visible = false;
            // 
            // FechaOst
            // 
            this.FechaOst.HeaderText = "Fecha OST";
            this.FechaOst.Name = "FechaOst";
            this.FechaOst.ReadOnly = true;
            this.FechaOst.Visible = false;
            // 
            // Ost
            // 
            this.Ost.HeaderText = "OST";
            this.Ost.Name = "Ost";
            this.Ost.ReadOnly = true;
            this.Ost.Visible = false;
            // 
            // Resultado
            // 
            this.Resultado.HeaderText = "Resultado";
            this.Resultado.Name = "Resultado";
            this.Resultado.ReadOnly = true;
            this.Resultado.Visible = false;
            // 
            // Garantia
            // 
            this.Garantia.HeaderText = "Garantía";
            this.Garantia.Name = "Garantia";
            this.Garantia.ReadOnly = true;
            this.Garantia.Visible = false;
            this.Garantia.Width = 80;
            // 
            // Comprobante
            // 
            this.Comprobante.HeaderText = "Comprobante";
            this.Comprobante.Name = "Comprobante";
            this.Comprobante.ReadOnly = true;
            this.Comprobante.Visible = false;
            // 
            // Soles
            // 
            this.Soles.HeaderText = "S/.";
            this.Soles.Name = "Soles";
            this.Soles.ReadOnly = true;
            this.Soles.Visible = false;
            this.Soles.Width = 80;
            // 
            // Dolares
            // 
            this.Dolares.HeaderText = "US$";
            this.Dolares.Name = "Dolares";
            this.Dolares.ReadOnly = true;
            this.Dolares.Visible = false;
            this.Dolares.Width = 80;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(246, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 122;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(91, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(132, 21);
            this.comboBox1.TabIndex = 121;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 120;
            this.label1.Text = "Búsqueda por:";
            // 
            // frmHistorialIncidencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 649);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmHistorialIncidencias";
            this.Text = "Historial de incidencias";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRst;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rst;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaOst;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Garantia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Soles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dolares;
    }
}