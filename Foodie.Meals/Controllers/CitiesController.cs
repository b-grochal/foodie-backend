﻿using Foodie.Meals.Application.Functions.Cities.Commands.CreateCity;
using Foodie.Meals.Application.Functions.Cities.Commands.DeleteCity;
using Foodie.Meals.Application.Functions.Cities.Commands.UpdateCity;
using Foodie.Meals.Application.Functions.Cities.Queries.GetCities;
using Foodie.Meals.Application.Functions.Cities.Queries.GetCityById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Foodie.Meals.API.Controllers
{
    public class CitiesController : Controller
    {
        private readonly IMediator mediator;

        public CitiesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // POST api/cities
        [HttpPost]
        public async Task<IActionResult> CreateCity([FromBody] CreateCityCommand createCityCommand)
        {
            createCityCommand.CreatedBy = GetUserEmail();
            await mediator.Send(createCityCommand);
            return Ok();
        }

        // PUT api/cities/5
        [HttpPut("{cityId}")]
        public async Task<IActionResult> UpdateCity(int cityId, [FromBody] UpdateCityCommand updateCityCommand)
        {
            if (cityId != updateCityCommand.CityId)
            {
                return BadRequest();
            }

            updateCityCommand.LastModifiedBy = GetUserEmail();
            await mediator.Send(updateCityCommand);
            return Ok();
        }

        // DELETE api/cities/5
        [HttpDelete("{cityId}")]
        public async Task<IActionResult> DeleteCity(int cityId)
        {
            var command = new DeleteCityCommand(cityId);
            await mediator.Send(command);
            return Ok();
        }

        // GET api/cities/5
        [HttpGet("{cityId}")]
        public async Task<IActionResult> GetCity(int cityId)
        {
            var query = new GetCityByIdQuery(cityId);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/cities
        [HttpGet]
        public async Task<IActionResult> GetCities([FromQuery] GetCitiesQuery getCitiesQuery)
        {
            var result = await mediator.Send(getCitiesQuery);
            return Ok(result);
        }

        private string GetUserEmail()
        {
            return User.FindFirstValue(ClaimTypes.Email);
        }
    }
}
