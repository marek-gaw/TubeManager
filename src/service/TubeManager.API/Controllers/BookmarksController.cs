using Microsoft.AspNetCore.Mvc;
using TubeManager.API.Models;

namespace TubeManager.API.Controllers;

[Route("bookmarks")]
public class BookmarksController : ControllerBase
{
    // not thread safe.
    private static readonly List<Bookmark> _bookmarks = new();
    private static Guid _id = Guid.NewGuid();
    
    [HttpGet]
    public void Get()
    {
        
    }

    [HttpPost]
    public void Post([FromBody] Bookmark bookmark)
    {
        bookmark.Id = _id;

        var bookmarkExists = _bookmarks
            .Any(b => b.VideoUrl == bookmark.VideoUrl);

        if (bookmarkExists)
        {
            HttpContext.Response.StatusCode = StatusCodes.Status406NotAcceptable;
            return;
        }
        
        _bookmarks.Add(bookmark);
        HttpContext.Response.StatusCode = StatusCodes.Status201Created;
        HttpContext.Response.Headers.Add("Location", $"bookmarks/{_id}");
        _id = Guid.NewGuid();
    }

    [HttpPut]
    public void Put()
    {
        
    }

    [HttpDelete]
    public void Delete()
    {
        
    }
}
