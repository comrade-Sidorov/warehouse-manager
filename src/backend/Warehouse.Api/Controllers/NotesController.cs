using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Warehouse.BLL.DTO;
using Warehouse.BLL.Services.Interfaces;

namespace Warehouse.Api.Controllers;

[Authorize]
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

    [HttpPost]
    public async Task CreateNote(CreateNoteDto dto)
    {
        await _noteService.CreateAsync(dto);
    }

    [HttpPut]
    public async Task EditNote(NoteDto dto)
    {
        await _noteService.EditAsync(dto);
    }

    [HttpDelete]
    public async Task DeleteNote(long id)
    {
        await _noteService.DeleteAsync(id);
    }
}