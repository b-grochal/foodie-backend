﻿using Foodie.EventBus.IntegrationEvents.Basket;
using Foodie.Orders.Application.Functions.Orders.Commands.CreateOrder;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Foodie.Orders.Application.Functions.Orders.Commands.CreateOrder.CreateOrderCommand;

namespace Foodie.Orders.Application.IntegrationEventsHandlers
{
    public class CustomerCheckoutIntegrationEventHandler : IConsumer<CustomerCheckoutIntegrationEvent>
    {
        private readonly IMediator _medaitor;

        public CustomerCheckoutIntegrationEventHandler(IMediator mediator)
        {
            _medaitor = mediator;
        }

        public async Task Consume(ConsumeContext<CustomerCheckoutIntegrationEvent> context)
        {
            var message = context.Message;
            var orderItems = message.OrderItems.Select(o => new OrderItemDTO
            {
                MealId = o.MealId,
                MealName = o.MealName,
                UnitPrice = o.UnitPrice,
                Quantity = o.Quantity
            }).ToList();

            var createOrderCommand = new CreateOrderCommand(message.CustomerId, message.CustomerFirstName, message.CustomerLastName, message.CustomerPhoneNumber, message.CustomerEmail, message.AddressStreet, message.AddressCity,
                message.AddressCountry, message.RestaurantId, message.RestaurantName, message.LocationId, message.LocationAddress, message.LocationPhoneNumber, message.LocationEmail, message.CityId, message.CityName,
                message.LocationCountry, orderItems);

            await _medaitor.Send(createOrderCommand);
        }
    }
}
