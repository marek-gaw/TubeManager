namespace TubeManager.Core.DTO;

public sealed class ChannelDTO
{
    public Guid Id { get; set; }
    public string ChannelId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}