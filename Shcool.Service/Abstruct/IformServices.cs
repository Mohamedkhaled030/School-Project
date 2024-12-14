using Microsoft.AspNetCore.Http;

namespace Shcool.Service.Abstruct
{
    public interface IformServices
    {
        public Task<string> UploadImage(string Location, IFormFile file);
    }
}
