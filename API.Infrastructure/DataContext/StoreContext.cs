﻿using API.Core.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Infrastructure.DataContext
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
