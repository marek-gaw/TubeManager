using System.Threading.Channels;
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
  private readonly ChannelWriter<string> _channel;

  public ImportController(IImportBackupService importBackupService,
      IFileService fileService,
      ChannelWriter<string> channel)
  {
    _importBackupService = importBackupService;
    _fileService = fileService;
    _channel = channel;
  }
  [HttpPost]
  public async Task<ActionResult> Post(IFormFile file)
  {
    string path = await _fileService.PostFileAsync(file);
    await _channel.WriteAsync(path);
    return Ok();
  }
}