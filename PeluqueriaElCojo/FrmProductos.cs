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
    public partial class FrmProductos : Form
    {
        private ProductoRepository _repo = new ProductoRepository();
        private Producto productoActual = null;
        private void CargarProductos()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = _repo.ObtenerTodos();

            dgvProductos.ReadOnly = true;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;

            dgvProductos.ClearSelection();
            dgvProductos.DefaultCellStyle.SelectionBackColor = dgvProductos.DefaultCellStyle.BackColor;

            dgvProductos.Columns["Codigo"].HeaderText = "Código";
            dgvProductos.Columns["Nombre"].HeaderText = "Nombre";
            dgvProductos.Columns["Categoria"].HeaderText = "Categoría";
            dgvProductos.Columns["Precio"].HeaderText = "Precio";
            dgvProductos.Columns["Costo"].HeaderText = "Costo";
            dgvProductos.Columns["Stock"].HeaderText = "Stock";
            dgvProductos.Columns["StockMinimo"].HeaderText = "Stock Mínimo";


        }

        private void CargarCategorias()
        {
            cmbCategoria.DataSource = Enum.GetValues(typeof(CategoriaProducto));
        }
        public FrmProductos()
        {
            InitializeComponent();


        }





        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)8)
    {
                e.Handled = true;
            }

            // evitar más de un punto
            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)8)
    {
                e.Handled = true;
            }

            // evitar más de un punto
            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtStockMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (productoActual == null)
                {
                    Producto p = new Producto();
                    p.Codigo = txtCodigo.Text;
                    p.Nombre = txtNombre.Text;
                    p.Categoria = (CategoriaProducto)cmbCategoria.SelectedItem;
                    p.Precio = decimal.Parse(txtPrecio.Text);
                    p.Costo = decimal.Parse(txtCosto.Text);
                    p.Stock = int.Parse(txtStock.Text);
                    p.StockMinimo = int.Parse(txtStockMinimo.Text);

                    _repo.Insertar(p);
                    MessageBox.Show("Producto agregado");
                }
                else
                {
                    productoActual.Codigo = txtCodigo.Text;
                    productoActual.Nombre = txtNombre.Text;
                    productoActual.Categoria = (CategoriaProducto)cmbCategoria.SelectedItem;
                    productoActual.Precio = decimal.Parse(txtPrecio.Text);
                    productoActual.Costo = decimal.Parse(txtCosto.Text);
                    productoActual.Stock = int.Parse(txtStock.Text);
                    productoActual.StockMinimo = int.Parse(txtStockMinimo.Text);

                    productoActual.Categoria = (CategoriaProducto)cmbCategoria.SelectedItem;

                    
                    _repo.Actualizar(productoActual);

                    MessageBox.Show("Producto actualizado");

                    productoActual = null;
                }

                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPrecio.Text, out decimal precio) &&
        decimal.TryParse(txtCosto.Text, out decimal costo))
            {
                if (precio <= costo)
                {
                    MessageBox.Show("El precio debe ser mayor que el costo");
                }
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void btnEditar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
          


        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();
           // CargarCategorias();
            cmbCategoria.DataSource = Enum.GetValues(typeof(CategoriaProducto));
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnSeleccionar_Click(null, null);

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un producto");
                return;
            }

            productoActual = (Producto)dgvProductos.CurrentRow.DataBoundItem;

            txtCodigo.Text = productoActual.Codigo;
            txtNombre.Text = productoActual.Nombre;
            txtPrecio.Text = productoActual.Precio.ToString();
            txtCosto.Text = productoActual.Costo.ToString();
            txtStock.Text = productoActual.Stock.ToString();
            txtStockMinimo.Text = productoActual.StockMinimo.ToString();


            cmbCategoria.SelectedIndex = (int)productoActual.Categoria;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un producto");
                return;
            }

            Producto p = (Producto)dgvProductos.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show("¿Eliminar producto?", "Confirmar", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                _repo.Eliminar(p.Id);
                CargarProductos();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtCosto.Clear();
            txtStock.Clear();
            txtStockMinimo.Clear();

            cmbCategoria.SelectedIndex = 0;

            productoActual = null;

            dgvProductos.ClearSelection();

            txtCodigo.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
