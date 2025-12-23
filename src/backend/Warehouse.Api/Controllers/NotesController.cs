using Microsoft.AspNetCore.Mvc;
using Warehouse.BLL.Services.Interfaces;

namespace Warehouse.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class NotesController : ControllerBase
{
    private readonly INoteService _noteService;

    public NotesController(
        INoteService noteService)
    {
        _noteService = noteService ?? throw new ArgumentNullException(nameof(noteService));
    }

    [HttpGet("{noteId:long}")]
    public async Task<string> GetNoteById(long noteId)
    {
        return await _noteService.GetNoteByIdAsync(noteId);
    }

    [HttpGet]
    public async Task<string[]> GetNotes()
    {
        return await _noteService.GetNotesAsync();
    }
}