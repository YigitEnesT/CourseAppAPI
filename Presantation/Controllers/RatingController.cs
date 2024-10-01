using Entities.DataTransferObjects;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presantation.Controllers
{
    [ApiController]
    [Route("api/ratings")]
    public class RatingController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public RatingController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRatings([FromQuery] RatingParameters ratingParameters)
        {
            var pagedResult =await _manager.RatingService.GetALlRatingsAsync(ratingParameters, false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.ratings);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRatingsByCourse([FromRoute] int id, [FromQuery] RatingParameters ratingParameters)
        {
            var pagedResult = await _manager.RatingService.GetAllRatingsByCourseAsync(ratingParameters, id, false);
            
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.ratings);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOneRating([FromBody] RatingDto rating)
        {
            if (rating is null)
                return BadRequest();

            var entity = await _manager.RatingService.CreateOneRatingAsync(rating);
            return Ok(entity);
        }
    }
}
