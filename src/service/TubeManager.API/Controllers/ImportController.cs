using Microsoft.AspNetCore.Mvc;

namespace TubeManager.API.Controllers;

[ApiController]
[Route("import")]
public class ImportController : ControllerBase
{
  [HttpPost]
  public ActionResult Post()
  {
    return Ok();
  }
}