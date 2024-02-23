using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MessagingAPI.Console.Models;
using MessagingAPI.Console.Services;

namespace MessagingAPI.Console.Tests
{
    [TestClass()]
    public class RabbitMQProcessorTests
    {
        private readonly Mock<IMongoConnector> _mockService;
        private readonly RabbitMQProcessor _processor;

        public RabbitMQProcessorTests() {
            _mockService = new Mock<IMongoConnector>();
            _processor = new RabbitMQProcessor(_mockService.Object);
        }

        [TestMethod()]
        public void SendProductsToQueueTest()
        {
            _mockService.Setup(s => s.GetProductsFromDB()).Returns(GetMockProducts());
            var result = _processor.SendProductsToQueue();
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void SendPriceReductionToQueueTest()
        {
            _mockService.Setup(s => s.GetPriceReductionsFromDB()).Returns(GetMockReductions());
            var result = _processor.SendPriceReductionToQueue();
            Assert.IsNotNull(result);
        }

        private List<Product> GetMockProducts()
        {
            List<Product> products = new List<Product>() { new Product() { 
                Id = "1",
                EntryDate = DateTime.Now,
                Name = "Test",
                Price = 10
            
            }};
            return products;
        }

        private List<PriceReduction> GetMockReductions()
        {
            List<PriceReduction> priceReductions = new List<PriceReduction>() { new PriceReduction() {
                Id = "1",
                DayOfWeek = 1,
                Reduction = 0
            }};
            return priceReductions;
        }
    }
}