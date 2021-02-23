using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        //List<Color> GetColorByCar(Car car);

        IResult Add(Color color);
        IResult Delete(Color color);

        IResult Update(Color color);

        IDataResult<Color> Get(int id);
        IDataResult<List<Color>> GetAll();
    }
}
