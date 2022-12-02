﻿using AutoMapper;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Queries.GetCustomersOrders
{
    public class GetCustomersOrdersQueryHandler : IRequestHandler<GetCustomersOrdersQuery, GetCustomersOrdersQueryResponse>
    {
        private readonly IOrderQueries _orderQueries;
        private readonly IMapper _mapper;

        public GetCustomersOrdersQueryHandler(IOrderQueries orderQueries, IMapper mapper)
        {
            _orderQueries = orderQueries;
            _mapper = mapper;
        }

        public async Task<GetCustomersOrdersQueryResponse> Handle(GetCustomersOrdersQuery request, CancellationToken cancellationToken)
        {
            var customersOrders = await _orderQueries.GetAllAsync(request.PageNumber, request.PageSize, request.UserId, request.OrderStatusId, request.ContractorName);

            return new GetCustomersOrdersQueryResponse
            {
                TotalCount = customersOrders.TotalCount,
                PageSize = customersOrders.PageSize,
                CurrentPage = customersOrders.CurrentPage,
                TotalPages = (int)Math.Ceiling(customersOrders.TotalCount / (double)customersOrders.PageSize),
                CustomersOrders = _mapper.Map<IEnumerable<CustomersOrderDto>>(customersOrders),
                OrderStatusId = request.OrderStatusId,
                ContractorName = request.ContractorName
            };
        }
    }
}