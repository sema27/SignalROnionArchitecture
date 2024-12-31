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
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        private readonly ApplicationDbContext _context;

        public EfDiscountDal(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void ChangeStatusToFalse(int id)
        {
            var value = _context.Discounts.Find(id);
            value.Status = false;
            _context.SaveChanges();
        }

        public void ChangeStatusToTrue(int id)
        {
            var value = _context.Discounts.Find(id);
            value.Status = true;
            _context.SaveChanges();
        }

        public List<Discount> GetListByStatusTrue()
        {
            var value = _context.Discounts.Where(x => x.Status == true).ToList();
            return value;
        }
    }
}