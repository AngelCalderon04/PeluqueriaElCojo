using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using PeluqueriaElCojo.Atributos;

namespace PeluqueriaElCojo.Utilidades
{
    public static class GeneradorReportes
    {
        /// <summary>
        /// Genera una tabla de texto para cualquier lista de objetos
        /// usando Reflection para leer propiedades y atributos
        /// </summary>
        public static string GenerarTabla<T>(List<T> lista, string titulo)
        {
            if (lista == null || lista.Count == 0)
                return "No hay datos.";

            StringBuilder sb = new StringBuilder();
            Type tipo = typeof(T);

            // Obtener propiedades con [Reporte]
            List<ColumnaInfo> columnas = ObtenerColumnas(tipo);

            if (columnas.Count == 0)
                return "No hay columnas para reporte.";

            int anchoTotal = 1;
            foreach (ColumnaInfo c in columnas)
                anchoTotal += c.Ancho + 1;

            // Título
            sb.AppendLine("+" + new string('-', anchoTotal - 2) + "+");
            sb.AppendLine("|" + Centrar(titulo, anchoTotal - 2) + "|");
            sb.AppendLine("+" + new string('-', anchoTotal - 2) + "+");

            // Encabezados
            sb.Append("|");
            foreach (ColumnaInfo c in columnas)
                sb.Append(Ajustar(c.Nombre, c.Ancho) + "|");
            sb.AppendLine();

            sb.AppendLine("+" + new string('-', anchoTotal - 2) + "+");

            // Datos - REFLECTION EN ACCIÓN
            foreach (T item in lista)
            {
                sb.Append("|");
                foreach (ColumnaInfo c in columnas)
                {
                    // Obtener valor con Reflection
                    object valor = c.Propiedad.GetValue(item);
                    string texto = Formatear(valor, c.Formato);
                    sb.Append(Ajustar(texto, c.Ancho) + "|");
                }
                sb.AppendLine();
            }

            sb.AppendLine("+" + new string('-', anchoTotal - 2) + "+");
            sb.AppendLine(string.Format("Total registros: {0}", lista.Count));

            return sb.ToString();
        }

        private static List<ColumnaInfo> ObtenerColumnas(Type tipo)
        {
            List<ColumnaInfo> cols = new List<ColumnaInfo>();

            foreach (PropertyInfo prop in tipo.GetProperties())
            {
                // Buscar atributo [Reporte]
                object[] attrs = prop.GetCustomAttributes(
                    typeof(ReporteAttribute), true);

                if (attrs.Length > 0)
                {
                    ReporteAttribute rep = attrs[0] as ReporteAttribute;
                    if (rep != null && rep.Incluir)
                    {
                        ColumnaInfo col = new ColumnaInfo();
                        col.Propiedad = prop;
                        col.Ancho = rep.Ancho;
                        col.Formato = rep.Formato;

                        // Buscar nombre amigable
                        object[] nmAttrs = prop.GetCustomAttributes(
                            typeof(NombreMostrarAttribute), true);
                        if (nmAttrs.Length > 0)
                        {
                            NombreMostrarAttribute nm = nmAttrs[0] as NombreMostrarAttribute;
                            col.Nombre = nm.Nombre;
                        }
                        else
                        {
                            col.Nombre = prop.Name;
                        }

                        cols.Add(col);
                    }
                }
            }
            return cols;
        }

        private static string Formatear(object valor, string formato)
        {
            if (valor == null) return "";
            if (string.IsNullOrEmpty(formato)) return valor.ToString();

            if (valor is IFormattable f)
                return f.ToString(formato, null);

            return valor.ToString();
        }

        private static string Ajustar(string texto, int ancho)
        {
            if (texto == null) texto = "";
            if (texto.Length > ancho) texto = texto.Substring(0, ancho);
            return texto.PadRight(ancho);
        }

        private static string Centrar(string texto, int ancho)
        {
            if (texto.Length >= ancho) return texto;
            int pad = (ancho - texto.Length) / 2;
            return texto.PadLeft(pad + texto.Length).PadRight(ancho);
        }
    }

    internal class ColumnaInfo
    {
        public PropertyInfo Propiedad { get; set; }
        public string Nombre { get; set; }
        public int Ancho { get; set; }
        public string Formato { get; set; }
    }
}  