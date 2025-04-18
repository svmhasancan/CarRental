using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car,RentACarContext>,ICarDal
    {
        //public List<CarDetailDto> GetCarDetails()
        //{
        //    using (RentACarContext context = new RentACarContext())
        //    {
        //        var result = from c in context.Cars
        //            join b in context.Brands
        //                on c.BrandId equals b.Id
        //            join co in context.Colors
        //                on c.ColorId equals co.Id
        //            select new CarDetailDto
        //            {
        //                CarName = c.Name,
        //                BrandName = b.Name,
        //                ColorName = co.Name,
        //                DailyPrice = c.DailyPrice
        //            };
        //        return result.ToList();
        //    }
        //}

        public List<CarDetailDto2> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join co in context.Colors on c.ColorId equals co.Id
                             from ci in context.CarImages.Where(x => x.CarId == c.Id).DefaultIfEmpty() // Client tarafında işle
                             select new CarDetailDto2
                             {
                                 CarId = c.Id,
                                 CarName = c.Name,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description,
                                 CarImages = context.CarImages
                                     .Where(x => x.CarId == c.Id)
                                     .Select(x => new CarImageDto
                                     {
                                         ImagePath = x.ImagePath,
                                         Date = x.Date
                                     }).ToList()
                             };
                return result.ToList();
            }
        }



        public string GetCarDetailsByBrandName(string brandName)
        {
            return brandName;
        }

    }
}