﻿using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public decimal DailyPrice { get; set; }
    }
}