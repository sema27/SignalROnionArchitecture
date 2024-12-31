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
    public class EfTestimonialDal : GenericRepository<Testimonial>, ITestimonialDal
    {
        public EfTestimonialDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}