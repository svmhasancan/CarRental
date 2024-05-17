using Business.Concrete;
using Core.Entities;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
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
            //CarTest();
            //BrandTest();
            //ColorTest();
            Console.ReadLine();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //carManager.Update(new Car
            //{
            //    CarId = 2,
            //    BrandId = 2,
            //    ColorId = 2,
            //    Name = "Mercedes",
            //    ModelYear = 2015,
            //    DailyPrice = 300,
            //    Description = "Mercedes"
            //});

            var result = carManager.GetCarDetails();
            foreach (var car in result.Data)
            {
                Console.WriteLine("Car : " + car.Name + "\n" + "Brand : " + car.Brand + "\n" + "Color : " + car.Color + "\n" + "Daily Price : " + car.DailyPrice);
                Console.WriteLine("");
            }


            Console.WriteLine(result.Message);
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            brandManager.Delete(new Brand
            {
                BrandId = 3
            });

            var result = brandManager.GetAll();
            foreach (var brand in result.Data)
            {
                Console.WriteLine(brand.Name);
            }
            
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Update(new Color
            {
                ColorId = 1,
                Name = "Turuncu"
            });
            var result = colorManager.GetAll();
            foreach (var color in result.Data)
            {
                Console.WriteLine(color.Name);
            }
        }
    }
}