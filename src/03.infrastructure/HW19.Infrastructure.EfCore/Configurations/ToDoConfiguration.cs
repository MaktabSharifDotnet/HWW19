
using HW19.Domain.ToDoAgg.Entities;
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
    public class ToDoConfiguration : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.HasQueryFilter(t => t.IsDeleted==false);

            builder.Property(t => t.Description).HasMaxLength(40000);
            builder.Property(t => t.Title).HasMaxLength(10);
        }
    }
}
