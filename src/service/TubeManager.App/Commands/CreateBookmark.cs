namespace TubeManager.App.Commands;

public record CreateBookmark(Guid BookmarkId, string Title, string VideoUrl, string ThumbnailUrl, string Channel, string Description);
