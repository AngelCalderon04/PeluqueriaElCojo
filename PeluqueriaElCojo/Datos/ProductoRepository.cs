using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PeluqueriaElCojo.Modelos;

namespace PeluqueriaElCojo.Datos
{
    public class ProductoRepository
    {
        public List<Producto> ObtenerTodos()
        {
            List<Producto> lista = new List<Producto>();

            string sql = @"SELECT Id, Codigo, Nombre, Categoria, Precio, Costo, Stock, StockMinimo, Activo
                          FROM Productos WHERE Activo = 1 ORDER BY Nombre";

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Producto p = new Producto();
                        typeof(Producto).GetProperty("Id").SetValue(p, reader.GetInt32(0));
                        p.Codigo = reader.GetString(1);
                        p.Nombre = reader.GetString(2);
                        p.Categoria = (CategoriaProducto)reader.GetInt32(3);
                        p.Precio = reader.GetDecimal(4);
                        p.Costo = reader.GetDecimal(5);
                        p.Stock = reader.GetInt32(6);
                        p.StockMinimo = reader.GetInt32(7);
                        p.Activo = reader.GetBoolean(8);
                        lista.Add(p);
                    }
                }
            }
            return lista;
        }

        public List<Producto> ObtenerStockBajo()
        {
            List<Producto> lista = new List<Producto>();

            string sql = @"SELECT Id, Codigo, Nombre, Categoria, Precio, Costo, Stock, StockMinimo, Activo
                          FROM Productos 
                          WHERE Activo = 1 AND Stock <= StockMinimo 
                          ORDER BY Stock";

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Producto p = new Producto();
                        typeof(Producto).GetProperty("Id").SetValue(p, reader.GetInt32(0));
                        p.Codigo = reader.GetString(1);
                        p.Nombre = reader.GetString(2);
                        p.Categoria = (CategoriaProducto)reader.GetInt32(3);
                        p.Precio = reader.GetDecimal(4);
                        p.Costo = reader.GetDecimal(5);
                        p.Stock = reader.GetInt32(6);
                        p.StockMinimo = reader.GetInt32(7);
                        p.Activo = reader.GetBoolean(8);
                        lista.Add(p);
                    }
                }
            }
            return lista;
        }

        public bool ExisteCodigo(string codigo)
        {
            string sql = "SELECT COUNT(*) FROM Productos WHERE Codigo = @Codigo";

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Codigo", codigo);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public int Insertar(Producto p)
        {
            string sql = @"INSERT INTO Productos (Codigo, Nombre, Categoria, Precio, Costo, Stock, StockMinimo)
                          VALUES (@Codigo, @Nombre, @Categoria, @Precio, @Costo, @Stock, @StockMinimo);
                          SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Codigo", p.Codigo);
                    cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                    cmd.Parameters.AddWithValue("@Categoria", (int)p.Categoria);
                    cmd.Parameters.AddWithValue("@Precio", p.Precio);
                    cmd.Parameters.AddWithValue("@Costo", p.Costo);
                    cmd.Parameters.AddWithValue("@Stock", p.Stock);
                    cmd.Parameters.AddWithValue("@StockMinimo", p.StockMinimo);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}