﻿using Foodie.Common.Application.Requests.Commands.Abstractions;
using Foodie.Common.Results;
using MediatR;
using System.Collections.Generic;

namespace Foodie.Meals.Application.Functions.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommand : IAuditableCommand, IRequest<Result<CreateRestaurantCommandResponse>>
    {
        public string Name { get; set; }
        public IReadOnlyCollection<int> CategoriesIds { get; set; }
        public string User { get; set; }
    }
}