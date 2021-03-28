using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine("--------------------------------");
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(car.CarName);
            }
            carManager.Add(new Car { BrandId = 1, ColorId = 1, CarName = "BMW 520i", ModelYear = "2015", DailyPrice = 350, Description = "2015 Model BMW 520i"});
        }
    }
}
