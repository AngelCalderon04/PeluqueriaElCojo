using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeluqueriaElCojo.Modelos;

namespace PeluqueriaElCojo
{
    public partial class Form1 : Form
    {

        private List<Cliente> _clientes = new List<Cliente>();
        private List<Servicio> _servicios = new List<Servicio>();
        private Cliente _clienteActual = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente c = new Cliente(txtNombre.Text, txtTelefono.Text);
                _clientes.Add(c);
                lstClientes.Items.Add(c);
                txtNombre.Clear();
                txtTelefono.Clear();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void lstClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstClientes.SelectedIndex >= 0)
                _clienteActual = _clientes[lstClientes.SelectedIndex];
        }
    }
}
