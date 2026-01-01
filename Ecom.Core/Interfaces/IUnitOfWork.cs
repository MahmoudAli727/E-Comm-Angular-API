
namespace Ecom.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoriesRepository { get; }
        public IProductRepository ProductsRepository { get; }
        public IPhotoRepository PhotosRepository { get; }
    }
}
