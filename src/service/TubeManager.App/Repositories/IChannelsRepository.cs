using TubeManager.Core.Entities;

namespace TubeManager.App.Repositories;

public interface IChannelsRepository
{
    IEnumerable<Channel> GetAll();
    Channel Get(Guid id);
    Channel Get(string channelId);
    void Add(Channel channel);
    void Update(Channel channel);
    void Delete(Channel channel);
}
