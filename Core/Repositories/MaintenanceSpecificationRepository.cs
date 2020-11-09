using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Interfaces;
using Core.Models;

namespace Core.Repositories
{
    public class MaintenanceSpecificationRepository : IMaintenanceSpecificationRepository
    {
        private List<MaintenanceSpecification> _msStaticDB;

        public MaintenanceSpecificationRepository()
        {
            _msStaticDB = new List<MaintenanceSpecification>
            {
                new MaintenanceSpecification() { Id = 1, Date = DateTime.Now, Milage = 1234567890, Description = "Onderhoud", Type = Enums.MaintenanceTypeEnum.MOT, Car = new Car() { Id = 1, LicenseNumber = "1-ABC-23", Brand = new Brand() {Id = 1, Name = "Audi" }, Model = new Model() {Id = 1, Name = "A4", Brand = new Brand() {Id = 1, Name = "Audi" } }, Owner = new Customer() { Id = 1, FirstName = "Jelle", LastName = "Schut", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" }, Customer = new Customer() { Id = 1, FirstName = "Jelle", LastName = "Schut", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" }, Status = Enums.StatusEnum.REGISTERED }},
                new MaintenanceSpecification() { Id = 2, Date = DateTime.Now, Milage = 1234567890, Description = "Onderhoud", Type = Enums.MaintenanceTypeEnum.MOT, Car = new Car() { Id = 2, LicenseNumber = "9-ZYX-87", Brand = new Brand() {Id = 2, Name = "BMW" }, Model = new Model() {Id = 2, Name = "M6", Brand = new Brand() {Id = 2, Name = "BMW" } }, Owner = new Customer() { Id = 2, FirstName = "Fred", LastName = "Flintstone", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" }, Customer = new Customer() { Id = 2, FirstName = "Fred", LastName = "Flintstone", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" }, Status = Enums.StatusEnum.REGISTERED }},
                new MaintenanceSpecification() { Id = 3, Date = DateTime.Now, Milage = 1234567890, Description = "Onderhoud", Type = Enums.MaintenanceTypeEnum.MOT, Car = new Car() { Id = 3, LicenseNumber = "6-XXX-66", Brand = new Brand() {Id = 3, Name = "Fiat" }, Model = new Model() {Id = 3, Name = "Punto", Brand = new Brand() {Id = 3, Name = "Fiat" } }, Owner = new Customer() { Id = 3, FirstName = "Sjaak", LastName = "Swart", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" }, Customer = new Customer() { Id = 3, FirstName = "Sjaak", LastName = "Swart", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" }, Status = Enums.StatusEnum.REGISTERED }},
                new MaintenanceSpecification() { Id = 4, Date = DateTime.Now, Milage = 1234567890, Description = "Onderhoud", Type = Enums.MaintenanceTypeEnum.MOT, Car = new Car() { Id = 4, LicenseNumber = "AB-CD-12", Brand = new Brand() {Id = 4, Name = "Renault" }, Model = new Model() {Id = 4, Name = "Clio", Brand = new Brand() {Id = 4, Name = "Renault" } }, Owner = new LeaseCompany() { Id = 1, Name = "SomeCompany", City = "SomeCity", Street = "SomeStreet", HouseNumber = 1, Zipcode = "1234AB"}, Customer = new Customer() { Id = 4, FirstName = "Pietje", LastName = "Puk", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" }, Status = Enums.StatusEnum.REGISTERED }},
                new MaintenanceSpecification() { Id = 5, Date = DateTime.Now, Milage = 1234567890, Description = "Onderhoud", Type = Enums.MaintenanceTypeEnum.MOT, Car = new Car() { Id = 5, LicenseNumber = "98-ZY-XW", Brand = new Brand() {Id = 5, Name = "Skoda" }, Model = new Model() {Id = 5, Name = "Superb", Brand = new Brand() {Id = 5, Name = "Skoda" } }, Owner = new LeaseCompany() { Id = 2, Name = "OtherCompany", City = "OtherCity", Street = "OtherStreet", HouseNumber = 1, Zipcode = "4321XZ"}, Customer = new Customer() { Id = 5, FirstName = "Michael", LastName = "Schumacher", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" }, Status = Enums.StatusEnum.REGISTERED }},
                new MaintenanceSpecification() { Id = 6, Date = DateTime.Now, Milage = 1234567890, Description = "Onderhoud", Type = Enums.MaintenanceTypeEnum.MOT, Car = new Car() { Id = 6, LicenseNumber = "XD-XD-88", Brand = new Brand() {Id = 6, Name = "Volkswagen" }, Model = new Model() {Id = 6, Name = "Golf", Brand = new Brand() {Id = 6, Name = "Volkswagen" } }, Owner = new LeaseCompany() { Id = 3, Name = "ThirdCompany", City = "ThirdCity", Street = "ThirdStreet", HouseNumber = 1, Zipcode = "0987TX"}, Customer = new Customer() { Id = 6, FirstName = "Johan", LastName = "Cruijff", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" }, Status = Enums.StatusEnum.REGISTERED }},
            };
        }

        public void AddMaintenanceSpecification(MaintenanceSpecification ms)
        {
            ms.Id = _msStaticDB.Max(m => m.Id) + 1;
            ms.Date = DateTime.Now.Date;
            _msStaticDB.Add(ms);
        }

        public void DeleteMaintenanceSpecification(int id)
        {
            var item = _msStaticDB.FirstOrDefault(m => m.Id == id);
            _msStaticDB.Remove(item);
        }

        public void EditMaintenanceSpecification(int id, MaintenanceSpecification ms)
        {
            var item = _msStaticDB.FirstOrDefault(m => m.Id == id);
            item.Date = ms.Date;
            item.Milage = ms.Milage;
            item.Description = ms.Description;
            item.Car = ms.Car;
        }

        public List<MaintenanceSpecification> GetAllMaintenanceSpecifications()
        {
            return _msStaticDB;
        }

        public MaintenanceSpecification GetMaintenanceSpecification(int id)
        {
            return _msStaticDB.FirstOrDefault(m => m.Id == id);
        }
    }
}
