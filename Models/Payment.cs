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
    /// Оплата
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Код оплаты
        /// </summary>
        [Key]
        public Guid PaymentGuid { get; set; }

        [ForeignKey(nameof(Contract))]
        public Guid ContractGuid { get; set; }

        /// <summary>
        /// Вид оплаты
        /// </summary>
        public string TypePayment { get; set; }

        public DateTime PaymentDate { get; set; }

        public decimal Sum { get; set; }

        /// <summary>
        /// Расчётный счёт
        /// </summary>
        public string CheckingAccount { get; set; }

        public virtual Contract Contract { get; set; }

        public Payment()
        {
            PaymentGuid = Guid.NewGuid();
        }
    }
}
