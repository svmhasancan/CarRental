﻿using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto2> GetCarDetails();
        List<CarDetailDto2> GetCarDetailsByBrandName(string brandName);
    }
}