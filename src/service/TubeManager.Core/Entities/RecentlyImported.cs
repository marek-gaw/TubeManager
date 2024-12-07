namespace TubeManager.Core.Entities;

public record RecentlyImported(Guid Id, DateTime ImportedDateTime, string FileName);
