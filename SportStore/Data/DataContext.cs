﻿using Microsoft.EntityFrameworkCore;
using SportStore.Models;

namespace SportStore.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts):base(opts) { }
    
        public DbSet<Product> Products { get; set; }
    }
}