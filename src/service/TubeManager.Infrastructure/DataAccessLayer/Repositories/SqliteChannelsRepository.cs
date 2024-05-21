using Microsoft.EntityFrameworkCore;
using TubeManager.App.Abstractions;
using TubeManager.App.Commands.Channels;
using TubeManager.App.Repositories;
using TubeManager.Core.DTO;
using TubeManager.Core.Entities;

namespace TubeManager.Infrastructure.DataAccessLayer.Repositories;

internal sealed class SqliteChannelsRepository : IChannelsRepository
{
    private readonly BookmarksDbContext _dbContext;
    private readonly DbSet<Channel> _channels;

    public SqliteChannelsRepository(BookmarksDbContext dbContext)
    {
        _dbContext = dbContext;
        _channels = _dbContext.Channels;
    }

    public IEnumerable<Channel> GetAll()
    {
        return _channels.ToList();
    }

    public Channel Get(Guid id)
    {
        return _channels.SingleOrDefault(ch => ch.Id == id);
    }

    public Channel Get(string channelId)
    {
        return _channels.SingleOrDefault(ch => ch.ChannelId == channelId);
    }

    public void Add(Channel channel)
    {
        _channels.Add(channel);
        _dbContext.SaveChanges();
    }

    public void Update(Channel channel)
    {
        _channels.Update(channel);
        _dbContext.SaveChanges();
    }

    public void Delete(Channel channel)
    {
        _channels.Remove(channel);
        _dbContext.SaveChanges();
    }
}