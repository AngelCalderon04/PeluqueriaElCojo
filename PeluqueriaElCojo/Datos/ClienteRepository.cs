using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PeluqueriaElCojo.Modelos;

namespace PeluqueriaElCojo.Datos
{
    public class ClienteRepository
    {
        // ═══════════════════════════════════════════════════════
        // OBTENER TODOS LOS CLIENTES
        // ═══════════════════════════════════════════════════════
        public List<Cliente> ObtenerTodos()
        {
            List<Cliente> lista = new List<Cliente>();

            string sql = @"SELECT Id, Nombre, Telefono, Tipo, Visitas, FechaRegistro, Activo 
                          FROM Clientes 
                          WHERE Activo = 1 
                          ORDER BY Nombre";

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente c = MapearCliente(reader);
                            lista.Add(c);
                        }
                    }
                }
            }

            return lista;
        }

        // ═══════════════════════════════════════════════════════
        // OBTENER POR ID
        // ═══════════════════════════════════════════════════════
        public Cliente ObtenerPorId(int id)
        {
            Cliente cliente = null;

            string sql = @"SELECT Id, Nombre, Telefono, Tipo, Visitas, FechaRegistro, Activo 
                          FROM Clientes 
                          WHERE Id = @Id";

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cliente = MapearCliente(reader);
                        }
                    }
                }
            }

            return cliente;
        }

        // ═══════════════════════════════════════════════════════
        // INSERTAR NUEVO CLIENTE
        // ═══════════════════════════════════════════════════════
        public int Insertar(Cliente cliente)
        {
            string sql = @"INSERT INTO Clientes (Nombre, Telefono, Tipo, Visitas)
                          VALUES (@Nombre, @Telefono, @Tipo, @Visitas);
                          SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@Tipo", (int)cliente.Tipo);
                    cmd.Parameters.AddWithValue("@Visitas", cliente.Visitas);

                    // Ejecutar y obtener el ID generado
                    object result = cmd.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
        }

        // ═══════════════════════════════════════════════════════
        // ACTUALIZAR CLIENTE
        // ═══════════════════════════════════════════════════════
        public bool Actualizar(Cliente cliente)
        {
            string sql = @"UPDATE Clientes 
                          SET Nombre = @Nombre, 
                              Telefono = @Telefono, 
                              Tipo = @Tipo, 
                              Visitas = @Visitas
                          WHERE Id = @Id";

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", cliente.Id);
                    cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@Tipo", (int)cliente.Tipo);
                    cmd.Parameters.AddWithValue("@Visitas", cliente.Visitas);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        // ═══════════════════════════════════════════════════════
        // ELIMINAR (Soft Delete)
        // ═══════════════════════════════════════════════════════
        public bool Eliminar(int id)
        {
            // Soft delete: solo marcamos como inactivo
            string sql = "UPDATE Clientes SET Activo = 0 WHERE Id = @Id";

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        // ═══════════════════════════════════════════════════════
        // BUSCAR POR NOMBRE O TELÉFONO
        // ═══════════════════════════════════════════════════════
        public List<Cliente> Buscar(string termino)
        {
            List<Cliente> lista = new List<Cliente>();

            string sql = @"SELECT Id, Nombre, Telefono, Tipo, Visitas, FechaRegistro, Activo 
                          FROM Clientes 
                          WHERE Activo = 1 
                            AND (Nombre LIKE @Termino OR Telefono LIKE @Termino)
                          ORDER BY Nombre";

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Termino", "%" + termino + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(MapearCliente(reader));
                        }
                    }
                }
            }

            return lista;
        }

        // ═══════════════════════════════════════════════════════
        // MÉTODO PRIVADO: Mapear DataReader a Objeto
        // ═══════════════════════════════════════════════════════
        private Cliente MapearCliente(SqlDataReader reader)
        {
            Cliente c = new Cliente();
        
            

            // Usamos reflection para setear el Id (es private set)
            typeof(Cliente).GetProperty("Id")
                .SetValue(c, reader.GetInt32(0));

            c.Nombre = reader.GetString(1);
            c.Telefono = reader.GetString(2);
            c.Tipo = (TipoCliente) reader.GetInt32(3);

            // Setear visitas via reflection
            typeof(Cliente).GetProperty("Visitas")
                .SetValue(c, reader.GetInt32(4));

            return c;
            
        }
    }
}