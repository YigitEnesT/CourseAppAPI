using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RatingManager : IRatingService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public RatingManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<RatingDto> CreateOneRatingAsync(RatingDto rating)
        {
            var entity = _mapper.Map<Rating>(rating);
            _manager.Rating.CreateOneRating(entity);
            await _manager.SaveAsync();
            return _mapper.Map<RatingDto>(entity);
        }

        public async Task<(IEnumerable<RatingDto> ratings, MetaData metaData)> GetALlRatingsAsync(RatingParameters ratingParameters ,bool trackChanges)
        {
            var ratingsWithMetaData = await _manager.Rating.GetAllRatingsAsync(ratingParameters,trackChanges);
            
            var ratingDto = _mapper.Map<IEnumerable<RatingDto>>(ratingsWithMetaData);
            return (ratingDto, ratingsWithMetaData.MetaData);
        }

        public async Task<(IEnumerable<RatingDto> ratings, MetaData metaData)> GetAllRatingsByCourseAsync(RatingParameters ratingParameters, int id, bool trackChanges)
        {
            var ratingsWithMetaData = await _manager.Rating.GetRatingByCourseAsync(ratingParameters, id, trackChanges);
            var ratingDto = _mapper.Map<IEnumerable<RatingDto>>(ratingsWithMetaData);
            
            return (ratingDto, ratingsWithMetaData.MetaData);
        }
    }
}
