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
    public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
    {
        private readonly ApplicationDbContext _context;

        public EfMenuTableDal(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void ChangeMenuTableStatusToFalse(int id)
        {
            var value = _context.MenuTables.Where(x => x.MenuTableID == id).FirstOrDefault();
            value.Status = false;
            _context.SaveChanges();
        }

        public void ChangeMenuTableStatusToTrue(int id)
        {
            var value = _context.MenuTables.Where(x => x.MenuTableID == id).FirstOrDefault();
            value.Status = true;
            _context.SaveChanges();
        }

        public int MenuTableCount()
        {
            return _context.MenuTables.Count();
        }
    }
}