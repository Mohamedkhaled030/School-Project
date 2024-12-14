using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Shcool.Service.Abstruct;

namespace Shcool.Service.Implementations
{
    public class FileService : IformServices
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> UploadImage(string Location, IFormFile file)
        {
            var path = _webHostEnvironment.WebRootPath + "/" + Location + "/";
            var Extintion = Path.GetExtension(file.FileName);
            var filename = Guid.NewGuid().ToString().Replace("_", string.Empty) + Extintion;
            if (file.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    using (FileStream fileStreem = File.Create(path + filename))
                    {
                        await file.CopyToAsync(fileStreem);
                        await fileStreem.FlushAsync();
                        return $"/{Location}/{filename}";
                    }
                }
                catch (Exception)
                {
                    return "FaildUpload";
                }
            }
            else
            {
                return "NoImage";
            }
        }
    }
}
