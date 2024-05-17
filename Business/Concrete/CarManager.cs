using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.Name.Length < 2)
            {
                return new ErrorResult("Araba İsmi Min. 2 karakter olmalıdır.");
            }
            if (car.DailyPrice <= 0)
            {
                return new ErrorResult("Araba Günlük Fiyatı 0 ₺'nin altında olamaz.");
            }
            _carDal.Add(car);
            return new SuccessResult("Araba Eklendi!");
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Araba Silindi!");
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),"Arabalar Listelendi!");
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p=>p.CarId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult("Araba Güncellendi");
        }
    }
}