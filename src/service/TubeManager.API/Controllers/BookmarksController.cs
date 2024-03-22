using Microsoft.AspNetCore.Mvc;
using TubeManager.API.Models;
using TubeManager.API.Services;

namespace TubeManager.API.Controllers;

[ApiController]
[Route("bookmarks")]
public class BookmarksController : ControllerBase
{
    // not thread safe.
    private readonly BookmarksService _bookmarksService = new();

    [HttpGet]
    public ActionResult<Bookmark[]> Get()
    {
        return Ok(_bookmarksService.Get());
    }
    
    [HttpGet(("{id}"))]
    public ActionResult<Bookmark> Get(Guid id)
    {
        var bookmark = _bookmarksService.Get(id);
        if (bookmark is null)
        {
            return NotFound();
        }
        return bookmark;
    }

    [HttpPost]
    public ActionResult Post(Bookmark bookmark)
    {
        var id = _bookmarksService.Create(bookmark);

        if (id is null)
        {
            return BadRequest();
        }
        
        return CreatedAtAction(nameof(Post), new { id }, default);
    }
 
    [HttpPut("{id:guid}")]
    public ActionResult Put(Guid id, Bookmark bookmark)
    {
        var status = _bookmarksService.Update(bookmark);
        if (!status)
        {
            return BadRequest();
        }

        return Accepted();
    }

    [HttpDelete("{id:guid}")]
    public ActionResult Delete(Guid id)
    {
        var status = _bookmarksService.Delete(id);
        if (!status)
        {
            return BadRequest();
        }
        return Accepted();
    }
}
