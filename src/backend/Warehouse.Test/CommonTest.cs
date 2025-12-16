using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Warehouse.BLL.Services.Impl;
using Warehouse.DAL.Context;
using Warehouse.DAL.Entities;
using Warehouse.DAL.Repositories.Impl;
using Warehouse.DAL.Repositories.Interfaces;
using Xunit.Abstractions;

namespace Warehouse.Test;

public class CommonTest
{
    private readonly WarehouseDbContext _context;
    private readonly ITestOutputHelper _outputHelper;
    public CommonTest(ITestOutputHelper outputHelper)
    {
        var optionsBuilder = new DbContextOptionsBuilder<WarehouseDbContext>()
            .UseNpgsql("Host=172.21.0.2;Port=5432; Username=warehouse; Password=warehouse;Database=warehouse").Options;
        _context = new WarehouseDbContext(optionsBuilder);
        _outputHelper = outputHelper ?? throw new ArgumentNullException(nameof(outputHelper));

    }
    [Fact]
    public void Test1()
    {
        var r = 2 + 2;
        Assert.True(r == 4);
    }

    [Fact]
    public void Test2()
    {
        var r = 2 + 3;
        Assert.False(r == 4);
    }

    [Fact]
    public async Task Test3()
    {
        var mockLogger = new Mock<ILogger<CommonRepository<Note>>>();
       var commonRepo = new CommonRepository<Note>(_context, mockLogger.Object);

       var entities = await commonRepo.GetEntities();

       foreach(var item in entities)
        {
            _outputHelper.WriteLine(item.Value);
            Console.WriteLine(item.Value);
        }

        Assert.True(entities.Length > 0);
    }
}
