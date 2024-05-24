using TubeManager.App.Commands.Category;
using TubeManager.Core.DTO;

namespace TubeManager.App.Abstractions;

public interface ICategoryService
{
    IEnumerable<CategoryDTO> Get();
    CategoryDTO? Get(Guid id);
    
    CategoryDTO? Get(string name);
    Guid? Create(CreateCategory command);
    bool Update(UpdateCategory command);
    bool Delete(DeleteCategory command);
}