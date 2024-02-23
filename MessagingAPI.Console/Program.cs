using MessagingAPI.Console;
using MessagingAPI.Console.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


IHost host = Host.CreateDefaultBuilder().ConfigureServices(service => {
    service.AddScoped<IMongoConnector, MongoConnector>();
    }).Build();


var serviceObj = host.Services.GetService<IMongoConnector>();


RabbitMQProcessor rabbitMQProcessor = new RabbitMQProcessor(serviceObj);

// Send Products to queue
var isProductSent = rabbitMQProcessor.SendProductsToQueue();
if (isProductSent)
{
    Console.WriteLine("Products published to queue successfully");
}
else
{
    Console.WriteLine("Error occured while publishing products to queue");
}

// send price reduction to queue
var isReductionSent = rabbitMQProcessor.SendPriceReductionToQueue();
if (isReductionSent)
{
    Console.WriteLine("Reductions published to queue successfully");
}
else
{
    Console.WriteLine("Error occured while publishing reductions to queue");
}

Console.ReadKey();