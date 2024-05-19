using Microsoft.AspNetCore.Mvc;
using TubeManager.App.Services;
using TubeManager.Core.DTO;

namespace TubeManager.API.Controllers;

[ApiController]
[Route("channels")]
public class ChannelsController: ControllerBase
{
    private ChannelsService _channelsService;

    public ChannelsController(ChannelsService channelsService)
    {
        _channelsService = channelsService;
    }
    
    [HttpGet]
    public ActionResult<ChannelDTO[]> Get()
    {
        var channels = _channelsService.Get();
        return Ok(channels);
    }

    [HttpGet("{guid:id}")]
    public ActionResult<ChannelDTO> Get(Guid id)
    {
        var channel = _channelsService.Get(id);
        return Ok(channel);
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