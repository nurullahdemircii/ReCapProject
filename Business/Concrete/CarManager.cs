using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public Car Add(Car car)
        {
            if (car.CarName.Length <= 2)
            {
                Console.WriteLine("Araba İsmi 2 karakterden fazla olmalıdır!");
            }
            if (car.DailyPrice <= 0)
            {
                Console.WriteLine("Günlük Fiyat 0₺'den Büyük olmak zorundadır!");
                //return new ErrorResult(Messages.Error);
            }
            _carDal.Add(car);
            Console.WriteLine("Yeni Araba Eklendi.");
            return car;
            //return new SuccessResult(Messages.CarAdded);
        }

        public List<Car> GetAll()
        {
            // İş kodları
            // Yetkisi Var mı?
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }
    }
}
