﻿using Foodie.Common.Application.Requests.Commands.Interfaces;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Identity.Application.Functions.Admins.Commands.CreateAdmin
{
    public class CreateAdminCommand : IAuditableCommand, IRequest<Result<CreateAdminCommandResponse>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int ApplicationUserId { get; set; }
        public string ApplicationUserEmail { get; set; }
    }
}
