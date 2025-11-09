using HW19.Domain.CategoryAgg.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW19.Infrastructure.EfCore.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasQueryFilter(c => c.IsDeleted == false);
            builder.Property(c => c.Name).HasMaxLength(100);

            builder.HasData(
                  new Category { Id = 1, Name = "شخصی", IsDeleted = false },
                  new Category { Id = 2, Name = "کاری", IsDeleted = false },
                  new Category { Id = 3, Name = "دانشگاهی", IsDeleted = false },
                  new Category { Id = 4, Name = "سایر", IsDeleted = false },
                  new Category { Id = 5, Name = "خرید", IsDeleted = false }
                 );
               builder.HasMany(c => c.ToDos)
                .WithOne(t => t.Category)
                .HasForeignKey(t=>t.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
