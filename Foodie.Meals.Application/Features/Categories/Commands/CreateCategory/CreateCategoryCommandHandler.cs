﻿using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<CreateCategoryCommandResponse>>
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoriesRepository categoriesRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<CreateCategoryCommandResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            await _categoriesRepository.CreateAsync(category);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<CreateCategoryCommandResponse>(category);
        }
    }
}