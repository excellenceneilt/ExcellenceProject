using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using FontAwesome.Sharp;
using CapaNegocio;
using CapaPresentacion.Modales;

namespace CapaPresentacion
{
    public partial class Inicio : Form
    {

        private static Usuario usuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;
    
        public Inicio(Usuario objusuario = null) //Quitar null después de pruebas
        {
            //PARA PRUEBAS CON LOGIN BORRAR DESDE AQUÍ
            if (objusuario == null) 
                usuarioActual = new Usuario() { NombreCompleto = "Admin predefinido", IdUsuario = 1 }; //Ingreso directo
            else
                usuarioActual = objusuario;
            //HASTA ACÁ

           // usuarioActual = objusuario;
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> ListaPermisos = new CN_Permiso().Listar(usuarioActual.IdUsuario);

            
            //Recorre cada item contenido en el menu:name
            foreach (IconMenuItem iconmenu in menu.Items)
            {
                bool encontrado = ListaPermisos.Any(m => m.NombreMenu == iconmenu.Name);
                if (encontrado == false)
                {
                    iconmenu.Visible= false;
                }
            }
            lblUsuario.Text = usuarioActual.NombreCompleto.ToString();
        }

        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }

            menu.BackColor = Color.Silver;
            MenuActivo = menu;

            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }
            FormularioActivo = formulario;
            formulario.TopLevel= false;
            formulario.FormBorderStyle= FormBorderStyle.None;
            formulario.Dock= DockStyle.Fill;
            formulario.BackColor= Color.CornflowerBlue;
           contenedor.Controls.Add(formulario);
            formulario.Show();
        }
        
        #region MENÚ 

        //Usuarios
        private void menuUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmUsuarios());
        }
        //Mantenimiento
        private void menuClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmClientes());
        }
        private void menuProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmProveedores());
        }
        private void submenuEspecialidad_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuMantenimiento, new frmEspecialidad());
        }

        #endregion

        #region SUBMENU
        //Mantenimiento
        private void submenuCategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuMantenimiento, new frmCategoria());
        }
        private void submenuProducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuMantenimiento, new frmProducto());
        }
        private void equipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuMantenimiento, new frmEquipo());
        }
        //Ventas
        private void submenuRegistrarventas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuVentas, new frmVentas(usuarioActual));
        }
        private void submenuDetalleVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuVentas, new frmDetalleVenta());
        }
        //Compras
        private void submenuRegistrarcompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuCompras, new frmCompras(usuarioActual));
        }
        private void submenuDetallecompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuCompras, new frmDetalleCompra());
        }
        #endregion

        private void submenureportecompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuReportes, new frmReporteCompras());
        }

        private void submenureporteventas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuReportes, new frmReporteVentas());
        }

        private void submenunegocio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuMantenimiento, new frmNegocio());
        }

        private void menuAcercade_Click(object sender, EventArgs e)
        {
            mdAcercade md=new mdAcercade();
            md.ShowDialog();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas salir?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void iconMenuItem1_Click(object sender, EventArgs e)
        {

        }

        //SERVICIO TECNICO
        private void submenuIngresoRecepcionEquipos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuServicioTecnico, new frmRecepcionServicioTecnico());
        }
        private void submenuReporteRecepcionServicioTecnico_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuServicioTecnico, new frmRegistroRecepcionST());
        }
        private void submenuIngresoOrdenServicio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuServicioTecnico, new frmOrdenST());
        }
        private void submenuHistorialIncidencias_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuServicioTecnico, new frmHistorialIncidencias());
        }
        private void submenuCertificadosGarantia_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuServicioTecnico, new frmCertifiadoGarantia());
        }
        private void submenuReporteCertificadosGarantia_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuServicioTecnico, new frmReporteDatos());
        }

        private void submenuActualizarDatosBasicosOst_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuServicioTecnico, new frmMantenimientoTablas());
        }
    }
}
