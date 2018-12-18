using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Storage.Database;
using Storage.Database.Models;
using Storage.Domain.Nomenclatures.Models;

namespace Storage.Domain.Nomenclatures
{
    public class NomenclatureService: IDisposable
    {
        private readonly DatabaseContext _context;

        public NomenclatureService()
        {
            _context = new DatabaseContext();
        }

        public Guid Create(NomenclatureInfo nomenclatureInfo)
        {
            var res = Mapper.Map<Nomenclature>(nomenclatureInfo);
            _context.Nomenclatures.Add(res);
            _context.SaveChanges();
            return res.NomenclatureGuid;
        }

        public void Delete(Guid nomenclatureguid)
        {
            var res = _context.Nomenclatures.First(x => x.NomenclatureGuid== nomenclatureguid);
            _context.Nomenclatures.Remove(res);
            _context.SaveChanges();
        }

        public List<Nomenclature> Get()
        {
            return _context.Nomenclatures
                .Include(x=>x.Storages)
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
