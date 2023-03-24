using Business.Abstract;
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
            //CarTest();
            //BrandTest();
            //ColorTest();
            //UserTest();
            //RentalTest();
            //CustomerTest();
            
            
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
            //userManager.Add(new User { UserId = 1, FirstName = "Onur", LastName = "Aydın", Password = "onuraydin", Email = "onuraydin@hotmail.com" });
            foreach (var item in userManager.GetAll().Data)
            {
                Console.WriteLine(item.UserId + " : " + item.FirstName + " " + item.LastName);
            }
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

            foreach (var c in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(c.CarName + " : " +c.BrandName+ " : " +c.ColorName +" : " +c.DailyPrice);
            }
            Console.WriteLine(carManager.GetById(3).Data.CarName + " " + carManager.GetById(3).Message);
        }
    }
}