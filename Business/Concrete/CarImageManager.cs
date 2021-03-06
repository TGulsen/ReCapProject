using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file,CarImage carImage)
        {
            string ImagePath = FileHelper.Add(file);
            IResult result = BusinessRules.Run(CheckIfCarImagesCompleted(carImage.CarId));
            if (result==null && ImagePath!=null)
            {
                carImage.Date = DateTime.Now;
                carImage.ImagePath = FileHelper.Add(file);
                _carImageDal.Add(carImage);

            return new SuccessResult(Messages.Added);
            }
            return new ErrorResult(Messages.NotAdded);
        }

        // Arabanın resimlerinin tamamlanıp tamamlanmadığını ölçen method (max 5 resim):
        private IResult CheckIfCarImagesCompleted(int carid)
        {
            var result = _carImageDal.GetAll(c => c.CarId== carid).Count;
            if (result>5)
            {
                return new ErrorResult(Messages.CapacityFulled);
            }
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            var result = this.Get(carImage.Id);
            var Deleted= FileHelper.Delete(result.Data.ImagePath);
            if (Deleted.Success)
            {
                _carImageDal.Delete(carImage);
                 return new SuccessResult(Messages.Deleted);
            }
            return new ErrorResult();
        }


        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id));
        }

        // Arabanın herhangi bir resmi yoksa default resmimizi gönderen method:
        private List<CarImage> CheckIfCarImageNull(int id)
        {
            var result = _carImageDal.GetAll(i => i.CarId == id).Any();
            if (!result)
            {
                return new List<CarImage>
                {
                    new CarImage
                    {
                        CarId = id,
                        Date= DateTime.Now,
                        ImagePath = "rental.jpg"
                    }
                };
            }
            return _carImageDal.GetAll(i => i.CarId == id);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath, file);
           
            _carImageDal.Update(carImage);

            return new SuccessResult();
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i=>i.Id==id),Messages.Listed);
        }


    }
}
