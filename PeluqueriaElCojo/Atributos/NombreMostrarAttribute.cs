using System;

namespace PeluqueriaElCojo.Atributos
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public class NombreMostrarAttribute : Attribute
    {
        public string Nombre { get; }
        public string Descripcion { get; set; }
        public int Orden { get; set; }

        public NombreMostrarAttribute(string nombre)
        {
            Nombre = nombre;
            Orden = 0;
        }
    }
}