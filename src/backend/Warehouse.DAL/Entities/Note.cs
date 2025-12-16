namespace Warehouse.DAL.Entities;

public class Note : CommonEntity
{
    public string Value { get; set; } = string.Empty;
    public DateTime ChangedTime { get; set; }
}