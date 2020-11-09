using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface ICarRepository
    {
        void AddCar(Car car);
        List<Car> GetAllCars();
        Car GetCar(int id);
        void EditCar(int id, Car car);
        void DeleteCar(int id);
    }
}
