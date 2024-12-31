using SignalROnionArchitecture.Application;
using SignalROnionArchitecture.Core.Entities;
using SignalROnionArchitecture.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalROnionArchitecture.Infrastructure.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        private readonly ApplicationDbContext _context;

        public EfCategoryDal(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public int ActiveCategoryCount()
        {
            return _context.Categories.Where(x => x.CategoryStatus == true).Count();
        }

        public int CategoryCount()
        {
            return _context.Categories.Count();
        }

        public int PassiveCategoryCount()
        {
            return _context.Categories.Where(x => x.CategoryStatus == false).Count();
        }
    }
}