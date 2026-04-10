namespace PeluqueriaElCojo.Modelos
{
    public class Servicio : IFacturable
    {
        public string Nombre { get; set; }
        public decimal PrecioBase { get; set; }
        public int DuracionMinutos { get; set; }

        public Servicio(string nombre, decimal precio, int duracion)
        {
            Nombre = nombre;
            PrecioBase = precio;
            DuracionMinutos = duracion;
        }

        public virtual decimal CalcularPrecio()
        {
            return PrecioBase;
        }

        public virtual string GenerarLineaRecibo()
        // metodo que genera la linea del recibo (puede ser modificado en clases hijas)

        {
            return string.Format("{0,-20} RD${1:N0}", Nombre, CalcularPrecio());
        }
    }
}
