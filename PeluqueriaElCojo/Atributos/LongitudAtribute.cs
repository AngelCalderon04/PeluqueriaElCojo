using System;

namespace PeluqueriaElcojo.Atributos

{
    public class LongitudAttribute : ValidacionAttribute
         
    { 
      public int Min {  get; } //Minimo de caracteres permitidos 
        public int Max { get;  } //maximo de carateres permitidos 

        public LongitudAttribute(int min, int max) 
        
        {
            Min = min;
            Max = max;
            MensajeError = string.Format("Debe tener  entre {0} y {1} caracteres", min, max);
            //Mensaje de error que se muestra sino se cumplela validaccion 
        }

        public override bool EsValido(object valor)
        {
            if (valor == null) return Min == 0;
            // si el valor es null, solo sera valido si el minimo es 0

            string s = valor.ToString();
            // convierte el valor a texto para poder medir su longitud

            return s.Length >= Min && s.Length <= Max;
            // retorna true si la longitud esta dentro del rango permitido

        }

    }
}
