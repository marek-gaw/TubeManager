using System.IO.IsolatedStorage;
using TubeManager.Core.Entities;

namespace TubeManager.Core.DTO;

public class BookmarkDTO
{
    public Guid? Id { get; set; } 
    public string Title { get; set; }
    public string VideoUrl { get; set; }
    public string ThumbnailUrl { get; set; }
    public string Channel { get; set; }
    public string Description { get; set; }
    public TagDTO[] Tags { get; set; }

    public CategoryDTO? Category { get; set; }
}
