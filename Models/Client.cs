using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Storage.Database.Models
{
    /// <summary>
    /// Заказчик
    /// </summary>
    public class Client
    {
        [Key]
        public Guid ClietnGuid { get; set; }

        public string OrganizationName { get; set; }

        public string Inn { get; set; }

        /// <summary>
        /// Физический адрес
        /// </summary>
        public string AddressF { get; set; }

        /// <summary>
        /// Юрирический адрес
        /// </summary>
        public string AddressO { get; set; }

        /// <summary>
        /// Расчётный счёт
        /// </summary>
        public string CheckingAccount { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }

        public Client()
        {
            ClietnGuid = Guid.NewGuid();
        }
    }
}
