namespace PeluqueriaElCojo.Modelos
{
    public class Afeitado : Servicio
    {
        public bool ConToalla { get; set; }

        public Afeitado(bool conToalla) : base("Afeitado", 150, 15)
        // constructor que recibe si lleva toalla
        // llama al constructor base con nombre, precio base y duracion
        {
            ConToalla = conToalla;
            // asigna si el servicio incluye toalla
        }

        public Afeitado() : this(false) { }
        // constructor por defecto, asume que no lleva toalla


        public override decimal CalcularPrecio()
        {
            if (ConToalla) return PrecioBase + 50;
            return PrecioBase;
        }

        public override string GenerarLineaRecibo()
        // metodo que genera el texto que se mostrara en el recibo

        {
            string txt = ConToalla ? "Afeitado + Toalla" : "Afeitado";
            // define el texto dependiendo si incluye toalla o no

            return string.Format("{0,-20} RD${1:N0}", txt, CalcularPrecio());
            // formatea el texto con alineacion y muestra el precio calculado
        }
    }
    
}
