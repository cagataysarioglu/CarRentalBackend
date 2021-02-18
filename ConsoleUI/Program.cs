using System;
using System.Collections.Generic;
using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarAddition();
            //CarUpdate();
            //CarDeregistration();
            //DisplayingCarDetails();
            //DisplayingCarsByPrice();
            //DisplayingCarsByBrand();
            //DisplayingCarsByColor();
            NonFilterListing();

            //UserAddition();
            //ListOfAllUsers();
            //AddListRental();

            Console.ReadKey();
        }

        private static void AddListRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rentalToAdd = new Rental()
            {
                CarId = 1,
                CustomerId = 1,
                RentDate = new DateTime(2020, 2, 12).Date
            };
            rentalManager.Add(rentalToAdd);
            Console.WriteLine(Messages.Added);
            var result = rentalManager.GetAll();
            if (result.Success == true)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine("Car ID: {0} / Customer ID: {1} / Rent date: {2}", rental.CarId, rental.CustomerId,
                        rental.RentDate);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ListOfAllUsers()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetAll();
            if (result.Success == true)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine("User name: {0} / User surname: {1} / E-mail: {2}", user.Name, user.Surname, user.Email);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void UserAddition()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User userToAdd = new User()
            {
                Name = "Çağatay",
                Surname = "Sarıoğlu",
                Email = "cagataysarioglu@eposta.com",
                Password = "parolalorap"
            };
            userManager.Add(userToAdd);
            Console.WriteLine(Messages.Added);
        }

        private static void NonFilterListing()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car name: {0} / Daily price: {1} / Car id: {2}", car.Name, car.DailyPrice, car.CarId);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void DisplayingCarsByColor()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarsByColorId(5);
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car by color: {0}", car.Name);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void DisplayingCarsByBrand()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarsByBrandId(1);
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car and its model year by brand: {0} - {1}", car.Name, car.ModelYear);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void DisplayingCarsByPrice()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetByDailyPrice(100, 600);
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car in the specified price range: {0}", car.Name);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void DisplayingCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails(10);
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car name: {0}\nDaily price: {1}\nModel year: {2}", car.Name, car.DailyPrice, car.ModelYear);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarDeregistration()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.Delete(carManager.GetById(1002).Data);
            Console.WriteLine(Messages.Deleted);
        }

        private static void CarUpdate()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car carToUpdate = carManager.GetById(5).Data;
            carToUpdate.DailyPrice = 725;
            var result = carManager.Update(carToUpdate);
            Console.WriteLine(Messages.Updated);
        }

        private static void CarAddition()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car carToAdd = new Car()
            {
                BrandId = 1,
                Name = "TOGG",
                ColorId = 2,
                ModelYear = 2022,
                DailyPrice = 700,
                Description = "Best in class."
            };
            carManager.Add(carToAdd);
            Console.WriteLine(Messages.Added);
        }
    }
}
