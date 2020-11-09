using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Interfaces;
using Core.Models;

namespace Core.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private List<Model> _modelStaticDB;
        public ModelRepository()
        {
            _modelStaticDB = new List<Model>
            {
                new Model() {Id = 1, Name = "A4", Brand = new Brand() {Id = 1, Name = "Audi" } },
                new Model() {Id = 2, Name = "M6", Brand = new Brand() {Id = 2, Name = "BMW" } },
                new Model() {Id = 3, Name = "Punto", Brand = new Brand() {Id = 3, Name = "Fiat" } },
                new Model() {Id = 4, Name = "Clio", Brand = new Brand() {Id = 4, Name = "Renault" } },
                new Model() {Id = 5, Name = "Superb", Brand = new Brand() {Id = 5, Name = "Skoda" } },
                new Model() {Id = 6, Name = "Golf", Brand = new Brand() {Id = 6, Name = "Volkswagen" } },
            };
        }
        public void AddModel(Model model)
        {
            model.Id = _modelStaticDB.Max(m => m.Id) + 1;
            _modelStaticDB.Add(model);
        }

        public void DeleteModel(int id)
        {
            var item = _modelStaticDB.FirstOrDefault(m => m.Id == id);
            _modelStaticDB.Remove(item);
        }

        public void EditModel(int id, Model model)
        {
            var item = _modelStaticDB.FirstOrDefault(m => m.Id == id);
            item.Name = model.Name;
            item.Brand = model.Brand;
        }

        public void EditModel(int id, string modelName)
        {
            var item = _modelStaticDB.FirstOrDefault(m => m.Id == id);
            item.Name = modelName;
        }

        public List<Model> GetAllModels()
        {
            return _modelStaticDB;
        }

        public List<Model> GetModelsByBrand(int brandId)
        {
            return _modelStaticDB.Where(m => m.Brand.Id == brandId).ToList();
        }
        public List<Model> GetModelsByBrand(string brandName)
        {
            return _modelStaticDB.Where(m => m.Brand.Name == brandName).ToList();
        }

        public List<Model> GetModelsByBrand(Brand brand)
        {
            return _modelStaticDB.Where(m => m.Brand == brand).ToList();
        }

        public Model GetModel(int id)
        {
            return _modelStaticDB.FirstOrDefault(m => m.Id == id);
        }
    }
}
