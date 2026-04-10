using System;
using PeluqueriaElcojo.Atributos;

namespace PeluqueriaElCojo.Atributos
{
    public class TelefonoDominicanoAttribute : ValidacionAttribute
    {
        public TelefonoDominicanoAttribute()
        {
            MensajeError = "Teléfono inválido. Use: 809-555-1234";
        }

        public override bool EsValido(object valor)
        {
            if (valor == null) return false;
            // si no hay valor, no es valido

            string tel = valor.ToString().Replace("-", "").Replace(" ", "");
            // convierte el valor a texto y elimina guiones y espacios

            if (tel.Length != 10) return false;
            // verifica que tenga exactamente 10 digitos

            // prefijos validos en republica dominicana
            string prefijo = tel.Substring(0, 3);
            // toma los primeros 3 digitos

            return prefijo == "809" || prefijo == "829" || prefijo == "849";
            // retorna true si el prefijo es valido
        }
    }
}