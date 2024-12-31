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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        private readonly ApplicationDbContext _context;

        public EfBookingDal(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void BookingStatusApproved(int id)
        {
            var values = _context.Bookings.Find(id);
            values.Description = "Rezervasyon Onaylandı";
            _context.SaveChanges();
        }

        public void BookingStatusCancelled(int id)
        {
            var values = _context.Bookings.Find(id);
            values.Description = "Rezervasyon İptal Edildi";
            _context.SaveChanges();
        }
    }
}