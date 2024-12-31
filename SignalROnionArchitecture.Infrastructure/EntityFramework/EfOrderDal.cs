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
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        private readonly ApplicationDbContext _context;

        public EfOrderDal(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public int ActiveOrderCount()
        {
            return _context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
        }

        public decimal LastOrderPrice()
        {
            return _context.Orders.OrderByDescending(x => x.OrderID).Take(1).Select(y => y.TotalPrice).FirstOrDefault();
        }

        public decimal TodayTotalPrice()
        {
            return 0;
        }

        public int TotalOrderCount()
        {
            return _context.Orders.Count();
        }
    }
}