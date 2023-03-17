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
            if (objusuario == null) 
                usuarioActual = new Usuario() { NombreCompleto = "Admin predefinido", IdUsuario = 1 }; //Ingreso directo
            else
                usuarioActual = objusuario;

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
        //Menú

        //Usuarios
        private void menuUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmUsuarios());
        }

      
        //Mantenimiento
        private void submenuCategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuMantenimiento, new frmCategoria());
        }

        private void submenuProducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuMantenimiento, new frmProducto());
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

        private void submenunegocio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuMantenimiento, new frmNegocio());
        }

        private void submenureportecompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuReportes, new frmReporteCompras());
        }

        private void submenureporteventas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuReportes, new frmReporteVentas());
        }

        private void menuAcercade_Click(object sender, EventArgs e)
        {
            mdAcercade md = new mdAcercade();
            md.ShowDialog();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Desea salir?","Mensaje",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
