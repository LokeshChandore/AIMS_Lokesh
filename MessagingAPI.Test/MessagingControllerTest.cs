using MessagingAPI.BusinessModels;
using MessagingAPI.Controllers;
using MessagingAPI.Services;
using Moq;

namespace MessagingAPI.Test
{
    [TestClass]
    public class MessagingControllerTest
    {
        private readonly Mock<IRabbitMQService> _mockService;
        private readonly MessagingController _controller;
        public MessagingControllerTest() { 
            _mockService = new Mock<IRabbitMQService>();
            _controller = new MessagingController( _mockService.Object );
        }
        
        [TestMethod]
        public void Get_Products()
        {
            _mockService.Setup(s => s.GetProducts()).Returns(GetMockProducts());
            var result = _controller.GetProducts();
            Assert.IsNotNull( result );
        }

        [TestMethod]
        public void Get_ProductById()
        {
            int id = 1;
            _mockService.Setup(s => s.GetProduct(id)).Returns(GetMockProductById(id));
            var result = _controller.GetProduct(id);
            Assert.IsNotNull(result);
        }

        private List<Product> GetMockProducts() {
            List<Product> products = new List<Product>();
            products.Add(new Product()
            {
                Id = 1,
                Name = "Uncle Ben's Rice",
                EntryDate = DateTime.Now,
                Price = 20,
            });
            products.Add(new Product()
            {
                Id = 2,
                Name = "A pile of potatos",
                EntryDate = DateTime.Now,
                Price = 50,
            });
            return products;
        }

        private ProductPriceDetail GetMockProductById(int id)
        {
            List<ProductPriceDetail> products = new List<ProductPriceDetail>();
            products.Add(new ProductPriceDetail()
            {
                Id = 1,
                Name = "Uncle Ben's Rice",
                EntryDate = DateTime.Now,
                PriceWithReduction = 20,
            });
            products.Add(new ProductPriceDetail()
            {
                Id = 2,
                Name = "A pile of potatos",
                EntryDate = DateTime.Now,
                PriceWithReduction = 50,
            });
            return products.FirstOrDefault(x => x.Id == id);
        }
    }
}