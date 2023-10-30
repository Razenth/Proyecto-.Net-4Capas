using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Data
{
    public class Proyecto4CapasContext : DbContext
    {
        public Proyecto4CapasContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Rol> Roles {get; set;}
        public DbSet<User> Users { get; set; }
        public DbSet<UserRol> UserRols { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}