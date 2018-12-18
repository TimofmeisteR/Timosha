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
    /// Договор
    /// </summary>
    public class Contract
    {
        /// <summary>
        /// Нормер договора
        /// </summary>
        [Key]
        public Guid ContractGuid { get; set; }

        [ForeignKey(nameof(Client))]
        public Guid ClientGuid { get; set; }

        /// <summary>
        /// Вид договора
        /// </summary>
        public string TypeContract { get; set; }

        public DateTime DateContract { get; set; }

        /// <summary>
        /// Срок действия
        /// </summary>
        public DateTime ValidityTime { get; set; }

        public virtual Client Client { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Order> Orders { get; set; }


        public Contract()
        {
            ContractGuid = Guid.NewGuid();
        }
    }
}
