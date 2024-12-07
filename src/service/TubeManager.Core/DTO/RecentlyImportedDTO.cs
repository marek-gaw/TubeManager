namespace TubeManager.Core.DTO;

public record RecentlyImportedDTO(Guid Id, DateTime ImportedDateTime, string FileName);
