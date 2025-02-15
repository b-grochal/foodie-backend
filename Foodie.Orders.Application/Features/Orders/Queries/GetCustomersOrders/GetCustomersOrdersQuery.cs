﻿using Foodie.Common.Application.Requests.Interfaces;
using Foodie.Common.Application.Requests.Queries.Interfaces;
using Foodie.Common.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Foodie.Orders.Application.Features.Orders.Queries.GetCustomersOrders
{
    public class GetCustomersOrdersQuery : PagedQuery, IRequest<Result<GetCustomersOrdersQueryResponse>>, IApplicationUserIdRequest
    {
        [JsonIgnore]
        public int ApplicationUserId { get; set; }
        public int? OrderStatusId { get; set; }
        public string ContractorName { get; set; }
    }
}
