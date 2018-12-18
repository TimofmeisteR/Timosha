using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Storage.Domain.Contracts.Models
{
    public class ContractInfo
    { 

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

        public ContractInfo()
        {
            
        }
    }
}
