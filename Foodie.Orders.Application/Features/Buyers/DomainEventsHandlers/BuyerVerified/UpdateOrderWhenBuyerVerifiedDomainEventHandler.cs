﻿using Foodie.Orders.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Orders.Domain.Buyers.DomainEvents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Buyers.DomainEventsHandlers.BuyerVerified
{
    public class UpdateOrderWhenBuyerVerifiedDomainEventHandler : INotificationHandler<BuyerVerifiedDomainEvent>
    {
        private readonly IOrdersRepository _ordersRepository;

        public UpdateOrderWhenBuyerVerifiedDomainEventHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task Handle(BuyerVerifiedDomainEvent buyerVerifiedDomainEvent, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _ordersRepository.GetByIdAsync(buyerVerifiedDomainEvent.OrderId);
            orderToUpdate.SetBuyerId(buyerVerifiedDomainEvent.Buyer.Id);
        }
    }
}
