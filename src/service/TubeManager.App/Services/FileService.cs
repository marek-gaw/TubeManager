namespace TubeManager.App.Services;

using Microsoft.AspNetCore.Http;

    public class FileService : IFileService
    {

        public FileService()
        {
        }

        public async Task PostFileAsync(IFormFile fileData, FileType fileType)
        {
            try
            {
                using (var stream = new MemoryStream())
                {
                    fileData.CopyTo(stream);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CopyStream(Stream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
               await stream.CopyToAsync(fileStream);
            }
        }
    }
