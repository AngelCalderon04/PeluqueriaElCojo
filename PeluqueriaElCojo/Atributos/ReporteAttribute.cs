using System;

namespace PeluqueriaElCojo.Atributos
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ReporteAttribute : Attribute
    {
        public bool Incluir { get; set; }
        public string Formato { get; set; }  // Ej: "N2", "C0"
        public int Ancho { get; set; }

        public ReporteAttribute()
        {
            Incluir = true;
            Ancho = 15;
        }
    }

    // Ocultar propiedad en formularios
    [AttributeUsage(AttributeTargets.Property)]
    public class OcultarAttribute : Attribute { }

    // Solo lectura en formularios
    [AttributeUsage(AttributeTargets.Property)]
    public class SoloLecturaAttribute : Attribute { }
}