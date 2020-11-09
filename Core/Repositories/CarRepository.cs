using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Enums;
using Core.Interfaces;
using Core.Models;

namespace Core.Repositories
{
    public class CarRepository : ICarRepository
    {
        private List<Car> _carStaticDB;
        public CarRepository()
        {
            _carStaticDB = new List<Car>
            {
                new Car() { Id = 1, LicenseNumber = "1-ABC-23", Brand = new Brand() {Id = 1, Name = "Audi" }, Model = new Model() {Id = 1, Name = "A4", Brand = new Brand() {Id = 1, Name = "Audi" } }, Owner = new Customer() { Id = 1, FirstName = "Jelle", LastName = "Schut", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" }, Customer = new Customer() { Id = 1, FirstName = "Jelle", LastName = "Schut", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" }, Status = Enums.StatusEnum.REGISTERED },
                new Car() { Id = 2, LicenseNumber = "9-ZYX-87", Brand = new Brand() {Id = 2, Name = "BMW" }, Model = new Model() {Id = 2, Name = "M6", Brand = new Brand() {Id = 2, Name = "BMW" } }, Owner = new Customer() { Id = 2, FirstName = "Fred", LastName = "Flintstone", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" }, Customer = new Customer() { Id = 2, FirstName = "Fred", LastName = "Flintstone", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" }, Status = Enums.StatusEnum.REGISTERED },
                new Car() { Id = 3, LicenseNumber = "6-XXX-66", Brand = new Brand() {Id = 3, Name = "Fiat" }, Model = new Model() {Id = 3, Name = "Punto", Brand = new Brand() {Id = 3, Name = "Fiat" } }, Owner = new Customer() { Id = 3, FirstName = "Sjaak", LastName = "Swart", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" }, Customer = new Customer() { Id = 3, FirstName = "Sjaak", LastName = "Swart", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" }, Status = Enums.StatusEnum.REGISTERED },
                new Car() { Id = 4, LicenseNumber = "AB-CD-12", Brand = new Brand() {Id = 4, Name = "Renault" }, Model = new Model() {Id = 4, Name = "Clio", Brand = new Brand() {Id = 4, Name = "Renault" } }, Owner = new LeaseCompany() { Id = 1, Name = "SomeCompany", City = "SomeCity", Street = "SomeStreet", HouseNumber = 1, Zipcode = "1234AB"}, Customer = new Customer() { Id = 4, FirstName = "Pietje", LastName = "Puk", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" }, Status = Enums.StatusEnum.REGISTERED },
                new Car() { Id = 5, LicenseNumber = "98-ZY-XW", Brand = new Brand() {Id = 5, Name = "Skoda" }, Model = new Model() {Id = 5, Name = "Superb", Brand = new Brand() {Id = 5, Name = "Skoda" } }, Owner = new LeaseCompany() { Id = 2, Name = "OtherCompany", City = "OtherCity", Street = "OtherStreet", HouseNumber = 1, Zipcode = "4321XZ"}, Customer = new Customer() { Id = 5, FirstName = "Michael", LastName = "Schumacher", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" }, Status = Enums.StatusEnum.REGISTERED },
                new Car() { Id = 6, LicenseNumber = "XD-XD-88", Brand = new Brand() {Id = 6, Name = "Volkswagen" }, Model = new Model() {Id = 6, Name = "Golf", Brand = new Brand() {Id = 6, Name = "Volkswagen" } }, Owner = new LeaseCompany() { Id = 3, Name = "ThirdCompany", City = "ThirdCity", Street = "ThirdStreet", HouseNumber = 1, Zipcode = "0987TX"}, Customer = new Customer() { Id = 6, FirstName = "Johan", LastName = "Cruijff", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" }, Status = Enums.StatusEnum.REGISTERED }
            };
        }
        public void AddCar(Car car)
        {
            car.Id = _carStaticDB.Max(c => c.Id) + 1;
            car.Status = StatusEnum.REGISTERED;
            _carStaticDB.Add(car);
        }

        public void DeleteCar(int id)
        {
            var item = _carStaticDB.FirstOrDefault(c => c.Id == id);
            _carStaticDB.Remove(item);
        }

        public void EditCar(int id, Car car)
        {
            var item = _carStaticDB.FirstOrDefault(c => c.Id == id);
            item.LicenseNumber = car.LicenseNumber;
            item.Brand = car.Brand;
            item.Model = car.Model;
            item.Owner = car.Owner;
            item.Customer = car.Customer;
            item.Status = car.Status;

        }

        public List<Car> GetAllCars()
        {
            return _carStaticDB;
        }

        public Car GetCar(int id)
        {
            return _carStaticDB.FirstOrDefault(c => c.Id == id);
        }
    }
}
