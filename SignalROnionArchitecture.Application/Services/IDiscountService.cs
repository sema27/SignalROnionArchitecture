using SignalROnionArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalROnionArchitecture.Application.Services
{
    public interface IDiscountService : IGenericService<Discount>
    {
        void TChangeStatusToTrue(int id);
        void TChangeStatusToFalse(int id);
        List<Discount> TGetListByStatusTrue();
    }
}
