﻿using Foodie.Common.Results;
using MediatR;
using System.Collections.Generic;

namespace Foodie.Orders.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Result>
    {
        public string CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressCountry { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public int LocationId { get; set; }
        public string LocationAddress { get; set; }
        public string LocationPhoneNumber { get; set; }
        public string LocationEmail { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        private readonly List<OrderItemDTO> _orderItems;
        public IEnumerable<OrderItemDTO> OrderItems => _orderItems;

        public CreateOrderCommand()
        {
            _orderItems = new List<OrderItemDTO>();
        }

        public CreateOrderCommand(string userId, string userFirstName, string userLastName, string userPhoneNumber, string userEmail, string addressStreet, string addressCity,
            string addressCountry, int restaurantId, string restaurantName, int locationId, string locationAddress,
            string locationPhoneNumber, string locationEmail, int cityId, string cityName, int countryId, string countryName, List<OrderItemDTO> orderItems) : this()
        {
            CustomerId = userId;
            CustomerFirstName = userFirstName;
            CustomerLastName = userLastName;
            CustomerPhoneNumber = userPhoneNumber;
            CustomerEmail = userEmail;
            AddressStreet = addressStreet;
            AddressCity = addressCity;
            AddressCountry = addressCountry;
            RestaurantId = restaurantId;
            RestaurantName = restaurantName;
            LocationId = locationId;
            LocationAddress = locationAddress;
            LocationPhoneNumber = locationPhoneNumber;
            LocationEmail = locationEmail;
            CityId = cityId;
            CityName = cityName;
            CountryId = countryId;
            CountryName = countryName;
            _orderItems = orderItems;
        }

        public record OrderItemDTO
        {
            public int MealId { get; init; }
            public string MealName { get; init; }
            public decimal UnitPrice { get; init; }
            public int Quantity { get; init; }
        }
    }
}
