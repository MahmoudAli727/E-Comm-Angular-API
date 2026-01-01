
using Ecom.Core.Interfaces;
using Ecom.infrastructure.Data;

namespace Ecom.infrastructure.Repositries
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public ICategoryRepository CategoriesRepository { get;}
        public IProductRepository ProductsRepository { get;}
        public IPhotoRepository PhotosRepository { get;}

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            CategoriesRepository = new CategoryRepository(_context);
            ProductsRepository = new ProductRepository(_context);
            PhotosRepository = new PhotoRepository(_context);
        }
    }
}
