using Microsoft.AspNetCore.Mvc;
using TubeManager.App.Abstractions;
using TubeManager.App.Services;

namespace TubeManager.API.Controllers;

[ApiController]
[Route("import")]
public class ImportController : ControllerBase
{
  private readonly IImportBackupService _importBackupService;
  private readonly IFileService _fileService;

  public ImportController(IImportBackupService importBackupService, IFileService fileService)
  {
    _importBackupService = importBackupService;
    _fileService = fileService;
  }
  [HttpPost]
  public async Task<ActionResult> Post(IFormFile file)
  {
    await _fileService.PostFileAsync(file);
    return Ok();
  }
}