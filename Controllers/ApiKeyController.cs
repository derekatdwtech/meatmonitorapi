using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tempaastapi.Models;
using tempaastapi.repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace tempaastapi.Controllers
{
    [ApiController]
    [Route("api/key")]
    public class ApiKeyController : ControllerBase
    {
        private readonly ILogger<ApiKeyController> _logger;
        private IApiKey _akr;
        public ApiKeyController(ILogger<ApiKeyController> logger, IApiKey akr)
        {
            _logger = logger;
            _akr = akr;
        }

        [HttpGet("")]
        public List<ApiKeyEntity> Get(string userId)
        {
            return _akr.GetApiKeyByUser(userId);

        }

        [HttpPost("")]
        public ApiKeyEntity UpdateApiKey(string userId)
        {
            return _akr.GenerateApiKey(userId);
        }
    }
}
