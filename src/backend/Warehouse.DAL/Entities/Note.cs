namespace Warehouse.DAL.Entities;

public class Note
{
    public long Id { get; set; }
    public string Value { get; set; } = string.Empty;
    public DateTime ChangedTime { get; set; }
}