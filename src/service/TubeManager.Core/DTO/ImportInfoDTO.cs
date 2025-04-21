namespace TubeManager.Core.DTO;

public record ImportInfoDto(Guid Id, DateTime Timestamp, Guid[] Bookmarks, int BookmarkCount);
