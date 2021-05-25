using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using meatmonitorapi.Models;
using meatmonitorapi.repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace meatmonitorapi.Controllers
{
    [ApiController]
    [Route("alert/config")]
    public class AlertConfigController : ControllerBase
    {
        private readonly ILogger<AlertConfigController> _logger;
        private IAlertConfig _acr;
        public AlertConfigController(ILogger<AlertConfigController> logger, IAlertConfig acr)
        {
            _logger = logger;
            _acr = acr;
        }

        [HttpGet("{key}")]
        public List<AlertConfigEntity> GetAll(string key)
        {
            return _acr.GetAllAlertConfig(key);
           
        }

        [HttpPost]
        public AlertConfigEntity UpdateAlertConfig(AlertConfig pc) {
            return _acr.UpdateAlertConfig(pc);
        }
    }
}
