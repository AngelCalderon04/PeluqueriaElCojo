using System;
using System.Collections.Generic;
using System.Reflection;
using PeluqueriaElcojo.Atributos;
using PeluqueriaElCojo.Atributos;

namespace PeluqueriaElCojo.Utilidades
{
    public class ResultadoValidacion
    {
        public bool EsValido { get; set; }
        public List<string> Errores { get; set; }

        public ResultadoValidacion()
        {
            EsValido = true;
            Errores = new List<string>();
        }
    }

    public static class Validador
    {
        /// <summary>
        /// Valida cualquier objeto usando sus atributos de validación
        /// </summary>
        public static ResultadoValidacion Validar<T>(T objeto)
        {
            ResultadoValidacion resultado = new ResultadoValidacion();

            if (objeto == null)
            {
                resultado.EsValido = false;
                resultado.Errores.Add("El objeto es nulo");
                return resultado;
            }

            // REFLECTION: Obtener el tipo del objeto
            Type tipo = objeto.GetType();

            // REFLECTION: Obtener todas las propiedades
            PropertyInfo[] propiedades = tipo.GetProperties();

            foreach (PropertyInfo prop in propiedades)
            {
                // REFLECTION: Obtener valor actual
                object valor = prop.GetValue(objeto);

                // Obtener nombre amigable
                string nombreProp = ObtenerNombre(prop);

                // REFLECTION: Buscar atributos de validación
                object[] attrs = prop.GetCustomAttributes(
                    typeof(ValidacionAttribute), true);

                foreach (object attr in attrs)
                {
                    ValidacionAttribute val = attr as ValidacionAttribute;
                    if (val != null && !val.EsValido(valor))
                    {
                        resultado.EsValido = false;
                        resultado.Errores.Add(
                            string.Format("{0}: {1}", nombreProp, val.MensajeError));
                    }
                }
            }

            return resultado;
        }

        private static string ObtenerNombre(PropertyInfo prop)
        {
            // Buscar atributo NombreMostrar
            object[] attrs = prop.GetCustomAttributes(
                typeof(NombreMostrarAttribute), true);

            if (attrs.Length > 0)
            {
                NombreMostrarAttribute nm = attrs[0] as NombreMostrarAttribute;
                if (nm != null) return nm.Nombre;
            }
            return prop.Name;
        }
    }
}