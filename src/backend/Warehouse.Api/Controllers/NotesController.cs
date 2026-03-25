using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class NotesController : ControllerBase
{
    

    [HttpGet("{noteId:long}")]
    public async Task<string> GetNoteById(long noteId)
    {
        await Task.Delay(1);
        return "some notes";
    }

    [HttpGet]
    public async Task<string[]> GetNotes()
    {
        string s = "shit";
        await Task.Delay(1);
        return new string[] { "note 1", "note 2", "note 3" };
    }

    // [HttpPost]
    // public async Task CreateNote(CreateNoteDto dto)
    // {
    //     await _noteService.CreateAsync(dto);
    // }

    // [HttpPut]
    // public async Task EditNote(NoteDto dto)
    // {
    //     await _noteService.EditAsync(dto);
    // }

    // [HttpDelete]
    // public async Task DeleteNote(long id)
    // {
    //     await _noteService.DeleteAsync(id);
    // }
}