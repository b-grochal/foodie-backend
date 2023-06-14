﻿using Foodie.Identity.Domain.Entities;
using Foodie.Shared.Authentication;

namespace Foodie.Identity.Application.Contracts.Infrastructure.Services
{
    public interface IJwtService
    {
        string GenerateToken(ApplicationUser applicationUser);
        int GetApplicationUserIdFromExpiredToken(string token);
    }
}
