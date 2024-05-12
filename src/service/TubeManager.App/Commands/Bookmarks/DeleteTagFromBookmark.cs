namespace TubeManager.App.Commands.Bookmarks;

public record DeleteTagFromBookmark(Guid BookmarkId, List<Guid> TagsId);
