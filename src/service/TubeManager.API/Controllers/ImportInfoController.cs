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
            new ImportInfoDto(Guid.NewGuid(), DateTime.UtcNow, [new Guid("0012a34d-1d55-41eb-8e7f-8c0cabe2bea1")], 42),
            new ImportInfoDto(Guid.NewGuid(), DateTime.UtcNow, [new Guid("006e814f-eb9a-49ce-b6c7-2a5af0abad8a")], 43),
        };
    }
}