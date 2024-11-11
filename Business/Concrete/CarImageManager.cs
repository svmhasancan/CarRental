using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        private IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImageLimit());

            if(result != null)
            {
                return new ErrorResult(result.Message);
            }

            string root = PathConstants.ImagesPath;
            carImage.ImagePath = _fileHelper.Upload(file, root);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult("Resim başarılı bir şekilde eklendi!");
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            string root = PathConstants.ImagesPath;
            string filePath = root + carImage.ImagePath;
            _fileHelper.Update(file,filePath,root);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=>c.Id == imageId));
        }
        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));

            if(result != null)
            {
                return new SuccessDataResult<List<CarImage>>(GetDefaultImage(carId).Data,"Aracın resmi olmadığı için default resim gösterilmiştir.");
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c=>c.CarId == carId));
        }

        public IResult CheckCarImageLimit()
        {
            var result = _carImageDal.GetAll().Count;

            if(result > 5)
            {
                return new ErrorResult("Bir arabanın en fazla 5 resmi olabilir.");
            }
            return new SuccessResult();
        }

        public IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c=>c.CarId == carId).Count;
            if(result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImages = new List<CarImage>();

            carImages.Add(new CarImage
            {
                CarId = carId,
                Date = DateTime.Now,
                ImagePath = PathConstants.DefaultImagePath
            });

            return new SuccessDataResult<List<CarImage>>(carImages);
        }
    }
}
