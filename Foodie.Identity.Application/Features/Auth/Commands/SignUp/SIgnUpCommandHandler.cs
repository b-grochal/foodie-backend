﻿using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Infrastructure.Cache.Interfaces;
using Foodie.Common.Results;
using Foodie.Identity.Application.Contracts.Infrastructure.ApplicationUserUtilities;
using Foodie.Identity.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Identity.Application.Features.Common;
using Foodie.Identity.Domain.Customers;
using Foodie.Templates.Services;
using Hangfire;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Features.Auth.Commands.SignUp
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, Result<SignUpCommandResponse>>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SignUpCommandHandler(ICustomersRepository customersRepository,
                                    IApplicationUsersRepository applicationUsersRepository,
                                    IPasswordService passwordService,
                                    IMapper mapper,
                                    ICacheService cacheService,
                                    IBackgroundJobClient backgroundJobClient,
                                    IEmailsService emailsService, IUnitOfWork unitOfWork)
        {
            _customersRepository = customersRepository;
            _applicationUsersRepository = applicationUsersRepository;
            _passwordService = passwordService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<SignUpCommandResponse>> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            if (!await _applicationUsersRepository.IsEmailUniqueAsync(request.Email))
                return Result.Failure<SignUpCommandResponse>(ApplicationUserErrors.ApplicationUserAlreadyExists(request.Email));

            var passwordHash = _passwordService.HashPassword(request.Password);

            var customer = Customer.Create(request.FirstName, request.LastName, request.Email, request.PhoneNumber, passwordHash);

            await _customersRepository.CreateAsync(customer);

            await _unitOfWork.CommitChangesAsync(handlerName: GetType().Name, cancellationToken: cancellationToken);

            return _mapper.Map<SignUpCommandResponse>(customer);
        }
    }
}
