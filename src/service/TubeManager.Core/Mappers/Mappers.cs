using TubeManager.Core.DTO;
using TubeManager.Core.Entities;

namespace TubeManager.Core.Mappers;

public sealed class Mappers
{
    public static TagDTO TagToTagDTO(Tag t)
    {
        return new TagDTO(){ Id = t.Id, Title = t.Title };
    }

    public static TagDTO[] ToArray(List<Tag> tags)
    {
        return tags.Select(tag => new TagDTO(){Id = tag.Id, Title = tag.Title} ).ToArray();
    }
    
}