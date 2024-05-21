using TubeManager.App.Abstractions;
using TubeManager.App.Commands.Channels;
using TubeManager.App.Repositories;
using TubeManager.Core.DTO;

namespace TubeManager.App.Services;

public sealed class ChannelsService: IChannelsService
{
    private IChannelsRepository _channelsRepository;

    public ChannelsService(IChannelsRepository repository)
    {
        _channelsRepository = repository;
    }
    public IEnumerable<ChannelDTO> Get()
    {
        return _channelsRepository.GetAll()
            .Select(ch => new ChannelDTO
            {
                ChannelId = ch.ChannelId,
                Name = ch.Name,
                Description = ch.Description
            });
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