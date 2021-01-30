using System.Linq;
using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CoverTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(CoverType coverType)
        {
            var coverTypeFromDb = _dbContext.CoverTypes
                .FirstOrDefault(type => type.Id == coverType.Id);
            if (coverTypeFromDb != null)
                coverTypeFromDb.Name = coverType.Name;
        }
    }
}