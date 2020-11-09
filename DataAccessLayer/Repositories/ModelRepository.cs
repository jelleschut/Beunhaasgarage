using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Interfaces;
using Core.Models;

namespace DataAccessLayer.Repositories
{
    public class ModelRepository : GenericRepository<Model>, IModelRepository
    {
        public ModelRepository(GarageContext context) : base(context)
        {

        }

        public void EditModel(int id, Model model)
        {
            var item = _context.Models.Find(id);
            item.Name = model.Name;
            item.Brand = model.Brand;
        }

        public void EditModel(int id, string modelName)
        {
            var item = _context.Models.Find(id);
            item.Name = modelName;
        }

        public List<Model> GetModelsByBrand(int brandId)
        {
            return _context.Models.Where(m => m.Brand.BrandId == brandId).ToList();
        }
        public List<Model> GetModelsByBrand(string brandName)
        {
            return _context.Models.Where(m => m.Brand.Name == brandName).ToList();
        }

        public List<Model> GetModelsByBrand(Brand brand)
        {
            return _context.Models.Where(m => m.Brand == brand).ToList();
        }
    }
}
