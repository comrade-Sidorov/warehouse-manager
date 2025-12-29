namespace Warehouse.DAL.Entities;

public class Measure : CommonEntity
{
    public string Name { get; set; } = string.Empty;
    public int State { get; set; }
}