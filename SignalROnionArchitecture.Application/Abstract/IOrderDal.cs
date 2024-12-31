using SignalROnionArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalROnionArchitecture.Application
{
	public interface IOrderDal:IGenericDal<Order>
	{
        int TotalOrderCount();
        int ActiveOrderCount();
        decimal LastOrderPrice();
        decimal TodayTotalPrice();
    }
}
