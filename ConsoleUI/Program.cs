using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //carManager.Add(new Car
            //{
            //    BrandName = "ABC",
            //    DailyPrice = 0,
            //    BrandId = 1,
            //    ColorId = 2,
            //    Description = "asdas",
            //    ModelYear = 2018
            //});
            //carManager.Delete(new Car
            //{
            //    Id = 104
            //});
            carManager.Update(new Car
            {
                Id = 103,
                BrandName = "Mercedes",
                DailyPrice = 150,
                BrandId = 2,
                ColorId = 1,
                Description = "asdas",
                ModelYear = 2018
            });
            foreach (var brand in carManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
            
            Console.ReadLine();
        }
    }
}