using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace VISTA
{
    public partial class FormRegistro : Form
    {
        //Declaro variables temporales para crear los objetos del modelo
        CONTROLADORA.CLIENTES cCLIENTES;
        MODELO.CLIENTE oCLIENTE;
        //Variable para la accion
        MODELO.ACCION ACCION;

        public FormRegistro(MODELO.CLIENTE miCLIENTE, MODELO.ACCION miACCION)
        {
            InitializeComponent();

            cCLIENTES = CONTROLADORA.CLIENTES.obtener_instancia();
            oCLIENTE = miCLIENTE;
            ACCION = miACCION;

            if(ACCION != MODELO.ACCION.AGREGAR)
            {
                txtNOMBRE.Text = oCLIENTE.NOMBRE;
                txtDOMICILIO.Text = oCLIENTE.DIRECCION;
                txtTEL.Text = oCLIENTE.TEL.ToString();
                txtMAIL.Text = oCLIENTE.EMAIL;
                txtDNI.Text = oCLIENTE.DNI.ToString();
                txtCONTRASEÑA.Text = oCLIENTE.CONTRASENIA;

                btnREGISTRARSE.Text = "Modificar";
            }
        }

        private void FormRegistro_Load(object sender, EventArgs e)
        {

        }

        private void btnSALIR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnREGISTRARSE_Click(object sender, EventArgs e)
        {
            #region VALIDACIONES
            int DNI;
            if(!int.TryParse(txtDNI.Text, out DNI))
            {
                MessageBox.Show("Ingrese el DNI correctamente");
                return;
            }
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
            if (string.IsNullOrEmpty(txtDOMICILIO.Text))
            {
                MessageBox.Show("Ingrese el DOMICILIO correctamente");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMAIL.Text))
            {
                MessageBox.Show("Ingrese el MAIL correctamente");
                return;
            }
            int TEL;
            if (!int.TryParse(txtTEL.Text, out TEL))
            {
                MessageBox.Show("Ingrese el TELEFONO correctamente");
                return;
            }
            #endregion

            //Asignacion de valores a los atributos del objeto
            oCLIENTE.NOMBRE = txtNOMBRE.Text.ToUpper();
            oCLIENTE.DNI = DNI;
            oCLIENTE.TEL = TEL;
            oCLIENTE.EMAIL = txtMAIL.Text;
            oCLIENTE.CONTRASENIA = encriptar(txtCONTRASEÑA.Text);
            oCLIENTE.DIRECCION = txtDOMICILIO.Text;

            //Si la operacion es la de Agregar, se agrega al banco
            if(ACCION == MODELO.ACCION.AGREGAR)
            {
                cCLIENTES.AGREGAR_CLIENTE(oCLIENTE);
                MessageBox.Show("Registro Exitoso");
                LIMPIAR_CAMPOS();
                this.Close();
            }
            else
            {
                cCLIENTES.MODIFICAR_CLIENTE(oCLIENTE);
                MessageBox.Show("Cambio Exitoso");
                LIMPIAR_CAMPOS();
                this.Close();
            }

            this.DialogResult = DialogResult.OK;
            
        }

        private void btnLIMPIAR_Click(object sender, EventArgs e)
        {
            LIMPIAR_CAMPOS();
        }

        private void LIMPIAR_CAMPOS()
        {
            txtNOMBRE.Clear();
            txtMAIL.Clear();
            txtCONTRASEÑA.Clear();
            txtTEL.Clear();
            txtDOMICILIO.Clear();
            txtDNI.Clear();
        }

        static public string encriptar(string passVista)
        {
            string passEncriptado;
            passEncriptado = string.Empty;
            SHA512 sha512 = SHA512.Create();

            UTF8Encoding encoding = new UTF8Encoding();

            byte[] stream = null;

            StringBuilder sb = new StringBuilder();
            stream = sha512.ComputeHash(encoding.GetBytes(passVista));

            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x1}", stream[i]);
            }

            return passEncriptado = sb.ToString();

        }

    }
}
