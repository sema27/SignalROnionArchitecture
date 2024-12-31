﻿using SignalROnionArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalROnionArchitecture.Application
{
	public interface IMenuTableDal : IGenericDal<MenuTable>
	{
		int MenuTableCount();
		void ChangeMenuTableStatusToTrue(int id);
		void ChangeMenuTableStatusToFalse(int id);
	}
}
