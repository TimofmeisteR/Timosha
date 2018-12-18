using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Storage.Database;
using Storage.Database.Models;
using Storage.Domain.Payments.Models;

namespace Storage.Domain.Payments
{
    public class PaymentService: IDisposable
    {
        private readonly DatabaseContext _context;

        public PaymentService()
        {
            _context = new DatabaseContext();
        }

        public Guid Create(PaymentInfo paymentInfo)
        {
            var res = Mapper.Map<Payment>(paymentInfo);
            _context.Payments.Add(res);
            _context.SaveChanges();
            return res.PaymentGuid;
        }

        public void Delete(Guid paymentguid)
        {
            var res = _context.Payments.First(x => x.PaymentGuid== paymentguid);
            _context.Payments.Remove(res);
            _context.SaveChanges();
        }

        public List<Payment> Get()
        {
            return _context.Payments
                .Include(x=>x.Contract)
                .ToList();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
