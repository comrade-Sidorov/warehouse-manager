namespace Warehouse.DAL.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name {get; set; } = string.Empty;
    public short Age { get; set; }
}