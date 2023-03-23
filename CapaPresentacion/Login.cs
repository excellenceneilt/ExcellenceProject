using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            //List<Usuario> TEST = new CN_Usuario().Listar();
            //Expresiones landa para tomar acciones respecto a listas, se automatiza la búsqueda de un objeto y devuelve el primero que encuentre o null
            Usuario oUsuario = new CN_Usuario().Listar().Where(u => u.Documento == txtDocumento.Text && u.Clave == txtClave.Text).FirstOrDefault();

            if (oUsuario != null)
            {

                Inicio form = new Inicio(oUsuario);
                form.Show();
                this.Hide();

                form.FormClosing += frm_closing;
            }
            else
            {
                MessageBox.Show("No se ha encontrado el usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
         }          

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            txtDocumento.Text = "";
            txtClave.Text = "";
            this.Show();

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
