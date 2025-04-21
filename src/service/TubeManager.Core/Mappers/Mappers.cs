using TubeManager.Core.DTO;
using TubeManager.Core.Entities;

namespace TubeManager.Core.Mappers;

public static class Mappers
{
    public static TagDTO TagDTO(this Tag t)
    {
        return new TagDTO(){ Id = t.Id, Title = t.Title };
    }

    public static TagDTO[]? ToDtoArray(this List<Tag> tags)
    {
        return tags.Select(tag => new TagDTO(){Id = tag.Id, Title = tag.Title} ).ToArray();
    }

    public static BookmarkDTO ToBookmarkDTO(this Bookmark bookmark)
    {
        return new BookmarkDTO()
        {
            Id = bookmark.Id,
            Category = bookmark.Category?.ToCategoryDTO(),
            Channel = bookmark.Channel,
            Description = bookmark.Description,
            Tags = bookmark.Tags?.ToDtoArray(),
            ThumbnailUrl = bookmark.ThumbnailUrl,
            Title = bookmark.Title,
            VideoUrl = bookmark.ThumbnailUrl,
        };
    }

    public static IEnumerable<BookmarkDTO> ToDtoList(this IEnumerable<Bookmark> bookmarks)
    { 
        var ret =bookmarks.Select(bookmark => bookmark.ToBookmarkDTO()).ToList();
        return ret;
    }

    public static CategoryDTO ToCategoryDTO(this Category category)
    {
        return new CategoryDTO(category.Id, category.Name, category.Description);
    }

    public static ImportInfoDto toDto(this ImportInfo importInfo)
    {
        return new ImportInfoDto(importInfo.Id, importInfo.ImportTimestamp, 42);
    }
}