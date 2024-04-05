using Microsoft.AspNetCore.Mvc;
using TubeManager.App.Abstractions;

namespace TubeManager.API.Controllers;

[ApiController]
[Route("import")]
public class ImportController : ControllerBase
{
  private readonly IImportBackupService _importBackupService;

  public ImportController(IImportBackupService importBackupService)
  {
    _importBackupService = importBackupService;
  }
  [HttpPost]
  public ActionResult Post()
  {
    return Ok();
  }
}