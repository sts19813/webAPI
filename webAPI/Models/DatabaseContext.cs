﻿using Microsoft.EntityFrameworkCore;
using System;

namespace webAPI.Models
{
    /// <summary>
    /// clase para el contexto
    /// </summary>
    public class DatabaseContext : DbContext
    {
        //contexto
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
                : base(options)
        {
        }

        public DbSet<Developer> Developers { get; set; }

      
    }
}
