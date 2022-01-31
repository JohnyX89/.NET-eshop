using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.Models.Database.Configuration
{
    public class GuardingDogConfiguration : EntityConfiguration, IEntityTypeConfiguration<GuardingDog>
    {
        public void Configure(EntityTypeBuilder<GuardingDog> builder)
        {
            base.Configure(builder);
        }
    }
}
