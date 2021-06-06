using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tempaastapi.Models;
using tempaastapi.repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace tempaastapi.Controllers
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
        [Authorize]
        public ProbeConfig Get(string id)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Console.WriteLine($"From COntroller {userId}");
            return _pcr.GetProbeConfig(id);
           
        }

        [HttpPost]
        public ProbeConfig UpdateProbeConfig(ProbeConfig pc) {
            return _pcr.UpdateProbeConfig(pc);
        }
    }
}
