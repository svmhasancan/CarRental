using Core.DataAccess.EnityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        //public List<CarDetailDto> GetCarDetails()
        //{
        //    using (RentACarContext context = new RentACarContext())
        //    {
        //        var result = from c in context.Cars
        //                     join b in context.Brands
        //                     on c.BrandId equals b.BrandId
        //                     join co in context.Colors
        //                     on c.ColorId equals co.ColorId
        //                     select new CarDetailDto
        //                     {
        //                         Name = c.Name,
        //                         Brand = b.Name,
        //                         Color = co.Name,
        //                         DailyPrice = c.DailyPrice
        //                     };
        //        return result.ToList();
        //    }
        //}
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             select new CarDetailDto
                             {
                                 Name = c.Name,
                                 Brand = b.Name,
                                 Color = co.Name,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}