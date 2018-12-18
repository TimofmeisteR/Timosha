using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Domain.Clients.Models
{
    public class ClientInfo
    {
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

        public ClientInfo()
        {
            
        }
    }
}
