using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom.Core.Entity.Product
{
    public class Product: BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category? Category { get; set; } = new Category();
        public virtual List<Photo> Photos { get; set; }
    }
}
