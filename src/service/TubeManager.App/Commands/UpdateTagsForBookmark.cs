namespace TubeManager.App.Commands;

public record UpdateTagsForBookmark(Guid Id, List<Guid> Tags);
