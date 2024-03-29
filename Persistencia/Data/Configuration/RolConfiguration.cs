using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("Rol");

            builder.Property(p => p.Id)
            .IsRequired();

            builder.Property(p => p.Nombre)
            .HasColumnType("rolName")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();
            
        }
    }
}