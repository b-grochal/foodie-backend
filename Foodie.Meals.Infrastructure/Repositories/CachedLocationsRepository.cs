﻿using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Cache;
using Foodie.Shared.Types.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.Repositories
{
    internal class CachedLocationsRepository : ILocationsRepository
    {
        private readonly ILocationsRepository decoratedRepository;
        private readonly ICacheService cacheService;

        public CachedLocationsRepository(ILocationsRepository decoratedRepository, ICacheService cacheService)
        {
            this.decoratedRepository = decoratedRepository;
            this.cacheService = cacheService;
        }

        public async Task<Location> CreateAsync(Location entity)
        {
            var result = await decoratedRepository.CreateAsync(entity);
            await cacheService.RemoveByPrefixAsync(CachePrefixes.Locations);
            return result;
        }

        public async Task DeleteAsync(Location entity)
        {
            await decoratedRepository.DeleteAsync(entity);
            await cacheService.RemoveByPrefixAsync(CachePrefixes.Locations);
        }

        public async Task<PagedResult<Location>> GetAllAsync(int pageNumber, int pageSize, int? restaurantId, int? cityId)
        {
            return await cacheService.GetAsync(async () =>
            {
                return await decoratedRepository.GetAllAsync(pageNumber, pageSize, restaurantId, cityId);
            }, CachePrefixes.Locations, parameters: new string[] { nameof(pageNumber), pageNumber.ToString(), nameof(pageSize), pageSize.ToString(), nameof(restaurantId), restaurantId.ToString(), nameof(cityId), cityId.ToString() });
        }

        public async Task<IReadOnlyList<Location>> GetAllAsync(int restaurantId, int? cityId)
        {
            return await cacheService.GetAsync(async () =>
            {
                return await decoratedRepository.GetAllAsync(restaurantId, cityId);
            }, CachePrefixes.Locations, parameters: new string[] { nameof(restaurantId), restaurantId.ToString(), nameof(cityId), cityId.ToString() });
        }

        public async Task<IReadOnlyList<Location>> GetAllAsync()
        {
            return await cacheService.GetAsync(async () =>
            {
                return await decoratedRepository.GetAllAsync();
            }, CachePrefixes.Locations);
        }

        public async Task<Location> GetByIdAsync(int id)
        {
            return await decoratedRepository.GetByIdAsync(id);
        }

        public Task<Location> GetByIdWithRelatedDataAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAsync(Location entity)
        {
            await decoratedRepository.UpdateAsync(entity);
            await cacheService.RemoveAsync(CachePrefixes.Locations);
        }
    }
}