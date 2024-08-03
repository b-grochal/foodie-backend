﻿using Foodie.Common.Application.Requests.Commands.Interfaces;
using Foodie.Common.Application.Requests.Interfaces;
using Foodie.Common.Enums;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Orders.Application.Features.Orders.Commands.SetInProgressOrderStatus
{
    public class SetInProgressOrderStatusCommand : IApplicationUserLocationRequest, IAuditableCommand, IRequest<Result>
    {
        public int Id { get; set; }

        public int LocationId { get; set; }
        public int ApplicationUserId { get; set; }
        public string ApplicationUserEmail { get; set; }

        public ApplicationUserRole Role { get; set; }

        public SetInProgressOrderStatusCommand(int id)
        {
            Id = id;
        }
    }
}
