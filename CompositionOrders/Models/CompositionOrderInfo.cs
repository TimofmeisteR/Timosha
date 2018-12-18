using System;

namespace Storage.Domain.CompositionOrders.Models
{
    public class CompositionOrderInfo
    {
        public Guid OrderGuid { get; set; }

        public Guid NomenclatureGuid { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public int Count { get; set; }

        public CompositionOrderInfo()
        {
            
        }
    }
}
