using System.Collections.Generic;
using tempaastapi.Models;
using tempaastapi.repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace tempaastapi.Controllers
{
    [ApiController]
    [Route("api/alert")]
    public class AlertConfigController : ControllerBase
    {
        private readonly ILogger<AlertConfigController> _logger;
        private IAlertConfig _acr;
        public AlertConfigController(ILogger<AlertConfigController> logger, IAlertConfig acr)
        {
            _logger = logger;
            _acr = acr;
        }

        // ALERTS
        [HttpGet("")]
        [Authorize]
        public List<Alert> GetRecentAlerts(string startTime, string endTime)
        {
            return new List<Alert>();
        }

        // CONFIGURATIONS
        [HttpGet("config")]
        [Authorize]
        public List<AlertConfigEntity> GetAll()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value.Split("|")[1];
            return _acr.GetAllAlertConfig(userId);

        }

        [HttpPost("config")]
        [Authorize]
        public AlertConfigEntity UpdateAlertConfig(AlertConfig pc)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value.Split("|")[1];
            return _acr.UpdateAlertConfig(pc, userId);
        }

        // SUPPRESSIONS
        [HttpGet("{key}/suppressions")]
        public string GetAlertSuppressions(string key)
        {
            return key;
        }

    }
}
