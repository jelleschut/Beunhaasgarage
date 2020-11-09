using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Core.Interfaces
{
    public interface IModelRepository : IGenericRepository<Model>
    {
        List<Model> GetModelsByBrand(int brandId);
        List<Model> GetModelsByBrand(string brandName);
        List<Model> GetModelsByBrand(Brand brand);
        void EditModel(int id, Model model);
        void EditModel(int id, string modelName);
    }
}
