using System;
using System.Diagnostics;
using System.Globalization;
using meatmonitorapi.Models;
using meatmonitorapi.utils;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

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

        public TempTableEntity UpdateTemperature(TempReading tr)
        {
            var timestamp = new DateTimeOffset(Convert.ToDateTime(tr.time));

            var insert = new TempTableEntity() {
                name = tr.name,
                temp_c = tr.temperature.c.ToString(),
                temp_f = tr.temperature.f.ToString(),
                time = tr.time,
                Timestamp = timestamp,
                RowKey = tr.time
            };
            Console.WriteLine($"{JsonConvert.SerializeObject(insert)}");
            var tableClient = new AzureTableStorage<TempTableEntity>(_config["ConnectionStrings:StorageAccount"], _config["AppSettings:TemperatureReadingTable"]);
            return tableClient.InsertOrUpdateAsync(insert).Result;
        }
    }
}