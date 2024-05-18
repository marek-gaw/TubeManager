namespace TubeManager.Core.Entities;

public sealed class Channel
{
    public Guid Id { get; set; }
    
    public string ChannelId { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }
    public Channel(Guid id, string channelId, string name, string? description)
    {
        Id = id;
        ChannelId = channelId;
        Name = name;
        Description = description ?? "No description available";
    }
    
}