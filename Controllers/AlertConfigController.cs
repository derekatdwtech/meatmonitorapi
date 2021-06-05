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
    [Route("alert/")]
    public class AlertConfigController : ControllerBase
    {
        private readonly ILogger<AlertConfigController> _logger;
        private IAlertConfig _acr;
        public AlertConfigController(ILogger<AlertConfigController> logger, IAlertConfig acr)
        {
            _logger = logger;
            _acr = acr;
        }

// CONFIGURATIONS
        [HttpGet("config/{key}")]
        public List<AlertConfigEntity> GetAll(string key)
        {
            return _acr.GetAllAlertConfig(key);
           
        }

        [HttpPost("config")]
        public AlertConfigEntity UpdateAlertConfig(AlertConfig pc) {
            return _acr.UpdateAlertConfig(pc);
        }
        
// SUPPRESSIONS
        [HttpGet("{key}/suppressions")]
        public string GetAlertSuppressions(string key) {
            return key;
        }

    }
}
