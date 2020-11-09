using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Interfaces;
using Core.Models;

namespace Core.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private List<Brand> _brandStaticDB;

        public BrandRepository()
        {
            _brandStaticDB = new List<Brand>
            {
                new Brand() {Id = 1, Name = "Audi" },
                new Brand() {Id = 2, Name = "BMW" },
                new Brand() {Id = 3, Name = "Fiat" },
                new Brand() {Id = 4, Name = "Renault" },
                new Brand() {Id = 5, Name = "Skoda" },
                new Brand() {Id = 6, Name = "Volkswagen" },
            };
        }

        public void AddBrand(Brand brand)
        {
            brand.Id = _brandStaticDB.Max(b => b.Id) + 1;
            _brandStaticDB.Add(brand);
        }

        public void DeleteBrand(int id)
        {
            var item = _brandStaticDB.FirstOrDefault(b => b.Id == id);
            _brandStaticDB.Remove(item);
        }

        public void EditBrand(int id, Brand brand)
        {
            var item = _brandStaticDB.FirstOrDefault(b => b.Id == id);
            item.Name = brand.Name;
        }

        public List<Brand> GetAllBrands()
        {
            return _brandStaticDB;
        }

        public Brand GetBrand(int id)
        {
            return _brandStaticDB.FirstOrDefault(b => b.Id == id);
        }
    }
}
