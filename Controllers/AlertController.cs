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

// ALERT HISTORY
        [HttpGet("history")]
        [Authorize]
        public List<AlertHistory> GetAlertHistory(int count) {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value.Split("|")[1];
            return _acr.GetRecentAlerts(userId, count);

        }

        // SUPPRESSIONS
        [HttpGet("{key}/suppressions")]
        public string GetAlertSuppressions(string key)
        {
            return key;
        }

    }
}
