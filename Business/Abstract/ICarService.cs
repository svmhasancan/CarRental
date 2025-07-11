﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<Car> GetCarById(int carId);
        IDataResult<List<CarDetailDto2>> GetCarDetails();
        IDataResult<List<CarDetailDto2>> GetCarDetailsByBrandName(string brandName);
        //IDataResult<List<CarDetailDto>> GetCarDetailsByBrandName(string brandName);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        
    }
}