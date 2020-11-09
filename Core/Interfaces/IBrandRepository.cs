using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IBrandRepository
    {
        void AddBrand(Brand brand);
        List<Brand> GetAllBrands();
        Brand GetBrand(int id);
        void EditBrand(int id, Brand brand);
        void DeleteBrand(int id);
    }
}
