namespace TurismoApp.Services
{
    public delegate decimal CalculateDelegate(decimal precoOriginal);

    public static class DiscountService
    {
        public static decimal AplicarDesconto(decimal preco)
        {
            return preco * 0.9m;
        }
    }
}
