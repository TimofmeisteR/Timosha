using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Storage.Database.Models
{
    /// <summary>
    /// Номенклатура
    /// </summary>
    public class Nomenclature
    {
        [Key]
        public Guid NomenclatureGuid { get; set; }

        public decimal Price { get; set; }

        /// <summary>
        /// Единица измерения
        /// </summary>
        public string Unit { get; set; }

        public virtual ICollection<CompositionOrder> CompositionOrders { get; set; }
        public virtual ICollection<Storage> Storages { get; set; }

        public Nomenclature()
        {
            NomenclatureGuid = Guid.NewGuid();
        }

    }
}
