namespace Warehouse.Infrastructure.Entities;

public class TestEntity
{
    public  Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime TimeManipulation { get; set; }
}