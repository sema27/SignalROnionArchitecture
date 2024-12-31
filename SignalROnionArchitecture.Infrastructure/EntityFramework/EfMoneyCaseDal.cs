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
    public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
    {
        private readonly ApplicationDbContext _context;

        public EfMoneyCaseDal(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public decimal TotalMoneyCaseAmount()
        {
            return _context.MoneyCases.Select(x => x.TotalAmount).FirstOrDefault();
        }
    }
}