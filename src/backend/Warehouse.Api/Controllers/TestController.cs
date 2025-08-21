using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Infrastructure;

namespace Warehouse.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;
    private readonly WarehouseContext _context;
    public TestController(WarehouseContext context, ILogger<TestController> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentException(nameof(logger));
    }

    [HttpGet]
    public IActionResult Get()
    {
        var conn = _context.Database.GetDbConnection();
        _logger.LogInformation(conn.ConnectionString);
        _context.Database.OpenConnection();
        return Ok(conn.State);
    }
}