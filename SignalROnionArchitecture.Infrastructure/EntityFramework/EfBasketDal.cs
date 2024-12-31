using Microsoft.EntityFrameworkCore;
using SignalROnionArchitecture.Application;
using SignalROnionArchitecture.Core.Entities;
using SignalROnionArchitecture.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SignalROnionArchitecture.Infrastructure.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        private readonly ApplicationDbContext _context;

        public EfBasketDal(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Basket> GetBasketByMenuTableNumber(int id)
        {
            var values = _context.Baskets
                .Where(x => x.MenuTableID == id)
                .Include(y => y.Product)
                .ToList();

            return values;
        }
    }
}
