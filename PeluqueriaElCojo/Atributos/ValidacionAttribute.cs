using System;
using System.Security.Permissions;

namespace PeluqueriaElcojo.Atributos 

    {

      //indicamos que este atributo soloaplique apropiedades 
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class  ValidacionAttribute : Attribute
    {
        public string MensajeError {  get; set; }

        //metodo abstarato ; cada validacion lo implementa 

        public abstract bool EsValido(object Valor);
    }

}