namespace TubeManager.Core.Entities;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public List<Bookmark> Bookmarks { get; } = [];

    public Category(Guid id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}