using System;
using System.Threading.Channels;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Repository;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // RentCarContext context= new RentCarContext();
            // context.Database.Migrate(); rf
            CarManager carManager = new CarManager(new EfCarDao());
            BrandManager brandManager = new BrandManager(new EfBrandDao());
            ColorManager colorManager = new ColorManager(new EfColorDao());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDao());
            UserManager userManager = new UserManager(new EfUserDao());
            RentalManager rentalManager = new RentalManager(new EfRentalDao());

            //    bool cikis = true;
            //    while (cikis)
            //    {
            //        Console.WriteLine(
            //            "Rent A Car \n---------------------------------------------------------------" +
            //            "\n\n1.Araba Ekleme\n" +
            //            "2.Araba Silme\n" +
            //            "3.Araba Güncelleme\n" +
            //            "4.Arabaların Listelenmesi\n" +
            //            "5.Arabaların detaylı bir şekilde Listelenmesi\n" +
            //            "6.Arabaların fiyat aralığına göre Listelenmesi\n" +
            //            "7.Arabaların model yılına göre Listelenmesi\n" +
            //            "8.Müşteri Ekleme\n" +
            //            "9.Müşterilerin Listelenmesi\n" +
            //            "10.Kullanıcı Ekleme\n" +
            //            "11.Kullanıcıların Listelenmesi\n" +
            //            "12.Araba Kiralama\n" +
            //            "13.Araba Teslim Etme\n" +
            //            "14.Araba Kiralama Listesi\n" +
            //            "15.Çıkış\n" +
            //            "Yukarıdakilerden hangi işlemi gerçekleştirmek istiyorsunuz ?"
            //        );
            //        int number = Convert.ToInt32(Console.ReadLine());
            //        Console.WriteLine("----------------------------------");
            //        switch (number)
            //        {
            //            case 1:
            //                CarAddition(carManager,brandManager,colorManager);
            //                break;
            //            case 2:
            //                GetAllCarDetails(carManager);
            //                CarDeletion(carManager);
            //                break;
            //            case 3:
            //                GetAllCarDetails(carManager);
            //                CarUpdate(carManager);
            //                break;
            //            case 4:
            //                GetAllCar(carManager);
            //                break;
            //            case 5:
            //                GetAllCarDetails(carManager);
            //                break;
            //            case 6:
            //                carByDetailPrice(carManager,brandManager,colorManager);
            //                break;
            //            case 7:
            //                GetAllCarDetails(carManager);
            //                CarByModelYear(carManager,brandManager,colorManager);
            //                break;
            //            case 8:
            //                GetAllUserList(userManager);
            //                CustomerAddition(customerManager);
            //                break;
            //            case 9:
            //                GetAllCustomerList(customerManager);
            //                break;
            //            case 10:
            //                UserAddition(userManager);
            //                break;
            //            case 11:
            //                GetAllUserList(userManager);
            //                break;
            //            case 12:
            //                GetAllCarDetails(carManager);
            //                GetAllCustomerList(customerManager);
            //                RentalAddition(rentalManager);
            //                break;
            //            case 13:
            //                ReturnRental(rentalManager);
            //                break;
            //            case 14:
            //                GetAllRentalDetails(rentalManager);
            //                break;
            //            case 15:
            //                cikis = false;
            //                Console.WriteLine("cikiş işlemi gerçekleştirildi");
            //                break;
            //            default:
            //                cikis = false;
            //                Console.WriteLine("istenilmeyen durum veya hatalı giriş");
            //                break;
            //        }
            //    }
            //}

            //private static void UserAddition(UserManager userManager)
            //{
            //    Console.WriteLine("First Name : ");
            //    string userNameForAdd = Console.ReadLine();
            //    Console.WriteLine("Last Name : ");
            //    string userSurnameForAdd = Console.ReadLine();
            //    Console.WriteLine(" Email Name  : ");
            //    string userEmailForAdd = Console.ReadLine();
            //    Console.WriteLine(" Password Name : ");
            //    string userPasswordForAdd = Console.ReadLine();

            //    User userForAdd = new User
            //    {
            //        FirstName = userNameForAdd,
            //        LastName = userSurnameForAdd,
            //        Email = userEmailForAdd,

            //    };
            //    userManager.Add(userForAdd);
            //}

            //private static void CustomerAddition(CustomerManager customerManager)
            //{
            //    Console.WriteLine("User Id : ");
            //    int userIdForAdd = Convert.ToInt32(Console.ReadLine());

            //    Console.WriteLine("Customer Name : ");
            //    string companyNameForAdd = Console.ReadLine();

            //    Customer customerForAdd = new Customer
            //    {
            //        UserId = userIdForAdd,
            //        CompanyName = companyNameForAdd
            //    };
            //    customerManager.Add(customerForAdd);
            //}

            //private static void GetAllRentalDetails(RentalManager rentalManager)
            //{
            //    Console.WriteLine("Kiralanan arabalar Listesi : \n Id\tCar Name\tCompanyName\tRent Date\tReturn Date");
            //    foreach (var rental in rentalManager.GetRentalDetails().Data)
            //    {
            //        Console.WriteLine($"{rental.RentalId}\t{rental.CarName}\t{rental.CompanyName}\t{rental.RentDate}\t{rental.ReturnDate}");
            //    }
            //}

            //private static void ReturnRental(RentalManager rentalManager)
            //{
            //    Console.WriteLine("Kiraladığınız araba hangi car Idye sahiptir ?");
            //    int carId = Convert.ToInt32(Console.ReadLine());
            //    var returnedRental = rentalManager.GetRentalDetails(I => I.CarId == carId);
            //    foreach (var rental in returnedRental.Data)
            //    {
            //        rental.ReturnDate = DateTime.Now;
            //        Console.WriteLine(returnedRental.Message);
            //    }
            //}

            //private static void RentalAddition(RentalManager rentalManager)
            //{
            //    Console.WriteLine("Car Id: ");
            //    int carIdForAdd = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine("Customer Id: ");
            //    int customerIdForAdd = Convert.ToInt32(Console.ReadLine());

            //    Rental rentalForAdd = new Rental
            //    {
            //        CarId = carIdForAdd,
            //        CustomerId = customerIdForAdd,
            //        RentDate = DateTime.Now,
            //        ReturnDate = null,
            //    };
            //    Console.WriteLine(rentalManager.Add(rentalForAdd).Message);

            //}

            //private static void GetAllCustomerList(CustomerManager customerManager)
            //{
            //    Console.WriteLine("Müsterilerin Listesi : \nId\tKullanıcı Id\t CompanyName");
            //    foreach (var customer in customerManager.GetAll().Data)
            //    {
            //        Console.WriteLine($"{customer.CustomerId}\t{customer.UserId}\t{customer.CompanyName}");
            //    }
            //}

            //private static void GetAllUserList(UserManager userManager)
            //{
            //    Console.WriteLine("Kullanıcı Listesi : \nId\tFirst Name\tLast Name\tEmail\tPassword");
            //    foreach (var user in userManager.GetAll().Data)
            //    {
            //        Console.WriteLine($"{user.UserId}\t{user.FirstName}\t{user.LastName}\t{user.Email}\t{user.Password}");
            //    }
            //}

            //private static void CarByModelYear(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
            //{
            //    Console.WriteLine("hangi model yılına sahip arabayı görmek istiyorsunuz ? Lütfen Yıl değeri giriniz.");

            //    string modelYearForCarList = Console.ReadLine();

            //    Console.WriteLine($"{modelYearForCarList}istenilen model yılına sahip arabalar \nId\tModelYear\tCar Name\tDaily Price\tDescription");

            //    foreach (var car in carManager.GetByModelYear(modelYearForCarList).Data)
            //    {
            //        Console.WriteLine($"{car.CarId}\t{car.ModelYear}\t{car.CarName}\t{car.DailyPrice}\t{car.Descriptions}");
            //    }
            //}

            //private static void carByDetailPrice(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
            //{
            //    decimal min = Convert.ToDecimal(Console.ReadLine());
            //    decimal max = Convert.ToDecimal(Console.ReadLine());

            //    Console.WriteLine($"\n\n Günlük Fiyat Aralığı {min} ile {max} olan arabalar : \nId\tColorId\tBrandId\tModel Year\tDaily PRice\t Description");
            //    foreach (var car in carManager.GetByDailyPrice(min, max).Data)
            //    {
            //        Console.WriteLine($"{car.CarId}\t{car.ColorId}\t{car.BrandId}\t{car.ModelYear}\t{car.DailyPrice}\t{car.Descriptions}");
            //    }
            //}

            //private static void CarUpdate(CarManager carManager)
            //{
            //    Console.WriteLine("Car Id : ");
            //    int carIdForUpdate = Convert.ToInt32(Console.ReadLine());

            //    Console.WriteLine("Brand Id : ");
            //    int brandIdForUpdate = Convert.ToInt32(Console.ReadLine());

            //    Console.WriteLine("Color Id : ");
            //    int colorIdForUptade = Convert.ToInt32(Console.ReadLine());

            //    Console.WriteLine("Daily Price : ");
            //    decimal dailyPriceForUpdate = Convert.ToDecimal(Console.ReadLine());

            //    Console.WriteLine("Description : ");
            //    string descriptionForUpdate = Console.ReadLine();

            //    Console.WriteLine("Model Year : ");
            //    string modelYearForUpdate = Console.ReadLine();

            //    Car carForUpdate = new Car
            //    {
            //        CarId = carIdForUpdate, BrandId = brandIdForUpdate, ColorId = colorIdForUptade,
            //        DailyPrice = dailyPriceForUpdate, Descriptions = descriptionForUpdate, ModelYear = modelYearForUpdate
            //    };
            //    carManager.Update(carForUpdate);
            //}
            //private static void CarAddition(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
            //{
            //    Console.WriteLine("Color Listesi");
            //    GetAllColor(colorManager);

            //    Console.WriteLine("Brand Listesi");
            //    GetAllBrand(brandManager);

            //    Console.WriteLine("\nBrand Id: ");
            //    int brandIdForAdd = Convert.ToInt32(Console.ReadLine());

            //    Console.WriteLine("Color Id: ");
            //    int colorIdForAdd = Convert.ToInt32(Console.ReadLine());

            //    Console.WriteLine("Daily Price: ");
            //    decimal dailyPriceForAdd = Convert.ToDecimal(Console.ReadLine());

            //    Console.WriteLine("Description : ");
            //    string descriptionForAdd = Console.ReadLine();

            //    Console.WriteLine("Model Year: ");
            //    string modelYearForAdd = Console.ReadLine();

            //    Car carForAdd = new Car { BrandId = brandIdForAdd, ColorId = colorIdForAdd, DailyPrice = dailyPriceForAdd, Descriptions = descriptionForAdd, ModelYear = modelYearForAdd };
            //    carManager.Add(carForAdd);
            //}
            //private static void CarDeletion(CarManager carManager)
            //{
            //    Console.WriteLine("Hangi Idye sahip arabayı silmek istiyorsunuz ?");
            //    int carIdForDelete = Convert.ToInt32(Console.ReadLine());
            //    carManager.Delete(carManager.GetById(carIdForDelete).Data);
            //}
            //private static void GetAllCarDetails(CarManager carManager)
            //{
            //    Console.WriteLine("Arabaların detaylı listesi:  \nId\tCar Name\tColor Name\tBrand Name\tDaily Price");
            //    foreach (var car in carManager.GetCarDetails().Data)
            //    {
            //        Console.WriteLine($"{car.CarId}\t{car.CarName}\t{car.ColorName}\t\t{car.BrandName}\t\t{car.DailyPrice}\t");
            //    }
            //}
            //private static void GetAllCar(CarManager carManager)
            //{
            //    Console.WriteLine("Arabaların Listesi:  \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            //    foreach (var car in carManager.GetAll().Data)
            //    {
            //        Console.WriteLine($"{car.CarId}\t{car.ColorId}\t\t{car.BrandId}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");
            //    }
            //}
            //private static void CarById(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
            //{
            //    Console.WriteLine("Hangi arabayı görmek istiyorsunuz? Lütfen bir Id numarası yazınız.");
            //    int carId = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine($"\n\nId'si {carId} olan araba: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            //    Car carById = carManager.GetById(carId).Data;
            //    Console.WriteLine($"{carById.CarId}\t{colorManager.GetById(carById.ColorId).Data.ColorName}\t\t{brandManager.GetById(carById.BrandId).Data.BrandName}\t\t{carById.ModelYear}\t\t{carById.DailyPrice}\t\t{carById.Descriptions}");
            //}
            //private static void GetAllBrand(BrandManager brandManager)
            //{
            //    foreach (var brand in brandManager.GetAll().Data)
            //    {
            //        Console.WriteLine($"{brand.BrandId}\t{brand.BrandName}");
            //    }
            //}

            //private static void GetAllColor(ColorManager colorManager)
            //{
            //    foreach (var color in colorManager.GetAll().Data)
            //    {
            //        Console.WriteLine($"{color.ColorId}\t{color.ColorName}");
            //    }
            //}
        }
    }
}
