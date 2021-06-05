
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Table;
using tempaastapi.Models;
using tempaastapi.utils;

namespace tempaastapi.attributes
{

    [AttributeUsage(validOn: AttributeTargets.Method)]
    sealed class ApiKeyAttribute : Attribute
    {
        private const string APIKEYNAME = "Api-Key";
        private readonly IConfiguration _config;

        public ApiKeyAttribute()
        {

        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "No Api-Key was not provided. Please pass the attribute "
                };
                return;
            }

            
            var apiKey = GetApiKeyByValue(extractedApiKey);

            if (apiKey.Count < 1)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Api Key is not valid"
                };
                return;
            }

            await next();
        }

        private List<ApiKeyEntity> GetApiKeyByValue(string key) {
            AzureTableStorage<ApiKeyEntity> _tableClient = new AzureTableStorage<ApiKeyEntity>(_config["ConnectionStrings:StorageAccount"], _config["AppSettings:ApiKeyTable"]);
            DateTime now = new DateTime();
            string isoTime = now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
            TableQuery<ApiKeyEntity> _query = new TableQuery<ApiKeyEntity>().Where(
                TableQuery.CombineFilters(
                TableQuery.GenerateFilterCondition("ApiKey", QueryComparisons.Equal, key),
                TableOperators.And,
                TableQuery.GenerateFilterCondition("expirationDate", QueryComparisons.GreaterThanOrEqual, isoTime))
            );

            var foundKey = _tableClient.GetMany(_query).Result;

            return foundKey;

        }
    }


}