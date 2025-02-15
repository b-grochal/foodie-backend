﻿using Dapper;
using Foodie.Common.Collections;
using Foodie.Common.Infrastructure.Database.Connections.Interfaces;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Orders;
using Foodie.Orders.Infrastructure.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dapper.SqlBuilder;

namespace Foodie.Orders.Infrastructure.Queries
{
    public class OrdersQueries : IOrdersQueries
    {
        private readonly IDbConnecionFactory _dapperContext;

        public OrdersQueries(IDbConnecionFactory dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<PagedList<OrderQueryDto>> GetAllAsync(int pageNumber, int pageSize, string buyerEmail, string orderStatusName, string contractorName, int? locationId)
        {
            var selector = PrepareSqlTemplateForGettingAllOrders(pageNumber, pageSize, buyerEmail, orderStatusName, contractorName, locationId);

            using var connection = _dapperContext.CreateConnection();

            connection.Open();

            var orders = await connection.QueryAsync<OrderQueryDto>(selector.RawSql, selector.Parameters);
            return PagedList<OrderQueryDto>.Create(orders, pageNumber, pageSize);
        }

        public async Task<PagedList<OrderQueryDto>> GetAllAsync(int pageNumber, int pageSize, int customerId, int? orderStatusId, string contractorName)
        {
            var selector = PrepareSqlTemplateForGettingAllOrders(pageNumber, pageSize, customerId, orderStatusId, contractorName);

            using var connection = _dapperContext.CreateConnection();

            connection.Open();

            var orders = await connection.QueryAsync<OrderQueryDto>(selector.RawSql, selector.Parameters);
            return PagedList<OrderQueryDto>.Create(orders, pageNumber, pageSize);
        }

        public async Task<OrderDetailsQueryDto> GetByIdAsync(int id)
        {
            var selector = PrepareSqlTemplateForGettingOrderById(id);

            using var connection = _dapperContext.CreateConnection();
            connection.Open();

            var ordersMap = new Dictionary<int, OrderDetailsQueryDto>();
            var sqlQueryResult = await connection.QueryAsync<OrderDetailsQueryDto, OrderItemQueryDto, OrderDetailsQueryDto>(selector.RawSql, param: selector.Parameters,
                map: (orderDetails, orderItem) =>
                {
                    if (ordersMap.TryGetValue(orderDetails.OrderId, out OrderDetailsQueryDto existingOrder))
                    {
                        orderDetails = existingOrder;
                    }
                    else
                    {
                        orderDetails.OrderItems = new List<OrderItemQueryDto>();
                        ordersMap.Add(orderDetails.OrderId, orderDetails);
                    }

                    orderDetails.OrderItems.Add(orderItem);
                    return orderDetails;
                },
                splitOn: "OrderItemId");

            return sqlQueryResult.FirstOrDefault();
        }

        public async Task<OrderDetailsQueryDto> GetByIdAsync(int id, int customerId)
        {
            var selector = PrepareSqlTemplateForGettingOrderById(id, customerId);

            using var connection = _dapperContext.CreateConnection();
            connection.Open();

            var ordersMap = new Dictionary<int, OrderDetailsQueryDto>();
            var sqlQueryResult = await connection.QueryAsync<OrderDetailsQueryDto, OrderItemQueryDto, OrderDetailsQueryDto>(selector.RawSql, param: selector.Parameters,
                map: (orderDetails, orderItem) =>
                {
                    if (ordersMap.TryGetValue(orderDetails.OrderId, out OrderDetailsQueryDto existingOrder))
                    {
                        orderDetails = existingOrder;
                    }
                    else
                    {
                        orderDetails.OrderItems = new List<OrderItemQueryDto>();
                        ordersMap.Add(orderDetails.OrderId, orderDetails);
                    }

                    orderDetails.OrderItems.Add(orderItem);
                    return orderDetails;
                },
                splitOn: "OrderItemId");

            return sqlQueryResult.FirstOrDefault();
        }

        private Template PrepareSqlTemplateForGettingAllOrders(int pageNumber, int pageSize, string buyerEmail, string orderStatusName, string contractorName, int? locationId)
        {
            var builder = new SqlBuilder();

            var selector = builder.AddTemplate("Select /**select**/ from orders o /**innerjoin**/ /**where**/ /**orderby**/ offset @offset rows fetch next @pageSize rows only", new { offset = (pageNumber - 1) * pageSize, pageSize });

            builder.Select("o.Id as Id, o.OrderDate as OrderDate, os.Id as OrderStatusId, os.Name as OrderStatusName, b.Id as BuyerId, b.Email as BuyerEmail, c.Id as ContractorId, c.Name as ContractorName");
            builder.InnerJoin("Buyers b on o.BuyerId = b.Id");
            builder.InnerJoin("Contractors c on o.ContractorId = c.Id");
            builder.InnerJoin("OrderStatuses os on o.OrderStatusId = os.Id");
            builder.OrderBy("o.Id");

            if (buyerEmail != null)
                builder.Where("b.Email = @buyerEmail", new { buyerEmail });

            if (orderStatusName != null)
                builder.Where("os.Name= @orderStatusName", new { orderStatusName });

            if (contractorName != null)
                builder.Where("c.Name like @contractorName", new { contractorName = $"%{contractorName}%" });

            if (locationId.HasValue)
                builder.Where("c.LocationId = @locationId", new { locationId = locationId.Value });

            return selector;
        }

        private Template PrepareSqlTemplateForGettingAllOrders(int pageNumber, int pageSize, int customerId, int? orderStatusId, string contractorName)
        {
            var builder = new SqlBuilder();

            var selector = builder.AddTemplate("Select /**select**/ from orders o /**innerjoin**/ /**where**/ /**orderby**/ offset @offset rows fetch next @pageSize rows only", new { offset = (pageNumber - 1) * pageSize, pageSize });

            builder.Select("o.Id as OrderId, o.OrderStatus as OrderStatus, b.Id as BuyerId, b.Email as BuyerEmail, c.Id as ContractorId, c.Name as ContractorName");
            builder.InnerJoin("Buyers b on o.BuyerId = b.Id");
            builder.InnerJoin("Contractors c on o.ContractorId = c.Id");
            builder.OrderBy("o.Id desc");
            builder.Where("b.CustomerId = @customerId", new { customerId });

            if (orderStatusId != null)
                builder.Where("os.Id = @orderStatusId", new { orderStatusId.Value });

            if (contractorName != null)
                builder.Where("c.Name like @contractorName", new { contractorName = $"%{contractorName}%" });

            return selector;
        }

        private Template PrepareSqlTemplateForGettingOrderById(int id)
        {
            var builder = new SqlBuilder();

            var selector = builder.AddTemplate("Select /**select**/ from orders o /**innerjoin**/ /**where**/");

            builder.Select("o.Id as OrderId, o.OrderDate as OrderDate, o.Address_Street as AddressStreet, o.Address_City as AddressCity, " +
                "o.Address_Country as AddressCountry, os.Id as OrderStatusId, os.Name as OrderStatusName, b.Id as BuyerId, b.FirstName as BuyerFirstName, " +
                "b.LastName as BuyerLastName, b.PhoneNumber as BuyerPhoneNumber, b.Email as BuyerEmail, c.Id as ContractorId, c.Name as ContractorName, " +
                "c.Address as ContractorAddress, c.PhoneNumber as ContractorPhoneNumber, c.Email as ContractorEmail, c.City as ContractorCity, " +
                "c.Country as ContractorCountry, oi.Id as OrderItemId, oi.Name as Name, oi.Units as Units, oi.UnitPrice as UnitPrice");

            builder.InnerJoin("Buyers b on o.BuyerId = b.Id");
            builder.InnerJoin("Contractors c on o.ContractorId = c.Id");
            builder.InnerJoin("OrderStatuses os on o.OrderStatusId = os.Id");
            builder.InnerJoin("OrderItems oi on o.Id = oi.OrderId");
            builder.Where("o.Id = @id", new { id });

            return selector;
        }

        private Template PrepareSqlTemplateForGettingOrderById(int id, int customerId)
        {
            var builder = new SqlBuilder();

            var selector = builder.AddTemplate("Select /**select**/ from orders o /**innerjoin**/ /**where**/");

            builder.Select("o.Id as OrderId, o.OrderDate as OrderDate, o.Address_Street as AddressStreet, o.Address_City as AddressCity, " +
                "o.Address_Country as AddressCountry, os.Id as OrderStatusId, os.Name as OrderStatusName, b.Id as BuyerId, b.FirstName as BuyerFirstName, " +
                "b.LastName as BuyerLastName, b.PhoneNumber as BuyerPhoneNumber, b.Email as BuyerEmail, c.Id as ContractorId, c.Name as ContractorName, " +
                "c.Address as ContractorAddress, c.PhoneNumber as ContractorPhoneNumber, c.Email as ContractorEmail, c.City as ContractorCity, " +
                "c.Country as ContractorCountry, oi.Id as OrderItemId, oi.Name as Name, oi.Units as Units, oi.UnitPrice as UnitPrice");

            builder.InnerJoin("Buyers b on o.BuyerId = b.Id");
            builder.InnerJoin("Contractors c on o.ContractorId = c.Id");
            builder.InnerJoin("OrderStatuses os on o.OrderStatusId = os.Id");
            builder.InnerJoin("OrderItems oi on o.Id = oi.OrderId");
            builder.Where("o.Id = @id", new { id });
            builder.Where("b.UserId = @userId", new { customerId });

            return selector;
        }
    }
}
