
using System.Text.Json.Serialization;

namespace Ecom.Core.Entity.Product
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
