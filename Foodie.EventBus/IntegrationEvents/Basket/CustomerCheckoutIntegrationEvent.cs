﻿using Foodie.EventBus.IntegrationEvents.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.EventBus.IntegrationEvents.Basket
{
    public interface CustomerCheckoutIntegrationEvent : IntegrationEvent
    {
        string UserId { get; set; }
        string UserFirstName { get; set; }
        string UserLastName { get; set; }
        string UserPhoneNumber { get; set; }
        string UserEmail { get; set; }
        string AddressStreet { get; set; }
        string AddressCity { get; set; }
        string AddressCountry { get; set; }
        int RestaurantId { get; set; }
        string RestaurantName { get; set; }
        int LocationId { get; set; }
        string LocationAddress { get; set; }
        string LocationPhoneNumber { get; set; }
        string LocationEmail { get; set; }
        int CityId { get; set; }
        string CityName { get; set; }
        string LocationCountry { get; set; }
        IEnumerable<OrderItem> OrderItems { get;}
    }

    public interface OrderItem
    {
        int MealId { get; set; }
        string MealName { get; set; }
        decimal UnitPrice { get; set; }
        int Quantity { get; set; }
    }
}