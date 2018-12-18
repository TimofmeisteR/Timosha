using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Storage.Database;
using Storage.Database.Models;
using Storage.Domain.Orders.Models;

namespace Storage.Domain.Orders
{
    public class OrderService: IDisposable
    {
        private readonly DatabaseContext _context;

        public OrderService()
        {
            _context = new DatabaseContext();
        }

        public Guid Create(OrderInfo orderInfo)
        {
            var res = Mapper.Map<Order>(orderInfo);
            _context.Orders.Add(res);
            _context.SaveChanges();
            return res.OrderGuid;
        }

        public void Delete(Guid orderguid)
        {
            var res = _context.Orders.First(x => x.OrderGuid== orderguid);
            _context.Orders.Remove(res);
            _context.SaveChanges();
        }

        public List<Order> Get()
        {
            return _context.Orders
                .Include(x=>x.Contract)
                .Include(x=>x.Employee)
                .Include(x=>x.CompositionOrders)
                .ToList();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
