﻿using AutoMapper;
using Foodie.Common.Results;
using Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Locations.Queries.GetLocations
{
    public class GetLocationsQueryHandler : IRequestHandler<GetLocationsQuery, Result<GetLocationsQueryResponse>>
    {
        private readonly ILocationsRepository locationsRepository;
        private readonly IMapper mapper;

        public GetLocationsQueryHandler(ILocationsRepository locationsRepository, IMapper mapper)
        {
            this.locationsRepository = locationsRepository;
            this.mapper = mapper;
        }

        public async Task<Result<GetLocationsQueryResponse>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            var result = await locationsRepository.GetAllAsync(request.PageNumber, request.PageSize, request.RestaurantId, request.CityId);

            return new GetLocationsQueryResponse
            {
                TotalCount = result.TotalCount,
                PageSize = result.PageSize,
                Page = result.Page,
                TotalPages = result.TotalPages,
                Items = mapper.Map<IEnumerable<LocationDto>>(result.Items),
                RestaurantId = request.RestaurantId,
                CityId = request.CityId
            };
        }
    }
}
