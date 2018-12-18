using System;

namespace Storage.Domain.Nomenclatures.Models
{
    public class NomenclatureInfo
    {

        public Guid ContractGuid { get; set; }

        public Guid EmployeeGuid { get; set; }

        public DateTime OrderDate { get; set; }

        public NomenclatureInfo()
        {
            
        }
    }
}
