using Microsoft.Extensions.Logging;
using Warehouse.BLL.Services.Interfaces;
using Warehouse.DAL.Entities;
using Warehouse.DAL.Repositories.Interfaces;

namespace Warehouse.BLL.Services.Impl;

public class NoteService : INoteService
{
    private readonly ICommonRepository<Note> _noteRepo;
    private readonly ILogger<NoteService> _logger;

    public NoteService(ICommonRepository<Note> noteRepo, ILogger<NoteService> logger)
    {
        _noteRepo = noteRepo ?? throw new ArgumentNullException(nameof(noteRepo));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    public async Task<string> GetNoteByIdAsync(long id)
    {
        _logger.LogInformation($"Start {nameof(GetNoteByIdAsync)}");
        var entity = await _noteRepo.GetEntityByIdAsync(id);
        if(entity is null)
        {
            return string.Empty;
        }

        if(string.IsNullOrEmpty(entity.Value))
        {
            return string.Empty;
        }
        
        return entity.Value;
    }

    public async Task<string[]> GetNotesAsync()
    {
        Note[] entities = await _noteRepo.GetEntitiesAsync();
        string[] notes = entities.Select(s => s.Value).ToArray();
        return notes;
        
    }
}