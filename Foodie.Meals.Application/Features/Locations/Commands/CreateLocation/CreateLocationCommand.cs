﻿using Foodie.Common.Application.Requests.Commands.Abstractions;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Locations.Commands.CreateLocation
{
    public class CreateLocationCommand : IAuditableCommand, IRequest<Result<CreateLocationCommandResponse>>
    {
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int CityId { get; set; }
        public int RestaurantId { get; set; }
        public string User { get; set; }
    }
}