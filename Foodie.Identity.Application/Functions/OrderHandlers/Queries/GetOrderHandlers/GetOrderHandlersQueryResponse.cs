﻿using Foodie.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Queries.GetOrderHandlers
{
    public class GetOrderHandlersQueryResponse : PagedResponse
    {
        public IEnumerable<OrderHandlerDto> OrderHandlers { get; set; }
        public string Email { get; set; }
    }
}