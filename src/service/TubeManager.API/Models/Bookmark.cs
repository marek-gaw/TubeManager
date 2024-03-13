namespace TubeManager.API.Models;

public class Bookmark
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string VideoUrl { get; set; }
    public string ThumbnailUrl { get; set; }
    public string Channel { get; set; }
}