namespace TubeManager.Core.Entities;

public sealed class Channel
{
    public Guid Id { get; set; }
    
    public string ChannelId { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string ThumbnailUrl { get; set; }

    public Channel(Guid id, string channelId, string name, string description, string thumbnailUrl)
    {
        Id = id;
        ChannelId = channelId;
        Name = name;
        Description = description;
        ThumbnailUrl = thumbnailUrl;
    }
    
}