﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalROnionArchitecture.Application.Dtos.MenuTableDto
{
    public class GetMenuTableDto
    {
        public int MenuTableID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}