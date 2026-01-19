using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHostedService<HiService>();
var app = builder.Build();

var factory = new ConnectionFactory() { HostName = "rabbitmq", Port = 5672, UserName = "warehouse", Password = "12345" };
using var connection = await factory.CreateConnectionAsync();
using var chanel = await connection.CreateChannelAsync();

await chanel.QueueDeclareAsync(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

app.Logger.LogInformation("test");

var consumer = new AsyncEventingBasicConsumer(chanel);
string  msg = "";
consumer.ReceivedAsync += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    app.Logger.LogInformation(message);
    msg = message;
    return Task.CompletedTask;
};

app.MapGet("/", () => "Hello World!");
app.MapGet("/hi", async () =>
{
    var factory = new ConnectionFactory() { HostName = "rabbitmq", Port = 5672, UserName = "warehouse", Password = "12345" };
    using var connection = await factory.CreateConnectionAsync();
    using var chanel = await connection.CreateChannelAsync();

    await chanel.QueueDeclareAsync(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

    app.Logger.LogInformation("test");

    var consumer = new AsyncEventingBasicConsumer(chanel);
    string  msg = "";
    consumer.ReceivedAsync += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        app.Logger.LogInformation(message);
        msg = message;
        return Task.CompletedTask;
    };

    return Results.Ok(msg);
});

app.Run();


public class HiService : BackgroundService
{
    private readonly ILogger<HiService> _logger;

    public HiService(ILogger<HiService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory() { HostName = "rabbitmq", Port = 5672, UserName = "warehouse", Password = "12345" };
        using var connection = await factory.CreateConnectionAsync();
        using var chanel = await connection.CreateChannelAsync();
        await chanel.QueueDeclareAsync(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

       _logger.LogInformation("test");

        var consumer = new AsyncEventingBasicConsumer(chanel);
        string  msg = "dgftb";
        consumer.ReceivedAsync += (model, ea) =>
        {
            _logger.LogInformation("from event");
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            _logger.LogInformation(message);
            msg = message;
            return Task.CompletedTask;
        };
        _logger.LogInformation(msg);
    }
}