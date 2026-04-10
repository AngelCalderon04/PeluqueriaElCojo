using System;
using PeluqueriaElcojo.Atributos;


namespace PeluqueriaElCojo.Atributos

{

    public class RequeridoAttribute : ValidacionAttribute

    {
        public RequeridoAttribute()
        {
            MensajeError = "Este Campo Es requerido"; 


        }

        public override bool EsValido(object valor)
        {
            if (valor == null) return false;
            // si el valor es null no es valido

            if (valor is string s) return !string.IsNullOrWhiteSpace(s);
            // si es un texto, verifica que no este vacio ni tenga solo espacios

            return true;
            // si no es null y no es string, se considera valido
        }
    }
}