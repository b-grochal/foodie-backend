﻿using Foodie.Orders.Application.Functions.Contractors.Queries.GetContractorById;
using Foodie.Orders.Application.Functions.Contractors.Queries.GetContractors;
using Foodie.Shared.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Foodie.Orders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractorsController : BaseController
    {
        public ContractorsController(IMediator mediator) : base(mediator) { }

        // GET api/contractors/5
        [HttpGet("{contractorId}")]
        public async Task<IActionResult> GetBuyer(int contractorId)
        {
            var query = new GetContractorByIdQuery(contractorId);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/contractors
        [HttpGet]
        public async Task<IActionResult> GetBuyers([FromQuery] GetContractorsQuery getBuyersQuery)
        {
            var result = await mediator.Send(getBuyersQuery);
            return Ok(result);
        }
    }
}
