using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeluqueriaElCojo.Datos;
using PeluqueriaElCojo.Modelos;

namespace PeluqueriaElCojo
{
    public partial class FrmEmpleados : Form
    {
        private EmpleadoRepository _repo = new EmpleadoRepository();
        private Empleado empleadoActual = null;
        public FrmEmpleados()
        {
            InitializeComponent();
            FormHelper.PosicionFija(this);
        }

        private void CargarEmpleados()
        {
            dgvEmpleados.DataSource = null;
            dgvEmpleados.DataSource = _repo.ObtenerTodos();
            dgvEmpleados.ClearSelection();
        }

        private void CargarRoles()
        {
            cmbRol.DataSource = Enum.GetValues(typeof(RolEmpleado));
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            CargarRoles();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {


            try
            {
                if (empleadoActual == null)
                {
                    Empleado emp = new Empleado();
                    emp.Nombre = txtNombre.Text;
                    emp.Apodo = txtApodo.Text;
                    emp.Cedula = txtCedula.Text;
                    emp.Telefono = txtTelefono.Text;
                    emp.Rol = (RolEmpleado)cmbRol.SelectedItem;

                    _repo.Insertar(emp);
                    MessageBox.Show("Empleado agregado");
                }
                else
                {
                    empleadoActual.Nombre = txtNombre.Text;
                    empleadoActual.Apodo = txtApodo.Text;
                    empleadoActual.Cedula = txtCedula.Text;
                    empleadoActual.Telefono = txtTelefono.Text;
                    empleadoActual.Rol = (RolEmpleado)cmbRol.SelectedItem;

                    // 🔥 ESTO ES LO QUE TE FALTABA
                    _repo.Actualizar(empleadoActual);

                    MessageBox.Show("Empleado actualizado");

                    empleadoActual = null;
                }

                CargarEmpleados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmpleados.CurrentRow == null) return;

            empleadoActual = (Empleado)dgvEmpleados.CurrentRow.DataBoundItem;

            txtNombre.Text = empleadoActual.Nombre;
            txtApodo.Text = empleadoActual.Apodo;
            txtCedula.Text = empleadoActual.Cedula;
            txtTelefono.Text = empleadoActual.Telefono;
            cmbRol.SelectedItem = empleadoActual.Rol;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow == null) return;

            Empleado emp = (Empleado)dgvEmpleados.CurrentRow.DataBoundItem;

            // cuando hagamos delete en repo lo conectamos aquí
            MessageBox.Show("Eliminar pendiente");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (empleadoActual == null)
            {
                MessageBox.Show("Primero selecciona un empleado y dale a EDITAR.");
                return;
            }

            using (SqlConnection con = new SqlConnection(@"Server=DESKTOP-5MDNF5H;Database=PeluqueriaElCojo;Trusted_Connection=True;"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "UPDATE Empleados SET Nombre=@Nombre, Apodo=@Apodo, Cedula=@Cedula, Telefono=@Telefono, Rol=@Rol WHERE Id=@Id",
                    con);

                cmd.Parameters.AddWithValue("@Id", empleadoActual.Id);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Apodo", txtApodo.Text);
                cmd.Parameters.AddWithValue("@Cedula", txtCedula.Text);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);

                //  Convertir texto → número
                int rol = cmbRol.Text == "Barbero" ? 1 : 2;
                cmd.Parameters.AddWithValue("@Rol", rol);
               

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Empleado actualizado correctamente ✅");

            CargarEmpleados(); // refrescar tabla

            empleadoActual = null; // limpiar selección
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtApodo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            string numeros = new string(txtCedula.Text.Where(char.IsDigit).ToArray());

            if (numeros.Length > 11)
                numeros = numeros.Substring(0, 11);

            string formato = "";

            if (numeros.Length >= 1)
                formato = numeros.Substring(0, Math.Min(3, numeros.Length));

            if (numeros.Length > 3)
                formato += "-" + numeros.Substring(3, Math.Min(7, numeros.Length - 3));

            if (numeros.Length > 10)
                formato += "-" + numeros.Substring(10, Math.Min(1, numeros.Length - 10));

            txtCedula.Text = formato;
            txtCedula.SelectionStart = txtCedula.Text.Length;
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            string numeros = new string(txtTelefono.Text.Where(char.IsDigit).ToArray());

            if (numeros.Length > 12)
                numeros = numeros.Substring(0, 12);

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

        private void dgvEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            dgvEmpleados.ClearSelection();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

            if (dgvEmpleados.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un empleado primero");
                return;
            }

            empleadoActual = (Empleado)dgvEmpleados.CurrentRow.DataBoundItem;

            txtNombre.Text = empleadoActual.Nombre;
            txtApodo.Text = empleadoActual.Apodo;
            txtCedula.Text = empleadoActual.Cedula;
            txtTelefono.Text = empleadoActual.Telefono;
            cmbRol.SelectedItem = empleadoActual.Rol;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtApodo.Clear();
            txtCedula.Clear();
            txtTelefono.Clear();

            cmbRol.SelectedIndex = 0;

            empleadoActual = null;

            dgvEmpleados.ClearSelection();

            txtNombre.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
    
    
}
