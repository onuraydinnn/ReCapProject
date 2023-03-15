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
            CarManager carManager = new CarManager(new EFCarDal());
            carManager.GetAll();
            carManager.Add(new Car {CarId = 1, BrandId = 2, ColorId = 6, DailyPrice = 250000, ModelYear = "2014", CarName = "opel j station wagon" });




            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.CarName+" : "+c.DailyPrice);
            }





        }
    }
}