using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Storage.Database;
using Storage.Database.Models;
using Storage.Domain.Contracts.Models;

namespace Storage.Domain.Contracts
{
    public class ContractService: IDisposable
    {
        private readonly DatabaseContext _context;

        public ContractService()
        {
            _context = new DatabaseContext();
        }

        public Guid Create(ContractInfo contractInfo)
        {
            var res = Mapper.Map<Contract>(contractInfo);
            _context.Contracts.Add(res);
            _context.SaveChanges();
            return res.ContractGuid;
        }

        public void Delete(Guid contractguid)
        {
            var res = _context.Contracts.First(x => x.ContractGuid== contractguid);
            _context.Contracts.Remove(res);
            _context.SaveChanges();
        }

        public List<Contract> Get()
        {
            return _context.Contracts
                .Include(x=>x.Client)
                .Include(x=>x.Orders)
                .Include(x=>x.Payments)
                .ToList();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
