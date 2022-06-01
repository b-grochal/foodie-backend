﻿using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Entities;
using Foodie.Shared.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.Repositories
{
    public class AdminsRepository : IAdminsRepository
    {
        private readonly UserManager<Admin> userManager;
        private readonly IdentityDbContext identityDbContext;

        public AdminsRepository(UserManager<Admin> userManager, IdentityDbContext identityDbContext)
        {
            this.userManager = userManager;
            this.identityDbContext = identityDbContext;
        }

        public async Task CreateAsync(Admin admin)
        {
            await userManager.CreateAsync(admin);
            await userManager.AddToRoleAsync(admin, ApplicationUserRoles.Admin);
        }

        public async Task DeleteAsync(Admin admin)
        {
            await userManager.DeleteAsync(admin);
        }

        public async Task<IReadOnlyList<Admin>> GetAllAsync()
        {
            return await identityDbContext.Admins.ToListAsync();
        }

        public async Task<PagedList<Admin>> GetAllAsync(int pageNumber, int pageSize, string email)
        {
            var admins = identityDbContext.Admins
                .Where(c => email == null || c.Email.Equals(email));

            return PagedList<Admin>.ToPagedList(admins, pageNumber, pageSize);
        }

        public async Task<Admin> GetByIdAsync(string id)
        {
            return await identityDbContext.Admins.FindAsync(id);
        }

        public async Task UpdateAsync(Admin admin)
        {
            await userManager.UpdateAsync(admin);
        }
    }
}