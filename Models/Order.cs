using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Storage.Database.Models
{
    /// <summary>
    /// Zakaz
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Order id
        /// </summary>
        [Key]
        public Guid OrderGuid { get; set; }

        [ForeignKey(nameof(Contract))]
        public Guid ContractGuid { get; set; }

        [ForeignKey(nameof(Employee))]
        public Guid EmployeeGuid { get; set; }

        public DateTime OrderDate { get; set; }

        public virtual Contract Contract { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<CompositionOrder> CompositionOrders { get; set; }


        public Order()
        {
            OrderGuid = Guid.NewGuid();
        }
    }
}
