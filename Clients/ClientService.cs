using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Storage.Database;
using Storage.Database.Models;
using Storage.Domain.Clients.Models;

namespace Storage.Domain.Clients
{
    public class ClientService: IDisposable
    {
        private readonly DatabaseContext _context;

        public ClientService()
        {
            _context = new DatabaseContext();
        }

        public Guid Create(ClientInfo clientInfo)
        {
            var res = Mapper.Map<Client>(clientInfo);
            _context.Clients.Add(res);
            _context.SaveChanges();
            return res.ClietnGuid;
        }

        public void Delete(Guid clientGuid)
        {
            var res = _context.Clients.First(x => x.ClietnGuid == clientGuid);
            _context.Clients.Remove(res);
            _context.SaveChanges();
        }

        public List<Client> Get()
        {
            return _context.Clients.Include(x=>x.Contracts).ToList();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
