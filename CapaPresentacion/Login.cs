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
using CapaPresentacion.Utilidades;
using System.Runtime.InteropServices;

namespace CapaPresentacion
{
    public partial class Login : Form
    {

        //Rounded corner
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        //End Rounded corner

        

        public Login()
        {   //Rounded corner
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 584, 242, 20, 20));
            //End Rounded corner


            InitializeComponent();
            //Se crea la lista
            List<Usuario> listaUsuario = new CN_Usuario().Listar();
            //Se recorre la lista
            foreach (Usuario item in listaUsuario)
            {
                cbousuario.Items.Add(new OpcionCombo() { Valor = item.IdUsuario, Texto = item.Documento });
            }
            cbousuario.DisplayMember = "Texto";
            cbousuario.ValueMember = "Valor";
            cbousuario.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            

            List<Usuario> TEST = new CN_Usuario().Listar();

            

            //Expresiones landa para tomar acciones respecto a listas, se automatiza la búsqueda de un objeto y devuelve el primero que encuentre o null
            Usuario oUsuario = new CN_Usuario().Listar().Where(u => u.Documento == cbousuario.Text && u.Clave == txtClave.Text).FirstOrDefault();

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
           // txtDocumento.Text = "";
            txtClave.Text = "";
            this.Show();

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
