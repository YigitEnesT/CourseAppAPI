using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record CourseDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; } = String.Empty;
        public string Instructor { get; init; } = String.Empty;
        public int Price { get; init; }
        public int CategoryId { get; init; }
        public string CategoryName { get; init; }
        public double AverageRating { get; init; }
        public int RatingCount { get; init; }
    }
}
