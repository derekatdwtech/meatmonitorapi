using tempaastapi.Models;
using tempaastapi.utils;
using Microsoft.Extensions.Configuration;

namespace tempaastapi.repository
{
    public class ProbeConfigRepository : IProbeConfig
    {
        private readonly IConfiguration _config;
        public ProbeConfigRepository(IConfiguration config)
        {
            _config = config;
        }

        public ProbeConfig GetProbeConfig(string partitionKey, string rowKey)
        {
            var tableClient = new AzureTableStorage<ProbeConfig>(_config["ConnectionStrings:StorageAccount"], _config["ProbeConfigTable"]);
            return tableClient.Get(partitionKey, rowKey).Result;
        }

        public ProbeConfig UpdateProbeConfig(ProbeConfig pc)
        {
            var tableClient = new AzureTableStorage<ProbeConfig>(_config["ConnectionStrings:StorageAccount"], _config["ProbeConfigTable"]);
            return tableClient.InsertOrUpdateAsync(pc).Result;
        }
    }
}