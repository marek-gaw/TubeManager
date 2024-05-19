using TubeManager.App.Abstractions;
using TubeManager.App.Commands.Channels;
using TubeManager.Core.DTO;

namespace TubeManager.App.Services;

public sealed class ChannelsService: IChannelService
{
    public IEnumerable<ChannelDTO> Get()
    {
        throw new NotImplementedException();
    }

    public ChannelDTO Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public Guid? Create(CreateChannel command)
    {
        throw new NotImplementedException();
    }

    public bool Update(UpdateChannel command)
    {
        throw new NotImplementedException();
    }

    public bool Delete(DeleteChannel command)
    {
        throw new NotImplementedException();
    }
}