using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using meatmonitorapi.Models;
using meatmonitorapi.utils;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;

namespace meatmonitorapi.repository
{
    public class TemperatureRepository : ITemperature
    {
        private readonly IConfiguration _config;

        public TemperatureRepository(IConfiguration config)
        {
            _config = config;
        }

        public TempReading GetLatestTemperature()
        {
            throw new System.NotImplementedException();
        }

        public List<TempTableEntity> GetTemperatureBetweenTime(string probeName, string startTime, string endTime)
        {
            TableQuery<TempTableEntity> query = new TableQuery<TempTableEntity>().Where(
            TableQuery.CombineFilters(
                TableQuery.CombineFilters(
                TableQuery.GenerateFilterCondition("time", QueryComparisons.GreaterThanOrEqual, startTime),
                TableOperators.And,
                TableQuery.GenerateFilterCondition("time", QueryComparisons.LessThanOrEqual, endTime)),
                TableOperators.And,
                TableQuery.GenerateFilterCondition("name", QueryComparisons.Equal, probeName)));

            var tableClient = new AzureTableStorage<TempTableEntity>(_config["ConnectionStrings:StorageAccount"], _config["AppSettings:TemperatureReadingTable"]);
            return tableClient.GetMany(query).Result;


        }

        public TempTableEntity UpdateTemperature(TempReading tr)
        {
            var timestamp = new DateTimeOffset(Convert.ToDateTime(tr.time));

            var insert = new TempTableEntity()
            {
                name = tr.name,
                temp_c = tr.temperature.c.ToString(),
                temp_f = tr.temperature.f.ToString(),
                time = tr.time,
                Timestamp = timestamp,
                RowKey = tr.time,
                PartitionKey = tr.name
            };
            Console.WriteLine($"{JsonConvert.SerializeObject(insert)}");
            var tableClient = new AzureTableStorage<TempTableEntity>(_config["ConnectionStrings:StorageAccount"], _config["AppSettings:TemperatureReadingTable"]);
            return tableClient.InsertOrUpdateAsync(insert).Result;
        }
    }
}