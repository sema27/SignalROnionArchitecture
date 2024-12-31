using SignalROnionArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalROnionArchitecture.Application.Services
{
    public interface IBasketService : IGenericService<Basket>
    {
        List<Basket> TGetBasketByMenuTableNumber(int id);
    }
}
