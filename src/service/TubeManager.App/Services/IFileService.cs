using Microsoft.AspNetCore.Http;

namespace TubeManager.App.Services;

public interface IFileService
{
    public Task PostFileAsync(IFormFile fileData, FileType fileType);
}