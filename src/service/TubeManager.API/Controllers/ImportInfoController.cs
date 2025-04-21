using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TubeManager.App.Abstractions;
using TubeManager.Core.DTO;

namespace TubeManager.API.Controllers;

[ApiController]
[Route("/import-info")]
public class ImportInfoController : ControllerBase
{
    // private readonly IImportInfoService _importInfoService;

    // public ImportInfoController(IImportInfoService importInfoService)
    // {
    //     _importInfoService = importInfoService;
    // }

    [HttpGet]
    public ActionResult<ImportInfoDto[]> GetAll()
    {
        return new [] {
            new ImportInfoDto(Guid.NewGuid(), DateTime.UtcNow, 42),
            new ImportInfoDto(Guid.NewGuid(), DateTime.UtcNow, 43),
        };
    }
}