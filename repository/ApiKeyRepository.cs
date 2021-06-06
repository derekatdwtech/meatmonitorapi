using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Table;
using tempaastapi.Models;
using tempaastapi.utils;

namespace tempaastapi.repository
{
    public class ApiKeyRepository : IApiKey
    {

        private string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
        AzureTableStorage<ApiKeyEntity> _tableClient;
        IConfiguration _config;

        public ApiKeyRepository(IConfiguration config)
        {
            _config = config;
            _tableClient = new AzureTableStorage<ApiKeyEntity>(_config["ConnectionStrings:StorageAccount"], _config["ApiKeyTable"]);

        }
        public async void DeleteApiKey(string id, string key)
        {
            var entity = _tableClient.Get(id, key).Result;
            await _tableClient.Delete(entity);
        }

        public ApiKeyEntity GenerateApiKey(string id)
        {
            DateTime expiration = DateTime.UtcNow.AddDays(365);
            string apiKey = GenerateString(32);
            ApiKeyEntity keyEntity = new ApiKeyEntity()
            {
                PartitionKey = id,
                RowKey = apiKey,
                apiKey = apiKey,
                expirationDate = expiration,
                creationDate = DateTime.UtcNow,
                userId = id
            };

            return _tableClient.InsertOrUpdateAsync(keyEntity).Result;

        }

        public List<ApiKeyEntity> GetApiKeyByUser(string id)
        {
            TableQuery<ApiKeyEntity> query = new TableQuery<ApiKeyEntity>().Where(
            TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, id));

            return _tableClient.GetMany(query).Result;
        }


        private static string GenerateString(int length)
        {
            using (var crypto = new RNGCryptoServiceProvider())
            {
                var bits = (length * 6);
                var byte_size = ((bits + 7) / 8);
                var bytesarray = new byte[byte_size];
                crypto.GetBytes(bytesarray);
                return Convert.ToBase64String(bytesarray);
            }
        }
    }
}