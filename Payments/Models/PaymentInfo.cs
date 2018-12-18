using System;

namespace Storage.Domain.Payments.Models
{
    public class PaymentInfo
    {
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

        public PaymentInfo()
        {
            
        }
    }
}
