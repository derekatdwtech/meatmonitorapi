using System;
using meatmonitorapi.Models;
using meatmonitorapi.utils;
using Microsoft.Extensions.Configuration;

namespace meatmonitorapi.repository {
    public class ProbeConfigRepository : IProbeConfig
    {
        private readonly IConfiguration _config;
        public ProbeConfigRepository(IConfiguration config) {
            _config = config;
        }
        public ProbeConfig GetProbeConfig(Guid id)
        {
            var tableClient = new AzureTableStorage<ProbeConfig>(_config["ConnectionStrings:StorageAccount"], _config["AppSettings:ProbeConfigTable"]);
            return tableClient.Get(id).Result;
        }

        public ProbeConfig UpdateProbeConfig(ProbeConfig pc)
        {
            var tableClient = new AzureTableStorage<ProbeConfig>(_config["ConnectionStrings:StorageAccount"], _config["AppSettings:ProbeConfigTable"]);

            return tableClient.InsertOrUpdateAsync(pc).Result;
        }
    }
}