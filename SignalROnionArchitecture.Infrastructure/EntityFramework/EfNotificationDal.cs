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
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        private readonly ApplicationDbContext _context;

        public EfNotificationDal(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Notification> GetAllNotificationByFalse()
        {
            return _context.Notifications.Where(x => x.Status == false).ToList();
        }

        public int NotificationCountByStatusFalse()
        {
            return _context.Notifications.Where(x => x.Status == false).Count();
        }

        public void NotificationStatusChangeToFalse(int id)
        {
            var value = _context.Notifications.Find(id);
            value.Status = false;
            _context.SaveChanges();
        }

        public void NotificationStatusChangeToTrue(int id)
        {
            var value = _context.Notifications.Find(id);
            value.Status = true;
            _context.SaveChanges();
        }
    }
}