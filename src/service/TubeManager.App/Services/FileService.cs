namespace TubeManager.App.Services;

using Microsoft.AspNetCore.Http;

public class FileService : IFileService
{
    public FileService()
    {
    }

    public async Task<string> PostFileAsync(IFormFile fileData)
    {
        string filePath = "";
        try
        {
            filePath = Path.Combine(Path.GetTempPath(),
                (fileData.FileName + "_imported.zip"));

            using (var fileStream = System.IO.File.Create(filePath))
            {
                await fileData.CopyToAsync(fileStream);
            }
        }
        catch (Exception)
        {
            throw;
        }

        return filePath;
    }
}