using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


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

        SqlConnection coneccion = new SqlConnection("server=EZE-ASUS ; database = PIZZERIA ; INTEGRATED SECURITY = true");

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
            try
            {
                logins();
            }
            catch
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
            }
        }

        private void LIMPIAR_CAMPOS()
        {
            txtNOMBRE.Clear();
            txtCONTRASEÑA.Clear();
        }

        public void logins()
        {
            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["PIZZERIA"].ConnectionString;
                using(SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT NOMBRE, CONTRASENIA FROM CLIENTEs WHERE NOMBRE='"+txtNOMBRE.Text+"' AND CONTRASENIA='" + txtCONTRASEÑA.Text + "'", conexion))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            if(txtNOMBRE.Text=="admin1"&& txtCONTRASEÑA.Text == "admin1")
                            {
                                FormABM formuABM = FormABM.OBTENER_INSTANCIA();
                                formuABM.Show();
                                this.Close();
                            }
                            else
                            {
                                FormBeneficios FormuBeneficios = new FormBeneficios();
                                FormuBeneficios.Show();
                            }
                            this.Close();
                            
                        }
                        else
                        {
                            MessageBox.Show("Datos Incorrectos");
                            LIMPIAR_CAMPOS();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegistro formuRegistro = new FormRegistro(new MODELO.CLIENTE(), MODELO.ACCION.AGREGAR);
            formuRegistro.Show();
            this.Close();
        }
    }
}
