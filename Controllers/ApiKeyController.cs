using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tempaastapi.Models;
using tempaastapi.repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

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
        public ApiKeyEntity GenerateApiKey(string userId)
        {
            return _akr.GenerateApiKey(userId);
        }

        [HttpDelete]
        public IActionResult DeleteApiKey(string userId, string apiKey) {
            try {
                _akr.DeleteApiKey(userId, apiKey);
                return Ok();
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}
