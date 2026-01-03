namespace Warehouse.DAL.Entities;

public class Resource : CommonEntity
{
    public string Name { get; set; } = string.Empty;
    public int State { get; set; }
    public ICollection<Measure> Measures { get; } = default!;
}