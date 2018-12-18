using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Domain.Orders.Models
{
    public class OrderInfo
    {

        public Guid ContractGuid { get; set; }

        public Guid EmployeeGuid { get; set; }

        public DateTime OrderDate { get; set; }

        public OrderInfo()
        {
            
        }
    }
}
