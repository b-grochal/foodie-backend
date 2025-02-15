﻿using Foodie.Common.Collections;
using Foodie.Common.Infrastructure.Cache;
using Foodie.Common.Infrastructure.Cache.Interfaces;
using Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Meals.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.Database.Repositories
{
    public class CachedCategoriesRepository : ICategoriesRepository
    {
        private readonly ICategoriesRepository decoratedRepository;
        private readonly ICacheService cacheService;

        public CachedCategoriesRepository(ICategoriesRepository categoriesRepository, ICacheService cacheService)
        {
            decoratedRepository = categoriesRepository;
            this.cacheService = cacheService;
        }

        public async Task<Category> CreateAsync(Category entity)
        {
            var result = await decoratedRepository.CreateAsync(entity);
            await cacheService.RemoveByPrefixAsync(CachePrefixes.Categories);
            return result;
        }

        public async Task DeleteAsync(Category entity)
        {
            await decoratedRepository.DeleteAsync(entity);
            await cacheService.RemoveByPrefixAsync(CachePrefixes.Categories);
        }

        public async Task<IReadOnlyList<Category>> GetAllAsync(IReadOnlyCollection<int> categoryIds)
        {
            return await decoratedRepository.GetAllAsync(categoryIds);
            //return await cacheService.GetAsync(async () =>
            //{
            //    return await decoratedRepository.GetAllAsync(categoryIds);
            //}, CachePrefixes.Categories, parameters: new string[] { nameof(categoryIds), categoryIds.ToString() });
        }

        public async Task<PagedList<Category>> GetAllAsync(int pageNumber, int pageSize, string name)
        {
            return await cacheService.GetAsync(async () =>
            {
                return await decoratedRepository.GetAllAsync(pageNumber, pageSize, name);
            }, CachePrefixes.Categories, parameters: new string[] { nameof(pageNumber), pageNumber.ToString(), nameof(pageSize), pageSize.ToString(), nameof(name), name });
        }

        public async Task<IReadOnlyList<Category>> GetAllAsync()
        {
            return await cacheService.GetAsync(async () =>
            {
                return await decoratedRepository.GetAllAsync();
            }, CachePrefixes.Categories);
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await decoratedRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Category entity)
        {
            await decoratedRepository.UpdateAsync(entity);
            await cacheService.RemoveByPrefixAsync(CachePrefixes.Categories);
        }
    }
}
