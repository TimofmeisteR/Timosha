using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Storage.Database.Models
{
    /// <summary>
    /// состав заказа
    /// </summary>
    public class CompositionOrder
    {
        [Key]
        public Guid CompositionOrderGuid { get; set; }

        [ForeignKey(nameof(Order))]
        public Guid OrderGuid { get; set; }

        [ForeignKey(nameof(Nomenclature))]
        public Guid NomenclatureGuid { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public int Count { get; set; }

        public virtual Order Order { get; set; }
        public virtual Nomenclature Nomenclature { get; set; }

        public virtual ICollection<ShippingUnit> ShippingUnits { get; set; }


        public CompositionOrder()
        {
            CompositionOrderGuid = Guid.NewGuid();
        }
    }
}
