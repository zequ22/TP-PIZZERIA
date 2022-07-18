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
    public partial class FormABM : Form
    {
        //Declaro variables y metodos estaticos para aplicar el patron Singleton
        private static FormABM instancia;
        public static FormABM OBTENER_INSTANCIA()
        {
            if (instancia == null)
            {
                instancia = new FormABM();
            }
            if (instancia.IsDisposed)
            {
                instancia = new FormABM();
            }

            return instancia;
        }

        //Declaro variables temporales para crear los objetos del modelo
        private CONTROLADORA.CLIENTES cCLIENTES;
        private MODELO.CLIENTE oCLIENTE;

        //Indica la accion
        private MODELO.ACCION ACCION;

        private FormABM()
        {
            InitializeComponent();
            cCLIENTES = CONTROLADORA.CLIENTES.obtener_instancia();
            ARMAR_GRILLA();
        }

        private void ARMAR_GRILLA()
        {
            dgvABM.DataSource = null;
            dgvABM.DataSource = cCLIENTES.OBTENER_CLIENTES();
        }

        private void FormABM_Load(object sender, EventArgs e)
        {

        }

        private void btnSALIR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAGREGAR_Click(object sender, EventArgs e)
        {
            FormRegistro FormuRegistro = new FormRegistro(new MODELO.CLIENTE(), MODELO.ACCION.AGREGAR);
            DialogResult rta = FormuRegistro.ShowDialog();
            if (rta == DialogResult.OK)
            {
                ARMAR_GRILLA();
            }
        }

        private void btnMODIFICAR_Click(object sender, EventArgs e)
        {
            if (dgvABM.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar a un cliente del listado");
                return;
            }
            oCLIENTE = (MODELO.CLIENTE)dgvABM.CurrentRow.DataBoundItem;
            FormRegistro FormuRegistro = new FormRegistro(oCLIENTE, MODELO.ACCION.MODIFICAR);
            DialogResult rta = FormuRegistro.ShowDialog();
            if (rta == DialogResult.OK)
            {
                ARMAR_GRILLA();
            }
        }

        private void btnELIMINAR_Click(object sender, EventArgs e)
        {
            if (dgvABM.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar a un cliente del listado");
                return;
            }
            oCLIENTE = (MODELO.CLIENTE)dgvABM.CurrentRow.DataBoundItem;

            DialogResult rta = MessageBox.Show("Desea eliminar el cliente " + oCLIENTE.NOMBRE, "Atención!", MessageBoxButtons.YesNo);
            if (rta == DialogResult.Yes)
            {
                cCLIENTES.ELIMINAR_CLIENTE(oCLIENTE);
                ARMAR_GRILLA();
            }
        }
    }
}
