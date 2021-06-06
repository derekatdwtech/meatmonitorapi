using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tempaastapi.Models;
using tempaastapi.repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using tempaastapi.attributes;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace tempaastapi.Controllers
{
    [ApiController]
    [Route("api/key")]
    public class ApiKeyController : ControllerBase
    {
        private readonly ILogger<ApiKeyController> _logger;
        private IApiKey _akr;
        IConfiguration _config;
        public ApiKeyController(ILogger<ApiKeyController> logger, IApiKey akr, IConfiguration config)
        {
            _logger = logger;
            _akr = akr;
            _config = config;
        }

        [ApiKey]
        [HttpGet("")]
        public List<ApiKeyEntity> Get()
        {
            string id = _config["userId"];            
            return _akr.GetApiKeyByUser(id);

        }

        [HttpPost("")]
        public ApiKeyEntity GenerateApiKey(string userId)
        {
            return _akr.GenerateApiKey(userId);
        }

        [HttpDelete]
        public IActionResult DeleteApiKey(string userId, string apiKey)
        {
            try
            {
                _akr.DeleteApiKey(userId, apiKey);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        public static void GetAttribute(Type t)
        {
            
        }

    }
}
