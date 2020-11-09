using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Core.Interfaces
{
    public interface IModelRepository
    {
        void AddModel(Model model);
        List<Model> GetAllModels();
        List<Model> GetModelsByBrand(int brandId);
        List<Model> GetModelsByBrand(string brandName);
        List<Model> GetModelsByBrand(Brand brand);
        Model GetModel(int id);
        void EditModel(int id, Model model);
        void EditModel(int id, string modelName);
        void DeleteModel(int id);

    }
}
