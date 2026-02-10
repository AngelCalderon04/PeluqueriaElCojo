namespace PeluqueriaElCojo.Modelos
{
    public interface IFacturable
    {
        decimal CalcularPrecio();
        string GenerarLineaRecibo();
    }
}
