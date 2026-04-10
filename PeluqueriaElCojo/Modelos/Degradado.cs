namespace PeluqueriaElCojo.Modelos
{
    public class Degradado : Servicio
    {
        public int NivelComplejidad { get; set; }

        public Degradado(int nivel) : base("Degradado", 200, 35) 
        // constructor que recibe el nivel de complejidad
        // llama al constructor base con nombre, precio base y duracion
        {
            NivelComplejidad = nivel;
        }

        public Degradado() : this(1) { }

        public override decimal CalcularPrecio()
        {
            return PrecioBase + (NivelComplejidad * 50);
            // suma al precio base un extra segun el nivel de complejidad
        }

        public override string GenerarLineaRecibo()
        {
            string txt = "Degradado (Nv." + NivelComplejidad + ")";
            // crea el texto mostrando el nivel

            return string.Format("{0,-20} RD${1:N0}", txt, CalcularPrecio());
            // muestra el nombre alineado y el precio formateado
        }
    }
}
