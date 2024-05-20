using Microsoft.EntityFrameworkCore;
using TubeManager.Core.Entities;

namespace TubeManager.Infrastructure.DataAccessLayer.Repositories;

internal sealed class SqliteChannelsRepository
{
    private readonly BookmarksDbContext _dbContext;
    private readonly DbSet<Channel> _channels;

    public SqliteChannelsRepository(BookmarksDbContext dbContext)
    {
        _dbContext = dbContext;
        _channels = _dbContext.Channels;
    }
    
    
}