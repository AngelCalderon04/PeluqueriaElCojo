namespace PeluqueriaElCojo.Modelos
{
    public interface IFacturable
    // define un contrato que obliga a implementar ciertos metodos

    {
        decimal CalcularPrecio();
        // metodo que debe calcular y devolver el precio

        string GenerarLineaRecibo();
        // metodo que debe generar el texto para mostrar en el recibo
    }
}
