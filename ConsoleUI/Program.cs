﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CarImageTest();
            //CarTest();
            //BrandTest();
            //ColorTest();
            //UserTest();
            //RentalTest();
            //CustomerTest();


        }

        private static void CarImageTest()
        {
           
        }

        private static void CustomerTest()
        {
            ICustomerService customerManager = new CustomerManager(new EFCustomerDal());

            customerManager.Add(new Customer { CustomerId = 1, UserId = 1, CompanyName = "Deepy" });
            
            foreach (var c in customerManager.GetAll().Data)
            {
                Console.WriteLine(c.CustomerId + " : " + c.CompanyName);
            }
        }

        private static void RentalTest()
        {
            IRentalService rentalManager = new RentalManager(new EFRentalDal());

            var result = rentalManager.Add(new Rental {RentalId = 1, CustomerId = 1, CarId=3, RentDate = DateTime.Now});
            Console.WriteLine(result.Message);
            
            foreach (var item in rentalManager.GetAll().Data)
            {
                Console.WriteLine(item.RentalId + " : " + item.CustomerId + " " + item.CarId + " " + item.RentDate);
            }

        }

        private static void UserTest()
        {
            IUserService userManager = new UserManager(new EFUserDal());
            //userManager.Add(new User { FirstName = "Ahmet", LastName = "Aydın", Password = "ahmetaydin"});
            foreach (var item in userManager.GetAll().Data)
            {
                Console.WriteLine(item.Id + " : " + item.FirstName + " " + item.LastName);
            }
            //userManager.Delete(new User { UserId = 4 });
            
        }

        private static void ColorTest()
        {
            IColorService colorManager = new ColorManager(new EFColorDal());

            foreach (var c in colorManager.GetAll().Data)
            {
                Console.WriteLine(c.ColorId + " " + c.ColorName);
            }
            Console.WriteLine(colorManager.GetById(3).Data.ColorName);
        }

        private static void BrandTest()
        {
            IBrandService brandManager = new BrandManager(new EFBrandDal());

            foreach (var c in brandManager.GetAll().Data)
            {
                Console.WriteLine(c.BrandId + " " + c.BrandName);
            }
            Console.WriteLine(brandManager.GetById(3).Data.BrandName);
        }
         
        private static void CarTest()
        {
            ICarService carManager = new CarManager(new EFCarDal());
            carManager.Add(new Car { BrandId = 3, CarName = "sedan", ColorId = 4, DailyPrice = 250000, ModelYear = "2014" });

            foreach (var c in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(c.CarName + " : " +c.BrandName+ " : " +c.ColorName +" : " +c.DailyPrice);
            }
            //Console.WriteLine(carManager.GetById(3).Data.CarName + " " + carManager.GetById(3).Message);
        }
    }
}