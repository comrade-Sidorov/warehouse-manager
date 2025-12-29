namespace Warehouse.DAL.Entities;

public class AdmissionResource : CommonEntity
{
    public long ResourceId { get; set; }
    public long MeasureId { get; set; }
    public int Count { get; set; }
}