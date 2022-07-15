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
    public partial class FormRegistro : Form
    {
        CONTROLADORA.CLIENTES cCLIENTES;
        MODELO.CLIENTE oCLIENTE;

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
                /*
                if (ACCION == MODELO.ACCION.CONSULTAR)
                {
                    btnREGISTRARSE.Enabled = false;
                }*/
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
            oCLIENTE.CONTRASENIA = txtCONTRASEÑA.Text;
            oCLIENTE.DIRECCION = txtDOMICILIO.Text;

            //Si la operacion es la de Agregar, se agrega al banco
            if(ACCION == MODELO.ACCION.AGREGAR)
            {
                cCLIENTES.AGREGAR_CLIENTE(oCLIENTE);
            }
            else
            {
                cCLIENTES.MODIFICAR_CLIENTE(oCLIENTE);
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
