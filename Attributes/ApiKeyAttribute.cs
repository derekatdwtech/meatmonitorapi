
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Table;
using tempaastapi.Models;
using tempaastapi.utils;
using Microsoft.Extensions.DependencyInjection;

namespace tempaastapi.attributes
{

    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    sealed class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string APIKEYNAME = "Api-Key";
        public string userId { get; set; }

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

            var config = context.HttpContext.RequestServices.GetService<IConfiguration>();
            var connString = config.GetValue<string>("StorageAccountConnString");
            var tableName = config.GetValue<string>("ApiKeyTable");
            var apiKey = GetApiKeyByValue(extractedApiKey, connString, tableName);
            if (apiKey.Count < 1)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Api Key is not valid"
                };
                return;
            }
            else
            {
                config["UserId"] = apiKey[0].userId;
            }

            await next();
        }



        private List<ApiKeyEntity> GetApiKeyByValue(string key, string connString, string table)
        {
            AzureTableStorage<ApiKeyEntity> _tableClient = new AzureTableStorage<ApiKeyEntity>(connString, table);
            DateTime now = DateTime.UtcNow;

            TableQuery<ApiKeyEntity> _query = new TableQuery<ApiKeyEntity>().Where(
                TableQuery.CombineFilters(
                TableQuery.GenerateFilterCondition("apiKey", QueryComparisons.Equal, key),
                TableOperators.And,
                TableQuery.GenerateFilterConditionForDate("expirationDate", QueryComparisons.GreaterThan, now))
            );
            var foundKey = _tableClient.GetMany(_query).Result;

            return foundKey;

        }
    }


}