using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Storage.Database;
using Storage.Database.Models;
using Storage.Domain.ShippingUnits.Models;

namespace Storage.Domain.ShippingUnits
{
    public class ShippingUnitService: IDisposable
    {
        private readonly DatabaseContext _context;

        public ShippingUnitService()
        {
            _context = new DatabaseContext();
        }

        public Guid Create(ShippingUnitInfo shippingUnitInfo)
        {
            var res = Mapper.Map<ShippingUnit>(shippingUnitInfo);
            _context.ShippingUnits.Add(res);
            _context.SaveChanges();
            return res.ShippingUnitGuid;
        }

        public void Delete(Guid shippingUnitguid)
        {
            var res = _context.ShippingUnits.First(x => x.ShippingUnitGuid== shippingUnitguid);
            _context.ShippingUnits.Remove(res);
            _context.SaveChanges();
        }

        public List<ShippingUnit> Get()
        {
            return _context.ShippingUnits
                .Include(x=>x.Storage)
                .Include(x=>x.CompositionOrder)
                .ToList();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
