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
{ // logic
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        private IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal,IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimit(carImage.CarId));

            if(result != null)
            {
                return new ErrorResult();
            }

            string root = PathConstants.ImagesPath;
            carImage.ImagePath = _fileHelper.Upload(file, root);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult("Araç resmi eklendi");
        }

        public IResult Delete(CarImage carImage)
        {
            string filePath = PathConstants.ImagesPath+carImage.ImagePath;
            _fileHelper.Delete(filePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult("Araç resmi silindi");
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetImageById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=>c.Id == id));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c=>c.CarId == carId));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IResult CheckImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if(result > 5)
            {
                return new ErrorResult("Bir Arabanın En Fazla 5 resmi olabilir!");
            }
            return new SuccessResult();
        }
    }
}
