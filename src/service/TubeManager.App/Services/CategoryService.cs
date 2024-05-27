using TubeManager.App.Abstractions;
using TubeManager.App.Commands.Category;
using TubeManager.App.Repositories;
using TubeManager.Core.DTO;
using TubeManager.Core.Entities;

namespace TubeManager.App.Services;

public class CategoryService: ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository repository)
    {
        _categoryRepository = repository;
    }
    
    public IEnumerable<CategoryDTO> Get()
    {
        return _categoryRepository
            .GetAll()
            .Select(c => new CategoryDTO(c.Id, c.Name, c.Description));
    }

    public CategoryDTO? Get(Guid id)
    {
        return Get().SingleOrDefault(c => c.Id == id);
    }

    public CategoryDTO? Get(string name)
    {
        return Get().SingleOrDefault(c => c.Name == name);
    }

    public Guid? Create(CreateCategory command)
    {
        var existing = _categoryRepository.Get(command.Name);

        if (existing is not null)
        {
            return null;
        }

        var category = new Category(command.Id, command.Name, command.Description);
        _categoryRepository.Add(category);
        return category.Id;
    }

    public bool Update(UpdateCategory command)
    {
        var existing = _categoryRepository.Get(command.Id);
        
        if (existing is null)
        {
            return false;
        }

        existing.Name = command.Name;
        existing.Description = command.Description;
        _categoryRepository.Update(existing);
        return true;
    }

    public bool Delete(DeleteCategory command)
    {
        var existing = _categoryRepository.Get(command.Id);
        
        if (existing is null)
        {
            return false;
        }

        _categoryRepository.Delete(existing);
        return true;
    }
}