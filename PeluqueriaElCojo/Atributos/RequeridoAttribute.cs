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
            if (valor is string s) return !string.IsNullOrWhiteSpace(s);
            return true;
        }
    }
}