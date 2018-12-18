using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Storage.Database;
using Storage.Database.Models;
using Storage.Domain.CompositionOrders.Models;

namespace Storage.Domain.CompositionOrders
{
    public class CompositionOrderService: IDisposable
    {
        private readonly DatabaseContext _context;

        public CompositionOrderService()
        {
            _context = new DatabaseContext();
        }

        public Guid Create(CompositionOrderInfo compositionOrderInfo)
        {
            var res = Mapper.Map<CompositionOrder>(compositionOrderInfo);
            _context.CompositionOrders.Add(res);
            _context.SaveChanges();
            return res.CompositionOrderGuid;
        }

        public void Delete(Guid compositionOrderguid)
        {
            var res = _context.CompositionOrders.First(x => x.CompositionOrderGuid == compositionOrderguid);
            _context.CompositionOrders.Remove(res);
            _context.SaveChanges();
        }

        public List<CompositionOrder> Get()
        {
            return _context.CompositionOrders
                .Include(x=>x.ShippingUnits)
                .Include(x=>x.Order)
                .Include(x=>x.Nomenclature)
                .ToList();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
