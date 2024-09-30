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
    public class RatingConfig : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Star).IsRequired();
            builder.Property(r => r.Comment).HasMaxLength(140);

            builder.HasData(
                new Rating { Id = 1, CourseId = 3, Star=4, Comment="This course is beautiful." },
                new Rating { Id = 2, CourseId = 1, Star=3, Comment="This course is beautiful." },
                new Rating { Id = 3, CourseId = 2, Star=5, Comment="This course is beautiful." }
            );
        }
    }
}
