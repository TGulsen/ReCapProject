using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCarContext reCarContext=new ReCarContext())
            {
                var result = from b in reCarContext.Brand
                             join c in reCarContext.Car on b.BrandId equals c.BrandId
                             join r in reCarContext.Color on c.ColorId equals r.ColorId
                             select new CarDetailDto
                             {
                                 BrandName = b.BrandName,
                                 CarName=c.Name,
                                 CarId = c.Id,
                                 DailyPrice = c.DailyPrice,
                                 ColorName=r.ColorName
                                 
                             };

                return result.ToList();

            }
        }
    }
}
