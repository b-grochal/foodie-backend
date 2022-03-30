﻿using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommand>
    {
        private readonly IRestaurantsRepository restaurantsRepository;
        private readonly ICategoriesRepository categoriesRepository;
        private readonly IMapper mapper;

        public UpdateRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository, ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            this.restaurantsRepository = restaurantsRepository;
            this.categoriesRepository  = categoriesRepository;
            this.mapper =  mapper;
        }

        public async Task<Unit> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);

            if (restaurant == null)
                throw new RestaurantNotFoundException(request.RestaurantId);

            var editedRestaurant = mapper.Map(request, restaurant);
            
            var categories = await categoriesRepository.GetAllAsync(request.CategoryIds);
            editedRestaurant.Categories.Clear();
            
            foreach (var category in categories)
            {
                editedRestaurant.Categories.Add(category);
            }

            await restaurantsRepository.UpdateAsync(editedRestaurant);
            return new Unit();
        }
    }
}
