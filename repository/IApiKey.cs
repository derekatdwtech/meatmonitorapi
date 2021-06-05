using System.Collections.Generic;
using tempaastapi.Models;

namespace tempaastapi.repository {
    public interface IApiKey 
    {
        ApiKeyEntity GenerateApiKey(string id);
        List<ApiKeyEntity> GetApiKeyByUser(string id);
        void DeleteApiKey(string id, string key);
    }
}