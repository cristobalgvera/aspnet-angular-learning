using System.Linq;
using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Product product)
        {
            var productFromDb = _dbContext.Products
                .FirstOrDefault(prod => prod.Id == product.Id);
            if (productFromDb == null) return;

            if (product.ImageUrl != null)
                productFromDb.ImageUrl = product.ImageUrl;

            productFromDb.Author = product.Author;
            productFromDb.Description = product.Description;
            productFromDb.Isbn = product.Isbn;
            productFromDb.ListPrice = product.ListPrice;
            productFromDb.Price = product.Price;
            productFromDb.Price50 = product.Price50;
            productFromDb.Price100 = product.Price100;
            productFromDb.Title = product.Title;
            productFromDb.CategoryId = product.CategoryId;
            productFromDb.CoverTypeId = product.CoverTypeId;
        }
    }
}