﻿using Foodie.Common.Api.Controllers;
using Foodie.Common.Api.Results;
using Foodie.Orders.Application.Features.Buyers.Queries.GetBuyerById;
using Foodie.Orders.Application.Features.Buyers.Queries.GetBuyers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Foodie.Orders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyersController : BaseController
    {
        public BuyersController(IMediator mediator) : base(mediator) { }

        // GET api/buyers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBuyer(int id)
        {
            var query = new GetBuyerByIdQuery(id);
            var result = await mediator.Send(query);

            return result.Match(
                onSuccess: () => Ok(result.Value),
                onFailure: HandleFailure);
        }

        // GET api/buyers
        [HttpGet]
        public async Task<IActionResult> GetBuyers([FromQuery] GetBuyersQuery getBuyersQuery)
        {
            var result = await mediator.Send(getBuyersQuery);

            return result.Match(
                onSuccess: () => Ok(result.Value),
                onFailure: HandleFailure);
        }
    }
}
