﻿using Foodie.Meals.Commands.Meals;
using Foodie.Meals.Queries.Meals;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Meals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly IMediator mediator;

        public MealsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // POST api/Meals
        [HttpPost]
        public async Task<IActionResult> CreateMeal([FromBody] CreateMealCommand createMealCommand)
        {
            await mediator.Send(createMealCommand);
            return Ok();
        }

        // PUT api/Meals/5
        [HttpPut("{mealId}")]
        public async Task<IActionResult> EditMeal(int mealId, [FromBody] EditMealCommand editMealCommand)
        {
            if (mealId != editMealCommand.MealId)
            {
                return BadRequest();
            }

            await mediator.Send(editMealCommand);
            return Ok();
        }

        // DELETE api/Meals/5
        [HttpDelete("{mealId}")]
        public async Task<IActionResult> DeleteMeal(int mealId)
        {
            var command = new DeleteMealCommand(mealId);
            await mediator.Send(command);
            return Ok();
        }

        // GET api/Meals/5
        [HttpGet("{mealId}")]
        public async Task<IActionResult> GetMeal(int mealId)
        {
            var query = new GetMealByIdQuery(mealId);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/Meals
        [HttpGet]
        public async Task<IActionResult> GetAllMeals()
        {
            var query = new GetAllMealsQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}