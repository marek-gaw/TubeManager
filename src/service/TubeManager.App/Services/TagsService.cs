using TubeManager.App.Abstractions;
using TubeManager.App.Commands.Tags;
using TubeManager.App.Repositories;
using TubeManager.Core.DTO;
using TubeManager.Core.Entities;

namespace TubeManager.App.Services;

public class TagsService: ITagsService
{
    private readonly ITagsRepository _tagsRepository;

    public TagsService(ITagsRepository repository)
    {
        _tagsRepository = repository;
    }
    
    public IEnumerable<TagDTO> Get()
    {
        return _tagsRepository
            .GetAll()
            .Select(t => new TagDTO
            {
                Id = t.Id,
                Title = t.Title
            });
    }

    public TagDTO? Get(Guid id)
    {
        return Get().SingleOrDefault(t => t.Id == id);
    }

    public Guid? Create(CreateTag command)
    {
        var existing = _tagsRepository.Get(command.Title);
        
        if (existing is null)
        {
            return null;
        }

        var tag = new Tag(command.TagId, command.Title);
        _tagsRepository.Add(tag);
        return tag.Id;
    }

    public bool Update(UpdateTag command)
    {
        var existing = _tagsRepository.Get(command.Title);
        
        if (existing is null)
        {
            return false;
        }

        var tag = new Tag(command.Id, command.Title);
        _tagsRepository.Update(tag);
        return true;
    }

    public bool Delete(DeleteTag command)
    {
        var existing = _tagsRepository.Get(command.Id);
        
        if (existing is null)
        {
            return false;
        }

        _tagsRepository.Delete(existing);
        return true;
    }
}