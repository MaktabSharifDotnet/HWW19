using HW19.Domain.CategoryAgg.Entities;
using HW19.Domain.UserAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW19.Infrastructure.EfCore.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Username).HasMaxLength(100);
            builder.HasMany(u=>u.ToDos)
                .WithOne(t=>t.User)
                .HasForeignKey(t=>t.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
