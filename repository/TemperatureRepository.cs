using meatmonitorapi.Models;
using meatmonitorapi.utils;
using Microsoft.Extensions.Configuration;

namespace meatmonitorapi.repository {
    public class TemperatureRepository : ITemperature
    {
        private readonly IConfiguration _config;

        public TemperatureRepository(IConfiguration config) {
            _config = config;
        }

        public TempReading GetLatestTemperature()
        {
            throw new System.NotImplementedException();
        }

        public TempReading UpdateTemperature(TempReading tr)
        {
            var tableClient = new AzureTableStorage<TempReading>(_config["ConnectionStrings:StorageAccount"], _config["AppSettings:TemperatureReadingTable"]);

            return tableClient.InsertOrUpdateAsync(tr).Result;
        }
    }
}