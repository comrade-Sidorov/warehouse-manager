using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;

namespace Warehouse.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _loggerTest;

    public TestController(ILogger<TestController> loggerTest)
    {
        _loggerTest = loggerTest ?? throw new ArgumentNullException(nameof(loggerTest));
    }

    [HttpGet]
    public ActionResult<string> TestString()
    {
        _loggerTest.LogInformation("log from api");
        return Ok("shit");
    }

    [HttpGet("hi")]
    public async Task<IActionResult> SayHello()
    {
        var factory = new ConnectionFactory() { HostName = "rabbitmq", Port = 5672, UserName = "warehouse", Password = "12345" };
        using var connection = await factory.CreateConnectionAsync();
        using var chanel = await connection.CreateChannelAsync();

        await chanel.QueueDeclareAsync(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

        const string message = "Hello microservice";
        var body = Encoding.UTF8.GetBytes(message);

        await chanel.BasicPublishAsync(exchange: string.Empty, routingKey: "hello", body: body);
        return Ok();
    }
}