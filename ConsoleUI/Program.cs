using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ICarDal carDal = new InMemory();
            carDal.AddCar(new Car {Id=1, BrandId=1, ColorId="2225", DailyPrice=250000, ModelYear="2014", Description="J station wagon"});
            carDal.AddCar(new Car { Id = 2, BrandId = 2, ColorId = "6223", DailyPrice = 4825000, ModelYear = "2014", Description = "G Arazi" });
            carDal.AddCar(new Car { Id = 3, BrandId = 2, ColorId = "0000", DailyPrice = 2539000, ModelYear = "2021", Description = "C Sedan" });

            CarManager carManager = new CarManager(carDal);
            carManager.GetAll();

            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine("Firma : " + c.BrandId + " Fiyat : " + c.DailyPrice + " " + c.Description);
            }

            Console.WriteLine("-----------------------------------");
            carDal.Delete(new Car {Id=2 });

            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine("Firma : " + c.BrandId + " Fiyat : " + c.DailyPrice + " " + c.Description);
            }


        }
    }
}