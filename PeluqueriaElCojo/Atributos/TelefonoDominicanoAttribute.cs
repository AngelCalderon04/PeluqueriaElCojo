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
            string tel = valor.ToString().Replace("-", "").Replace(" ", "");

            if (tel.Length != 10) return false;

            // Prefijos válidos en RD
            string prefijo = tel.Substring(0, 3);
            return prefijo == "809" || prefijo == "829" || prefijo == "849";
        }
    }
}