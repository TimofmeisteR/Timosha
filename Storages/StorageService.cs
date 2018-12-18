using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Storage.Database;
using Storage.Database.Models;
using Storage.Domain.Storages.Models;

namespace Storage.Domain.Storages
{
    public class StorageService: IDisposable
    {
        private readonly DatabaseContext _context;

        public StorageService()
        {
            _context = new DatabaseContext();
        }

        public Guid Create(StorageInfo storageInfo)
        {
            var res = Mapper.Map<Database.Models.Storage>(storageInfo);
            _context.Storages.Add(res);
            _context.SaveChanges();
            return res.StorageGuid;
        }

        public void Delete(Guid storageguid)
        {
            var res = _context.Storages.First(x => x.StorageGuid == storageguid);
            _context.Storages.Remove(res);
            _context.SaveChanges();
        }

        public List<Database.Models.Storage> Get()
        {
            return _context.Storages
                .Include(x=>x.Nomenclature)
                .Include(x=>x.ShippingUnits)
                .ToList();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
