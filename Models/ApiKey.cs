using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace tempaastapi.Models
{
    public class ApiKeyEntity : TableEntity
    {
        public string apiKey { get; set; } // This is also the Row Key
        public string userId { get; set; } // This is also the Partition key
        public DateTime expirationDate { get; set; }
        public DateTime creationDate { get; set; }
    }

    public class ApiKey
    {

        public string apiKey { get; set; } // This is also the Row Key
        public string userId { get; set; } // This is also the Partition key
        public DateTime expirationDate { get; set; }
        public DateTime creationDate { get; set; }
    }
}