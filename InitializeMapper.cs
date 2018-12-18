using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Storage.Database;
using Storage.Database.Models;
using Storage.Domain.Clients.Models;
using Storage.Domain.CompositionOrders.Models;
using Storage.Domain.Contracts.Models;
using Storage.Domain.Employees.Models;
using Storage.Domain.Nomenclatures.Models;
using Storage.Domain.Orders.Models;
using Storage.Domain.Payments.Models;
using Storage.Domain.ShippingUnits.Models;
using Storage.Domain.Storages.Models;
using Storage = Storage.Database.Models.Storage;

namespace Storage.Domain
{
    public static class Initializer
    {
        public static void InitializeMapper()
        {
            Mapper.Initialize(opt =>
            {
                opt.CreateMap<ClientInfo, Client>();
                opt.CreateMap<ContractInfo, Contract>();
                opt.CreateMap<PaymentInfo, Payment>();
                opt.CreateMap<OrderInfo, Order>();
                opt.CreateMap<EmployeeInfo, Employee>();
                opt.CreateMap<CompositionOrderInfo, CompositionOrder>();
                opt.CreateMap<StorageInfo, Database.Models.Storage>();
                opt.CreateMap<NomenclatureInfo, Nomenclature>();
                opt.CreateMap<ShippingUnitInfo, ShippingUnit>();
            });
        }

        public static void InitializeDb()
        {
            using (var context = new DatabaseContext())
            {
                context.Database.CreateIfNotExists();
            }
        }
    }
}
