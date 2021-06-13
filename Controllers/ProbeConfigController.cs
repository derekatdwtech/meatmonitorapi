using tempaastapi.Models;
using tempaastapi.repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tempaastapi.attributes;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace tempaastapi.Controllers
{
    [ApiController]
    [Route("api/probe/config")]
    public class ProbeConfigController : ControllerBase
    {
        private readonly ILogger<ProbeConfigController> _logger;
        private IProbeConfig _pcr;
        private IConfiguration _config;
        public ProbeConfigController(ILogger<ProbeConfigController> logger, IProbeConfig pcr, IConfiguration config)
        {
            _logger = logger;
            _pcr = pcr;
            _config = config;
        }

        [HttpGet("")]
        [ApiKey]
        public IActionResult Get(string probeId)
        {
            // string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            // Console.WriteLine($"From COntroller {userId}");
            var result = _pcr.GetProbeConfig(_config["UserId"], probeId);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound($"Probe config for {probeId} was not found.");
            }

        }

        [HttpGet("list")]
        [Authorize]
        public IActionResult GetAll() {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value.Split("|")[1];
            var results = _pcr.GetAllProbeConfigs(userId);
            if(results.Count > 0) {
                return Ok(results);
            }
            else {
                 return NoContent();
            }
        }

        [HttpPost]
        [ApiKey]
        public ProbeConfig UpdateProbeConfig(ProbeConfig pc)
        {
            return _pcr.UpdateProbeConfig(pc);
        }
    }
}
