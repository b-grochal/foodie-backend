﻿using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Extensions;
using Foodie.Shared.Types.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.Repositories
{
    public class CategoriesRepository : BaseMealsRepository<Category>, ICategoriesRepository
    {
        public CategoriesRepository(MealsDbContext dbContext) : base(dbContext) { }

        public async Task<IReadOnlyList<Category>> GetAllAsync(IReadOnlyCollection<int> categoryIds)
        {
            return await dbContext.Categories
                .Where(c => categoryIds.Contains(c.Id))
                .ToListAsync();
        }

        public async Task<PagedResult<Category>> GetAllAsync(int pageNumber, int pageSize, string name)
        {
            return dbContext.Categories
                .Where(c => name == null || c.Name.Equals(name))
                .Paginate(pageNumber, pageSize);
        }
    }
}
