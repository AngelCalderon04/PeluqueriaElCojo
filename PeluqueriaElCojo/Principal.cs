using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeluqueriaElCojo
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmClientes frm = new FrmClientes();
            frm.ShowDialog();

        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            FrmEmpleados frm = new FrmEmpleados();
            frm.ShowDialog();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            FrmProductos frm = new FrmProductos();
            frm.ShowDialog();
        }

        private void CITAS_Click(object sender, EventArgs e)
        {
            FrmCitas frm = new FrmCitas();
            frm.ShowDialog();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            FrmFacturacion frm = new FrmFacturacion();
            frm.ShowDialog();
        }
    }
}
