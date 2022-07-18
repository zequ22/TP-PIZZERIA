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
    public partial class FormLogin : Form
    {
        //Declaro variables y metodos estaticos para aplicar el patron Singleton
        private static FormLogin instancia;
        public static FormLogin OBTENER_INSTANCIA()
        {
            if (instancia == null)
            {
                instancia = new FormLogin();
            }
            if (instancia.IsDisposed)
            {
                instancia = new FormLogin();
            }

            return instancia;
        }

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnSALIR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnINGRESAR_Click(object sender, EventArgs e)
        {
            #region VALIDACIONES
            if (string.IsNullOrWhiteSpace(txtNOMBRE.Text))
            {
                MessageBox.Show("Ingrese el NOMBRE correctamente");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCONTRASEÑA.Text))
            {
                MessageBox.Show("Ingrese la CONTRASEÑA correctamente");
                return;
            }
            #endregion

            if (txtNOMBRE.Text == "admin1" && txtCONTRASEÑA.Text == "admin1")
            {
                FormABM formuABM = FormABM.OBTENER_INSTANCIA();
                formuABM.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Datos Incorrectos");
                LIMPIAR_CAMPOS();
                return;
            }
            
        }

        private void LIMPIAR_CAMPOS()
        {
            txtNOMBRE.Clear();
            txtCONTRASEÑA.Clear();
        }
    }
}
