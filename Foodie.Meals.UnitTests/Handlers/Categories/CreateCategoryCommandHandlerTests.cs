﻿using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Application.Functions.Categories.Commands.CreateCategory;
using Foodie.Meals.Application.Mapper;
using Foodie.Meals.Domain.Entities;
using Foodie.Meals.UnitTests.Mocks.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Foodie.Meals.UnitTests.Handlers.Categories
{
    public class CreateCategoryCommandHandlerTests
    {
        private readonly IMapper mapper;

        public CreateCategoryCommandHandlerTests()
        { 
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MapperProfile>();
            });

            this.mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async void CreateCategoryCommandHandler_HandleCreatingNewCategory_ShouldReturnNewCreatedCategory()
        {
            var categoriesRepository = new MockCategoriesRepository()
                .MockCreateAsync();

            var command = new CreateCategoryCommand { Name = "Test category" };
            var commandHandler = new CreateCategoryCommandHandler(categoriesRepository.Object, this.mapper);

            var result = await commandHandler.Handle(command, CancellationToken.None);

            Assert.IsType<CreateCategoryCommandResponse>(result);
            categoriesRepository.VerifyCreateAsync(Times.Once());
        }
    }
}
