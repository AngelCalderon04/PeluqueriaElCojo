using System;
using PeluqueriaElcojo.Atributos;
using PeluqueriaElCojo.Atributos;

namespace PeluqueriaElCojo.Modelos
{
    public class Producto : IEquatable<Producto>
    {
        private static int _contadorId = 0;

        // ══════════════════════════════════════════════════════
        // PROPIEDADES
        // ══════════════════════════════════════════════════════

        [Ocultar]
        [Reporte(Ancho = 4)]
        public int Id { get; private set; }

        [NombreMostrar("Código")]
        [Requerido]
        [Longitud(4, 20)]
        [Reporte(Ancho = 12)]
        public string Codigo { get; set; }

        [NombreMostrar("Nombre")]
        [Requerido]
        [Longitud(3, 50)]
        [Reporte(Ancho = 20)]
        public string Nombre { get; set; }

        [NombreMostrar("Categoría")]
        [Reporte(Ancho = 12)]
        public CategoriaProducto Categoria { get; set; }

        [NombreMostrar("Precio")]
        [Rango(1, 50000)]
        [Reporte(Formato = "N0", Ancho = 10)]
        public decimal Precio { get; set; }

        [NombreMostrar("Costo")]
        [Rango(1, 50000)]
        [Reporte(Formato = "N0", Ancho = 10)]
        public decimal Costo { get; set; }

        [NombreMostrar("Stock")]
        [Rango(0, 9999)]
        [Reporte(Ancho = 6)]
        public int Stock { get; set; }

        [NombreMostrar("Stock Mínimo")]
        [Rango(0, 100)]
        public int StockMinimo { get; set; }

        [NombreMostrar("Activo")]
        public bool Activo { get; set; }

        // ══════════════════════════════════════════════════════
        // CONSTRUCTOR
        // ══════════════════════════════════════════════════════
        public Producto()
        {
            Id = ++_contadorId;
            Activo = true;
            StockMinimo = 5;
            Categoria = CategoriaProducto.Otros;
        }

        // ══════════════════════════════════════════════════════
        // IEquatable - Comparar por CÓDIGO
        // ══════════════════════════════════════════════════════
        public bool Equals(Producto otro)
        {
            if (otro == null) return false;
            // Dos productos son iguales si tienen el mismo código
            return string.Equals(this.Codigo, otro.Codigo,
                StringComparison.OrdinalIgnoreCase);
        }

        // También sobrescribimos Equals(object) y GetHashCode
        public override bool Equals(object obj)
        {
            return Equals(obj as Producto);
        }

        public override int GetHashCode()
        {
            if (Codigo == null) return 0;
            return Codigo.ToUpperInvariant().GetHashCode();
        }

        // ══════════════════════════════════════════════════════
        // PROPIEDADES CALCULADAS
        // ══════════════════════════════════════════════════════
        public decimal Ganancia
        {
            get { return Precio - Costo; }
        }

        public decimal MargenPorcentaje
        {
            get
            {
                if (Costo == 0) return 0;
                return (Ganancia / Costo) * 100;
            }
        }

        public bool RequiereReposicion
        {
            get { return Stock <= StockMinimo; }
        }

        public decimal ValorInventario
        {
            get { return Stock * Costo; }
        }

        // ══════════════════════════════════════════════════════
        // MÉTODOS
        // ══════════════════════════════════════════════════════
        public void AgregarStock(int cantidad)
        {
            if (cantidad > 0)
                Stock += cantidad;
        }

        public bool DescontarStock(int cantidad)
        {
            if (cantidad > 0 && Stock >= cantidad)
            {
                Stock -= cantidad;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return string.Format("[{0}] {1} - RD${2:N0} (Stock: {3})",
                Codigo, Nombre, Precio, Stock);
        }
    }
}