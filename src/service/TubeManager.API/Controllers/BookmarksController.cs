using Microsoft.AspNetCore.Mvc;
using TubeManager.API.Commands;
using TubeManager.API.DTO;
using TubeManager.API.Entities;
using TubeManager.API.Services;

namespace TubeManager.API.Controllers;

[ApiController]
[Route("bookmarks")]
public class BookmarksController : ControllerBase
{
    // not thread safe.
    private readonly BookmarksService _bookmarksService = new();

    [HttpGet]
    public ActionResult<BookmarkDTO[]> Get()
    {
        return Ok(_bookmarksService.Get());
    }
    
    [HttpGet(("{id:guid}"))]
    public ActionResult<BookmarkDTO> Get(Guid id)
    {
        var bookmark = _bookmarksService.Get(id);
        if (bookmark is null)
        {
            return NotFound();
        }
        return bookmark;
    }

    [HttpPost]
    public ActionResult Post(CreateBookmark command)
    {
        var id = _bookmarksService.Create(command with { BookmarkId = Guid.NewGuid()} );

        if (id is null)
        {
            return BadRequest();
        }
        
        return CreatedAtAction(nameof(Post), new { id }, default);
    }
 
    [HttpPut("{id:guid}")]
    public ActionResult Put(Guid id, UpdateBookmark command)
    {
        var status = _bookmarksService.Update(command with { Id = id });
        if (!status)
        {
            return BadRequest();
        }

        return Accepted();
    }

    [HttpDelete("{id:guid}")]
    public ActionResult Delete(Guid id)
    {
        var status = _bookmarksService.Delete(new DeleteBookmark(id));
        if (!status)
        {
            return BadRequest();
        }
        return Accepted();
    }
}
