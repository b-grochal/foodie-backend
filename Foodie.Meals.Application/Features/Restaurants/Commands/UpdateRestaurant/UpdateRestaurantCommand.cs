﻿using Foodie.Common.Application.Requests.Commands.Abstractions;
using Foodie.Common.Results;
using MediatR;
using System.Collections.Generic;

namespace Foodie.Meals.Application.Functions.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommand : IAuditableCommand, IRequest<Result<UpdateRestaurantCommandResponse>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IReadOnlyCollection<int> CategoriesIds { get; set; }
        public string User { get; set; }
    }
}