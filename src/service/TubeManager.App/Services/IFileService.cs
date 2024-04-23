using Microsoft.AspNetCore.Http;

namespace TubeManager.App.Services;

public interface IFileService
{
    public Task<string> PostFileAsync(IFormFile fileData);
}