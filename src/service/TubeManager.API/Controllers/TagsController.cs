using Microsoft.AspNetCore.Mvc;
using TubeManager.App.Abstractions;
using TubeManager.App.Commands.Tags;
using TubeManager.Core.DTO;

namespace TubeManager.API.Controllers;

[ApiController]
[Route("tags")]
public class TagsController: ControllerBase
{
    private readonly ITagsService _tagsService;

    public TagsController(ITagsService service)
    {
        _tagsService = service;
    }
    
    [HttpGet]
    public ActionResult<TagDTO[]> Get()
    {
        return Ok(_tagsService.Get());
    }

    [HttpPost]
    public ActionResult<TagDTO> Post(CreateTag command)
    {
        var id = _tagsService
            .Create(command with { TagId = Guid.NewGuid()} );

        if (id is null)
        {
            return BadRequest();
        }
        
        return CreatedAtAction(nameof(Post), new { id }, default);
    }

    [HttpPut("{id:guid}")]
    public ActionResult Put(Guid id, UpdateTag command)
    {
        var status = _tagsService.Update(command with { Id = id });
        if (!status)
        {
            return BadRequest();
        }

        return Accepted();
    }

    [HttpDelete("{id:guid}")]
    public ActionResult Delete(Guid id, DeleteTag command)
    {
        var status = _tagsService.Delete(new DeleteTag(id));
        if (!status)
        {
            return BadRequest();
        }
        return Accepted();
    }
}
