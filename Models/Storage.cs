using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Storage.Database.Models
{
    /// <summary>
    /// Склад
    /// </summary>
    public class Storage
    {
        /// <summary>
        /// ID единицы хранения
        /// </summary>
        [Key]
        public Guid StorageGuid { get; set; }

        [ForeignKey(nameof(Nomenclature))]
        public Guid NomenclatureGuid { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Дата поступления
        /// </summary>
        public DateTime IssueDate { get; set; }

        public int Count { get; set; }

        public virtual Nomenclature Nomenclature { get; set; }

        public virtual ICollection<ShippingUnit> ShippingUnits { get; set; }

        public Storage()
        {
            StorageGuid = Guid.NewGuid();
        }
    }
}
