using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using TubeManager.App.Abstractions;
using TubeManager.App.Commands.Category;
using TubeManager.Core.DTO;

namespace TubeManager.API.Controllers;

[ApiController]
[Route("category")]
public class CategoriesController: ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService service)
    {
        _categoryService = service;
    }
    
    [HttpGet]
    public ActionResult<CategoryDTO[]> Get()
    {
        return Ok(_categoryService.Get());
    }

    [HttpGet("{id:guid}")]
    public ActionResult<CategoryDTO> Get(Guid id)
    {
        return Ok(_categoryService.Get(id));
    }

    [HttpPost]
    public ActionResult Post(CreateCategory command)
    {
        var id = _categoryService
            .Create(command with { Id = Guid.NewGuid()} );

        if (id is null)
        {
            return BadRequest();
        }
        
        return CreatedAtAction(nameof(Post),new {id}, new { id, command.Name, command.Description});
    }

    [HttpPut("{id:guid}")]
    public ActionResult Put(Guid id, [FromBody] UpdateCategory command)
    {
        var status = _categoryService.Update(command with { Id = id });
        if (!status)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(Put),new {id}, new { id, command.Name, command.Description});
    }

    [HttpDelete("{id:guid}")]
    public ActionResult Delete(Guid id)
    {
        var existing = _categoryService.Delete(new DeleteCategory(id));
        if (!existing)
        {
            return BadRequest();
        }
        return Accepted();
    }
}