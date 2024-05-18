using Microsoft.AspNetCore.Mvc;

namespace TubeManager.API.Controllers;

[ApiController]
[Route("channels")]
public class ChannelsController: ControllerBase
{
    [HttpGet]
    public ActionResult Get()
    {
        return Ok();
    }

    [HttpPost]
    public ActionResult Post()
    {
        return Ok();
    }

    [HttpPut]
    public ActionResult Put()
    {
        return Ok();
    }

    [HttpDelete]
    public ActionResult Delete()
    {
        return Ok();
    }
}