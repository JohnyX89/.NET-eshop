using eshop.Models.Database.Configuration;
using eshop.Models.Database.Converter;
using eshop.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.Models.Database
{
    public class EshopDBContext : IdentityDbContext<User, Role, int>
    {
        IEnumerable<IDbContextOptionsExtension> optionsExtension;

        public EshopDBContext(DbContextOptions options) : base(options)
        {
            if (options != null)
            {
                this.optionsExtension = options.Extensions;
            }
        }


        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<eshop.Models.Identity.User> User { get; set; }

        public DbSet<GuardingDog> GuardingDogs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            this.ApplyConfigurationsForAll(modelBuilder);
            this.ApplyConfigurations(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.Relational().TableName.Replace("AspNet", String.Empty);      // Change name (remove "AspNet") from tables - default names
            }


            int stringLegth = 256;

            modelBuilder.Entity<User>(entity => entity.Property(m => m.NormalizedEmail).HasMaxLength(stringLegth));
            modelBuilder.Entity<User>(entity => entity.Property(m => m.NormalizedUserName).HasMaxLength(stringLegth));

            modelBuilder.Entity<Role>(entity => entity.Property(m => m.NormalizedName).HasMaxLength(stringLegth));

            modelBuilder.Entity<IdentityUserLogin<int>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(stringLegth));
            modelBuilder.Entity<IdentityUserLogin<int>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(stringLegth));

            modelBuilder.Entity<IdentityUserToken<int>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(stringLegth));
            modelBuilder.Entity<IdentityUserToken<int>>(entity => entity.Property(m => m.Name).HasMaxLength(stringLegth));


            if (optionsExtension != null && optionsExtension.Count() > 0)
            {
                foreach (var optionsExtension in optionsExtension)
                {
                    if (optionsExtension.GetType() == typeof(MySql.Data.EntityFrameworkCore.Infraestructure.MySQLOptionsExtension))
                    {
                        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                        {
                            foreach (var property in entityType.GetProperties())
                            {
                                if (property.ClrType == typeof(bool))
                                {
                                    property.SetValueConverter(new BoolToIntConverter());
                                }
                            }
                        }

                        break;
                    }
                }
            }
        }


        protected virtual void ApplyConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new CarouselConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new GuardingDogConfiguration());
        }

        protected virtual void ApplyConfigurationsForAll(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }
    }
}
