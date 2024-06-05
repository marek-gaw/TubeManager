using System.Collections;
using NSubstitute;
using TubeManager.App.Repositories;
using TubeManager.App.Services;
using TubeManager.Core.DTO;
using TubeManager.Core.Entities;

namespace TubeManager.Tests;

public class CategoryServiceTests
{
    [Fact]
    public void Should_return_category_if_esists()
    {
        // ARRANGE
        var categoryRepo = Substitute.For<ICategoryRepository>();
        var categoryId = Guid.NewGuid();
        var categoryService = new CategoryService(categoryRepo);

        categoryRepo.GetAll().Returns(new List<Category>
        {
            new Category(categoryId, "Test name", "Test desc"),
            new Category(Guid.NewGuid(), "Test2 name2", "Test2 desc2")
        });
        
        // ACT
        var result = categoryService.Get(categoryId);

        // ASSERT
        Assert.Equal(result.Id, categoryId);
    }
    
    [Fact]
    public void Should_return_null_if_not_exists()
    {
        // ARRANGE
        var categoryRepo = Substitute.For<ICategoryRepository>();
        var categoryService = new CategoryService(categoryRepo);

        categoryRepo.GetAll().Returns(new List<Category>
        {
            new Category(Guid.NewGuid(), "Test name", "Test desc"),
            new Category(Guid.NewGuid(), "Test2 name2", "Test2 desc2")
        });
        
        // ACT
        var result = categoryService.Get(Guid.NewGuid());

        // ASSERT
        Assert.Null(result);
    }
    
}