namespace TubeManager.Core.Entities;

public sealed class Tag
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public Tag(Guid id, string title)
    {
        Id = id;
        Title = title;
    }
}