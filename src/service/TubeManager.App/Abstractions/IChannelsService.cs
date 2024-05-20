using TubeManager.App.Commands.Channels;
using TubeManager.Core.DTO;

namespace TubeManager.App.Abstractions;

public interface IChannelsService
{
    IEnumerable<ChannelDTO> Get();
    ChannelDTO Get(Guid id);
    Guid? Create(CreateChannel command);
    bool Update(UpdateChannel command);
    bool Delete(DeleteChannel command);
}