using System;

namespace Storage.Domain.Storages.Models
{
    public class StorageInfo
    {
        public Guid NomenclatureGuid { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Дата поступления
        /// </summary>
        public DateTime IssueDate { get; set; }

        public int Count { get; set; }

        public StorageInfo()
        {
            
        }
    }
}
