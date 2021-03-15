using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        
        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
                new Car{Id=1, BrandId=1, ColorId=1, CarName="116d", ModelYear="2020", DailyPrice=200, Description="2020 BMW 1 Serisi 1.5 116d"},
                new Car{Id=2, BrandId=1, ColorId=2, CarName="sDrive 20i", ModelYear="2016", DailyPrice=160, Description="2016 BMW Z Serisi Z4 sDrive 20i"},
                new Car{Id=3, BrandId=2, ColorId=3, CarName="XC90", ModelYear="2020", DailyPrice=200, Description="Volvo XC90 Recharge"}
                new Car{Id=4, BrandId=2, ColorId=3, CarName="S90", ModelYear="2019", DailyPrice=180, Description="Volvo S90"}
                new Car{Id=5, BrandId=2, ColorId=1, CarName="V90", ModelYear="2021", DailyPrice=250, Description="Volvo V90 Cross Country"}
            };
        }
        
        public void Add(Car car)
        {
            _cars.Add(car);
        }
        
        public void Update(Car car)
        {
            // Göderilen ürün Id'sine sahip olan listedeki ürünü bulur.
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.CarName = car.CarName;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
        
        public void Delete(Car car)
        {
            // Aşağıdaki kod için Id numarası tanımlansa bile Remove ile silme işlemi yapmaz. Çünkü referans tiptir.
            // _cars.Remove(car);

            // Nasıl Yapılır Görelim.
            // 1. Yöntem
            /*Car carToDelete = null;
            foreach (var c in _cars)
            {
                if (car.Id == c.Id)
                {
                    carToDelete = c;
                }
            }
            _cars.Remove(carToDelete);*/

            // 2. Yöntem
            // LINQ ile yapılabilir.
            // LINQ - Language Integrated Query
            Car carToDelete = _cars.SingleOrDefault(c=>c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            // Where koşulu içinde belirtilen koşulu sağlayanları yeni bir liste haline getirir.
            return _cars.Where(c=>c.BrandId == brandId).ToList();
        }

        public List<Car> GetAllByColor(int colorId)
        {
            return _cars.Where(c => c.ColorId == colorId).ToList();
        }
    }
}
