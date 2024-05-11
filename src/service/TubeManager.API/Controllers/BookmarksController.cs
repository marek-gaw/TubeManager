using Microsoft.AspNetCore.Mvc;
using TubeManager.App.Commands;
using TubeManager.Core.DTO;
using TubeManager.App.Abstractions;

namespace TubeManager.API.Controllers;

[ApiController]
[Route("bookmarks")]
public class BookmarksController : ControllerBase
{
    private readonly IBookmarksService _bookmarksService;
    public BookmarksController(IBookmarksService bookmarksService)
    {
        _bookmarksService = bookmarksService;
    }
    
    [HttpGet]
    public ActionResult<BookmarkDTO[]> Get([FromQuery]int page, [FromQuery]int pageSize)
    {
        if (page == 0 && pageSize == 0)
        {
            return Ok(_bookmarksService.Get());
        }
        else 
        {
            var response = new PagedResponse<BookmarkDTO>(_bookmarksService.Get(page, pageSize),
                page,
                pageSize,
                _bookmarksService.GetElementsCount());
            return Ok(response);
        }
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

    [HttpPut("{id:guid}/tags")]
    public ActionResult Put(Guid id, UpdateTagsForBookmark command)
    {
        var bookmark = _bookmarksService.Get(id);
        if (bookmark is not null)
        {
            var status = _bookmarksService.Update(command with { Id = id });
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
