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
    public partial class FrmCitas : Form
    {
        private List<Cita> _citas = new List<Cita>();

        private ClienteRepository _clienteRepo = new ClienteRepository();
        private EmpleadoRepository _empleadoRepo = new EmpleadoRepository();

        public FrmCitas()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CargarClientes()
        {
            cmbClientes.DataSource = null;
            cmbClientes.DataSource = _clienteRepo.ObtenerTodos();
        }

        private void CargarEmpleados()
        {
            cmbEmpleados.DataSource = null;
            cmbEmpleados.DataSource = _empleadoRepo.ObtenerTodos();
        }

        private void FrmCitas_Load(object sender, EventArgs e)
        {
            cmbClientes.DataSource = _clienteRepo.ObtenerTodos();
            cmbEmpleados.DataSource = _empleadoRepo.ObtenerTodos();

            CargarClientes();
            CargarEmpleados();

        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedItem == null || cmbEmpleados.SelectedItem == null)
            {
                MessageBox.Show("Selecciona cliente y barbero");
                return;
            }

            Cita cita = new Cita();

            cita.Cliente = (Cliente)cmbClientes.SelectedItem;
            cita.Barbero = (Empleado)cmbEmpleados.SelectedItem;

            cita.Fecha = dtpFecha.Value.Date;
            //cita.Hora = dtpHora.Value.TimeOfDay;


            

            _citas.Add(cita);

            dgvCitas.DataSource = null;
            dgvCitas.DataSource = _citas;

            MessageBox.Show("Cita agendada correctamente");

            bool existe = _citas.Any(c =>
            c.Barbero == (Empleado)cmbEmpleados.SelectedItem &&
            c.FechaHoraCompleta == cita.FechaHoraCompleta);

            if (existe)
            {
                MessageBox.Show("Ese horario ya está ocupado");
                return;
            }

            if (cmbClientes.SelectedItem == null || cmbEmpleados.SelectedItem == null)
            {
                MessageBox.Show("Selecciona cliente y barbero");
                return;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una cita");
                return;
            }

            Cita cita = (Cita)dgvCitas.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show("¿Eliminar esta cita?", "Confirmar", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                _citas.Remove(cita);

                dgvCitas.DataSource = null;
                dgvCitas.DataSource = _citas;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbClientes.SelectedIndex = -1;
            cmbEmpleados.SelectedIndex = -1;

            dtpFecha.Value = DateTime.Now;

           

        }
    }
}
