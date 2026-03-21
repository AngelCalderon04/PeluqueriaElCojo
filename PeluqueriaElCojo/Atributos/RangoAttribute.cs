using System;
using PeluqueriaElcojo.Atributos;

namespace PeluqueriaElCojo.Atributos

{
    public class RangoAttribute : ValidacionAttribute

    {
        public double Minimo { get; set; }
        public double Maximo { get; set; }

        public RangoAttribute(double min,  double max)
        {
            Minimo = min;
            Maximo = max;
            MensajeError = string.Format("debe estar entre {0} y {1}", min, max);
        }

        public override bool EsValido(object Valor)

        {
            if (Valor == null) return true; 
            double num = Convert.ToDouble(Valor);
            return num >= Minimo && num <= Maximo;

        
        }

    }
}