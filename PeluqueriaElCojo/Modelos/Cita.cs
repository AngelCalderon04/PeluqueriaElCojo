using System;
using System.Collections.Generic;
using PeluqueriaElcojo.Atributos;
using PeluqueriaElCojo.Atributos;

namespace PeluqueriaElCojo.Modelos
{
    public class Cita : ICloneable
    {
        private static int _contadorId = 0;

        // ══════════════════════════════════════════════════════
        // PROPIEDADES
        // ══════════════════════════════════════════════════════

        [Ocultar]
        public int Id { get; private set; }

        [NombreMostrar("Fecha")]
        [Requerido]
        [Reporte(Formato = "dd/MM/yyyy", Ancho = 12)]
        public DateTime Fecha { get; set; }

        [NombreMostrar("Hora")]
        [Requerido]
        [Reporte(Formato = "hh\\:mm", Ancho = 6)]
        public TimeSpan Hora { get; set; }

        [NombreMostrar("Cliente")]
        [Requerido]
        public Cliente Cliente { get; set; }

        [NombreMostrar("Barbero")]
        [Requerido]
        public Empleado Barbero { get; set; }

        [NombreMostrar("Estado")]
        [Reporte(Ancho = 12)]
        public EstadoCita Estado { get; set; }

        [NombreMostrar("Servicios")]
        public List<Servicio> Servicios { get; set; }

        [NombreMostrar("Notas")]
        [Longitud(0, 200)]
        public string Notas { get; set; }

        [SoloLectura]
        public DateTime FechaCreacion { get; private set; }

        // ══════════════════════════════════════════════════════
        // CONSTRUCTOR
        // ══════════════════════════════════════════════════════
        public Cita()
        {
            Id = ++_contadorId;
            FechaCreacion = DateTime.Now;
            Estado = EstadoCita.Pendiente;
            Servicios = new List<Servicio>();
            Fecha = DateTime.Today;
            Hora = new TimeSpan(9, 0, 0);
        }

        // ══════════════════════════════════════════════════════
        // ICloneable - Duplicar cita (para reagendar)
        // ══════════════════════════════════════════════════════
        public object Clone()
        {
            Cita copia = new Cita();
            copia.Cliente = this.Cliente;
            copia.Barbero = this.Barbero;
            copia.Estado = EstadoCita.Pendiente;
            copia.Notas = this.Notas;

            // Copiar servicios
            foreach (Servicio s in this.Servicios)
            {
                copia.Servicios.Add(s);
            }

            // Fecha se deja para configurar después
            return copia;
        }

        // ══════════════════════════════════════════════════════
        // PROPIEDADES CALCULADAS
        // ══════════════════════════════════════════════════════
        public DateTime FechaHoraCompleta
        {
            get { return Fecha.Date.Add(Hora); }
        }

        public int DuracionTotalMinutos
        {
            get
            {
                int total = 0;
                foreach (Servicio s in Servicios)
                {
                    total += s.DuracionMinutos;
                }
                return total;
            }
        }

        public decimal TotalEstimado
        {
            get
            {
                decimal total = 0;
                foreach (Servicio s in Servicios)
                {
                    total += s.CalcularPrecio();
                }
                return total;
            }
        }

        // ══════════════════════════════════════════════════════
        // MÉTODOS
        // ══════════════════════════════════════════════════════
        public void Confirmar()
        {
            if (Estado == EstadoCita.Pendiente)
                Estado = EstadoCita.Confirmada;
        }

        public void Iniciar()
        {
            if (Estado == EstadoCita.Confirmada)
                Estado = EstadoCita.EnProceso;
        }

        public void Completar()
        {
            if (Estado == EstadoCita.EnProceso)
                Estado = EstadoCita.Completada;
        }

        public void Cancelar()
        {
            if (Estado != EstadoCita.Completada)
                Estado = EstadoCita.Cancelada;
        }

        public override string ToString()
        {
            string clienteNombre = Cliente != null ? Cliente.Nombre : "?";
            string barberoNombre = Barbero != null ? Barbero.Apodo : "?";
            return string.Format("{0:dd/MM} {1:hh\\:mm} - {2} con {3} [{4}]",
                Fecha, Hora, clienteNombre, barberoNombre, Estado);
        }
    }
}