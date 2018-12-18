using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Database.Models
{
    /// <summary>
    /// Отгрузочная еденица
    /// </summary>
    public class ShippingUnit
    {
        /// <summary>
        /// Ид отгрузки
        /// </summary>
        [Key]
        public Guid ShippingUnitGuid { get; set; }

        [ForeignKey(nameof(Storage))]
        public Guid StorageGuid { get; set; }

        [ForeignKey(nameof(CompositionOrder))]
        public Guid CompositionOrderGuid { get; set; }

        public virtual Storage Storage { get; set; }
        public virtual CompositionOrder CompositionOrder { get; set; }

        public ShippingUnit()
        {
            ShippingUnitGuid = Guid.NewGuid();
        }
    }
}
