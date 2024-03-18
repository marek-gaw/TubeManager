using Microsoft.AspNetCore.Mvc;
using TubeManager.API.Models;

namespace TubeManager.API.Controllers;

[ApiController]
[Route("bookmarks")]
public class BookmarksController : ControllerBase
{
    // not thread safe.
    private static readonly List<Bookmark> _bookmarks = new();
    private static Guid _id = Guid.NewGuid();

    [HttpGet]
    public ActionResult<Bookmark[]> Get()
    {
        return Ok(_bookmarks);
    }
    
    [HttpGet(("{id}"))]
    public ActionResult<Bookmark> Get(Guid id)
    {
        var bookmark = _bookmarks.SingleOrDefault(b => b.Id == id);
        if (bookmark is null)
        {
            return NotFound();
        }
        return bookmark;
    }

    [HttpPost]
    public ActionResult Post(Bookmark bookmark)
    {
        bookmark.Id = _id;

        var bookmarkExists = _bookmarks
            .Any(b => b.VideoUrl == bookmark.VideoUrl);

        if (bookmarkExists)
        {
            return BadRequest();
        }
        
        _bookmarks.Add(bookmark);
        _id = Guid.NewGuid();
        return CreatedAtAction(nameof(Post), new { bookmark.Id }, default);
    }
 
    [HttpPut("{id:guid}")]
    public ActionResult Put(Guid id, Bookmark bookmark)
    {
        var existingBookmark = _bookmarks.SingleOrDefault(b => b.Id == id);
        if (existingBookmark is null)
        {
            return BadRequest();
        }

        existingBookmark.Title = bookmark.Title;
        existingBookmark.Channel = bookmark.Channel;
        return Accepted();
    }

    [HttpDelete("{id:guid}")]
    public ActionResult Delete(Guid id)
    {
        var existingBookmark = _bookmarks.SingleOrDefault(b => b.Id == id);
        if (existingBookmark is null)
        {
            return BadRequest();
        }

        _bookmarks.Remove(existingBookmark);
        return Accepted();
    }
}
