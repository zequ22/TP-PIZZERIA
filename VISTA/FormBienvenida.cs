using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VISTA
{
    public partial class FormBienvenida : Form
    {
        public FormBienvenida()
        {
            InitializeComponent();
        }

        private void FormBienvenida_Load(object sender, EventArgs e)
        {

        }

        private void btnSALIR_Click(object sender, EventArgs e)
        {
            //Salir del programa
            Application.Exit();
        }

        private void btnINICIARSESION_Click(object sender, EventArgs e)
        {
            //Inicia el formulario de inicio de sesion
            FormLogin formuLogin = new FormLogin();
            formuLogin.Show();
        }

        private void btnREGISTRARME_Click(object sender, EventArgs e)
        {
            //Inicia el formulario de registro
            FormRegistro formuRegistro = new FormRegistro(new MODELO.CLIENTE(),MODELO.ACCION.AGREGAR);
            formuRegistro.Show();
        }
    }
}
