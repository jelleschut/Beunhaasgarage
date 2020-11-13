﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IBrandRepository : IGenericRepository<Brand>, IAsyncGenericRepository<Brand>
    {
    }
}
