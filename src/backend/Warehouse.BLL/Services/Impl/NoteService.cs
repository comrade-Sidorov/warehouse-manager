using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using Warehouse.BLL.Services.Interfaces;
using Warehouse.DAL.Entities;
using Warehouse.DAL.Repositories.Interfaces;

namespace Warehouse.BLL.Services.Impl;

public class NoteService : INoteService
{
    private readonly ICommonRepository<Note> _noteRepo;
    private readonly ILogger<NoteService> _logger;

    public NoteService(ICommonRepository<Note> noteRepo,
        ILogger<NoteService> logger)
    {
        _noteRepo = noteRepo ?? throw new ArgumentNullException(nameof(noteRepo));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    public async Task<string> GetNoteByIdAsync(long id)
    {
        _logger.LogInformation($"Get {nameof(Note)} by id: {id}");
        var entity = await _noteRepo.GetEntityById(id);
        if(entity is null)
        {
            _logger.LogInformation($"Entity by id:{id} not found");
            return string.Empty;
        }

        if(string.IsNullOrEmpty(entity.Value))
        {
            _logger.LogInformation($"Value is empty");
            return string.Empty;
        }
        
        return entity.Value;
    }
}