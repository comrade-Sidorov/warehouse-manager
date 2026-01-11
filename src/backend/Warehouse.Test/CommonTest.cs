using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Warehouse.BLL.Services.Impl;
using Warehouse.DAL.Entities;
using Warehouse.DAL.Repositories.Interfaces;
using Xunit.Abstractions;

namespace Warehouse.Test;

public class CommonTest
{
    private readonly ITestOutputHelper _outputHelper;
    public CommonTest(ITestOutputHelper outputHelper)
    {
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
        // test commit
        Assert.False(r == 4);
    }

    [Fact]
    public async Task Test4()
    {
        var mockLogger = new Mock<ILogger<NoteService>>();

        var repo = new Mock<ICommonRepository<Note>>();
        repo.Setup(r => r.GetEntityByIdAsync(1))
            .ReturnsAsync(new Note { Id = 1, Value = "draft", ChangedTime = DateTime.UtcNow});

        var service = new NoteService(repo.Object, mockLogger.Object);

        var result = await service.GetNoteByIdAsync(1);

        result.Should().NotBeNull();
    }
}
