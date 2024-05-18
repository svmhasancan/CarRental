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
            //CarTest(); - successful
            //BrandTest(); - successful
            //ColorTest(); - successful
            //UserTest(); - successful
            //CustomerTest(); - successful
            //RentalTest(); - successful
            Console.ReadLine();
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            userManager.Delete(new User
            {
                Id = 3,
            });

            var result = userManager.GetAll();

            foreach (var user in result.Data)
            {
                Console.WriteLine(user.FirstName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Update(new Car
            {
                Id = 3,
                BrandId = 3,
                ColorId = 3,
                Name = "Toyota",
                ModelYear = 2015,
                DailyPrice = 300,
                Description = "Toyota"
            });

            var result = carManager.GetCarDetails();
            foreach (var car in result.Data)
            {
                Console.WriteLine("Car : " + car.Name + "\n" + "Brand : " + car.Brand + "\n" + "Color : " + car.Color + "\n" + "Daily Price : " + car.DailyPrice);
                //Console.WriteLine(car.Name);
                Console.WriteLine("");
            }


            Console.WriteLine(result.Message);
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            brandManager.Delete(new Brand
            {
                Id = 4,
                Name = "Nissan"
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

            //colorManager.Delete(new Color
            //{
            //    Id = 4,
            //    Name = "Lila"
            //});
            var result = colorManager.GetById(2);
            foreach (var color in result.Data.Name)
            {
                Console.WriteLine(color);
            }
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            var result = customerManager.GetById(2);

            Console.WriteLine(result.Data.CompanyName);
            //foreach (var customer in result.Data)
            //{
            //    Console.WriteLine(customer.Id);
            //    Console.WriteLine(customer.UserId);
            //    Console.WriteLine(customer.CompanyName);
            //    Console.WriteLine("");
            //}
        }
        
        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            rentalManager.Add(new Rental
            {
                CarId = 2,
                CustomerId = 2,
                RentDate = DateTime.Now,
                ReturnDate = DateTime.Now
            });

            var result = rentalManager.GetAll();
            
            foreach (var rental in result.Data)
            {
                Console.WriteLine("Id : " + rental.Id);
                Console.WriteLine("CarId : " + rental.CarId);
                Console.WriteLine("CustomerId : " + rental.CustomerId);
                Console.WriteLine("RentDate : " + rental.RentDate);
                Console.WriteLine("ReturnDate : " + rental.ReturnDate);
                Console.WriteLine(result.Message);
                Console.WriteLine("");
            }
        }
    }
}