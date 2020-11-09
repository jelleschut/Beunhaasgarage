using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Enums;
using Core.Interfaces;
using Core.Models;

namespace DataAccessLayer.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(GarageContext context) : base(context)
        {

        }
    }
}
