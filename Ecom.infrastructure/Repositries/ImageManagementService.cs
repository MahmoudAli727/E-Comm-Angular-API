
using Ecom.Core.Services;
using Microsoft.AspNetCore.Http;

namespace Ecom.infrastructure.Repositries
{
    public class ImageManagementService : IImageManagementService
    {
        private readonly IFormatProvider _formatProvider;
        public ImageManagementService(IFormatProvider formatProvider)
        {
            _formatProvider = formatProvider;
        }
        public Task<List<string>> AddImageAsync(IFormFileCollection files, string src)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteImageAsync(string src)
        {
            throw new NotImplementedException();
        }
    }
}
