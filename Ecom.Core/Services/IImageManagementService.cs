using Microsoft.AspNetCore.Http;

namespace Ecom.Core.Services
{
    public interface IImageManagementService
    {
        Task<List<string>> AddImageAsync(IFormFileCollection files,string src);
        Task<bool> DeleteImageAsync(string src);
    }
}
