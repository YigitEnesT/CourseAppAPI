using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config
{
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.Description).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(150);
            builder.Property(c => c.Price).IsRequired();
            builder.Property(c => c.CategoryId).IsRequired();

            builder.HasData(
                new Course { Id = 1, Name = "React", Description = "This is a library.", CategoryId=1, Price=250, Instructor="John Doe" },
                new Course { Id = 2, Name = "Angular", Description = "This is a framework.", CategoryId=2, Price=150, Instructor="John Doe"  },
                new Course { Id = 3, Name = ".NET", Description = "This is a framework.", CategoryId = 2, Price = 150, Instructor = "John Doe" }
            );
        }
    }
}
