using MongoDB.Driver;


namespace MessagingAPI.Console.Services
{
    public class MongoConnector : IMongoConnector
    {
        private MongoClient client;

        private IMongoDatabase database;

        public MongoConnector()
        {
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("aimsdb");
        }

        public List<Models.Product> GetProductsFromDB()
        {
            return database.GetCollection<Models.Product>("products").Find(p => true).ToList();
        }

        public List<Models.PriceReduction> GetPriceReductionsFromDB()
        {
            return database.GetCollection<Models.PriceReduction>("priceReduction").Find(p => true).ToList();
        }

    }
}
