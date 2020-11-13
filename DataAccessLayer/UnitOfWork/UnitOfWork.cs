using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GarageContext _context;

        public UnitOfWork(GarageContext context)
        {
            _context = context;
            Brands = new BrandRepository(_context);
            Cars = new CarRepository(_context);
            Owners = new OwnerRepository(_context);
            MaintenanceSpecifications = new MaintenanceSpecificationRepository(_context);
            Models = new ModelRepository(_context);
        }

        public IBrandRepository Brands { get; private set; }
        public ICarRepository Cars { get; private set; }
        public IOwnerRepository Owners { get; private set; }
        public IMaintenanceSpecificationRepository MaintenanceSpecifications { get; private set; }
        public IModelRepository Models { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public Task<int> CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
