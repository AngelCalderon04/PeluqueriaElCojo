using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeluqueriaElCojo.Datos;
using PeluqueriaElCojo.Modelos;

namespace PeluqueriaElCojo
{
   
    public partial class FrmClientes : Form

    {
        private ClienteRepository _repo = new ClienteRepository();
        private Cliente clienteActual = null;
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void CargarClientes()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = _repo.ObtenerTodos();

            dgvClientes.Columns["Id"].Visible = true;
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (clienteActual == null)
                {
                    Cliente nuevo = new Cliente();
                    nuevo.Nombre = txtNombre.Text;
                    nuevo.Telefono = txtTelefono.Text;

                    _repo.Insertar(nuevo);
                    MessageBox.Show("Cliente agregado");
                }
                else
                {
                    clienteActual.Nombre = txtNombre.Text;
                    clienteActual.Telefono = txtTelefono.Text;

                    _repo.Actualizar(clienteActual);
                    MessageBox.Show("Cliente actualizado");

                    clienteActual = null;
                }

                CargarClientes();
                txtNombre.Clear();
                txtTelefono.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (dgvClientes.CurrentRow == null) return;

            clienteActual = (Cliente)dgvClientes.CurrentRow.DataBoundItem;

            txtNombre.Text = clienteActual.Nombre;
            txtTelefono.Text = clienteActual.Telefono;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;

            Cliente seleccionado = (Cliente)dgvClientes.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show("¿Eliminar cliente?", "Confirmar", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                _repo.Eliminar(seleccionado.Id);
                CargarClientes();
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, espacios y borrar
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo números y backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            string numeros = new string(txtTelefono.Text.Where(char.IsDigit).ToArray());

            if (numeros.Length > 10)
                numeros = numeros.Substring(0, 10);

            string formato = "";

            if (numeros.Length >= 1)
                formato = numeros.Substring(0, Math.Min(3, numeros.Length));

            if (numeros.Length > 3)
                formato += "-" + numeros.Substring(3, Math.Min(3, numeros.Length - 3));

            if (numeros.Length > 6)
                formato += "-" + numeros.Substring(6, Math.Min(4, numeros.Length - 6));

            txtTelefono.Text = formato;
            txtTelefono.SelectionStart = txtTelefono.Text.Length;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un cliente");
                return;
            }

            clienteActual = (Cliente)dgvClientes.CurrentRow.DataBoundItem;

            txtNombre.Text = clienteActual.Nombre;
            txtTelefono.Text = clienteActual.Telefono; 
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtTelefono.Clear();

            clienteActual = null;

            dgvClientes.ClearSelection();

            txtNombre.Focus();
        }
    }
    
}
