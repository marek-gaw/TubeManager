using Microsoft.AspNetCore.Http;

namespace TubeManager.App.Services;

    public class FileUploadModel
    {
        public IFormFile FileDetails { get; set; }
        public FileType FileType { get; set; }
    }

    public enum FileType
    {
        PDF = 1,
        DOCX = 2
    }