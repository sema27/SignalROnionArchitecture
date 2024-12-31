using SignalROnionArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalROnionArchitecture.Application
{
	public interface IDiscountDal : IGenericDal<Discount>
	{
		void ChangeStatusToTrue(int id);
		void ChangeStatusToFalse(int id);
		List<Discount> GetListByStatusTrue();
	}
}