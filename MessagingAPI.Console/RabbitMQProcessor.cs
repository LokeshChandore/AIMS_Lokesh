using EasyNetQ;
using MessagingAPI.Console.Services;

namespace MessagingAPI.Console
{
    public class RabbitMQProcessor
    {
        private IBus bus;
        private IMongoConnector _mongoConnector;
        public RabbitMQProcessor(IMongoConnector mongoConnector)
        {
            bus = RabbitHutch.CreateBus("host=localhost", s => s.EnableSystemTextJson());
            _mongoConnector = mongoConnector;
        }

        /// <summary>
        /// this function publishes the products to the queue.
        /// </summary>
        /// <returns></returns>
        public bool SendProductsToQueue()
        {
            try
            {
                // send products
                var products = _mongoConnector.GetProductsFromDB();
                List<MessagingAPI.BusinessModels.Product> businessProduct = new List<MessagingAPI.BusinessModels.Product>();
                int id = 0;
                foreach (var product in products)
                {
                    businessProduct.Add(new MessagingAPI.BusinessModels.Product()
                    {
                        Id = id + 1,
                        Name = product.Name,
                        EntryDate = product.EntryDate,
                        Price = product.Price
                    });
                    id++;
                }

                bus.SendReceive.Send<List<MessagingAPI.BusinessModels.Product>>("myQueue", businessProduct);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// this function publishes the price reduction to the queue.
        /// </summary>
        /// <returns></returns>
        public bool SendPriceReductionToQueue()
        {
            try
            {
                int id = 0;
                var priceReductions = _mongoConnector.GetPriceReductionsFromDB();
                List<MessagingAPI.BusinessModels.PriceReduction> reductions = new List<MessagingAPI.BusinessModels.PriceReduction>();
                foreach (var price in priceReductions)
                {
                    reductions.Add(new MessagingAPI.BusinessModels.PriceReduction()
                    {
                        Id = id + 1,
                        DayOfWeek = price.DayOfWeek,
                        Reduction = price.Reduction
                    });
                    id++;
                }

                bus.SendReceive.Send<List<MessagingAPI.BusinessModels.PriceReduction>>("PriceReductionQ", reductions);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
