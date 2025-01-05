using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TubeManager.App.Commands;
using TubeManager.Core.DTO;
using TubeManager.App.Abstractions;
using TubeManager.App.Commands.Bookmarks;
using TubeManager.App.Repositories;

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
    public ActionResult<PagedResponse<BookmarkDTO>> Get([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string? query)
    {
        //TODO: move this validation to filter, and set parameters as nullable
        //TODO: deprecate and remove. It should not be possible to query everything!
        if (page == 0 && pageSize == 0 && string.IsNullOrWhiteSpace(query))
        {
            return Ok(_bookmarksService.Get());
        }
        
        if (string.IsNullOrWhiteSpace(query))
        {
            var response = new PagedResponse<BookmarkDTO>(_bookmarksService.Get(page, pageSize),
                page,
                pageSize,
                _bookmarksService.GetElementsCount());
            return response;
        }
        else
        {
            return Ok(_bookmarksService.Get(query));
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

    [HttpGet(("{id:guid}/tags"))]
    public ActionResult<TagDTO[]> GetTagsForBookmark(Guid id)
    {
        var bookmark = _bookmarksService.Get(id);
        if (bookmark is null)
        {
            return NotFound();
        }

        return bookmark.Tags;
    }

    [HttpPost]
    public ActionResult Post(CreateBookmark command)
    {
        var id = _bookmarksService.Create(command with { BookmarkId = Guid.NewGuid() });

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
    public ActionResult Put(Guid id, [FromBody] UpdateTagsForBookmark command)
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

    [HttpDelete("{id:guid}/tags")]
    public ActionResult DeleteTagForBookmark(Guid id, [FromBody] DeleteTagFromBookmark command)
    {
        var bookmark = _bookmarksService.Get(id);
        if (bookmark is not null)
        {
            var status = _bookmarksService.Update(command with { BookmarkId = id });
            bookmark = _bookmarksService.Get(id);
            return Accepted(bookmark);
        }

        return BadRequest();
    }

    [HttpPut("{bookmarkId:guid}/category")]
    public ActionResult<BookmarkDTO> Put(Guid bookmarkId, [FromBody]CategoryCommand requestCommand)
    {
        var bookmark = _bookmarksService.Get(bookmarkId);
        if (bookmark is not null)
        {
            if (String.IsNullOrEmpty(requestCommand.categoryId))
            {
                var command = new ResetCategoryForBookmark(bookmarkId);
                _bookmarksService.Update(command);
            }
            else
            {
                Guid guid = new Guid(requestCommand.categoryId);
                var command = new UpdateCategoryForBookmark(bookmarkId, guid);
                _bookmarksService.Update(command);
                
            }
            return Ok();
        }

        return BadRequest();
    }
}