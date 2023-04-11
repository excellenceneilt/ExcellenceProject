namespace CapaPresentacion
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuUsuarios = new FontAwesome.Sharp.IconMenuItem();
            this.menuMantenimiento = new FontAwesome.Sharp.IconMenuItem();
            this.submenuCategoria = new FontAwesome.Sharp.IconMenuItem();
            this.submenuProducto = new FontAwesome.Sharp.IconMenuItem();
            this.submenuEspecialidad = new System.Windows.Forms.ToolStripMenuItem();
            this.submenunegocio = new System.Windows.Forms.ToolStripMenuItem();
            this.equipoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVentas = new FontAwesome.Sharp.IconMenuItem();
            this.submenuRegistrarventas = new FontAwesome.Sharp.IconMenuItem();
            this.submenuDetalleVenta = new FontAwesome.Sharp.IconMenuItem();
            this.menuServicioTecnico = new FontAwesome.Sharp.IconMenuItem();
            this.submenuIngresoRecepcionEquipos = new FontAwesome.Sharp.IconMenuItem();
            this.submenuReporteRecepcionServicioTecnico = new FontAwesome.Sharp.IconMenuItem();
            this.submenuIngresoOrdenServicio = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuHistorialIncidencias = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuCertificadosGarantia = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuReporteCertificadosGarantia = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuActualizarDatosBasicosOst = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCompras = new FontAwesome.Sharp.IconMenuItem();
            this.submenuRegistrarcompra = new FontAwesome.Sharp.IconMenuItem();
            this.submenuDetallecompra = new FontAwesome.Sharp.IconMenuItem();
            this.menuClientes = new FontAwesome.Sharp.IconMenuItem();
            this.menuProveedores = new FontAwesome.Sharp.IconMenuItem();
            this.menuReportes = new FontAwesome.Sharp.IconMenuItem();
            this.submenureportecompras = new System.Windows.Forms.ToolStripMenuItem();
            this.submenureporteventas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAcercade = new FontAwesome.Sharp.IconMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnsalir = new FontAwesome.Sharp.IconButton();
            this.contenedor = new System.Windows.Forms.Panel();
            this.marcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.White;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsuarios,
            this.menuMantenimiento,
            this.menuVentas,
            this.menuServicioTecnico,
            this.menuCompras,
            this.menuClientes,
            this.menuProveedores,
            this.menuReportes,
            this.menuAcercade});
            this.menu.Location = new System.Drawing.Point(0, 73);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(0);
            this.menu.Size = new System.Drawing.Size(1333, 69);
            this.menu.TabIndex = 0;
            this.menu.Text = "menu";
            // 
            // menuUsuarios
            // 
            this.menuUsuarios.AutoSize = false;
            this.menuUsuarios.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuUsuarios.IconChar = FontAwesome.Sharp.IconChar.UsersCog;
            this.menuUsuarios.IconColor = System.Drawing.Color.Black;
            this.menuUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuUsuarios.IconSize = 50;
            this.menuUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuUsuarios.Name = "menuUsuarios";
            this.menuUsuarios.Size = new System.Drawing.Size(122, 69);
            this.menuUsuarios.Text = "Usuarios";
            this.menuUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuUsuarios.Click += new System.EventHandler(this.menuUsuarios_Click);
            // 
            // menuMantenimiento
            // 
            this.menuMantenimiento.AutoSize = false;
            this.menuMantenimiento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuCategoria,
            this.submenuProducto,
            this.submenuEspecialidad,
            this.submenunegocio,
            this.equipoToolStripMenuItem,
            this.marcaToolStripMenuItem});
            this.menuMantenimiento.IconChar = FontAwesome.Sharp.IconChar.Tools;
            this.menuMantenimiento.IconColor = System.Drawing.Color.Black;
            this.menuMantenimiento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuMantenimiento.IconSize = 50;
            this.menuMantenimiento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuMantenimiento.Name = "menuMantenimiento";
            this.menuMantenimiento.Size = new System.Drawing.Size(122, 69);
            this.menuMantenimiento.Text = "Mantenimiento";
            this.menuMantenimiento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuCategoria
            // 
            this.submenuCategoria.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuCategoria.IconColor = System.Drawing.Color.Black;
            this.submenuCategoria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuCategoria.Name = "submenuCategoria";
            this.submenuCategoria.Size = new System.Drawing.Size(180, 22);
            this.submenuCategoria.Text = "Categoría";
            this.submenuCategoria.Click += new System.EventHandler(this.submenuCategoria_Click);
            // 
            // submenuProducto
            // 
            this.submenuProducto.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuProducto.IconColor = System.Drawing.Color.Black;
            this.submenuProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuProducto.Name = "submenuProducto";
            this.submenuProducto.Size = new System.Drawing.Size(180, 22);
            this.submenuProducto.Text = "Producto";
            this.submenuProducto.Click += new System.EventHandler(this.submenuProducto_Click);
            // 
            // submenuEspecialidad
            // 
            this.submenuEspecialidad.Name = "submenuEspecialidad";
            this.submenuEspecialidad.Size = new System.Drawing.Size(180, 22);
            this.submenuEspecialidad.Text = "Especialidad";
            this.submenuEspecialidad.Click += new System.EventHandler(this.submenuEspecialidad_Click);
            // 
            // submenunegocio
            // 
            this.submenunegocio.Name = "submenunegocio";
            this.submenunegocio.Size = new System.Drawing.Size(180, 22);
            this.submenunegocio.Text = "Negocio";
            this.submenunegocio.Click += new System.EventHandler(this.submenunegocio_Click);
            // 
            // equipoToolStripMenuItem
            // 
            this.equipoToolStripMenuItem.Name = "equipoToolStripMenuItem";
            this.equipoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.equipoToolStripMenuItem.Text = "Equipo";
            this.equipoToolStripMenuItem.Click += new System.EventHandler(this.equipoToolStripMenuItem_Click);
            // 
            // menuVentas
            // 
            this.menuVentas.AutoSize = false;
            this.menuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuRegistrarventas,
            this.submenuDetalleVenta});
            this.menuVentas.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.menuVentas.IconColor = System.Drawing.Color.Black;
            this.menuVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuVentas.IconSize = 50;
            this.menuVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuVentas.Name = "menuVentas";
            this.menuVentas.Size = new System.Drawing.Size(122, 69);
            this.menuVentas.Text = "Ventas";
            this.menuVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuRegistrarventas
            // 
            this.submenuRegistrarventas.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuRegistrarventas.IconColor = System.Drawing.Color.Black;
            this.submenuRegistrarventas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuRegistrarventas.Name = "submenuRegistrarventas";
            this.submenuRegistrarventas.Size = new System.Drawing.Size(128, 22);
            this.submenuRegistrarventas.Text = "Registrar";
            this.submenuRegistrarventas.Click += new System.EventHandler(this.submenuRegistrarventas_Click);
            // 
            // submenuDetalleVenta
            // 
            this.submenuDetalleVenta.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuDetalleVenta.IconColor = System.Drawing.Color.Black;
            this.submenuDetalleVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuDetalleVenta.Name = "submenuDetalleVenta";
            this.submenuDetalleVenta.Size = new System.Drawing.Size(128, 22);
            this.submenuDetalleVenta.Text = "Ver detalle";
            this.submenuDetalleVenta.Click += new System.EventHandler(this.submenuDetalleVenta_Click);
            // 
            // menuServicioTecnico
            // 
            this.menuServicioTecnico.AutoSize = false;
            this.menuServicioTecnico.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuIngresoRecepcionEquipos,
            this.submenuReporteRecepcionServicioTecnico,
            this.submenuIngresoOrdenServicio,
            this.submenuHistorialIncidencias,
            this.submenuCertificadosGarantia,
            this.submenuReporteCertificadosGarantia,
            this.submenuActualizarDatosBasicosOst});
            this.menuServicioTecnico.IconChar = FontAwesome.Sharp.IconChar.Tools;
            this.menuServicioTecnico.IconColor = System.Drawing.Color.Black;
            this.menuServicioTecnico.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuServicioTecnico.IconSize = 50;
            this.menuServicioTecnico.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuServicioTecnico.Name = "menuServicioTecnico";
            this.menuServicioTecnico.Size = new System.Drawing.Size(122, 69);
            this.menuServicioTecnico.Text = "Servicio Técnico";
            this.menuServicioTecnico.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuServicioTecnico.Click += new System.EventHandler(this.iconMenuItem1_Click);
            // 
            // submenuIngresoRecepcionEquipos
            // 
            this.submenuIngresoRecepcionEquipos.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuIngresoRecepcionEquipos.IconColor = System.Drawing.Color.Black;
            this.submenuIngresoRecepcionEquipos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuIngresoRecepcionEquipos.Name = "submenuIngresoRecepcionEquipos";
            this.submenuIngresoRecepcionEquipos.Size = new System.Drawing.Size(287, 22);
            this.submenuIngresoRecepcionEquipos.Text = "Ingreso de recepción de equipos";
            this.submenuIngresoRecepcionEquipos.Click += new System.EventHandler(this.submenuIngresoRecepcionEquipos_Click);
            // 
            // submenuReporteRecepcionServicioTecnico
            // 
            this.submenuReporteRecepcionServicioTecnico.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuReporteRecepcionServicioTecnico.IconColor = System.Drawing.Color.Black;
            this.submenuReporteRecepcionServicioTecnico.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuReporteRecepcionServicioTecnico.Name = "submenuReporteRecepcionServicioTecnico";
            this.submenuReporteRecepcionServicioTecnico.Size = new System.Drawing.Size(287, 22);
            this.submenuReporteRecepcionServicioTecnico.Text = "Reporte de recepción de servicio técnico";
            this.submenuReporteRecepcionServicioTecnico.Click += new System.EventHandler(this.submenuReporteRecepcionServicioTecnico_Click);
            // 
            // submenuIngresoOrdenServicio
            // 
            this.submenuIngresoOrdenServicio.Name = "submenuIngresoOrdenServicio";
            this.submenuIngresoOrdenServicio.Size = new System.Drawing.Size(287, 22);
            this.submenuIngresoOrdenServicio.Text = "Ingreso de orden de servicio";
            this.submenuIngresoOrdenServicio.Click += new System.EventHandler(this.submenuIngresoOrdenServicio_Click);
            // 
            // submenuHistorialIncidencias
            // 
            this.submenuHistorialIncidencias.Name = "submenuHistorialIncidencias";
            this.submenuHistorialIncidencias.Size = new System.Drawing.Size(287, 22);
            this.submenuHistorialIncidencias.Text = "Historial de incidencias";
            this.submenuHistorialIncidencias.Click += new System.EventHandler(this.submenuHistorialIncidencias_Click);
            // 
            // submenuCertificadosGarantia
            // 
            this.submenuCertificadosGarantia.Name = "submenuCertificadosGarantia";
            this.submenuCertificadosGarantia.Size = new System.Drawing.Size(287, 22);
            this.submenuCertificadosGarantia.Text = "Certificados de garantía";
            this.submenuCertificadosGarantia.Click += new System.EventHandler(this.submenuCertificadosGarantia_Click);
            // 
            // submenuReporteCertificadosGarantia
            // 
            this.submenuReporteCertificadosGarantia.Name = "submenuReporteCertificadosGarantia";
            this.submenuReporteCertificadosGarantia.Size = new System.Drawing.Size(287, 22);
            this.submenuReporteCertificadosGarantia.Text = "Reporte de certificados de garantía";
            this.submenuReporteCertificadosGarantia.Click += new System.EventHandler(this.submenuReporteCertificadosGarantia_Click);
            // 
            // submenuActualizarDatosBasicosOst
            // 
            this.submenuActualizarDatosBasicosOst.Name = "submenuActualizarDatosBasicosOst";
            this.submenuActualizarDatosBasicosOst.Size = new System.Drawing.Size(287, 22);
            this.submenuActualizarDatosBasicosOst.Text = "Actualizar datos básicos en ost";
            this.submenuActualizarDatosBasicosOst.Click += new System.EventHandler(this.submenuActualizarDatosBasicosOst_Click);
            // 
            // menuCompras
            // 
            this.menuCompras.AutoSize = false;
            this.menuCompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuRegistrarcompra,
            this.submenuDetallecompra});
            this.menuCompras.IconChar = FontAwesome.Sharp.IconChar.DollyFlatbed;
            this.menuCompras.IconColor = System.Drawing.Color.Black;
            this.menuCompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuCompras.IconSize = 50;
            this.menuCompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuCompras.Name = "menuCompras";
            this.menuCompras.Size = new System.Drawing.Size(122, 69);
            this.menuCompras.Text = "Compras";
            this.menuCompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuRegistrarcompra
            // 
            this.submenuRegistrarcompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuRegistrarcompra.IconColor = System.Drawing.Color.Black;
            this.submenuRegistrarcompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuRegistrarcompra.Name = "submenuRegistrarcompra";
            this.submenuRegistrarcompra.Size = new System.Drawing.Size(128, 22);
            this.submenuRegistrarcompra.Text = "Registrar";
            this.submenuRegistrarcompra.Click += new System.EventHandler(this.submenuRegistrarcompra_Click);
            // 
            // submenuDetallecompra
            // 
            this.submenuDetallecompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuDetallecompra.IconColor = System.Drawing.Color.Black;
            this.submenuDetallecompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuDetallecompra.Name = "submenuDetallecompra";
            this.submenuDetallecompra.Size = new System.Drawing.Size(128, 22);
            this.submenuDetallecompra.Text = "Ver detalle";
            this.submenuDetallecompra.Click += new System.EventHandler(this.submenuDetallecompra_Click);
            // 
            // menuClientes
            // 
            this.menuClientes.AutoSize = false;
            this.menuClientes.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.menuClientes.IconColor = System.Drawing.Color.Black;
            this.menuClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuClientes.IconSize = 50;
            this.menuClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuClientes.Name = "menuClientes";
            this.menuClientes.Size = new System.Drawing.Size(122, 69);
            this.menuClientes.Text = "Clientes";
            this.menuClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuClientes.Click += new System.EventHandler(this.menuClientes_Click);
            // 
            // menuProveedores
            // 
            this.menuProveedores.AutoSize = false;
            this.menuProveedores.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.menuProveedores.IconColor = System.Drawing.Color.Black;
            this.menuProveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuProveedores.IconSize = 50;
            this.menuProveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuProveedores.Name = "menuProveedores";
            this.menuProveedores.Size = new System.Drawing.Size(122, 69);
            this.menuProveedores.Text = "Proveedores";
            this.menuProveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuProveedores.Click += new System.EventHandler(this.menuProveedores_Click);
            // 
            // menuReportes
            // 
            this.menuReportes.AutoSize = false;
            this.menuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenureportecompras,
            this.submenureporteventas});
            this.menuReportes.IconChar = FontAwesome.Sharp.IconChar.BarChart;
            this.menuReportes.IconColor = System.Drawing.Color.Black;
            this.menuReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuReportes.IconSize = 50;
            this.menuReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuReportes.Name = "menuReportes";
            this.menuReportes.Size = new System.Drawing.Size(122, 69);
            this.menuReportes.Text = "Reportes";
            this.menuReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenureportecompras
            // 
            this.submenureportecompras.Name = "submenureportecompras";
            this.submenureportecompras.Size = new System.Drawing.Size(180, 22);
            this.submenureportecompras.Text = "Reporte de compras";
            this.submenureportecompras.Click += new System.EventHandler(this.submenureportecompras_Click);
            // 
            // submenureporteventas
            // 
            this.submenureporteventas.Name = "submenureporteventas";
            this.submenureporteventas.Size = new System.Drawing.Size(180, 22);
            this.submenureporteventas.Text = "Reporte de ventas";
            this.submenureporteventas.Click += new System.EventHandler(this.submenureporteventas_Click);
            // 
            // menuAcercade
            // 
            this.menuAcercade.AutoSize = false;
            this.menuAcercade.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.menuAcercade.IconColor = System.Drawing.Color.Black;
            this.menuAcercade.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuAcercade.IconSize = 50;
            this.menuAcercade.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuAcercade.Name = "menuAcercade";
            this.menuAcercade.Size = new System.Drawing.Size(122, 69);
            this.menuAcercade.Text = "Acerca de";
            this.menuAcercade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuAcercade.Click += new System.EventHandler(this.menuAcercade_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.AutoSize = false;
            this.menuStrip2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip2.Size = new System.Drawing.Size(1333, 73);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menutitulo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(71, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Excellence System";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(947, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario: ";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblUsuario.Location = new System.Drawing.Point(1006, 20);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(71, 17);
            this.lblUsuario.TabIndex = 5;
            this.lblUsuario.Text = "lblUsuario";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.LOGO_EN_128_X_128_BLANCO_Mesa_de_trabajo_1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnsalir
            // 
            this.btnsalir.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnsalir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnsalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsalir.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.btnsalir.IconColor = System.Drawing.Color.White;
            this.btnsalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnsalir.Location = new System.Drawing.Point(1255, 12);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.btnsalir.Size = new System.Drawing.Size(66, 50);
            this.btnsalir.TabIndex = 7;
            this.btnsalir.UseVisualStyleBackColor = false;
            this.btnsalir.Click += new System.EventHandler(this.btnsalir_Click);
            // 
            // contenedor
            // 
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 142);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1333, 653);
            this.contenedor.TabIndex = 3;
            // 
            // marcaToolStripMenuItem
            // 
            this.marcaToolStripMenuItem.Name = "marcaToolStripMenuItem";
            this.marcaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.marcaToolStripMenuItem.Text = "Marca";
            this.marcaToolStripMenuItem.Click += new System.EventHandler(this.marcaToolStripMenuItem_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 795);
            this.Controls.Add(this.btnsalir);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menuStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private FontAwesome.Sharp.IconMenuItem menuUsuarios;
        private FontAwesome.Sharp.IconMenuItem menuMantenimiento;
        private FontAwesome.Sharp.IconMenuItem menuVentas;
        private FontAwesome.Sharp.IconMenuItem menuCompras;
        private FontAwesome.Sharp.IconMenuItem menuClientes;
        private FontAwesome.Sharp.IconMenuItem menuProveedores;
        private FontAwesome.Sharp.IconMenuItem menuReportes;
        private FontAwesome.Sharp.IconMenuItem menuAcercade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUsuario;
        private FontAwesome.Sharp.IconMenuItem submenuCategoria;
        private FontAwesome.Sharp.IconMenuItem submenuProducto;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconMenuItem submenuRegistrarventas;
        private FontAwesome.Sharp.IconMenuItem submenuDetalleVenta;
        private FontAwesome.Sharp.IconMenuItem submenuRegistrarcompra;
        private FontAwesome.Sharp.IconMenuItem submenuDetallecompra;
        private System.Windows.Forms.ToolStripMenuItem submenuEspecialidad;
        private System.Windows.Forms.ToolStripMenuItem submenunegocio;
        private System.Windows.Forms.ToolStripMenuItem submenureportecompras;
        private System.Windows.Forms.ToolStripMenuItem submenureporteventas;
        private FontAwesome.Sharp.IconButton btnsalir;
        private FontAwesome.Sharp.IconMenuItem menuServicioTecnico;
        private FontAwesome.Sharp.IconMenuItem submenuIngresoRecepcionEquipos;
        private FontAwesome.Sharp.IconMenuItem submenuReporteRecepcionServicioTecnico;
        private System.Windows.Forms.ToolStripMenuItem submenuIngresoOrdenServicio;
        private System.Windows.Forms.ToolStripMenuItem submenuHistorialIncidencias;
        private System.Windows.Forms.ToolStripMenuItem submenuCertificadosGarantia;
        private System.Windows.Forms.ToolStripMenuItem submenuReporteCertificadosGarantia;
        private System.Windows.Forms.ToolStripMenuItem submenuActualizarDatosBasicosOst;
        //dev-angel
        private System.Windows.Forms.ToolStripMenuItem equipoToolStripMenuItem;
        //develop
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.ToolStripMenuItem marcaToolStripMenuItem;
    }
}

