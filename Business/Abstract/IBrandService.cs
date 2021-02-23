using System;
using System.Text;
using System.Collections.Generic;
using Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<Brand> GetBrandByCar(Car car);

        IResult Add(Brand brand);
        IResult Delete(Brand brand);
        IResult Update(Brand brand);

        IDataResult<Brand> Get(int id);
        IDataResult<List<Brand>> GetAll();
    }
}
