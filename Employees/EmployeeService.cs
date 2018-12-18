using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Storage.Database;
using Storage.Database.Models;
using Storage.Domain.Employees.Models;

namespace Storage.Domain.Employees
{
    public class EmployeeService: IDisposable
    {
        private readonly DatabaseContext _context;

        public EmployeeService()
        {
            _context = new DatabaseContext();
        }

        public Guid Create(EmployeeInfo employeeInfo)
        {
            var res = Mapper.Map<Employee>(employeeInfo);
            _context.Employees.Add(res);
            _context.SaveChanges();
            return res.EmployeeGuid;
        }

        public void Delete(Guid employeeguid)
        {
            var res = _context.Employees.First(x => x.EmployeeGuid== employeeguid);
            _context.Employees.Remove(res);
            _context.SaveChanges();
        }

        public List<Employee> Get()
        {
            return _context.Employees
                .Include(x=>x.Orders)
                .ToList();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
