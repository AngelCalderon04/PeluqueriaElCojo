using System;
using System.Collections.Generic;
using System.Text;
using PeluqueriaElCojo.Modelos;

namespace PeluqueriaElCojo.Utilidades
{
    public static class ReportesNegocio
    {
        // ══════════════════════════════════════════════════════
        // REPORTE: Ranking de Barberos
        // ══════════════════════════════════════════════════════
        public static string GenerarRankingBarberos(List<Empleado> empleados)
        {
            if (empleados == null || empleados.Count == 0)
                return "No hay empleados registrados.";

            // Filtrar solo barberos activos
            List<Empleado> barberos = new List<Empleado>();
            foreach (Empleado e in empleados)
            {
                if (e.Rol == RolEmpleado.Barbero && e.Activo)
                    barberos.Add(e);
            }

            if (barberos.Count == 0)
                return "No hay barberos activos.";

            // Ordenar usando IComparable (por ventas)
            barberos.Sort();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("╔══════════════════════════════════════════════╗");
            sb.AppendLine("║      🏆 RANKING DE BARBEROS DEL MES 🏆       ║");
            sb.AppendLine("╠══════════════════════════════════════════════╣");
            sb.AppendLine("║ #  │ Barbero          │ Ventas    │ Comisión ║");
            sb.AppendLine("╠════╪══════════════════╪═══════════╪══════════╣");

            int pos = 1;
            foreach (Empleado b in barberos)
            {
                string nombre = b.Apodo ?? b.Nombre;
                if (nombre.Length > 16) nombre = nombre.Substring(0, 16);

                string medalla = "";
                if (pos == 1) medalla = "🥇";
                else if (pos == 2) medalla = "🥈";
                else if (pos == 3) medalla = "🥉";

                sb.AppendLine(string.Format(
                    "║ {0}{1} │ {2,-16} │ {3,9:N0} │ {4,8:N0} ║",
                    medalla, pos, nombre, b.VentasMes, b.CalcularComision()));
                pos++;
            }

            sb.AppendLine("╚══════════════════════════════════════════════╝");
            return sb.ToString();
        }

        // ══════════════════════════════════════════════════════
        // REPORTE: Productos con Bajo Stock
        // ══════════════════════════════════════════════════════
        public static string GenerarAlertaStock(List<Producto> productos)
        {
            if (productos == null || productos.Count == 0)
                return "No hay productos registrados.";

            List<Producto> bajoStock = new List<Producto>();
            foreach (Producto p in productos)
            {
                if (p.RequiereReposicion && p.Activo)
                    bajoStock.Add(p);
            }

            if (bajoStock.Count == 0)
                return "✅ Todos los productos tienen stock suficiente.";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("╔══════════════════════════════════════════════╗");
            sb.AppendLine("║     ⚠️ ALERTA: PRODUCTOS CON BAJO STOCK ⚠️   ║");
            sb.AppendLine("╠══════════════════════════════════════════════╣");
            sb.AppendLine("║ Código    │ Producto         │ Stock │ Min  ║");
            sb.AppendLine("╠═══════════╪══════════════════╪═══════╪══════╣");

            foreach (Producto p in bajoStock)
            {
                string nombre = p.Nombre;
                if (nombre.Length > 16) nombre = nombre.Substring(0, 16);
                string codigo = p.Codigo;
                if (codigo.Length > 9) codigo = codigo.Substring(0, 9);

                sb.AppendLine(string.Format(
                    "║ {0,-9} │ {1,-16} │ {2,5} │ {3,4} ║",
                    codigo, nombre, p.Stock, p.StockMinimo));
            }

            sb.AppendLine("╚══════════════════════════════════════════════╝");
            sb.AppendLine(string.Format("Total productos con bajo stock: {0}", bajoStock.Count));

            return sb.ToString();
        }

        // ══════════════════════════════════════════════════════
        // REPORTE: Resumen de Citas del Día
        // ══════════════════════════════════════════════════════
        public static string GenerarResumenCitas(List<Cita> citas, DateTime fecha)
        {
            if (citas == null || citas.Count == 0)
                return "No hay citas registradas.";

            List<Cita> citasHoy = new List<Cita>();
            foreach (Cita c in citas)
            {
                if (c.Fecha.Date == fecha.Date)
                    citasHoy.Add(c);
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("╔══════════════════════════════════════════════════════╗");
            sb.AppendLine(string.Format(
                "║         📅 AGENDA DEL {0:dd/MM/yyyy}                  ║", fecha));
            sb.AppendLine("╠══════════════════════════════════════════════════════╣");

            if (citasHoy.Count == 0)
            {
                sb.AppendLine("║           No hay citas para esta fecha               ║");
            }
            else
            {
                sb.AppendLine("║ Hora  │ Cliente          │ Barbero    │ Estado     ║");
                sb.AppendLine("╠═══════╪══════════════════╪════════════╪════════════╣");

                foreach (Cita c in citasHoy)
                {
                    string cliente = c.Cliente != null ? c.Cliente.Nombre : "?";
                    string barbero = c.Barbero != null ?
                        (c.Barbero.Apodo ?? c.Barbero.Nombre) : "?";

                    if (cliente.Length > 16) cliente = cliente.Substring(0, 16);
                    if (barbero.Length > 10) barbero = barbero.Substring(0, 10);

                    sb.AppendLine(string.Format(
                        "║ {0:hh\\:mm} │ {1,-16} │ {2,-10} │ {3,-10} ║",
                        c.Hora, cliente, barbero, c.Estado));
                }
            }

            sb.AppendLine("╚══════════════════════════════════════════════════════╝");

            // Estadísticas
            int pendientes = 0, completadas = 0, canceladas = 0;
            foreach (Cita c in citasHoy)
            {
                if (c.Estado == EstadoCita.Pendiente || c.Estado == EstadoCita.Confirmada)
                    pendientes++;
                else if (c.Estado == EstadoCita.Completada)
                    completadas++;
                else if (c.Estado == EstadoCita.Cancelada)
                    canceladas++;
            }

            sb.AppendLine(string.Format(
                "Total: {0} | Pendientes: {1} | Completadas: {2} | Canceladas: {3}",
                citasHoy.Count, pendientes, completadas, canceladas));

            return sb.ToString();
        }
    }
}