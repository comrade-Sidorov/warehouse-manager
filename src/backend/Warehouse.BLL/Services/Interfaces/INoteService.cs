namespace Warehouse.BLL.Services.Interfaces;

public interface INoteService
{
    Task<string> GetNoteByIdAsync(long id);
    Task<string[]> GetNotesAsync();
}