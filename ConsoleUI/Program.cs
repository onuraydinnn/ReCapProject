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
            CarTest();
            //BrandTest();
            //ColorTest();

        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());

            foreach (var c in colorManager.GetAll().Data)
            {
                Console.WriteLine(c.ColorId + " " + c.ColorName);
            }
            Console.WriteLine(colorManager.GetById(3).Data.ColorName);
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());

            foreach (var c in brandManager.GetAll().Data)
            {
                Console.WriteLine(c.BrandId + " " + c.BrandName);
            }
            Console.WriteLine(brandManager.GetById(3).Data.BrandName);
        }
         
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());

            foreach (var c in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(c.CarName + " : " +c.BrandName+ " : " +c.ColorName +" : " +c.DailyPrice);
            }
            Console.WriteLine(carManager.GetById(3).Data.CarName + " " + carManager.GetById(3).Message);
        }
    }
}