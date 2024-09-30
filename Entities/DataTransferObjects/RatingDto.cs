using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record RatingDto
    {
        public int Id { get; init; }
        public int CourseId { get; init; }
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Star { get; init; }
        public string? Comment { get; init; } = String.Empty;
    }
}
