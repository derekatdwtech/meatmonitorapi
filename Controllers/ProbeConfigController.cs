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
    [Route("probe/config")]
    public class ProbeConfigController : ControllerBase
    {
        private readonly ILogger<ProbeConfigController> _logger;
        private IProbeConfig _pcr;
        public ProbeConfigController(ILogger<ProbeConfigController> logger, IProbeConfig pcr)
        {
            _logger = logger;
            _pcr = pcr;
        }

        [HttpGet("{id}")]
        public ProbeConfig Get(string id)
        {
            return _pcr.GetProbeConfig(id);
           
        }

        [HttpPost]
        public ProbeConfig UpdateProbeConfig(ProbeConfig pc) {
            return _pcr.UpdateProbeConfig(pc);
        }
    }
}
