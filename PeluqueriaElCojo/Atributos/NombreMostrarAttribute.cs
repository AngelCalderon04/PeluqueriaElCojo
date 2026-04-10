using System;

namespace PeluqueriaElCojo.Atributos

{  // indica que este atributo se puede usar en propiedades y en clases
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public class NombreMostrarAttribute : Attribute
    {
        public string Nombre { get; }
        public string Descripcion { get; set; }
        public int Orden { get; set; }

        public NombreMostrarAttribute(string nombre)
        {
            Nombre = nombre;
            // asigna el nombre recibido

            Orden = 0;
            // asigna un valor por defecto al orden
        }
    }
}