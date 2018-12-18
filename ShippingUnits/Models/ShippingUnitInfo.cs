using System;

namespace Storage.Domain.ShippingUnits.Models
{
    public class ShippingUnitInfo
    {

        public Guid ContractGuid { get; set; }

        public Guid EmployeeGuid { get; set; }

        public DateTime OrderDate { get; set; }

        public ShippingUnitInfo()
        {
            
        }
    }
}
