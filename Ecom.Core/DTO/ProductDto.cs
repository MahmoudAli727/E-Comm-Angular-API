
using Ecom.Core.Entity.Product;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ecom.Core.DTO
{
    public record ProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public virtual List<PhotoDto> Photos { get; set; }
    };
    public record PhotoDto
    {
        public string ImageName { get; set; } = string.Empty;
        public int ProductId { get; set; }

    }
}
