using DAL.API.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.API.DataContext
{
    public class StoreContext :DbContext
    {
        public StoreContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
