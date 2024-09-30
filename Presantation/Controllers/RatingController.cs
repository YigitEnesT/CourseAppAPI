﻿using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public async Task<IActionResult> GetAllRatings()
        {
            var ratings =await _manager.RatingService.GetALlRatingsAsync(false);
            return Ok(ratings);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRatingsByCourse([FromRoute] int id)
        {
            var ratings = await _manager.RatingService.GetAllRatingsByCourseAsync(id, false);
            return Ok(ratings);
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
