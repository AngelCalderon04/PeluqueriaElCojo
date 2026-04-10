using System;
using PeluqueriaElcojo.Atributos;
using PeluqueriaElCojo.Atributos;

namespace PeluqueriaElCojo.Modelos
{
    // Implementamos IComparable para ordenar e ICloneable para copiar
    public class Empleado : IComparable<Empleado>, ICloneable
    {
        private static int _contadorId = 0;

        // ══════════════════════════════════════════════════════
        // PROPIEDADES CON ATRIBUTOS
        // ══════════════════════════════════════════════════════

        [Ocultar]
        [Reporte(Incluir = true, Ancho = 4)]
        public int Id { get; private set; }

        [NombreMostrar("Nombre", Orden = 1)]
        [Requerido]
        [Longitud(3, 50)]
        [Reporte(Ancho = 20)]
        public string Nombre { get; set; }

        [NombreMostrar("Apodo", Orden = 2)]
        [Reporte(Ancho = 12)]
        public string Apodo { get; set; }

        [NombreMostrar("Cédula", Orden = 3)]
        [Requerido]
        [Longitud(11, 13)]
        public string Cedula { get; set; }

        [NombreMostrar("Teléfono", Orden = 4)]
        [TelefonoDominicano]
        [Reporte(Ancho = 12)]
        public string Telefono { get; set; }

        [NombreMostrar("Rol", Orden = 5)]
        [Reporte(Ancho = 14)]
        public RolEmpleado Rol { get; set; }

        [NombreMostrar("Salario", Orden = 6)]
        [Rango(15000, 100000)]
        [Reporte(Formato = "N0", Ancho = 10)]
        public decimal SalarioBase { get; set; }

        [NombreMostrar("Comisión %", Orden = 7)]
        [Rango(0, 50)]
        public decimal PorcentajeComision { get; set; }

        [NombreMostrar("Fecha Ingreso")]
        [SoloLectura]
        public DateTime FechaIngreso { get; private set; }

        [NombreMostrar("Activo")]
        public bool Activo { get; set; }

        // Ventas del mes (calculado, no guardado)
        [Reporte(Formato = "N0", Ancho = 12)]
        [NombreMostrar("Ventas Mes")]
        public decimal VentasMes { get; set; }

        // ══════════════════════════════════════════════════════
        // CONSTRUCTOR
        // ══════════════════════════════════════════════════════
        public Empleado()
        {
            Id = ++_contadorId;
            FechaIngreso = DateTime.Now;
            Activo = true;
            Rol = RolEmpleado.Barbero;
            PorcentajeComision = 10;
            SalarioBase = 20000;
        }

        // ══════════════════════════════════════════════════════
        // IComparable - Ordenar por VENTAS (mayor primero)
        // ══════════════════════════════════════════════════════
        public int CompareTo(Empleado otro)
        {
            if (otro == null) return 1;
            // Descendente: el de más ventas va primero
            return otro.VentasMes.CompareTo(this.VentasMes);
        }

        // ══════════════════════════════════════════════════════
        // ICloneable - Crear copia del empleado
        // ══════════════════════════════════════════════════════
        public object Clone()
        {
            Empleado copia = new Empleado();
            copia.Nombre = this.Nombre + " (Copia)";
            copia.Apodo = this.Apodo;
            copia.Cedula = "";  // Cédula vacía, es única
            copia.Telefono = this.Telefono;
            copia.Rol = this.Rol;
            copia.SalarioBase = this.SalarioBase;
            copia.PorcentajeComision = this.PorcentajeComision;
            return copia;
        }

        // ══════════════════════════════════════════════════════
        // MÉTODOS DE NEGOCIO
        // ══════════════════════════════════════════════════════
        public decimal CalcularComision()
        {
            return VentasMes * (PorcentajeComision / 100m);
        }

        public decimal CalcularSalarioTotal()
        {
            return SalarioBase + CalcularComision();
        }

        public override string ToString()
        {
            string display = string.IsNullOrEmpty(Apodo) ? Nombre : Apodo;
            return string.Format("[{0}] {1} ({2})", Id, display, Rol);
        }
    }
}