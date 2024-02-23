using MessagingAPI.Console.Models;

namespace MessagingAPI.Console.Services
{
    public interface IMongoConnector
    {
        List<PriceReduction> GetPriceReductionsFromDB();
        List<Product> GetProductsFromDB();
    }
}