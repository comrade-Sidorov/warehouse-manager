using Warehouse.BLL.DTO;

namespace Warehouse.BLL.Services.Interfaces;

public interface INoteService
{
    Task<string> GetNoteByIdAsync(long id);
    Task<string[]> GetNotesAsync();
    Task CreateAsync(CreateNoteDto dto);
    Task EditAsync(NoteDto dto);
    Task DeleteAsync(long id);
}