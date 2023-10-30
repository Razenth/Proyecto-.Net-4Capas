using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            {
                builder.ToTable("user");

                builder.Property(p => p.Id)
                .IsRequired();

                builder.Property(p => p.Username)
                .HasColumnType("username")
                .HasColumnType("varchar")
                .HasMaxLength(50);

                builder.Property(p => p.Password)
                .HasColumnType("password")
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

                builder.Property(p => p.Email)
                .HasColumnType("email")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

                builder
                .HasMany(p => p.Rols)
                .WithMany(r => r.Users)
                .UsingEntity<UserRol>(
                    j => j
                    .HasOne(pt => pt.Rol)
                    .WithMany(t => t.UserRols)
                    .HasForeignKey(ut => ut.RolId),

                    j => j
                    .HasOne(et => et.Usuario)
                    .WithMany(et => et.UserRols)
                    .HasForeignKey(el => el.UsuarioId),

                    j =>
                    {
                        j.ToTable("userRol");
                        j.HasKey(t => new {t. UsuarioId, t.RolId});
                    });

                builder.HasMany(p => p.RefreshTokens)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
            }
        }
    }
}