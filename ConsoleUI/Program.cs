using System;
using System.Collections.Generic;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine("Markaya göre araba adı: {0}", car.Name);
            }

            Console.WriteLine("***********************");

            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine("Renge göre araba adı: {0}", car.Name);
            }

            Console.WriteLine("***********************");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Araba: {0} / Model yılı: {1} / Günlük ücreti: {2}", car.Name, car.ModelYear, car.DailyPrice);
            }

            Console.WriteLine("***********************");

            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }

            Console.ReadKey();
        }
    }
}
