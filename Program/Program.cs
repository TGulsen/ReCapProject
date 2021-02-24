using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carmanager = new CarManager(new EfCarDal());


            var result = carmanager.GetCarsByDailyPrice(150000, 4000000);
            foreach (var item in result.Data)
            {
                Console.WriteLine(); 

            }


            
            //if (result.Success==true)
            //{
            //    foreach (var item in result.Data)
            //    {
            //        Console.WriteLine("Araba İsmi: " +item.CarName +"   Markası:" + item.BrandName +" Rengi: " + item.ColorName + " Günlük fiyat: " +item.DailyPrice);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}


     

            BrandManager brandManager = new BrandManager(new EfBrandDal());


            //var result= brandManager.GetAll();
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.BrandName);
            //}

        }
    }
}
