using System;
using System.Data.SqlClient;

namespace PeluqueriaElCojo.Datos
{
    /// <summary>
    /// Clase estática para manejar la conexión a SQL Server
    /// </summary>
    public static class Conexion
    {
        // ═══════════════════════════════════════════════════════
        // CADENA DE CONEXIÓN
        // ═══════════════════════════════════════════════════════

        // OPCIÓN 1: SQL Server con Autenticación de Windows
        private static readonly string _cadenaConexion =
            @"Server=DESKTOP-5MDNF5H;Database=PeluqueriaElCojo;Trusted_Connection=True;";

        // OPCIÓN 2: SQL Server con Usuario y Contraseña
        // private static readonly string _cadenaConexion = 
        //     @"Server=.\SQLEXPRESS;Database=PeluqueriaElCojo;User Id=sa;Password=TuPassword;";

        // OPCIÓN 3: SQL Server remoto
        // private static readonly string _cadenaConexion = 
        //     @"Server=192.168.1.100;Database=PeluqueriaElCojo;User Id=sa;Password=TuPassword;";

        /// <summary>
        /// Obtiene una nueva conexión a la base de datos
        /// </summary>
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_cadenaConexion);
        }

        /// <summary>
        /// Prueba la conexión a la base de datos
        /// </summary>
        public static bool ProbarConexion(out string mensaje)
        {
            try
            {
                using (SqlConnection conn = ObtenerConexion())
                {
                    conn.Open();
                    mensaje = "✅ Conexión exitosa a: " + conn.Database;
                    return true;
                }
            }
            catch (Exception ex)
            {
                mensaje = "❌ Error: " + ex.Message;
                return false;
            }
        }
    }
}