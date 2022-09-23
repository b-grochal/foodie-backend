﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Queries.GetOrders
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public int OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }
        public int BuyerId { get; set; }
        public string BuyerEmail { get; set; }
        public int ContractorId { get; set; }
        public string ContactorName { get; set; }
    }
}