using Microsoft.AspNetCore.Mvc;
using TubeManager.App.Abstractions;
using TubeManager.Core.DTO;

namespace TubeManager.API.Controllers;

[ApiController]
[Route("channels")]
public class ChannelsController: ControllerBase
{
    private IChannelsService _channelsService;

    public ChannelsController(IChannelsService channelsService)
    {
        _channelsService = channelsService;
    }
    
    [HttpGet]
    public ActionResult<ChannelDTO[]> Get()
    {
        var channels = _channelsService.Get();
        return Ok(channels);
    }

    [HttpGet("{id:guid}")]
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