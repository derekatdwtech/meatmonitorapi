using tempaastapi.Models;
using tempaastapi.utils;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;

namespace tempaastapi.repository
{
    public class ProbeConfigRepository : IProbeConfig
    {
        private readonly IConfiguration _config;
        public ProbeConfigRepository(IConfiguration config)
        {
            _config = config;
        }

        public List<ProbeConfig> GetAllProbeConfigs(string userId)
        {
            var tableClient = new AzureTableStorage<ProbeConfig>(_config["ConnectionStrings:StorageAccount"], _config["ProbeConfigTable"]);
            TableQuery<ProbeConfig> query = new TableQuery<ProbeConfig>().Where(
                TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, userId)
            );

            return tableClient.GetMany(query).Result;
        }

        public List<ProbeConfig> GetProbeConfig(string partitionKey, string rowKey)
        {
            TableQuery<ProbeConfig> query = new TableQuery<ProbeConfig>().Where(
                TableQuery.CombineFilters(
                    TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey),
                    TableOperators.And,
                    TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, rowKey)
                )

            );
            var tableClient = new AzureTableStorage<ProbeConfig>(_config["ConnectionStrings:StorageAccount"], _config["ProbeConfigTable"]);
            return tableClient.GetMany(query).Result;
        }

        public ProbeConfig UpdateProbeConfig(ProbeConfig pc)
        {
            var tableClient = new AzureTableStorage<ProbeConfig>(_config["ConnectionStrings:StorageAccount"], _config["ProbeConfigTable"]);
            return tableClient.InsertOrUpdateAsync(pc).Result;
        }
    }
}